namespace DownAllPics
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.srcPageUrlTB = new System.Windows.Forms.TextBox();
            this.useProxyCB = new System.Windows.Forms.CheckBox();
            this.proxyAddrTB = new System.Windows.Forms.TextBox();
            this.useCookieCB = new System.Windows.Forms.CheckBox();
            this.cookieTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logTB = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.clearSrcPageBtn = new System.Windows.Forms.Button();
            this.clearProxyAddrBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.localDirTB = new System.Windows.Forms.TextBox();
            this.pickDirBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес исходной страницы со ссылками на пикчи:";
            // 
            // srcPageUrlTB
            // 
            this.srcPageUrlTB.Location = new System.Drawing.Point(12, 78);
            this.srcPageUrlTB.Name = "srcPageUrlTB";
            this.srcPageUrlTB.Size = new System.Drawing.Size(451, 25);
            this.srcPageUrlTB.TabIndex = 1;
            // 
            // useProxyCB
            // 
            this.useProxyCB.AutoSize = true;
            this.useProxyCB.Location = new System.Drawing.Point(12, 352);
            this.useProxyCB.Name = "useProxyCB";
            this.useProxyCB.Size = new System.Drawing.Size(161, 21);
            this.useProxyCB.TabIndex = 2;
            this.useProxyCB.Text = "Использовать прокси:";
            this.useProxyCB.UseVisualStyleBackColor = true;
            this.useProxyCB.CheckedChanged += new System.EventHandler(this.useProxyCB_CheckedChanged);
            // 
            // proxyAddrTB
            // 
            this.proxyAddrTB.Enabled = false;
            this.proxyAddrTB.Location = new System.Drawing.Point(12, 379);
            this.proxyAddrTB.Name = "proxyAddrTB";
            this.proxyAddrTB.Size = new System.Drawing.Size(221, 25);
            this.proxyAddrTB.TabIndex = 3;
            // 
            // useCookieCB
            // 
            this.useCookieCB.AutoSize = true;
            this.useCookieCB.Location = new System.Drawing.Point(12, 109);
            this.useCookieCB.Name = "useCookieCB";
            this.useCookieCB.Size = new System.Drawing.Size(238, 21);
            this.useCookieCB.TabIndex = 4;
            this.useCookieCB.Text = "Подставлять cookie в HTTP запрос:";
            this.useCookieCB.UseVisualStyleBackColor = true;
            this.useCookieCB.CheckedChanged += new System.EventHandler(this.useCookieCB_CheckedChanged);
            // 
            // cookieTB
            // 
            this.cookieTB.Enabled = false;
            this.cookieTB.Location = new System.Drawing.Point(12, 136);
            this.cookieTB.Multiline = true;
            this.cookieTB.Name = "cookieTB";
            this.cookieTB.Size = new System.Drawing.Size(476, 210);
            this.cookieTB.TabIndex = 5;
            this.cookieTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cookieTB_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Лог:";
            // 
            // logTB
            // 
            this.logTB.BackColor = System.Drawing.SystemColors.Window;
            this.logTB.Location = new System.Drawing.Point(12, 427);
            this.logTB.Multiline = true;
            this.logTB.Name = "logTB";
            this.logTB.ReadOnly = true;
            this.logTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTB.Size = new System.Drawing.Size(476, 246);
            this.logTB.TabIndex = 7;
            this.logTB.WordWrap = false;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(264, 352);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(224, 52);
            this.startBtn.TabIndex = 9;
            this.startBtn.Text = "Запустить загрузку";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 680);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(476, 23);
            this.progressBar.TabIndex = 10;
            // 
            // clearSrcPageBtn
            // 
            this.clearSrcPageBtn.Location = new System.Drawing.Point(463, 78);
            this.clearSrcPageBtn.Name = "clearSrcPageBtn";
            this.clearSrcPageBtn.Size = new System.Drawing.Size(25, 25);
            this.clearSrcPageBtn.TabIndex = 11;
            this.clearSrcPageBtn.Text = "❌";
            this.clearSrcPageBtn.UseVisualStyleBackColor = true;
            this.clearSrcPageBtn.Click += new System.EventHandler(this.clearSrcPageBtn_Click);
            // 
            // clearProxyAddrBtn
            // 
            this.clearProxyAddrBtn.Enabled = false;
            this.clearProxyAddrBtn.Location = new System.Drawing.Point(233, 379);
            this.clearProxyAddrBtn.Name = "clearProxyAddrBtn";
            this.clearProxyAddrBtn.Size = new System.Drawing.Size(25, 25);
            this.clearProxyAddrBtn.TabIndex = 12;
            this.clearProxyAddrBtn.Text = "❌";
            this.clearProxyAddrBtn.UseVisualStyleBackColor = true;
            this.clearProxyAddrBtn.Click += new System.EventHandler(this.clearProxyAddrBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Адрес конечной директории для сохранения:";
            // 
            // localDirTB
            // 
            this.localDirTB.Location = new System.Drawing.Point(12, 30);
            this.localDirTB.Name = "localDirTB";
            this.localDirTB.Size = new System.Drawing.Size(451, 25);
            this.localDirTB.TabIndex = 14;
            // 
            // pickDirBtn
            // 
            this.pickDirBtn.Location = new System.Drawing.Point(463, 30);
            this.pickDirBtn.Name = "pickDirBtn";
            this.pickDirBtn.Size = new System.Drawing.Size(25, 25);
            this.pickDirBtn.TabIndex = 15;
            this.pickDirBtn.Text = "...";
            this.pickDirBtn.UseVisualStyleBackColor = true;
            this.pickDirBtn.Click += new System.EventHandler(this.pickDirBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 713);
            this.Controls.Add(this.pickDirBtn);
            this.Controls.Add(this.localDirTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clearProxyAddrBtn);
            this.Controls.Add(this.clearSrcPageBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.logTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cookieTB);
            this.Controls.Add(this.useCookieCB);
            this.Controls.Add(this.proxyAddrTB);
            this.Controls.Add(this.useProxyCB);
            this.Controls.Add(this.srcPageUrlTB);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownAllPics 0.3";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.MainWindow_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox srcPageUrlTB;
        private System.Windows.Forms.CheckBox useProxyCB;
        private System.Windows.Forms.TextBox proxyAddrTB;
        private System.Windows.Forms.CheckBox useCookieCB;
        private System.Windows.Forms.TextBox cookieTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button clearSrcPageBtn;
        private System.Windows.Forms.Button clearProxyAddrBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox localDirTB;
        private System.Windows.Forms.Button pickDirBtn;
    }
}

