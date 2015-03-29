namespace parcerHTML_bastchange
{
    partial class Massage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Massage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BodyMail = new System.Windows.Forms.TextBox();
            this.SubjectMail = new System.Windows.Forms.TextBox();
            this.FromMail = new System.Windows.Forms.TextBox();
            this.SendMsg = new System.Windows.Forms.Button();
            this.TypeOfMail = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ваш эмейл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тема";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сообщение";
            // 
            // BodyMail
            // 
            this.BodyMail.Location = new System.Drawing.Point(10, 316);
            this.BodyMail.Multiline = true;
            this.BodyMail.Name = "BodyMail";
            this.BodyMail.Size = new System.Drawing.Size(268, 154);
            this.BodyMail.TabIndex = 3;
            // 
            // SubjectMail
            // 
            this.SubjectMail.Location = new System.Drawing.Point(10, 277);
            this.SubjectMail.Name = "SubjectMail";
            this.SubjectMail.Size = new System.Drawing.Size(266, 20);
            this.SubjectMail.TabIndex = 4;
            // 
            // FromMail
            // 
            this.FromMail.Location = new System.Drawing.Point(10, 237);
            this.FromMail.Name = "FromMail";
            this.FromMail.Size = new System.Drawing.Size(169, 20);
            this.FromMail.TabIndex = 5;
            // 
            // SendMsg
            // 
            this.SendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SendMsg.Location = new System.Drawing.Point(10, 477);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(268, 30);
            this.SendMsg.TabIndex = 7;
            this.SendMsg.Text = "Отправить";
            this.SendMsg.UseVisualStyleBackColor = true;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // TypeOfMail
            // 
            this.TypeOfMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TypeOfMail.FormattingEnabled = true;
            this.TypeOfMail.Items.AddRange(new object[] {
            "mail.ru",
            "gmail.com",
            "rambler.ru",
            "hotmail.com",
            "yandex.ru",
            "yahoo.com",
            "bigmir.net",
            "E-mail.ru",
            "pochta.ru",
            "ukr.net"});
            this.TypeOfMail.Location = new System.Drawing.Point(187, 237);
            this.TypeOfMail.Name = "TypeOfMail";
            this.TypeOfMail.Size = new System.Drawing.Size(91, 21);
            this.TypeOfMail.TabIndex = 8;
            this.TypeOfMail.Text = "gmail.com";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::parcerHTML_bastchange.Properties.Resources.Technical_Support;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(267, 213);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Тема";
            // 
            // Massage
            // 
            this.AcceptButton = this.SendMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(291, 525);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TypeOfMail);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FromMail);
            this.Controls.Add(this.SubjectMail);
            this.Controls.Add(this.BodyMail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Massage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Связь со службой подержки";
            this.Load += new System.EventHandler(this.Massage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BodyMail;
        private System.Windows.Forms.TextBox SubjectMail;
        private System.Windows.Forms.TextBox FromMail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.ComboBox TypeOfMail;
        private System.Windows.Forms.Label label4;
    }
}