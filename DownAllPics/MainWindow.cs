using DownAllPics.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownAllPics
{
    public partial class MainWindow : Form
    {
        private static string[] picExt = { @".gif", @".png", @".jpg", @".jpeg" };
        private static Regex hrefRegex = new Regex("href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))",
            RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
        private static FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
        public MainWindow()
        {
            InitializeComponent();
            //Загрузить значения текстовых полей из файла настроек
            useProxyCB.Checked = Properties.Settings.Default.useProxy;
            useCookieCB.Checked = Properties.Settings.Default.useCookie;
            srcPageUrlTB.Text = Properties.Settings.Default.srcPageUrl;
            proxyAddrTB.Text = Properties.Settings.Default.proxyAddr;
            cookieTB.Text = Properties.Settings.Default.cookieStr;
            localDirTB.Text = Properties.Settings.Default.localDir;
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Сохранить значения текстовых полей в файл настроек
            Properties.Settings.Default.useProxy = useProxyCB.Checked;
            Properties.Settings.Default.useCookie = useCookieCB.Checked;
            Properties.Settings.Default.srcPageUrl = srcPageUrlTB.Text;
            Properties.Settings.Default.proxyAddr = proxyAddrTB.Text;
            Properties.Settings.Default.cookieStr = cookieTB.Text;
            Properties.Settings.Default.localDir = localDirTB.Text;

            Settings.Default.Save();
        }

        private void DownloadPictures(string srcPageUrl, bool useProxy,
            string proxyAddr, bool useCookie, string cookieStr, string localDir)
        {
            //Инициализация переменных
            WebClient webClient = new WebClient();
            Uri srcPageUri = new Uri(srcPageUrl);
            List<string> collectedUrls = new List<string>();
            int successfulDownloads = 0;
            string srcPage = @"";
            string currExt = @"";

            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add(@"user-agent", @"Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36");
            if (useProxy)  webClient.Proxy = new WebProxy(proxyAddr);
            if (useCookie) webClient.Headers.Add(HttpRequestHeader.Cookie, cookieStr);

            //Загрузить исходную страницу как строку
            try
            {
                srcPage = webClient.DownloadString(srcPageUri);
            }
            catch (Exception ex)
            {
                /*В случае ошибки загрузки исходной страницы вывести сообщение с ошибкой и
                остановить исполнение метода*/
                MessageBox.Show(ex.Message, @"Ошибка загрузки исходной страницы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Извлечь все значения href из исходной страницы
            MatchCollection hrefMatches = hrefRegex.Matches(srcPage);
            srcPage = @""; //Очистить строку с исходной страницей
            foreach (Match match in hrefMatches)
            {
                string currUrl = Convert.ToString(match.Groups[1]);
                //Проверить, что текущая ссылка ведёт на пикчу
                try
                {
                    currExt = Path.GetExtension(currUrl);
                }
                catch { }
                if (picExt.Contains(currExt))
                {
                    /*Проверить, не относительна ли текущая ссылка, и если так -
                    конвертировать в абсолютную*/
                    if (!Uri.IsWellFormedUriString(currUrl, UriKind.Absolute)) {
                        currUrl = new Uri(srcPageUri, currUrl).AbsoluteUri;
                    }
                    //Добавить ссылку в список для скачивания
                    collectedUrls.Add(currUrl);
                }
            }
            hrefMatches = null; //Удалить коллекцию значений href

            /*Если не извлечено ни одной ссылки на пикчу - вывести сообщение и прервать
            выполнение метода*/
            if (collectedUrls.Count == 0)
            {
                
                MessageBox.Show(@"На указанной странице не найдено ни одной ссылки на пикчу",
                    @"Ошибка загрузки пикч", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Удалить дубликаты из списка извлечённых ссылок на пикчи
            List<string> urlsToDownload = collectedUrls.Distinct().ToList();
            collectedUrls = null; //Удалить список собранных пикч

            //Сохранить и вывести число извлечённых из исходной страницы ссылок на пикчи
            int totalUrls = urlsToDownload.Count;
            WriteLineToLog($"С указанной web-страницы извлечено {totalUrls} ссылок на пикчи");

            //Создать целевую директорую, если она не существует
            localDir += $"{srcPageUri.Host} ({DateTime.Now.ToString("yyyy.MM.dd HH-mm")})\\";
            Directory.CreateDirectory(localDir);

            //Цикл загрузки файлов из сформированного списка
            for (int i = 0; i < totalUrls; i++)
            {
                WriteLineToLog($"Качаю файл #{i + 1}: {urlsToDownload.ElementAt(i)}");
                /*Попытаться скачать файл по текущей ссылке и в случае удачи увеличить
                счётчик успешных загрузок*/
                if (DownloadToDisk(webClient, urlsToDownload.ElementAt(i), localDir) == true)
                    successfulDownloads++;
                //Обновить значение статусбара с хаком против тормозов
                int currPercent = (int)(((i + 1.0) / totalUrls) * 100);
                if (currPercent < 100)
                {
                    progressBar.Value = currPercent + 1;
                }
                progressBar.Value = currPercent;
            }

            //Вывести отчёт о выполненной работе
            double downPercent = Math.Round((successfulDownloads * 1.0 / totalUrls) * 100);
            MessageBox.Show($"Загружено {successfulDownloads} из "+
                $"{totalUrls} пикч ({downPercent}%)", @"Задание выполнено",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool DownloadToDisk(WebClient wc, string url, string dir)
        {
            bool successful = true;
            string fileName = Path.GetFileName(url);
            string localPath = $"{dir}\\{fileName}";

            try
            {
                wc.DownloadFile(url, localPath);
            }
            catch (Exception ex)
            {
                successful = false;
                WriteLineToLog(ex.Message);
            }
            return successful;
        }

        private void WriteLineToLog(string message)
        {
            string currTime = DateTime.Now.ToString(@"HH:mm:ss");
            logTB.AppendText($"{currTime}: {message}\n");
            logTB.SelectionStart = logTB.Text.Length;
            logTB.ScrollToCaret();
        }

        private void PartialInputError(string message)
        {
            MessageBox.Show(message, @"Заполнены не все поля", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #region Event handler'ы
        private void startBtn_Click(object sender, EventArgs e)
        {
            bool useProxy = useProxyCB.Checked;
            bool useCookie = useCookieCB.Checked;
            string srcPageUrl = srcPageUrlTB.Text;
            string proxyAddr = proxyAddrTB.Text;
            string cookieStr = cookieTB.Text;
            string localDir = localDirTB.Text;

            //Проверки на пустые поля
            if (!string.IsNullOrWhiteSpace(srcPageUrl) && !string.IsNullOrWhiteSpace(localDir))
            {
                if (useProxy)
                {
                    if (string.IsNullOrWhiteSpace(proxyAddr))
                    {
                        PartialInputError(@"Адрес прокси-сервера пуст!");
                        return;
                    }
                } else
                {
                    proxyAddr = @"";
                }
                if (useCookie)
                {
                    if (string.IsNullOrWhiteSpace(cookieStr))
                    {
                        PartialInputError(@"Строка куков пуста!");
                        return;
                    }
                }
                else
                {
                    cookieStr = @"";
                }
                /*Если все условия выполнены - запустить скачивание, заблокировав на это
                время кнопку*/
                logTB.Clear(); //Очистить лог
                ((Button)sender).Enabled = false;
                DownloadPictures(srcPageUrl, useProxy, proxyAddr, useCookie, cookieStr,
                    localDir);
                ((Button)sender).Enabled = true;
                progressBar.Value = 0; //Сбросить прогресс
            } else
            {
                PartialInputError(@"Адрес конечной директории/адрес исходной страницы пуст");
            }

        }

        private void clearSrcPageBtn_Click(object sender, EventArgs e)
        {
            srcPageUrlTB.Clear();
            srcPageUrlTB.Focus();
        }

        private void clearProxyAddrBtn_Click(object sender, EventArgs e)
        {
            proxyAddrTB.Clear();
            proxyAddrTB.Focus();
        }

        private void useCookieCB_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = ((CheckBox)sender).Checked;
            cookieTB.Enabled = enable;
        }

        private void useProxyCB_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = ((CheckBox)sender).Checked;
            proxyAddrTB.Enabled = enable;
            clearProxyAddrBtn.Enabled = enable;
        }

        private void pickDirBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(folderBrowserDlg.SelectedPath))
            {
                string path = folderBrowserDlg.SelectedPath;
                if (!path.EndsWith(@"\")) path += @"\"; //Добавить слеш в конце, если его нет
                localDirTB.Text = path;
            }
        }

        private void cookieTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void MainWindow_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show(
                "Автоматическое скачивание пикч по ссылкам с web-страницы.\n" +
                "Автор: iw0rm3r",
                @"О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true; //Отключить курсор мыши с вопросительным знаком
        }
        #endregion
    }
}
