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
            this.panel_ControlBox = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.pictureBox_BackGround = new System.Windows.Forms.PictureBox();
            this.panel_Context = new System.Windows.Forms.Panel();
            this.panel_ControlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_ControlBox
            // 
            this.panel_ControlBox.BackColor = System.Drawing.Color.Transparent;
            this.panel_ControlBox.Controls.Add(this.label_Title);
            this.panel_ControlBox.Controls.Add(this.button_Minimize);
            this.panel_ControlBox.Controls.Add(this.button_Close);
            this.panel_ControlBox.Location = new System.Drawing.Point(0, 0);
            this.panel_ControlBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_ControlBox.Name = "panel_ControlBox";
            this.panel_ControlBox.Size = new System.Drawing.Size(960, 40);
            this.panel_ControlBox.TabIndex = 1;
            this.panel_ControlBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_ControlBox_MouseDown);
            this.panel_ControlBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_ControlBox_MouseMove);
            this.panel_ControlBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_ControlBox_MouseUp);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Title.Font = new System.Drawing.Font("华文行楷", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Title.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_Title.Location = new System.Drawing.Point(12, 9);
            this.label_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(136, 21);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "加密解密工具";
            this.label_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseDown);
            this.label_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseMove);
            this.label_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseUp);
            // 
            // button_Minimize
            // 
            this.button_Minimize.FlatAppearance.BorderSize = 0;
            this.button_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Image = global::UI.Properties.Resources.minimize;
            this.button_Minimize.Location = new System.Drawing.Point(880, 0);
            this.button_Minimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(40, 40);
            this.button_Minimize.TabIndex = 1;
            this.button_Minimize.UseVisualStyleBackColor = true;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
            this.button_Minimize.MouseEnter += new System.EventHandler(this.button_Minimize_MouseEnter);
            this.button_Minimize.MouseLeave += new System.EventHandler(this.button_Minimize_MouseLeave);
            // 
            // button_Close
            // 
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Image = global::UI.Properties.Resources.close;
            this.button_Close.Location = new System.Drawing.Point(920, 0);
            this.button_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(40, 40);
            this.button_Close.TabIndex = 0;
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            this.button_Close.MouseEnter += new System.EventHandler(this.button_Close_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.button_Close_MouseLeave);
            // 
            // pictureBox_BackGround
            // 
            this.pictureBox_BackGround.Image = global::UI.Properties.Resources._2233;
            this.pictureBox_BackGround.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_BackGround.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_BackGround.Name = "pictureBox_BackGround";
            this.pictureBox_BackGround.Size = new System.Drawing.Size(960, 540);
            this.pictureBox_BackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_BackGround.TabIndex = 0;
            this.pictureBox_BackGround.TabStop = false;
            // 
            // panel_Context
            // 
            this.panel_Context.BackColor = System.Drawing.Color.Transparent;
            this.panel_Context.Location = new System.Drawing.Point(0, 40);
            this.panel_Context.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Context.Name = "panel_Context";
            this.panel_Context.Size = new System.Drawing.Size(960, 500);
            this.panel_Context.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panel_Context);
            this.Controls.Add(this.panel_ControlBox);
            this.Controls.Add(this.pictureBox_BackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "加密、解密工具";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel_ControlBox.ResumeLayout(false);
            this.panel_ControlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_BackGround;
        private System.Windows.Forms.Panel panel_ControlBox;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Panel panel_Context;


    }
}