namespace net.nutcore.aliddns
{
    partial class Form_ngrok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ngrok));
            this.groupBox_AuthToken = new System.Windows.Forms.GroupBox();
            this.textBox_AuthToken = new System.Windows.Forms.TextBox();
            this.groupBox_Ngrokserver = new System.Windows.Forms.GroupBox();
            this.groupBox_Url = new System.Windows.Forms.GroupBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_NgrokDomain = new System.Windows.Forms.Label();
            this.label_tunnelAddr = new System.Windows.Forms.Label();
            this.label_Defaultport = new System.Windows.Forms.Label();
            this.label_http = new System.Windows.Forms.Label();
            this.label_https = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_tunnelAddr = new System.Windows.Forms.TextBox();
            this.textBox_httpAddr = new System.Windows.Forms.TextBox();
            this.textBox_httpsAddr = new System.Windows.Forms.TextBox();
            this.label_subDomain = new System.Windows.Forms.Label();
            this.label_lanHttp = new System.Windows.Forms.Label();
            this.label_lanhttps = new System.Windows.Forms.Label();
            this.textBox_subDomain = new System.Windows.Forms.TextBox();
            this.textBox_lanHttp = new System.Windows.Forms.TextBox();
            this.textBox_Https = new System.Windows.Forms.TextBox();
            this.label_lanTcp = new System.Windows.Forms.Label();
            this.label_remoteport = new System.Windows.Forms.Label();
            this.label_lanport = new System.Windows.Forms.Label();
            this.textBox_lanTunnel1 = new System.Windows.Forms.TextBox();
            this.textBox_remotePort1 = new System.Windows.Forms.TextBox();
            this.textBox_lanPort1 = new System.Windows.Forms.TextBox();
            this.textBox_lanTunnel2 = new System.Windows.Forms.TextBox();
            this.textBox_remotePort2 = new System.Windows.Forms.TextBox();
            this.textBox_lanPort2 = new System.Windows.Forms.TextBox();
            this.groupBox_AuthToken.SuspendLayout();
            this.groupBox_Ngrokserver.SuspendLayout();
            this.groupBox_Url.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_AuthToken
            // 
            this.groupBox_AuthToken.Controls.Add(this.textBox_AuthToken);
            this.groupBox_AuthToken.Location = new System.Drawing.Point(6, 12);
            this.groupBox_AuthToken.Name = "groupBox_AuthToken";
            this.groupBox_AuthToken.Size = new System.Drawing.Size(273, 50);
            this.groupBox_AuthToken.TabIndex = 0;
            this.groupBox_AuthToken.TabStop = false;
            this.groupBox_AuthToken.Text = "认证令牌";
            // 
            // textBox_AuthToken
            // 
            this.textBox_AuthToken.Location = new System.Drawing.Point(11, 21);
            this.textBox_AuthToken.Name = "textBox_AuthToken";
            this.textBox_AuthToken.Size = new System.Drawing.Size(250, 21);
            this.textBox_AuthToken.TabIndex = 0;
            // 
            // groupBox_Ngrokserver
            // 
            this.groupBox_Ngrokserver.Controls.Add(this.textBox_httpsAddr);
            this.groupBox_Ngrokserver.Controls.Add(this.textBox_httpAddr);
            this.groupBox_Ngrokserver.Controls.Add(this.textBox_tunnelAddr);
            this.groupBox_Ngrokserver.Controls.Add(this.textBox1);
            this.groupBox_Ngrokserver.Controls.Add(this.label_https);
            this.groupBox_Ngrokserver.Controls.Add(this.label_http);
            this.groupBox_Ngrokserver.Controls.Add(this.label_Defaultport);
            this.groupBox_Ngrokserver.Controls.Add(this.label_tunnelAddr);
            this.groupBox_Ngrokserver.Controls.Add(this.label_NgrokDomain);
            this.groupBox_Ngrokserver.Location = new System.Drawing.Point(6, 68);
            this.groupBox_Ngrokserver.Name = "groupBox_Ngrokserver";
            this.groupBox_Ngrokserver.Size = new System.Drawing.Size(273, 97);
            this.groupBox_Ngrokserver.TabIndex = 1;
            this.groupBox_Ngrokserver.TabStop = false;
            this.groupBox_Ngrokserver.Text = "服务端Ngrokd";
            // 
            // groupBox_Url
            // 
            this.groupBox_Url.Controls.Add(this.textBox_lanPort2);
            this.groupBox_Url.Controls.Add(this.textBox_remotePort2);
            this.groupBox_Url.Controls.Add(this.textBox_lanTunnel2);
            this.groupBox_Url.Controls.Add(this.textBox_lanPort1);
            this.groupBox_Url.Controls.Add(this.textBox_remotePort1);
            this.groupBox_Url.Controls.Add(this.textBox_lanTunnel1);
            this.groupBox_Url.Controls.Add(this.label_lanport);
            this.groupBox_Url.Controls.Add(this.label_remoteport);
            this.groupBox_Url.Controls.Add(this.label_lanTcp);
            this.groupBox_Url.Controls.Add(this.textBox_Https);
            this.groupBox_Url.Controls.Add(this.textBox_lanHttp);
            this.groupBox_Url.Controls.Add(this.textBox_subDomain);
            this.groupBox_Url.Controls.Add(this.label_lanhttps);
            this.groupBox_Url.Controls.Add(this.label_lanHttp);
            this.groupBox_Url.Controls.Add(this.label_subDomain);
            this.groupBox_Url.Location = new System.Drawing.Point(6, 171);
            this.groupBox_Url.Name = "groupBox_Url";
            this.groupBox_Url.Size = new System.Drawing.Size(273, 140);
            this.groupBox_Url.TabIndex = 2;
            this.groupBox_Url.TabStop = false;
            this.groupBox_Url.Text = "内网端Ngrok";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(40, 317);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(156, 317);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(80, 23);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_NgrokDomain
            // 
            this.label_NgrokDomain.AutoSize = true;
            this.label_NgrokDomain.Location = new System.Drawing.Point(9, 22);
            this.label_NgrokDomain.Name = "label_NgrokDomain";
            this.label_NgrokDomain.Size = new System.Drawing.Size(35, 12);
            this.label_NgrokDomain.TabIndex = 0;
            this.label_NgrokDomain.Text = "域名:";
            // 
            // label_tunnelAddr
            // 
            this.label_tunnelAddr.AutoSize = true;
            this.label_tunnelAddr.Location = new System.Drawing.Point(9, 47);
            this.label_tunnelAddr.Name = "label_tunnelAddr";
            this.label_tunnelAddr.Size = new System.Drawing.Size(59, 12);
            this.label_tunnelAddr.TabIndex = 1;
            this.label_tunnelAddr.Text = "侦听端口:";
            // 
            // label_Defaultport
            // 
            this.label_Defaultport.AutoSize = true;
            this.label_Defaultport.Location = new System.Drawing.Point(9, 73);
            this.label_Defaultport.Name = "label_Defaultport";
            this.label_Defaultport.Size = new System.Drawing.Size(83, 12);
            this.label_Defaultport.TabIndex = 2;
            this.label_Defaultport.Text = "默认服务端口:";
            // 
            // label_http
            // 
            this.label_http.AutoSize = true;
            this.label_http.Location = new System.Drawing.Point(89, 73);
            this.label_http.Name = "label_http";
            this.label_http.Size = new System.Drawing.Size(29, 12);
            this.label_http.TabIndex = 3;
            this.label_http.Text = "http";
            // 
            // label_https
            // 
            this.label_https.AutoSize = true;
            this.label_https.Location = new System.Drawing.Point(174, 73);
            this.label_https.Name = "label_https";
            this.label_https.Size = new System.Drawing.Size(35, 12);
            this.label_https.TabIndex = 4;
            this.label_https.Text = "https";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 21);
            this.textBox1.TabIndex = 5;
            // 
            // textBox_tunnelAddr
            // 
            this.textBox_tunnelAddr.Location = new System.Drawing.Point(72, 43);
            this.textBox_tunnelAddr.Name = "textBox_tunnelAddr";
            this.textBox_tunnelAddr.Size = new System.Drawing.Size(50, 21);
            this.textBox_tunnelAddr.TabIndex = 6;
            this.textBox_tunnelAddr.Text = "8083";
            // 
            // textBox_httpAddr
            // 
            this.textBox_httpAddr.Location = new System.Drawing.Point(120, 70);
            this.textBox_httpAddr.Name = "textBox_httpAddr";
            this.textBox_httpAddr.Size = new System.Drawing.Size(50, 21);
            this.textBox_httpAddr.TabIndex = 7;
            this.textBox_httpAddr.Text = "8081";
            // 
            // textBox_httpsAddr
            // 
            this.textBox_httpsAddr.Location = new System.Drawing.Point(211, 70);
            this.textBox_httpsAddr.Name = "textBox_httpsAddr";
            this.textBox_httpsAddr.Size = new System.Drawing.Size(50, 21);
            this.textBox_httpsAddr.TabIndex = 8;
            this.textBox_httpsAddr.Text = "8082";
            // 
            // label_subDomain
            // 
            this.label_subDomain.AutoSize = true;
            this.label_subDomain.Location = new System.Drawing.Point(9, 18);
            this.label_subDomain.Name = "label_subDomain";
            this.label_subDomain.Size = new System.Drawing.Size(53, 12);
            this.label_subDomain.TabIndex = 0;
            this.label_subDomain.Text = "次级域名";
            // 
            // label_lanHttp
            // 
            this.label_lanHttp.AutoSize = true;
            this.label_lanHttp.Location = new System.Drawing.Point(84, 18);
            this.label_lanHttp.Name = "label_lanHttp";
            this.label_lanHttp.Size = new System.Drawing.Size(77, 12);
            this.label_lanHttp.TabIndex = 1;
            this.label_lanHttp.Text = "http服务端口";
            // 
            // label_lanhttps
            // 
            this.label_lanhttps.AutoSize = true;
            this.label_lanhttps.Location = new System.Drawing.Point(178, 18);
            this.label_lanhttps.Name = "label_lanhttps";
            this.label_lanhttps.Size = new System.Drawing.Size(83, 12);
            this.label_lanhttps.TabIndex = 2;
            this.label_lanhttps.Text = "https服务端口";
            // 
            // textBox_subDomain
            // 
            this.textBox_subDomain.Location = new System.Drawing.Point(10, 37);
            this.textBox_subDomain.Name = "textBox_subDomain";
            this.textBox_subDomain.Size = new System.Drawing.Size(50, 21);
            this.textBox_subDomain.TabIndex = 3;
            this.textBox_subDomain.Text = "web";
            // 
            // textBox_lanHttp
            // 
            this.textBox_lanHttp.Location = new System.Drawing.Point(96, 37);
            this.textBox_lanHttp.Name = "textBox_lanHttp";
            this.textBox_lanHttp.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanHttp.TabIndex = 4;
            this.textBox_lanHttp.Text = "80";
            // 
            // textBox_Https
            // 
            this.textBox_Https.Location = new System.Drawing.Point(191, 37);
            this.textBox_Https.Name = "textBox_Https";
            this.textBox_Https.Size = new System.Drawing.Size(50, 21);
            this.textBox_Https.TabIndex = 5;
            this.textBox_Https.Text = "80";
            // 
            // label_lanTcp
            // 
            this.label_lanTcp.AutoSize = true;
            this.label_lanTcp.Location = new System.Drawing.Point(12, 65);
            this.label_lanTcp.Name = "label_lanTcp";
            this.label_lanTcp.Size = new System.Drawing.Size(47, 12);
            this.label_lanTcp.TabIndex = 6;
            this.label_lanTcp.Text = "TCP穿透";
            // 
            // label_remoteport
            // 
            this.label_remoteport.AutoSize = true;
            this.label_remoteport.Location = new System.Drawing.Point(96, 65);
            this.label_remoteport.Name = "label_remoteport";
            this.label_remoteport.Size = new System.Drawing.Size(53, 12);
            this.label_remoteport.TabIndex = 7;
            this.label_remoteport.Text = "远程端口";
            // 
            // label_lanport
            // 
            this.label_lanport.AutoSize = true;
            this.label_lanport.Location = new System.Drawing.Point(180, 65);
            this.label_lanport.Name = "label_lanport";
            this.label_lanport.Size = new System.Drawing.Size(77, 12);
            this.label_lanport.TabIndex = 8;
            this.label_lanport.Text = "内网服务端口";
            // 
            // textBox_lanTunnel1
            // 
            this.textBox_lanTunnel1.Location = new System.Drawing.Point(10, 85);
            this.textBox_lanTunnel1.Name = "textBox_lanTunnel1";
            this.textBox_lanTunnel1.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanTunnel1.TabIndex = 9;
            this.textBox_lanTunnel1.Text = "ssh";
            // 
            // textBox_remotePort1
            // 
            this.textBox_remotePort1.Location = new System.Drawing.Point(96, 85);
            this.textBox_remotePort1.Name = "textBox_remotePort1";
            this.textBox_remotePort1.Size = new System.Drawing.Size(50, 21);
            this.textBox_remotePort1.TabIndex = 10;
            this.textBox_remotePort1.Text = "2222";
            // 
            // textBox_lanPort1
            // 
            this.textBox_lanPort1.Location = new System.Drawing.Point(191, 85);
            this.textBox_lanPort1.Name = "textBox_lanPort1";
            this.textBox_lanPort1.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanPort1.TabIndex = 11;
            this.textBox_lanPort1.Text = "22";
            // 
            // textBox_lanTunnel2
            // 
            this.textBox_lanTunnel2.Location = new System.Drawing.Point(10, 113);
            this.textBox_lanTunnel2.Name = "textBox_lanTunnel2";
            this.textBox_lanTunnel2.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanTunnel2.TabIndex = 12;
            this.textBox_lanTunnel2.Text = "ftp";
            // 
            // textBox_remotePort2
            // 
            this.textBox_remotePort2.Location = new System.Drawing.Point(96, 113);
            this.textBox_remotePort2.Name = "textBox_remotePort2";
            this.textBox_remotePort2.Size = new System.Drawing.Size(50, 21);
            this.textBox_remotePort2.TabIndex = 13;
            this.textBox_remotePort2.Text = "2221";
            // 
            // textBox_lanPort2
            // 
            this.textBox_lanPort2.Location = new System.Drawing.Point(191, 112);
            this.textBox_lanPort2.Name = "textBox_lanPort2";
            this.textBox_lanPort2.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanPort2.TabIndex = 14;
            this.textBox_lanPort2.Text = "21";
            // 
            // Form_ngrok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 346);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox_Url);
            this.Controls.Add(this.groupBox_Ngrokserver);
            this.Controls.Add(this.groupBox_AuthToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ngrok";
            this.Text = "Ngrok设置";
            this.groupBox_AuthToken.ResumeLayout(false);
            this.groupBox_AuthToken.PerformLayout();
            this.groupBox_Ngrokserver.ResumeLayout(false);
            this.groupBox_Ngrokserver.PerformLayout();
            this.groupBox_Url.ResumeLayout(false);
            this.groupBox_Url.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_AuthToken;
        private System.Windows.Forms.GroupBox groupBox_Ngrokserver;
        private System.Windows.Forms.GroupBox groupBox_Url;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_AuthToken;
        private System.Windows.Forms.TextBox textBox_httpsAddr;
        private System.Windows.Forms.TextBox textBox_httpAddr;
        private System.Windows.Forms.TextBox textBox_tunnelAddr;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_https;
        private System.Windows.Forms.Label label_http;
        private System.Windows.Forms.Label label_Defaultport;
        private System.Windows.Forms.Label label_tunnelAddr;
        private System.Windows.Forms.Label label_NgrokDomain;
        private System.Windows.Forms.TextBox textBox_Https;
        private System.Windows.Forms.TextBox textBox_lanHttp;
        private System.Windows.Forms.TextBox textBox_subDomain;
        private System.Windows.Forms.Label label_lanhttps;
        private System.Windows.Forms.Label label_lanHttp;
        private System.Windows.Forms.Label label_subDomain;
        private System.Windows.Forms.TextBox textBox_lanPort2;
        private System.Windows.Forms.TextBox textBox_remotePort2;
        private System.Windows.Forms.TextBox textBox_lanTunnel2;
        private System.Windows.Forms.TextBox textBox_lanPort1;
        private System.Windows.Forms.TextBox textBox_remotePort1;
        private System.Windows.Forms.TextBox textBox_lanTunnel1;
        private System.Windows.Forms.Label label_lanport;
        private System.Windows.Forms.Label label_remoteport;
        private System.Windows.Forms.Label label_lanTcp;
    }
}