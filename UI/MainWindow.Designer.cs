namespace UI
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.LabelSeparator = new System.Windows.Forms.Label();
            this.ButtonTabDecrypt = new System.Windows.Forms.Button();
            this.ButtonTabEncrypt = new System.Windows.Forms.Button();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.PictureBoxWindowIcon = new System.Windows.Forms.PictureBox();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelCopyRight = new System.Windows.Forms.Label();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.TabControlMainWindow = new System.Windows.Forms.TabControl();
            this.TabPageEncrypt = new System.Windows.Forms.TabPage();
            this.EncryptFileList = new System.Windows.Forms.DataGridView();
            this.EncryptFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EncryptFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EncryptOperation = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EncryptState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPageDecrypt = new System.Windows.Forms.TabPage();
            this.DecryptFileList = new System.Windows.Forms.DataGridView();
            this.DecryptFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DecryptFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DecryptOpeation = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DecryptState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonAddDocument = new System.Windows.Forms.Button();
            this.ButtonAddFolder = new System.Windows.Forms.Button();
            this.ButtonClearList = new System.Windows.Forms.Button();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.WhetherDelete = new System.Windows.Forms.CheckBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWindowIcon)).BeginInit();
            this.PanelBottom.SuspendLayout();
            this.TabControlMainWindow.SuspendLayout();
            this.TabPageEncrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptFileList)).BeginInit();
            this.TabPageDecrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecryptFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.DarkViolet;
            this.PanelTitle.Controls.Add(this.LabelSeparator);
            this.PanelTitle.Controls.Add(this.ButtonTabDecrypt);
            this.PanelTitle.Controls.Add(this.ButtonTabEncrypt);
            this.PanelTitle.Controls.Add(this.LabelTitle);
            this.PanelTitle.Controls.Add(this.PictureBoxWindowIcon);
            this.PanelTitle.Controls.Add(this.ButtonMinimize);
            this.PanelTitle.Controls.Add(this.ButtonClose);
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Size = new System.Drawing.Size(800, 100);
            this.PanelTitle.TabIndex = 0;
            this.PanelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            this.PanelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseMove);
            this.PanelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseUp);
            // 
            // LabelSeparator
            // 
            this.LabelSeparator.AutoSize = true;
            this.LabelSeparator.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelSeparator.ForeColor = System.Drawing.Color.White;
            this.LabelSeparator.Location = new System.Drawing.Point(685, 54);
            this.LabelSeparator.Name = "LabelSeparator";
            this.LabelSeparator.Size = new System.Drawing.Size(29, 29);
            this.LabelSeparator.TabIndex = 6;
            this.LabelSeparator.Text = "/";
            this.LabelSeparator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            this.LabelSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseMove);
            this.LabelSeparator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseUp);
            // 
            // ButtonTabDecrypt
            // 
            this.ButtonTabDecrypt.FlatAppearance.BorderSize = 0;
            this.ButtonTabDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTabDecrypt.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonTabDecrypt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonTabDecrypt.Location = new System.Drawing.Point(715, 50);
            this.ButtonTabDecrypt.Name = "ButtonTabDecrypt";
            this.ButtonTabDecrypt.Size = new System.Drawing.Size(70, 40);
            this.ButtonTabDecrypt.TabIndex = 0;
            this.ButtonTabDecrypt.TabStop = false;
            this.ButtonTabDecrypt.Text = "解密";
            this.ButtonTabDecrypt.UseVisualStyleBackColor = true;
            this.ButtonTabDecrypt.Click += new System.EventHandler(this.ButtonTabDecrypt_Click);
            // 
            // ButtonTabEncrypt
            // 
            this.ButtonTabEncrypt.FlatAppearance.BorderSize = 0;
            this.ButtonTabEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTabEncrypt.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonTabEncrypt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonTabEncrypt.Location = new System.Drawing.Point(615, 50);
            this.ButtonTabEncrypt.Name = "ButtonTabEncrypt";
            this.ButtonTabEncrypt.Size = new System.Drawing.Size(70, 40);
            this.ButtonTabEncrypt.TabIndex = 0;
            this.ButtonTabEncrypt.TabStop = false;
            this.ButtonTabEncrypt.Text = "加密";
            this.ButtonTabEncrypt.UseVisualStyleBackColor = true;
            this.ButtonTabEncrypt.Click += new System.EventHandler(this.ButtonTabEncrypt_Click);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTitle.ForeColor = System.Drawing.Color.White;
            this.LabelTitle.Location = new System.Drawing.Point(95, 36);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(261, 29);
            this.LabelTitle.TabIndex = 1;
            this.LabelTitle.Text = "文件加密解密工具";
            this.LabelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            this.LabelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseMove);
            this.LabelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseUp);
            // 
            // PictureBoxWindowIcon
            // 
            this.PictureBoxWindowIcon.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxWindowIcon.Image = global::UI.Properties.Resources.Logo;
            this.PictureBoxWindowIcon.Location = new System.Drawing.Point(25, 18);
            this.PictureBoxWindowIcon.Name = "PictureBoxWindowIcon";
            this.PictureBoxWindowIcon.Size = new System.Drawing.Size(64, 64);
            this.PictureBoxWindowIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxWindowIcon.TabIndex = 2;
            this.PictureBoxWindowIcon.TabStop = false;
            this.PictureBoxWindowIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            this.PictureBoxWindowIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseMove);
            this.PictureBoxWindowIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseUp);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Location = new System.Drawing.Point(750, 0);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(25, 25);
            this.ButtonMinimize.TabIndex = 0;
            this.ButtonMinimize.TabStop = false;
            this.ButtonMinimize.Text = "_";
            this.ButtonMinimize.UseVisualStyleBackColor = true;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClose.Location = new System.Drawing.Point(775, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(25, 25);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.TabStop = false;
            this.ButtonClose.Text = "X";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.DarkViolet;
            this.PanelBottom.Controls.Add(this.LabelTime);
            this.PanelBottom.Controls.Add(this.LabelCopyRight);
            this.PanelBottom.Controls.Add(this.LabelVersion);
            this.PanelBottom.Location = new System.Drawing.Point(0, 425);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(800, 25);
            this.PanelBottom.TabIndex = 0;
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.BackColor = System.Drawing.Color.DarkViolet;
            this.LabelTime.ForeColor = System.Drawing.Color.White;
            this.LabelTime.Location = new System.Drawing.Point(4, 4);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(68, 17);
            this.LabelTime.TabIndex = 2;
            this.LabelTime.Text = "已用时间：";
            // 
            // LabelCopyRight
            // 
            this.LabelCopyRight.AutoSize = true;
            this.LabelCopyRight.BackColor = System.Drawing.Color.DarkViolet;
            this.LabelCopyRight.ForeColor = System.Drawing.Color.White;
            this.LabelCopyRight.Location = new System.Drawing.Point(216, 4);
            this.LabelCopyRight.Name = "LabelCopyRight";
            this.LabelCopyRight.Size = new System.Drawing.Size(368, 17);
            this.LabelCopyRight.TabIndex = 3;
            this.LabelCopyRight.Text = "本软件仅供学习交流！如果使用不当导致文件无法恢复，概不负责！";
            // 
            // LabelVersion
            // 
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.BackColor = System.Drawing.Color.DarkViolet;
            this.LabelVersion.ForeColor = System.Drawing.Color.White;
            this.LabelVersion.Location = new System.Drawing.Point(700, 4);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(93, 17);
            this.LabelVersion.TabIndex = 4;
            this.LabelVersion.Text = "当前版本：V1.0";
            // 
            // TabControlMainWindow
            // 
            this.TabControlMainWindow.Controls.Add(this.TabPageEncrypt);
            this.TabControlMainWindow.Controls.Add(this.TabPageDecrypt);
            this.TabControlMainWindow.Location = new System.Drawing.Point(0, 75);
            this.TabControlMainWindow.Name = "TabControlMainWindow";
            this.TabControlMainWindow.SelectedIndex = 0;
            this.TabControlMainWindow.Size = new System.Drawing.Size(800, 320);
            this.TabControlMainWindow.TabIndex = 0;
            this.TabControlMainWindow.TabStop = false;
            // 
            // TabPageEncrypt
            // 
            this.TabPageEncrypt.Controls.Add(this.EncryptFileList);
            this.TabPageEncrypt.Location = new System.Drawing.Point(4, 26);
            this.TabPageEncrypt.Name = "TabPageEncrypt";
            this.TabPageEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageEncrypt.Size = new System.Drawing.Size(792, 290);
            this.TabPageEncrypt.TabIndex = 0;
            this.TabPageEncrypt.Text = "Encrypt";
            this.TabPageEncrypt.UseVisualStyleBackColor = true;
            // 
            // EncryptFileList
            // 
            this.EncryptFileList.AllowUserToAddRows = false;
            this.EncryptFileList.AllowUserToDeleteRows = false;
            this.EncryptFileList.AllowUserToResizeColumns = false;
            this.EncryptFileList.AllowUserToResizeRows = false;
            this.EncryptFileList.BackgroundColor = System.Drawing.Color.White;
            this.EncryptFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EncryptFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EncryptFilePath,
            this.EncryptFileSize,
            this.EncryptOperation,
            this.EncryptState});
            this.EncryptFileList.Location = new System.Drawing.Point(0, 0);
            this.EncryptFileList.Name = "EncryptFileList";
            this.EncryptFileList.RowHeadersVisible = false;
            this.EncryptFileList.RowTemplate.Height = 25;
            this.EncryptFileList.Size = new System.Drawing.Size(792, 290);
            this.EncryptFileList.TabIndex = 0;
            this.EncryptFileList.TabStop = false;
            this.EncryptFileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EncryptFileList_CellContentClick);
            // 
            // EncryptFilePath
            // 
            this.EncryptFilePath.HeaderText = "文件（路径）";
            this.EncryptFilePath.Name = "EncryptFilePath";
            this.EncryptFilePath.ReadOnly = true;
            this.EncryptFilePath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EncryptFilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EncryptFilePath.Width = 500;
            // 
            // EncryptFileSize
            // 
            this.EncryptFileSize.HeaderText = "文件大小";
            this.EncryptFileSize.Name = "EncryptFileSize";
            this.EncryptFileSize.ReadOnly = true;
            this.EncryptFileSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EncryptFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EncryptOperation
            // 
            this.EncryptOperation.HeaderText = "操作";
            this.EncryptOperation.Name = "EncryptOperation";
            this.EncryptOperation.ReadOnly = true;
            this.EncryptOperation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EncryptOperation.Text = "删除文件";
            this.EncryptOperation.UseColumnTextForLinkValue = true;
            this.EncryptOperation.Width = 90;
            // 
            // EncryptState
            // 
            this.EncryptState.HeaderText = "状态";
            this.EncryptState.Name = "EncryptState";
            this.EncryptState.ReadOnly = true;
            this.EncryptState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EncryptState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EncryptState.Width = 80;
            // 
            // TabPageDecrypt
            // 
            this.TabPageDecrypt.Controls.Add(this.DecryptFileList);
            this.TabPageDecrypt.Location = new System.Drawing.Point(4, 26);
            this.TabPageDecrypt.Name = "TabPageDecrypt";
            this.TabPageDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDecrypt.Size = new System.Drawing.Size(792, 290);
            this.TabPageDecrypt.TabIndex = 1;
            this.TabPageDecrypt.Text = "Decrypt";
            this.TabPageDecrypt.UseVisualStyleBackColor = true;
            // 
            // DecryptFileList
            // 
            this.DecryptFileList.AllowUserToAddRows = false;
            this.DecryptFileList.AllowUserToResizeRows = false;
            this.DecryptFileList.BackgroundColor = System.Drawing.Color.White;
            this.DecryptFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DecryptFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DecryptFileName,
            this.DecryptFileSize,
            this.DecryptOpeation,
            this.DecryptState});
            this.DecryptFileList.Location = new System.Drawing.Point(0, 0);
            this.DecryptFileList.Name = "DecryptFileList";
            this.DecryptFileList.RowHeadersVisible = false;
            this.DecryptFileList.RowTemplate.Height = 25;
            this.DecryptFileList.Size = new System.Drawing.Size(792, 290);
            this.DecryptFileList.TabIndex = 0;
            this.DecryptFileList.TabStop = false;
            this.DecryptFileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DecryptFileList_CellContentClick);
            // 
            // DecryptFileName
            // 
            this.DecryptFileName.HeaderText = "文件（路径）";
            this.DecryptFileName.Name = "DecryptFileName";
            this.DecryptFileName.ReadOnly = true;
            this.DecryptFileName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DecryptFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DecryptFileName.Width = 500;
            // 
            // DecryptFileSize
            // 
            this.DecryptFileSize.HeaderText = "文件大小";
            this.DecryptFileSize.Name = "DecryptFileSize";
            this.DecryptFileSize.ReadOnly = true;
            this.DecryptFileSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DecryptFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DecryptOpeation
            // 
            this.DecryptOpeation.HeaderText = "操作";
            this.DecryptOpeation.Name = "DecryptOpeation";
            this.DecryptOpeation.ReadOnly = true;
            this.DecryptOpeation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DecryptOpeation.Text = "删除文件";
            this.DecryptOpeation.UseColumnTextForLinkValue = true;
            this.DecryptOpeation.Width = 90;
            // 
            // DecryptState
            // 
            this.DecryptState.HeaderText = "状态";
            this.DecryptState.Name = "DecryptState";
            this.DecryptState.ReadOnly = true;
            this.DecryptState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DecryptState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DecryptState.Width = 80;
            // 
            // ButtonAddDocument
            // 
            this.ButtonAddDocument.Location = new System.Drawing.Point(12, 396);
            this.ButtonAddDocument.Name = "ButtonAddDocument";
            this.ButtonAddDocument.Size = new System.Drawing.Size(75, 25);
            this.ButtonAddDocument.TabIndex = 0;
            this.ButtonAddDocument.TabStop = false;
            this.ButtonAddDocument.Text = "添加文件";
            this.ButtonAddDocument.UseVisualStyleBackColor = true;
            this.ButtonAddDocument.Click += new System.EventHandler(this.ButtonAddDocument_Click);
            // 
            // ButtonAddFolder
            // 
            this.ButtonAddFolder.Location = new System.Drawing.Point(94, 396);
            this.ButtonAddFolder.Name = "ButtonAddFolder";
            this.ButtonAddFolder.Size = new System.Drawing.Size(75, 25);
            this.ButtonAddFolder.TabIndex = 0;
            this.ButtonAddFolder.TabStop = false;
            this.ButtonAddFolder.Text = "批量添加";
            this.ButtonAddFolder.UseVisualStyleBackColor = true;
            this.ButtonAddFolder.Click += new System.EventHandler(this.ButtonAddFolder_Click);
            // 
            // ButtonClearList
            // 
            this.ButtonClearList.Location = new System.Drawing.Point(176, 396);
            this.ButtonClearList.Name = "ButtonClearList";
            this.ButtonClearList.Size = new System.Drawing.Size(75, 25);
            this.ButtonClearList.TabIndex = 0;
            this.ButtonClearList.TabStop = false;
            this.ButtonClearList.Text = "清空列表";
            this.ButtonClearList.UseVisualStyleBackColor = true;
            this.ButtonClearList.Click += new System.EventHandler(this.ButtonClearList_Click);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(718, 396);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 25);
            this.ButtonRun.TabIndex = 0;
            this.ButtonRun.TabStop = false;
            this.ButtonRun.Text = "开始";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // WhetherDelete
            // 
            this.WhetherDelete.AutoSize = true;
            this.WhetherDelete.Location = new System.Drawing.Point(570, 399);
            this.WhetherDelete.Name = "WhetherDelete";
            this.WhetherDelete.Size = new System.Drawing.Size(147, 21);
            this.WhetherDelete.TabIndex = 0;
            this.WhetherDelete.TabStop = false;
            this.WhetherDelete.Text = "操作完成后删除源文件";
            this.WhetherDelete.UseVisualStyleBackColor = true;
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(260, 400);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(44, 17);
            this.LabelPassword.TabIndex = 8;
            this.LabelPassword.Text = "密码：";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TextBoxPassword.Location = new System.Drawing.Point(295, 397);
            this.TextBoxPassword.MaxLength = 32;
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(250, 23);
            this.TextBoxPassword.TabIndex = 0;
            this.TextBoxPassword.TabStop = false;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.WhetherDelete);
            this.Controls.Add(this.ButtonRun);
            this.Controls.Add(this.ButtonClearList);
            this.Controls.Add(this.ButtonAddFolder);
            this.Controls.Add(this.ButtonAddDocument);
            this.Controls.Add(this.PanelTitle);
            this.Controls.Add(this.TabControlMainWindow);
            this.Controls.Add(this.PanelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWindowIcon)).EndInit();
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.TabControlMainWindow.ResumeLayout(false);
            this.TabPageEncrypt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EncryptFileList)).EndInit();
            this.TabPageDecrypt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DecryptFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel PanelTitle;
        private Button ButtonMinimize;
        private Button ButtonClose;
        private Label LabelTitle;
        private PictureBox PictureBoxWindowIcon;
        private Panel PanelBottom;
        private Label LabelSeparator;
        private Button ButtonTabDecrypt;
        private Button ButtonTabEncrypt;
        private Label LabelVersion;
        private TabControl TabControlMainWindow;
        private TabPage TabPageEncrypt;
        private TabPage TabPageDecrypt;
        private Label LabelCopyRight;
        private Button ButtonAddDocument;
        private Button ButtonAddFolder;
        private Button ButtonClearList;
        private Button ButtonRun;
        private CheckBox WhetherDelete;
        private Label LabelPassword;
        private TextBox TextBoxPassword;
        private DataGridView EncryptFileList;
        private DataGridView DecryptFileList;
        private Label LabelTime;
        private DataGridViewTextBoxColumn EncryptFilePath;
        private DataGridViewTextBoxColumn EncryptFileSize;
        private DataGridViewLinkColumn EncryptOperation;
        private DataGridViewTextBoxColumn EncryptState;
        private DataGridViewTextBoxColumn DecryptFileName;
        private DataGridViewTextBoxColumn DecryptFileSize;
        private DataGridViewLinkColumn DecryptOpeation;
        private DataGridViewTextBoxColumn DecryptState;
    }
}