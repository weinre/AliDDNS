namespace net.nutcore.aliddns
{
    partial class Form_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.authorInformation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PublishLink = new System.Windows.Forms.LinkLabel();
            this.personalWebsite = new System.Windows.Forms.LinkLabel();
            this.textBox_updateInfo = new System.Windows.Forms.TextBox();
            this.authorInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // authorInformation
            // 
            this.authorInformation.Controls.Add(this.label3);
            this.authorInformation.Controls.Add(this.linkLabel1);
            this.authorInformation.Controls.Add(this.label2);
            this.authorInformation.Controls.Add(this.label1);
            this.authorInformation.Controls.Add(this.PublishLink);
            this.authorInformation.Controls.Add(this.personalWebsite);
            this.authorInformation.Location = new System.Drawing.Point(18, 18);
            this.authorInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authorInformation.Name = "authorInformation";
            this.authorInformation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.authorInformation.Size = new System.Drawing.Size(363, 136);
            this.authorInformation.TabIndex = 8;
            this.authorInformation.TabStop = false;
            this.authorInformation.Text = "著作信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "本程序发布地址:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(160, 58);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(116, 18);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "阿里开发论坛";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "原程序发布地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "原作者主页:";
            // 
            // PublishLink
            // 
            this.PublishLink.AutoSize = true;
            this.PublishLink.Location = new System.Drawing.Point(160, 93);
            this.PublishLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PublishLink.Name = "PublishLink";
            this.PublishLink.Size = new System.Drawing.Size(188, 18);
            this.PublishLink.TabIndex = 2;
            this.PublishLink.TabStop = true;
            this.PublishLink.Text = "AliDDNS 3.0 之后版本";
            this.PublishLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PublishLink_LinkClicked);
            // 
            // personalWebsite
            // 
            this.personalWebsite.AutoSize = true;
            this.personalWebsite.Location = new System.Drawing.Point(124, 26);
            this.personalWebsite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.personalWebsite.Name = "personalWebsite";
            this.personalWebsite.Size = new System.Drawing.Size(143, 18);
            this.personalWebsite.TabIndex = 1;
            this.personalWebsite.TabStop = true;
            this.personalWebsite.Text = "www.nutcore.net";
            this.personalWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.personalWebsite_LinkClicked);
            // 
            // textBox_updateInfo
            // 
            this.textBox_updateInfo.Location = new System.Drawing.Point(18, 164);
            this.textBox_updateInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_updateInfo.Multiline = true;
            this.textBox_updateInfo.Name = "textBox_updateInfo";
            this.textBox_updateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_updateInfo.Size = new System.Drawing.Size(361, 196);
            this.textBox_updateInfo.TabIndex = 9;
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.textBox_updateInfo);
            this.Controls.Add(this.authorInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_About";
            this.Text = "关于";
            this.authorInformation.ResumeLayout(false);
            this.authorInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox authorInformation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel PublishLink;
        private System.Windows.Forms.LinkLabel personalWebsite;
        private System.Windows.Forms.TextBox textBox_updateInfo;
    }
}