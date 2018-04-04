namespace net.nutcore.aliddns
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.timeSetGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nextUpdateSeconds = new System.Windows.Forms.Label();
            this.updateNow = new System.Windows.Forms.Button();
            this.autoUpdateOff = new System.Windows.Forms.RadioButton();
            this.autoUpdateOn = new System.Windows.Forms.RadioButton();
            this.debugMessage = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.recordId = new System.Windows.Forms.TextBox();
            this.globalValue = new System.Windows.Forms.Label();
            this.globalDomainType = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.globalRR = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.globalSetGroup = new System.Windows.Forms.GroupBox();
            this.checkAndSaveConfig = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.newSeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fullDomainName = new System.Windows.Forms.TextBox();
            this.accessKeySecret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.accessKeyId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authorInformation = new System.Windows.Forms.GroupBox();
            this.personalWebsite = new System.Windows.Forms.LinkLabel();
            this.autoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.text_whatIsUrl = new System.Windows.Forms.TextBox();
            this.button_whatIsTest = new System.Windows.Forms.Button();
            this.groupBox_netstate = new System.Windows.Forms.GroupBox();
            this.domainIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.localIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_localIpStatus = new System.Windows.Forms.Label();
            this.label_DomainIpStatus = new System.Windows.Forms.Label();
            this.button_ShowHide = new System.Windows.Forms.Button();
            this.PublishLink = new System.Windows.Forms.LinkLabel();
            this.timeSetGroup.SuspendLayout();
            this.debugMessage.SuspendLayout();
            this.globalSetGroup.SuspendLayout();
            this.authorInformation.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox_netstate.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeSetGroup
            // 
            this.timeSetGroup.Controls.Add(this.label3);
            this.timeSetGroup.Controls.Add(this.nextUpdateSeconds);
            this.timeSetGroup.Controls.Add(this.updateNow);
            this.timeSetGroup.Controls.Add(this.autoUpdateOff);
            this.timeSetGroup.Controls.Add(this.autoUpdateOn);
            this.timeSetGroup.Location = new System.Drawing.Point(12, 44);
            this.timeSetGroup.Name = "timeSetGroup";
            this.timeSetGroup.Size = new System.Drawing.Size(190, 88);
            this.timeSetGroup.TabIndex = 4;
            this.timeSetGroup.TabStop = false;
            this.timeSetGroup.Text = "定时更新";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "秒后更新记录";
            // 
            // nextUpdateSeconds
            // 
            this.nextUpdateSeconds.AutoSize = true;
            this.nextUpdateSeconds.Location = new System.Drawing.Point(47, 40);
            this.nextUpdateSeconds.Name = "nextUpdateSeconds";
            this.nextUpdateSeconds.Size = new System.Drawing.Size(17, 12);
            this.nextUpdateSeconds.TabIndex = 3;
            this.nextUpdateSeconds.Text = "60";
            // 
            // updateNow
            // 
            this.updateNow.Location = new System.Drawing.Point(16, 55);
            this.updateNow.Name = "updateNow";
            this.updateNow.Size = new System.Drawing.Size(156, 23);
            this.updateNow.TabIndex = 2;
            this.updateNow.Text = "立即更新";
            this.updateNow.UseVisualStyleBackColor = true;
            this.updateNow.Click += new System.EventHandler(this.updateNow_Click);
            // 
            // autoUpdateOff
            // 
            this.autoUpdateOff.AutoSize = true;
            this.autoUpdateOff.Location = new System.Drawing.Point(125, 20);
            this.autoUpdateOff.Name = "autoUpdateOff";
            this.autoUpdateOff.Size = new System.Drawing.Size(47, 16);
            this.autoUpdateOff.TabIndex = 1;
            this.autoUpdateOff.Text = "关闭";
            this.autoUpdateOff.UseVisualStyleBackColor = true;
            // 
            // autoUpdateOn
            // 
            this.autoUpdateOn.AutoSize = true;
            this.autoUpdateOn.Checked = true;
            this.autoUpdateOn.Location = new System.Drawing.Point(17, 21);
            this.autoUpdateOn.Name = "autoUpdateOn";
            this.autoUpdateOn.Size = new System.Drawing.Size(47, 16);
            this.autoUpdateOn.TabIndex = 0;
            this.autoUpdateOn.TabStop = true;
            this.autoUpdateOn.Text = "开启";
            this.autoUpdateOn.UseVisualStyleBackColor = true;
            // 
            // debugMessage
            // 
            this.debugMessage.Controls.Add(this.label13);
            this.debugMessage.Controls.Add(this.recordId);
            this.debugMessage.Controls.Add(this.globalValue);
            this.debugMessage.Controls.Add(this.globalDomainType);
            this.debugMessage.Controls.Add(this.label12);
            this.debugMessage.Controls.Add(this.label11);
            this.debugMessage.Controls.Add(this.globalRR);
            this.debugMessage.Controls.Add(this.label10);
            this.debugMessage.Controls.Add(this.label9);
            this.debugMessage.Location = new System.Drawing.Point(12, 133);
            this.debugMessage.Name = "debugMessage";
            this.debugMessage.Size = new System.Drawing.Size(190, 111);
            this.debugMessage.TabIndex = 5;
            this.debugMessage.TabStop = false;
            this.debugMessage.Text = "调试信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(7, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "出错请手动修改config.xml!";
            // 
            // recordId
            // 
            this.recordId.Location = new System.Drawing.Point(68, 18);
            this.recordId.Name = "recordId";
            this.recordId.Size = new System.Drawing.Size(94, 21);
            this.recordId.TabIndex = 8;
            this.recordId.Text = "<null>";
            // 
            // globalValue
            // 
            this.globalValue.AutoSize = true;
            this.globalValue.Location = new System.Drawing.Point(65, 73);
            this.globalValue.Name = "globalValue";
            this.globalValue.Size = new System.Drawing.Size(41, 12);
            this.globalValue.TabIndex = 7;
            this.globalValue.Text = "<null>";
            // 
            // globalDomainType
            // 
            this.globalDomainType.AutoSize = true;
            this.globalDomainType.Location = new System.Drawing.Point(66, 57);
            this.globalDomainType.Name = "globalDomainType";
            this.globalDomainType.Size = new System.Drawing.Size(41, 12);
            this.globalDomainType.TabIndex = 6;
            this.globalDomainType.Text = "<null>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Value";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Type";
            // 
            // globalRR
            // 
            this.globalRR.AutoSize = true;
            this.globalRR.Location = new System.Drawing.Point(66, 40);
            this.globalRR.Name = "globalRR";
            this.globalRR.Size = new System.Drawing.Size(41, 12);
            this.globalRR.TabIndex = 3;
            this.globalRR.Text = "<null>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "RR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "RecordId";
            // 
            // globalSetGroup
            // 
            this.globalSetGroup.Controls.Add(this.button_ShowHide);
            this.globalSetGroup.Controls.Add(this.button_whatIsTest);
            this.globalSetGroup.Controls.Add(this.text_whatIsUrl);
            this.globalSetGroup.Controls.Add(this.label14);
            this.globalSetGroup.Controls.Add(this.checkAndSaveConfig);
            this.globalSetGroup.Controls.Add(this.label8);
            this.globalSetGroup.Controls.Add(this.newSeconds);
            this.globalSetGroup.Controls.Add(this.label7);
            this.globalSetGroup.Controls.Add(this.label6);
            this.globalSetGroup.Controls.Add(this.fullDomainName);
            this.globalSetGroup.Controls.Add(this.accessKeySecret);
            this.globalSetGroup.Controls.Add(this.label5);
            this.globalSetGroup.Controls.Add(this.accessKeyId);
            this.globalSetGroup.Controls.Add(this.label4);
            this.globalSetGroup.Location = new System.Drawing.Point(208, 44);
            this.globalSetGroup.Name = "globalSetGroup";
            this.globalSetGroup.Size = new System.Drawing.Size(206, 264);
            this.globalSetGroup.TabIndex = 6;
            this.globalSetGroup.TabStop = false;
            this.globalSetGroup.Text = "设置";
            // 
            // checkAndSaveConfig
            // 
            this.checkAndSaveConfig.Location = new System.Drawing.Point(8, 231);
            this.checkAndSaveConfig.Name = "checkAndSaveConfig";
            this.checkAndSaveConfig.Size = new System.Drawing.Size(93, 23);
            this.checkAndSaveConfig.TabIndex = 10;
            this.checkAndSaveConfig.Text = "验证并保存";
            this.checkAndSaveConfig.UseVisualStyleBackColor = true;
            this.checkAndSaveConfig.Click += new System.EventHandler(this.checkConfig_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "秒更新一次";
            // 
            // newSeconds
            // 
            this.newSeconds.Location = new System.Drawing.Point(41, 202);
            this.newSeconds.Name = "newSeconds";
            this.newSeconds.Size = new System.Drawing.Size(60, 21);
            this.newSeconds.TabIndex = 7;
            this.newSeconds.Text = "60";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "每隔";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "完整域名";
            // 
            // fullDomainName
            // 
            this.fullDomainName.Location = new System.Drawing.Point(65, 175);
            this.fullDomainName.Name = "fullDomainName";
            this.fullDomainName.Size = new System.Drawing.Size(135, 21);
            this.fullDomainName.TabIndex = 4;
            this.fullDomainName.Text = "www.xxx.com";
            // 
            // accessKeySecret
            // 
            this.accessKeySecret.Location = new System.Drawing.Point(8, 148);
            this.accessKeySecret.Name = "accessKeySecret";
            this.accessKeySecret.PasswordChar = '*';
            this.accessKeySecret.Size = new System.Drawing.Size(192, 21);
            this.accessKeySecret.TabIndex = 3;
            this.accessKeySecret.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "accessKeySecret";
            // 
            // accessKeyId
            // 
            this.accessKeyId.Location = new System.Drawing.Point(8, 109);
            this.accessKeyId.Name = "accessKeyId";
            this.accessKeyId.PasswordChar = '*';
            this.accessKeyId.Size = new System.Drawing.Size(192, 21);
            this.accessKeyId.TabIndex = 1;
            this.accessKeyId.Text = "null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "accessKeyId";
            // 
            // authorInformation
            // 
            this.authorInformation.Controls.Add(this.PublishLink);
            this.authorInformation.Controls.Add(this.personalWebsite);
            this.authorInformation.Location = new System.Drawing.Point(15, 246);
            this.authorInformation.Name = "authorInformation";
            this.authorInformation.Size = new System.Drawing.Size(187, 62);
            this.authorInformation.TabIndex = 7;
            this.authorInformation.TabStop = false;
            this.authorInformation.Text = "著作信息";
            // 
            // personalWebsite
            // 
            this.personalWebsite.AutoSize = true;
            this.personalWebsite.Location = new System.Drawing.Point(45, 17);
            this.personalWebsite.Name = "personalWebsite";
            this.personalWebsite.Size = new System.Drawing.Size(95, 12);
            this.personalWebsite.TabIndex = 1;
            this.personalWebsite.TabStop = true;
            this.personalWebsite.Text = "www.nutcore.net";
            this.personalWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.personalWebsite_LinkClicked);
            // 
            // autoUpdateTimer
            // 
            this.autoUpdateTimer.Enabled = true;
            this.autoUpdateTimer.Interval = 1000;
            this.autoUpdateTimer.Tick += new System.EventHandler(this.autoUpdateTimer_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AliDDNS Tray";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "退出";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(15, 314);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(399, 109);
            this.textBox_log.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "WAN口IP获取网址";
            // 
            // text_whatIsUrl
            // 
            this.text_whatIsUrl.Location = new System.Drawing.Point(8, 40);
            this.text_whatIsUrl.Name = "text_whatIsUrl";
            this.text_whatIsUrl.Size = new System.Drawing.Size(192, 21);
            this.text_whatIsUrl.TabIndex = 12;
            this.text_whatIsUrl.Text = "http://whatismyip.akamai.com/";
            // 
            // button_whatIsTest
            // 
            this.button_whatIsTest.Location = new System.Drawing.Point(8, 64);
            this.button_whatIsTest.Name = "button_whatIsTest";
            this.button_whatIsTest.Size = new System.Drawing.Size(192, 23);
            this.button_whatIsTest.TabIndex = 13;
            this.button_whatIsTest.Text = "获取WAN口IP";
            this.button_whatIsTest.UseVisualStyleBackColor = true;
            this.button_whatIsTest.Click += new System.EventHandler(this.button_whatIsTest_Click);
            // 
            // groupBox_netstate
            // 
            this.groupBox_netstate.Controls.Add(this.label_DomainIpStatus);
            this.groupBox_netstate.Controls.Add(this.label_localIpStatus);
            this.groupBox_netstate.Controls.Add(this.domainIP);
            this.groupBox_netstate.Controls.Add(this.label2);
            this.groupBox_netstate.Controls.Add(this.localIP);
            this.groupBox_netstate.Controls.Add(this.label1);
            this.groupBox_netstate.Location = new System.Drawing.Point(12, 3);
            this.groupBox_netstate.Name = "groupBox_netstate";
            this.groupBox_netstate.Size = new System.Drawing.Size(402, 38);
            this.groupBox_netstate.TabIndex = 9;
            this.groupBox_netstate.TabStop = false;
            this.groupBox_netstate.Text = "网络状态";
            // 
            // domainIP
            // 
            this.domainIP.AutoSize = true;
            this.domainIP.Location = new System.Drawing.Point(237, 19);
            this.domainIP.Name = "domainIP";
            this.domainIP.Size = new System.Drawing.Size(47, 12);
            this.domainIP.TabIndex = 7;
            this.domainIP.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "域名IP:";
            // 
            // localIP
            // 
            this.localIP.AutoSize = true;
            this.localIP.Location = new System.Drawing.Point(59, 19);
            this.localIP.Name = "localIP";
            this.localIP.Size = new System.Drawing.Size(47, 12);
            this.localIP.TabIndex = 5;
            this.localIP.Text = "0.0.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "WAN口IP:";
            // 
            // label_localIpStatus
            // 
            this.label_localIpStatus.AutoSize = true;
            this.label_localIpStatus.Location = new System.Drawing.Point(147, 19);
            this.label_localIpStatus.Name = "label_localIpStatus";
            this.label_localIpStatus.Size = new System.Drawing.Size(41, 12);
            this.label_localIpStatus.TabIndex = 8;
            this.label_localIpStatus.Text = "已连接";
            // 
            // label_DomainIpStatus
            // 
            this.label_DomainIpStatus.AutoSize = true;
            this.label_DomainIpStatus.Location = new System.Drawing.Point(340, 19);
            this.label_DomainIpStatus.Name = "label_DomainIpStatus";
            this.label_DomainIpStatus.Size = new System.Drawing.Size(53, 12);
            this.label_DomainIpStatus.TabIndex = 9;
            this.label_DomainIpStatus.Text = "已经绑定";
            // 
            // button_ShowHide
            // 
            this.button_ShowHide.Location = new System.Drawing.Point(106, 231);
            this.button_ShowHide.Name = "button_ShowHide";
            this.button_ShowHide.Size = new System.Drawing.Size(91, 23);
            this.button_ShowHide.TabIndex = 14;
            this.button_ShowHide.Text = "显示录入";
            this.button_ShowHide.UseVisualStyleBackColor = true;
            this.button_ShowHide.Click += new System.EventHandler(this.button_ShowHide_Click);
            // 
            // PublishLink
            // 
            this.PublishLink.AutoSize = true;
            this.PublishLink.Location = new System.Drawing.Point(49, 38);
            this.PublishLink.Name = "PublishLink";
            this.PublishLink.Size = new System.Drawing.Size(77, 12);
            this.PublishLink.TabIndex = 2;
            this.PublishLink.TabStop = true;
            this.PublishLink.Text = "程序发布页面";
            this.PublishLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PubilishLink_LinkClicked);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 430);
            this.Controls.Add(this.groupBox_netstate);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.authorInformation);
            this.Controls.Add(this.globalSetGroup);
            this.Controls.Add(this.debugMessage);
            this.Controls.Add(this.timeSetGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Aliddns - 3.2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.timeSetGroup.ResumeLayout(false);
            this.timeSetGroup.PerformLayout();
            this.debugMessage.ResumeLayout(false);
            this.debugMessage.PerformLayout();
            this.globalSetGroup.ResumeLayout(false);
            this.globalSetGroup.PerformLayout();
            this.authorInformation.ResumeLayout(false);
            this.authorInformation.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox_netstate.ResumeLayout(false);
            this.groupBox_netstate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox timeSetGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nextUpdateSeconds;
        private System.Windows.Forms.Button updateNow;
        private System.Windows.Forms.RadioButton autoUpdateOff;
        private System.Windows.Forms.RadioButton autoUpdateOn;
        private System.Windows.Forms.GroupBox debugMessage;
        private System.Windows.Forms.GroupBox globalSetGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox newSeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fullDomainName;
        private System.Windows.Forms.TextBox accessKeySecret;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox accessKeyId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox authorInformation;
        private System.Windows.Forms.LinkLabel personalWebsite;
        private System.Windows.Forms.Timer autoUpdateTimer;
        private System.Windows.Forms.Button checkAndSaveConfig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label globalRR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label globalDomainType;
        private System.Windows.Forms.Label globalValue;
        private System.Windows.Forms.TextBox recordId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.TextBox text_whatIsUrl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_whatIsTest;
        private System.Windows.Forms.GroupBox groupBox_netstate;
        private System.Windows.Forms.Label label_DomainIpStatus;
        private System.Windows.Forms.Label label_localIpStatus;
        private System.Windows.Forms.Label domainIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label localIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ShowHide;
        private System.Windows.Forms.LinkLabel PublishLink;
    }
}

