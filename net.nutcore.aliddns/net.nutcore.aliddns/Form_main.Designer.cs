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
            this.button_ngrok = new System.Windows.Forms.Button();
            this.checkBox_ngrok = new System.Windows.Forms.CheckBox();
            this.checkBox_logAutoSave = new System.Windows.Forms.CheckBox();
            this.checkBox_minimized = new System.Windows.Forms.CheckBox();
            this.checkBox_autoUpdate = new System.Windows.Forms.CheckBox();
            this.checkBox_autoBoot = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_nextUpdateSeconds = new System.Windows.Forms.Label();
            this.updateNow = new System.Windows.Forms.Button();
            this.debugMessage = new System.Windows.Forms.GroupBox();
            this.label_TTL = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.recordId = new System.Windows.Forms.TextBox();
            this.globalValue = new System.Windows.Forms.Label();
            this.globalDomainType = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.globalRR = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.globalSetGroup = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_TTL = new System.Windows.Forms.TextBox();
            this.button_ShowHide = new System.Windows.Forms.Button();
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
            this.autoUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_sysTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_checkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.groupBox_netstate = new System.Windows.Forms.GroupBox();
            this.label_DomainIpStatus = new System.Windows.Forms.Label();
            this.label_localIpStatus = new System.Windows.Forms.Label();
            this.domainIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.localIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_setWanIp = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_setIP = new System.Windows.Forms.MaskedTextBox();
            this.button_setIP = new System.Windows.Forms.Button();
            this.comboBox_whatIsUrl = new System.Windows.Forms.ComboBox();
            this.button_whatIsTest = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.timeSetGroup.SuspendLayout();
            this.debugMessage.SuspendLayout();
            this.globalSetGroup.SuspendLayout();
            this.contextMenuStrip_sysTrayMenu.SuspendLayout();
            this.groupBox_netstate.SuspendLayout();
            this.groupBox_setWanIp.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeSetGroup
            // 
            this.timeSetGroup.Controls.Add(this.button_ngrok);
            this.timeSetGroup.Controls.Add(this.checkBox_ngrok);
            this.timeSetGroup.Controls.Add(this.checkBox_logAutoSave);
            this.timeSetGroup.Controls.Add(this.checkBox_minimized);
            this.timeSetGroup.Controls.Add(this.checkBox_autoUpdate);
            this.timeSetGroup.Controls.Add(this.checkBox_autoBoot);
            this.timeSetGroup.Controls.Add(this.label3);
            this.timeSetGroup.Controls.Add(this.label_nextUpdateSeconds);
            this.timeSetGroup.Controls.Add(this.updateNow);
            this.timeSetGroup.Location = new System.Drawing.Point(12, 185);
            this.timeSetGroup.Name = "timeSetGroup";
            this.timeSetGroup.Size = new System.Drawing.Size(201, 145);
            this.timeSetGroup.TabIndex = 4;
            this.timeSetGroup.TabStop = false;
            this.timeSetGroup.Text = "其它设置";
            // 
            // button_ngrok
            // 
            this.button_ngrok.Location = new System.Drawing.Point(112, 53);
            this.button_ngrok.Name = "button_ngrok";
            this.button_ngrok.Size = new System.Drawing.Size(79, 23);
            this.button_ngrok.TabIndex = 10;
            this.button_ngrok.Text = "ngrok设置";
            this.button_ngrok.UseVisualStyleBackColor = true;
            this.button_ngrok.Click += new System.EventHandler(this.button_ngrok_Click);
            // 
            // checkBox_ngrok
            // 
            this.checkBox_ngrok.AutoSize = true;
            this.checkBox_ngrok.Location = new System.Drawing.Point(9, 57);
            this.checkBox_ngrok.Name = "checkBox_ngrok";
            this.checkBox_ngrok.Size = new System.Drawing.Size(78, 16);
            this.checkBox_ngrok.TabIndex = 9;
            this.checkBox_ngrok.Text = "启用ngrok";
            this.checkBox_ngrok.UseVisualStyleBackColor = true;
            this.checkBox_ngrok.CheckedChanged += new System.EventHandler(this.checkBox_ngrok_CheckedChanged);
            // 
            // checkBox_logAutoSave
            // 
            this.checkBox_logAutoSave.AutoSize = true;
            this.checkBox_logAutoSave.Location = new System.Drawing.Point(9, 77);
            this.checkBox_logAutoSave.Name = "checkBox_logAutoSave";
            this.checkBox_logAutoSave.Size = new System.Drawing.Size(96, 16);
            this.checkBox_logAutoSave.TabIndex = 8;
            this.checkBox_logAutoSave.Text = "日志自动转储";
            this.checkBox_logAutoSave.UseVisualStyleBackColor = true;
            this.checkBox_logAutoSave.CheckedChanged += new System.EventHandler(this.checkBox_logAutoSave_CheckedChanged);
            // 
            // checkBox_minimized
            // 
            this.checkBox_minimized.AutoSize = true;
            this.checkBox_minimized.Location = new System.Drawing.Point(9, 37);
            this.checkBox_minimized.Name = "checkBox_minimized";
            this.checkBox_minimized.Size = new System.Drawing.Size(96, 16);
            this.checkBox_minimized.TabIndex = 7;
            this.checkBox_minimized.Text = "启动时最小化";
            this.checkBox_minimized.UseVisualStyleBackColor = true;
            this.checkBox_minimized.CheckedChanged += new System.EventHandler(this.checkBox_minimized_CheckedChanged);
            // 
            // checkBox_autoUpdate
            // 
            this.checkBox_autoUpdate.AutoSize = true;
            this.checkBox_autoUpdate.Checked = true;
            this.checkBox_autoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoUpdate.Location = new System.Drawing.Point(9, 97);
            this.checkBox_autoUpdate.Name = "checkBox_autoUpdate";
            this.checkBox_autoUpdate.Size = new System.Drawing.Size(72, 16);
            this.checkBox_autoUpdate.TabIndex = 6;
            this.checkBox_autoUpdate.Text = "自动更新";
            this.checkBox_autoUpdate.UseVisualStyleBackColor = true;
            this.checkBox_autoUpdate.CheckedChanged += new System.EventHandler(this.checkBox_autoUpdate_CheckedChanged);
            // 
            // checkBox_autoBoot
            // 
            this.checkBox_autoBoot.AutoSize = true;
            this.checkBox_autoBoot.Location = new System.Drawing.Point(9, 19);
            this.checkBox_autoBoot.Name = "checkBox_autoBoot";
            this.checkBox_autoBoot.Size = new System.Drawing.Size(84, 16);
            this.checkBox_autoBoot.TabIndex = 5;
            this.checkBox_autoBoot.Text = "随系统启动";
            this.checkBox_autoBoot.UseVisualStyleBackColor = true;
            this.checkBox_autoBoot.CheckedChanged += new System.EventHandler(this.checkBox_autoBoot_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "秒后更新记录";
            // 
            // label_nextUpdateSeconds
            // 
            this.label_nextUpdateSeconds.ForeColor = System.Drawing.Color.Red;
            this.label_nextUpdateSeconds.Location = new System.Drawing.Point(87, 99);
            this.label_nextUpdateSeconds.Name = "label_nextUpdateSeconds";
            this.label_nextUpdateSeconds.Size = new System.Drawing.Size(30, 12);
            this.label_nextUpdateSeconds.TabIndex = 3;
            this.label_nextUpdateSeconds.Text = "60";
            this.label_nextUpdateSeconds.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // updateNow
            // 
            this.updateNow.Location = new System.Drawing.Point(6, 117);
            this.updateNow.Name = "updateNow";
            this.updateNow.Size = new System.Drawing.Size(185, 23);
            this.updateNow.TabIndex = 2;
            this.updateNow.Text = "立即更新";
            this.updateNow.UseVisualStyleBackColor = true;
            this.updateNow.Click += new System.EventHandler(this.updateNow_Click);
            // 
            // debugMessage
            // 
            this.debugMessage.Controls.Add(this.label_TTL);
            this.debugMessage.Controls.Add(this.label15);
            this.debugMessage.Controls.Add(this.recordId);
            this.debugMessage.Controls.Add(this.globalValue);
            this.debugMessage.Controls.Add(this.globalDomainType);
            this.debugMessage.Controls.Add(this.label12);
            this.debugMessage.Controls.Add(this.label11);
            this.debugMessage.Controls.Add(this.globalRR);
            this.debugMessage.Controls.Add(this.label10);
            this.debugMessage.Controls.Add(this.label9);
            this.debugMessage.Location = new System.Drawing.Point(219, 47);
            this.debugMessage.Name = "debugMessage";
            this.debugMessage.Size = new System.Drawing.Size(206, 79);
            this.debugMessage.TabIndex = 5;
            this.debugMessage.TabStop = false;
            this.debugMessage.Text = "调试信息";
            // 
            // label_TTL
            // 
            this.label_TTL.AutoSize = true;
            this.label_TTL.Location = new System.Drawing.Point(157, 44);
            this.label_TTL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_TTL.Name = "label_TTL";
            this.label_TTL.Size = new System.Drawing.Size(41, 12);
            this.label_TTL.TabIndex = 10;
            this.label_TTL.Text = "<null>";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(131, 44);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "TTL:";
            // 
            // recordId
            // 
            this.recordId.Location = new System.Drawing.Point(68, 18);
            this.recordId.Name = "recordId";
            this.recordId.Size = new System.Drawing.Size(116, 21);
            this.recordId.TabIndex = 8;
            this.recordId.Text = "<null>";
            // 
            // globalValue
            // 
            this.globalValue.AutoSize = true;
            this.globalValue.Location = new System.Drawing.Point(45, 63);
            this.globalValue.Name = "globalValue";
            this.globalValue.Size = new System.Drawing.Size(41, 12);
            this.globalValue.TabIndex = 7;
            this.globalValue.Text = "<null>";
            // 
            // globalDomainType
            // 
            this.globalDomainType.AutoSize = true;
            this.globalDomainType.Location = new System.Drawing.Point(93, 44);
            this.globalDomainType.Name = "globalDomainType";
            this.globalDomainType.Size = new System.Drawing.Size(41, 12);
            this.globalDomainType.TabIndex = 6;
            this.globalDomainType.Text = "<null>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Value:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(62, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Type:";
            // 
            // globalRR
            // 
            this.globalRR.AutoSize = true;
            this.globalRR.Location = new System.Drawing.Point(26, 44);
            this.globalRR.Name = "globalRR";
            this.globalRR.Size = new System.Drawing.Size(41, 12);
            this.globalRR.TabIndex = 3;
            this.globalRR.Text = "<null>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "RR:";
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
            this.globalSetGroup.Controls.Add(this.label13);
            this.globalSetGroup.Controls.Add(this.textBox_TTL);
            this.globalSetGroup.Controls.Add(this.button_ShowHide);
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
            this.globalSetGroup.Location = new System.Drawing.Point(219, 132);
            this.globalSetGroup.Name = "globalSetGroup";
            this.globalSetGroup.Size = new System.Drawing.Size(206, 198);
            this.globalSetGroup.TabIndex = 6;
            this.globalSetGroup.TabStop = false;
            this.globalSetGroup.Text = "设置";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 124);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "TTL(秒)";
            // 
            // textBox_TTL
            // 
            this.textBox_TTL.Location = new System.Drawing.Point(65, 121);
            this.textBox_TTL.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_TTL.Name = "textBox_TTL";
            this.textBox_TTL.Size = new System.Drawing.Size(37, 21);
            this.textBox_TTL.TabIndex = 15;
            this.textBox_TTL.Text = "600";
            // 
            // button_ShowHide
            // 
            this.button_ShowHide.Location = new System.Drawing.Point(106, 169);
            this.button_ShowHide.Name = "button_ShowHide";
            this.button_ShowHide.Size = new System.Drawing.Size(91, 23);
            this.button_ShowHide.TabIndex = 14;
            this.button_ShowHide.Text = "显示录入";
            this.button_ShowHide.UseVisualStyleBackColor = true;
            this.button_ShowHide.Click += new System.EventHandler(this.button_ShowHide_Click);
            // 
            // checkAndSaveConfig
            // 
            this.checkAndSaveConfig.Location = new System.Drawing.Point(8, 169);
            this.checkAndSaveConfig.Name = "checkAndSaveConfig";
            this.checkAndSaveConfig.Size = new System.Drawing.Size(93, 23);
            this.checkAndSaveConfig.TabIndex = 10;
            this.checkAndSaveConfig.Text = "测试并保存";
            this.checkAndSaveConfig.UseVisualStyleBackColor = true;
            this.checkAndSaveConfig.Click += new System.EventHandler(this.checkConfig_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "秒更新一次";
            // 
            // newSeconds
            // 
            this.newSeconds.Location = new System.Drawing.Point(41, 149);
            this.newSeconds.Name = "newSeconds";
            this.newSeconds.Size = new System.Drawing.Size(60, 21);
            this.newSeconds.TabIndex = 7;
            this.newSeconds.Text = "60";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "每隔";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "完整域名";
            // 
            // fullDomainName
            // 
            this.fullDomainName.Location = new System.Drawing.Point(65, 95);
            this.fullDomainName.Name = "fullDomainName";
            this.fullDomainName.Size = new System.Drawing.Size(135, 21);
            this.fullDomainName.TabIndex = 4;
            this.fullDomainName.Text = "www.xxx.com";
            this.fullDomainName.ModifiedChanged += new System.EventHandler(this.fullDomainName_ModifiedChanged);
            // 
            // accessKeySecret
            // 
            this.accessKeySecret.Location = new System.Drawing.Point(8, 68);
            this.accessKeySecret.Name = "accessKeySecret";
            this.accessKeySecret.PasswordChar = '*';
            this.accessKeySecret.Size = new System.Drawing.Size(192, 21);
            this.accessKeySecret.TabIndex = 3;
            this.accessKeySecret.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "accessKeySecret";
            // 
            // accessKeyId
            // 
            this.accessKeyId.Location = new System.Drawing.Point(8, 29);
            this.accessKeyId.Name = "accessKeyId";
            this.accessKeyId.PasswordChar = '*';
            this.accessKeyId.Size = new System.Drawing.Size(192, 21);
            this.accessKeyId.TabIndex = 1;
            this.accessKeyId.Text = "null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "accessKeyId";
            // 
            // autoUpdateTimer
            // 
            this.autoUpdateTimer.Enabled = true;
            this.autoUpdateTimer.Interval = 1000;
            this.autoUpdateTimer.Tick += new System.EventHandler(this.autoUpdateTimer_Tick);
            // 
            // notifyIcon_sysTray
            // 
            this.notifyIcon_sysTray.ContextMenuStrip = this.contextMenuStrip_sysTrayMenu;
            this.notifyIcon_sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_sysTray.Icon")));
            this.notifyIcon_sysTray.Text = "AliDDNS Tray";
            this.notifyIcon_sysTray.Visible = true;
            this.notifyIcon_sysTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_sysTray_MouseDoubleClick);
            // 
            // contextMenuStrip_sysTrayMenu
            // 
            this.contextMenuStrip_sysTrayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip_sysTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit,
            this.ToolStripMenuItem_checkUpdate,
            this.ToolStripMenuItem_About});
            this.contextMenuStrip_sysTrayMenu.Name = "contextMenuStrip1";
            this.contextMenuStrip_sysTrayMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_Exit.Text = "退出";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem_checkUpdate
            // 
            this.ToolStripMenuItem_checkUpdate.Name = "ToolStripMenuItem_checkUpdate";
            this.ToolStripMenuItem_checkUpdate.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_checkUpdate.Text = "检查升级";
            this.ToolStripMenuItem_checkUpdate.Click += new System.EventHandler(this.ToolStripMenuItem_checkUPdate_Click);
            // 
            // ToolStripMenuItem_About
            // 
            this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            this.ToolStripMenuItem_About.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_About.Text = "关于";
            this.ToolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(12, 335);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(413, 109);
            this.textBox_log.TabIndex = 8;
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
            this.groupBox_netstate.Size = new System.Drawing.Size(413, 38);
            this.groupBox_netstate.TabIndex = 9;
            this.groupBox_netstate.TabStop = false;
            this.groupBox_netstate.Text = "网络状态";
            // 
            // label_DomainIpStatus
            // 
            this.label_DomainIpStatus.AutoSize = true;
            this.label_DomainIpStatus.ForeColor = System.Drawing.Color.Red;
            this.label_DomainIpStatus.Location = new System.Drawing.Point(364, 19);
            this.label_DomainIpStatus.Name = "label_DomainIpStatus";
            this.label_DomainIpStatus.Size = new System.Drawing.Size(41, 12);
            this.label_DomainIpStatus.TabIndex = 9;
            this.label_DomainIpStatus.Text = "未绑定";
            // 
            // label_localIpStatus
            // 
            this.label_localIpStatus.AutoSize = true;
            this.label_localIpStatus.ForeColor = System.Drawing.Color.Red;
            this.label_localIpStatus.Location = new System.Drawing.Point(156, 19);
            this.label_localIpStatus.Name = "label_localIpStatus";
            this.label_localIpStatus.Size = new System.Drawing.Size(41, 12);
            this.label_localIpStatus.TabIndex = 8;
            this.label_localIpStatus.Text = "未连接";
            // 
            // domainIP
            // 
            this.domainIP.AutoSize = true;
            this.domainIP.Location = new System.Drawing.Point(259, 19);
            this.domainIP.Name = "domainIP";
            this.domainIP.Size = new System.Drawing.Size(47, 12);
            this.domainIP.TabIndex = 7;
            this.domainIP.Text = "0.0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "域名IP:";
            // 
            // localIP
            // 
            this.localIP.AutoSize = true;
            this.localIP.Location = new System.Drawing.Point(57, 19);
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
            // groupBox_setWanIp
            // 
            this.groupBox_setWanIp.Controls.Add(this.maskedTextBox_setIP);
            this.groupBox_setWanIp.Controls.Add(this.button_setIP);
            this.groupBox_setWanIp.Controls.Add(this.comboBox_whatIsUrl);
            this.groupBox_setWanIp.Controls.Add(this.button_whatIsTest);
            this.groupBox_setWanIp.Controls.Add(this.label14);
            this.groupBox_setWanIp.Location = new System.Drawing.Point(12, 47);
            this.groupBox_setWanIp.Name = "groupBox_setWanIp";
            this.groupBox_setWanIp.Size = new System.Drawing.Size(201, 135);
            this.groupBox_setWanIp.TabIndex = 10;
            this.groupBox_setWanIp.TabStop = false;
            this.groupBox_setWanIp.Text = "WAN口IP设置";
            // 
            // maskedTextBox_setIP
            // 
            this.maskedTextBox_setIP.Location = new System.Drawing.Point(7, 100);
            this.maskedTextBox_setIP.Mask = "000.000.000.000";
            this.maskedTextBox_setIP.Name = "maskedTextBox_setIP";
            this.maskedTextBox_setIP.PromptChar = ' ';
            this.maskedTextBox_setIP.Size = new System.Drawing.Size(106, 21);
            this.maskedTextBox_setIP.TabIndex = 20;
            // 
            // button_setIP
            // 
            this.button_setIP.Location = new System.Drawing.Point(119, 99);
            this.button_setIP.Name = "button_setIP";
            this.button_setIP.Size = new System.Drawing.Size(76, 23);
            this.button_setIP.TabIndex = 19;
            this.button_setIP.Text = "手工指定IP";
            this.button_setIP.UseVisualStyleBackColor = true;
            this.button_setIP.Click += new System.EventHandler(this.button_setIP_Click);
            // 
            // comboBox_whatIsUrl
            // 
            this.comboBox_whatIsUrl.FormattingEnabled = true;
            this.comboBox_whatIsUrl.Items.AddRange(new object[] {
            "http://whatismyip.akamai.com/",
            "http://www.net.cn/static/customercare/yourip.asp"});
            this.comboBox_whatIsUrl.Location = new System.Drawing.Point(6, 41);
            this.comboBox_whatIsUrl.Name = "comboBox_whatIsUrl";
            this.comboBox_whatIsUrl.Size = new System.Drawing.Size(189, 20);
            this.comboBox_whatIsUrl.TabIndex = 18;
            this.comboBox_whatIsUrl.Text = "http://whatismyip.akamai.com/";
            // 
            // button_whatIsTest
            // 
            this.button_whatIsTest.Location = new System.Drawing.Point(6, 66);
            this.button_whatIsTest.Name = "button_whatIsTest";
            this.button_whatIsTest.Size = new System.Drawing.Size(189, 23);
            this.button_whatIsTest.TabIndex = 17;
            this.button_whatIsTest.Text = "获取WAN口IP";
            this.button_whatIsTest.UseVisualStyleBackColor = true;
            this.button_whatIsTest.Click += new System.EventHandler(this.button_whatIsTest_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "查询网址:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 451);
            this.Controls.Add(this.groupBox_setWanIp);
            this.Controls.Add(this.groupBox_netstate);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.globalSetGroup);
            this.Controls.Add(this.debugMessage);
            this.Controls.Add(this.timeSetGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "AliDDNS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.timeSetGroup.ResumeLayout(false);
            this.timeSetGroup.PerformLayout();
            this.debugMessage.ResumeLayout(false);
            this.debugMessage.PerformLayout();
            this.globalSetGroup.ResumeLayout(false);
            this.globalSetGroup.PerformLayout();
            this.contextMenuStrip_sysTrayMenu.ResumeLayout(false);
            this.groupBox_netstate.ResumeLayout(false);
            this.groupBox_netstate.PerformLayout();
            this.groupBox_setWanIp.ResumeLayout(false);
            this.groupBox_setWanIp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox timeSetGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_nextUpdateSeconds;
        private System.Windows.Forms.Button updateNow;
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
        private System.Windows.Forms.NotifyIcon notifyIcon_sysTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_sysTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.GroupBox groupBox_netstate;
        private System.Windows.Forms.Label label_DomainIpStatus;
        private System.Windows.Forms.Label label_localIpStatus;
        private System.Windows.Forms.Label domainIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label localIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ShowHide;
        private System.Windows.Forms.CheckBox checkBox_autoBoot;
        private System.Windows.Forms.CheckBox checkBox_autoUpdate;
        private System.Windows.Forms.CheckBox checkBox_minimized;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
        private System.Windows.Forms.CheckBox checkBox_logAutoSave;
        private System.Windows.Forms.GroupBox groupBox_setWanIp;
        private System.Windows.Forms.ComboBox comboBox_whatIsUrl;
        private System.Windows.Forms.Button button_whatIsTest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_setIP;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_setIP;
        private System.Windows.Forms.Label label_TTL;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_TTL;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_checkUpdate;
        private System.Windows.Forms.Button button_ngrok;
        private System.Windows.Forms.CheckBox checkBox_ngrok;
        public System.Windows.Forms.TextBox textBox_log;
    }
}

