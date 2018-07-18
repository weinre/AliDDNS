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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_autoCheckUpdate = new System.Windows.Forms.CheckBox();
            this.label_latestVer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_currentVer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.authorInformation.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.authorInformation.Location = new System.Drawing.Point(12, 71);
            this.authorInformation.Name = "authorInformation";
            this.authorInformation.Size = new System.Drawing.Size(242, 81);
            this.authorInformation.TabIndex = 8;
            this.authorInformation.TabStop = false;
            this.authorInformation.Text = "著作信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "本程序发布地址:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(107, 39);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "阿里开发论坛";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "原程序发布地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "原作者主页:";
            // 
            // PublishLink
            // 
            this.PublishLink.AutoSize = true;
            this.PublishLink.Location = new System.Drawing.Point(107, 62);
            this.PublishLink.Name = "PublishLink";
            this.PublishLink.Size = new System.Drawing.Size(125, 12);
            this.PublishLink.TabIndex = 2;
            this.PublishLink.TabStop = true;
            this.PublishLink.Text = "AliDDNS 3.0 之后版本";
            this.PublishLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PublishLink_LinkClicked);
            // 
            // personalWebsite
            // 
            this.personalWebsite.AutoSize = true;
            this.personalWebsite.Location = new System.Drawing.Point(83, 17);
            this.personalWebsite.Name = "personalWebsite";
            this.personalWebsite.Size = new System.Drawing.Size(95, 12);
            this.personalWebsite.TabIndex = 1;
            this.personalWebsite.TabStop = true;
            this.personalWebsite.Text = "www.nutcore.net";
            this.personalWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.personalWebsite_LinkClicked);
            // 
            // textBox_updateInfo
            // 
            this.textBox_updateInfo.Location = new System.Drawing.Point(12, 158);
            this.textBox_updateInfo.Multiline = true;
            this.textBox_updateInfo.Name = "textBox_updateInfo";
            this.textBox_updateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_updateInfo.Size = new System.Drawing.Size(242, 119);
            this.textBox_updateInfo.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_autoCheckUpdate);
            this.groupBox1.Controls.Add(this.label_latestVer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label_currentVer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 62);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "升级设置";
            // 
            // checkBox_autoCheckUpdate
            // 
            this.checkBox_autoCheckUpdate.AutoSize = true;
            this.checkBox_autoCheckUpdate.Checked = true;
            this.checkBox_autoCheckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoCheckUpdate.Location = new System.Drawing.Point(8, 40);
            this.checkBox_autoCheckUpdate.Name = "checkBox_autoCheckUpdate";
            this.checkBox_autoCheckUpdate.Size = new System.Drawing.Size(96, 16);
            this.checkBox_autoCheckUpdate.TabIndex = 4;
            this.checkBox_autoCheckUpdate.Text = "自动检测升级";
            this.checkBox_autoCheckUpdate.UseVisualStyleBackColor = true;
            this.checkBox_autoCheckUpdate.CheckedChanged += new System.EventHandler(this.checkBox_autoCheckUpdate_CheckedChanged);
            // 
            // label_latestVer
            // 
            this.label_latestVer.AutoSize = true;
            this.label_latestVer.Location = new System.Drawing.Point(185, 19);
            this.label_latestVer.Name = "label_latestVer";
            this.label_latestVer.Size = new System.Drawing.Size(47, 12);
            this.label_latestVer.TabIndex = 3;
            this.label_latestVer.Text = "0.0.0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "远程版本:";
            // 
            // label_currentVer
            // 
            this.label_currentVer.AutoSize = true;
            this.label_currentVer.Location = new System.Drawing.Point(71, 19);
            this.label_currentVer.Name = "label_currentVer";
            this.label_currentVer.Size = new System.Drawing.Size(47, 12);
            this.label_currentVer.TabIndex = 1;
            this.label_currentVer.Text = "0.0.0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "本地版本:";
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 289);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_updateInfo);
            this.Controls.Add(this.authorInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_About";
            this.Text = "关于";
            this.Load += new System.EventHandler(this.Form_About_Load);
            this.authorInformation.ResumeLayout(false);
            this.authorInformation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_autoCheckUpdate;
        private System.Windows.Forms.Label label_latestVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_currentVer;
        private System.Windows.Forms.Label label4;
    }
}