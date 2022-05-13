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
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.PictureBoxWindowIcon = new System.Windows.Forms.PictureBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.ButtonTabEncrypt = new System.Windows.Forms.Button();
            this.ButtonTabDecrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWindowIcon)).BeginInit();
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.BackColor = System.Drawing.Color.DarkViolet;
            this.PanelTitle.Controls.Add(this.label1);
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
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(775, 0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(25, 25);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "X";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.Location = new System.Drawing.Point(750, 0);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(25, 25);
            this.ButtonMinimize.TabIndex = 1;
            this.ButtonMinimize.Text = "_";
            this.ButtonMinimize.UseVisualStyleBackColor = true;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
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
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelTitle.ForeColor = System.Drawing.Color.White;
            this.LabelTitle.Location = new System.Drawing.Point(95, 36);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(261, 29);
            this.LabelTitle.TabIndex = 3;
            this.LabelTitle.Text = "文件加密解密工具";
            this.LabelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            this.LabelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseMove);
            this.LabelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseUp);
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.DarkViolet;
            this.PanelBottom.Controls.Add(this.LabelVersion);
            this.PanelBottom.Location = new System.Drawing.Point(0, 425);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(800, 25);
            this.PanelBottom.TabIndex = 1;
            // 
            // LabelVersion
            // 
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.BackColor = System.Drawing.Color.DarkViolet;
            this.LabelVersion.ForeColor = System.Drawing.Color.White;
            this.LabelVersion.Location = new System.Drawing.Point(728, 4);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(69, 17);
            this.LabelVersion.TabIndex = 0;
            this.LabelVersion.Text = "版本：V1.0";
            // 
            // ButtonTabEncrypt
            // 
            this.ButtonTabEncrypt.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonTabEncrypt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonTabEncrypt.Location = new System.Drawing.Point(610, 50);
            this.ButtonTabEncrypt.Name = "ButtonTabEncrypt";
            this.ButtonTabEncrypt.Size = new System.Drawing.Size(70, 40);
            this.ButtonTabEncrypt.TabIndex = 4;
            this.ButtonTabEncrypt.Text = "加密";
            this.ButtonTabEncrypt.UseVisualStyleBackColor = true;
            this.ButtonTabEncrypt.Click += new System.EventHandler(this.ButtonTabEncrypt_Click);
            // 
            // ButtonTabDecrypt
            // 
            this.ButtonTabDecrypt.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonTabDecrypt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ButtonTabDecrypt.Location = new System.Drawing.Point(720, 50);
            this.ButtonTabDecrypt.Name = "ButtonTabDecrypt";
            this.ButtonTabDecrypt.Size = new System.Drawing.Size(70, 40);
            this.ButtonTabDecrypt.TabIndex = 5;
            this.ButtonTabDecrypt.Text = "解密";
            this.ButtonTabDecrypt.UseVisualStyleBackColor = true;
            this.ButtonTabDecrypt.Click += new System.EventHandler(this.ButtonTabDecrypt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(685, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.PanelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.PanelTitle.ResumeLayout(false);
            this.PanelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxWindowIcon)).EndInit();
            this.PanelBottom.ResumeLayout(false);
            this.PanelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel PanelTitle;
        private Button ButtonMinimize;
        private Button ButtonClose;
        private Label LabelTitle;
        private PictureBox PictureBoxWindowIcon;
        private Panel PanelBottom;
        private Label label1;
        private Button ButtonTabDecrypt;
        private Button ButtonTabEncrypt;
        private Label LabelVersion;
    }
}