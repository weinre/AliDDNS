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
            this.textBox_serverAddr = new System.Windows.Forms.TextBox();
            this.label_NgrokDomain = new System.Windows.Forms.Label();
            this.groupBox_Url = new System.Windows.Forms.GroupBox();
            this.textBox_lanPort2 = new System.Windows.Forms.TextBox();
            this.textBox_remotePort2 = new System.Windows.Forms.TextBox();
            this.textBox_lanPort1 = new System.Windows.Forms.TextBox();
            this.label_lanport = new System.Windows.Forms.Label();
            this.label_remoteport = new System.Windows.Forms.Label();
            this.label_tunnels = new System.Windows.Forms.Label();
            this.textBox_lanHttp = new System.Windows.Forms.TextBox();
            this.textBox_subDomain = new System.Windows.Forms.TextBox();
            this.label_lanHttp = new System.Windows.Forms.Label();
            this.label_subDomain = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_remotePort1 = new System.Windows.Forms.TextBox();
            this.label_tunnel1 = new System.Windows.Forms.Label();
            this.label_tunnel2 = new System.Windows.Forms.Label();
            this.label_tunnel3 = new System.Windows.Forms.Label();
            this.textBox_remotePort3 = new System.Windows.Forms.TextBox();
            this.textBox_lanPort3 = new System.Windows.Forms.TextBox();
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
            this.groupBox_Ngrokserver.Controls.Add(this.textBox_serverAddr);
            this.groupBox_Ngrokserver.Controls.Add(this.label_NgrokDomain);
            this.groupBox_Ngrokserver.Location = new System.Drawing.Point(6, 68);
            this.groupBox_Ngrokserver.Name = "groupBox_Ngrokserver";
            this.groupBox_Ngrokserver.Size = new System.Drawing.Size(273, 48);
            this.groupBox_Ngrokserver.TabIndex = 1;
            this.groupBox_Ngrokserver.TabStop = false;
            this.groupBox_Ngrokserver.Text = "服务端Ngrokd";
            // 
            // textBox_serverAddr
            // 
            this.textBox_serverAddr.Location = new System.Drawing.Point(50, 18);
            this.textBox_serverAddr.Name = "textBox_serverAddr";
            this.textBox_serverAddr.Size = new System.Drawing.Size(211, 21);
            this.textBox_serverAddr.TabIndex = 5;
            // 
            // label_NgrokDomain
            // 
            this.label_NgrokDomain.AutoSize = true;
            this.label_NgrokDomain.Location = new System.Drawing.Point(11, 21);
            this.label_NgrokDomain.Name = "label_NgrokDomain";
            this.label_NgrokDomain.Size = new System.Drawing.Size(35, 12);
            this.label_NgrokDomain.TabIndex = 0;
            this.label_NgrokDomain.Text = "地址:";
            // 
            // groupBox_Url
            // 
            this.groupBox_Url.Controls.Add(this.textBox_lanPort3);
            this.groupBox_Url.Controls.Add(this.textBox_remotePort3);
            this.groupBox_Url.Controls.Add(this.label_tunnel3);
            this.groupBox_Url.Controls.Add(this.label_tunnel2);
            this.groupBox_Url.Controls.Add(this.label_tunnel1);
            this.groupBox_Url.Controls.Add(this.textBox_lanPort2);
            this.groupBox_Url.Controls.Add(this.textBox_remotePort2);
            this.groupBox_Url.Controls.Add(this.textBox_lanPort1);
            this.groupBox_Url.Controls.Add(this.textBox_remotePort1);
            this.groupBox_Url.Controls.Add(this.label_lanport);
            this.groupBox_Url.Controls.Add(this.label_remoteport);
            this.groupBox_Url.Controls.Add(this.label_tunnels);
            this.groupBox_Url.Controls.Add(this.textBox_lanHttp);
            this.groupBox_Url.Controls.Add(this.textBox_subDomain);
            this.groupBox_Url.Controls.Add(this.label_lanHttp);
            this.groupBox_Url.Controls.Add(this.label_subDomain);
            this.groupBox_Url.Location = new System.Drawing.Point(6, 123);
            this.groupBox_Url.Name = "groupBox_Url";
            this.groupBox_Url.Size = new System.Drawing.Size(273, 170);
            this.groupBox_Url.TabIndex = 2;
            this.groupBox_Url.TabStop = false;
            this.groupBox_Url.Text = "内网端Ngrok";
            // 
            // textBox_lanPort2
            // 
            this.textBox_lanPort2.Location = new System.Drawing.Point(191, 112);
            this.textBox_lanPort2.Name = "textBox_lanPort2";
            this.textBox_lanPort2.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanPort2.TabIndex = 14;
            // 
            // textBox_remotePort2
            // 
            this.textBox_remotePort2.Location = new System.Drawing.Point(96, 112);
            this.textBox_remotePort2.Name = "textBox_remotePort2";
            this.textBox_remotePort2.Size = new System.Drawing.Size(50, 21);
            this.textBox_remotePort2.TabIndex = 13;
            // 
            // textBox_lanPort1
            // 
            this.textBox_lanPort1.Location = new System.Drawing.Point(191, 85);
            this.textBox_lanPort1.Name = "textBox_lanPort1";
            this.textBox_lanPort1.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanPort1.TabIndex = 11;
            // 
            // label_lanport
            // 
            this.label_lanport.AutoSize = true;
            this.label_lanport.Location = new System.Drawing.Point(178, 65);
            this.label_lanport.Name = "label_lanport";
            this.label_lanport.Size = new System.Drawing.Size(77, 12);
            this.label_lanport.TabIndex = 8;
            this.label_lanport.Text = "内网服务端口";
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
            // label_tunnels
            // 
            this.label_tunnels.AutoSize = true;
            this.label_tunnels.Location = new System.Drawing.Point(12, 65);
            this.label_tunnels.Name = "label_tunnels";
            this.label_tunnels.Size = new System.Drawing.Size(71, 12);
            this.label_tunnels.TabIndex = 6;
            this.label_tunnels.Text = "TCP穿透服务";
            // 
            // textBox_lanHttp
            // 
            this.textBox_lanHttp.Location = new System.Drawing.Point(96, 37);
            this.textBox_lanHttp.Name = "textBox_lanHttp";
            this.textBox_lanHttp.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanHttp.TabIndex = 4;
            // 
            // textBox_subDomain
            // 
            this.textBox_subDomain.Location = new System.Drawing.Point(20, 37);
            this.textBox_subDomain.Name = "textBox_subDomain";
            this.textBox_subDomain.Size = new System.Drawing.Size(50, 21);
            this.textBox_subDomain.TabIndex = 3;
            // 
            // label_lanHttp
            // 
            this.label_lanHttp.AutoSize = true;
            this.label_lanHttp.Location = new System.Drawing.Point(80, 18);
            this.label_lanHttp.Name = "label_lanHttp";
            this.label_lanHttp.Size = new System.Drawing.Size(89, 12);
            this.label_lanHttp.TabIndex = 1;
            this.label_lanHttp.Text = "http/s服务端口";
            // 
            // label_subDomain
            // 
            this.label_subDomain.AutoSize = true;
            this.label_subDomain.Location = new System.Drawing.Point(19, 18);
            this.label_subDomain.Name = "label_subDomain";
            this.label_subDomain.Size = new System.Drawing.Size(53, 12);
            this.label_subDomain.TabIndex = 0;
            this.label_subDomain.Text = "次级域名";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(40, 299);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(156, 299);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(80, 23);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_remotePort1
            // 
            this.textBox_remotePort1.Location = new System.Drawing.Point(96, 85);
            this.textBox_remotePort1.Name = "textBox_remotePort1";
            this.textBox_remotePort1.Size = new System.Drawing.Size(50, 21);
            this.textBox_remotePort1.TabIndex = 10;
            // 
            // label_tunnel1
            // 
            this.label_tunnel1.AutoSize = true;
            this.label_tunnel1.Location = new System.Drawing.Point(17, 88);
            this.label_tunnel1.Name = "label_tunnel1";
            this.label_tunnel1.Size = new System.Drawing.Size(53, 12);
            this.label_tunnel1.TabIndex = 15;
            this.label_tunnel1.Text = "Tunnel1:";
            // 
            // label_tunnel2
            // 
            this.label_tunnel2.AutoSize = true;
            this.label_tunnel2.Location = new System.Drawing.Point(17, 115);
            this.label_tunnel2.Name = "label_tunnel2";
            this.label_tunnel2.Size = new System.Drawing.Size(53, 12);
            this.label_tunnel2.TabIndex = 16;
            this.label_tunnel2.Text = "Tunnel2:";
            // 
            // label_tunnel3
            // 
            this.label_tunnel3.AutoSize = true;
            this.label_tunnel3.Location = new System.Drawing.Point(17, 142);
            this.label_tunnel3.Name = "label_tunnel3";
            this.label_tunnel3.Size = new System.Drawing.Size(53, 12);
            this.label_tunnel3.TabIndex = 17;
            this.label_tunnel3.Text = "Tunnel3:";
            // 
            // textBox_remotePort3
            // 
            this.textBox_remotePort3.Location = new System.Drawing.Point(96, 140);
            this.textBox_remotePort3.Name = "textBox_remotePort3";
            this.textBox_remotePort3.Size = new System.Drawing.Size(50, 21);
            this.textBox_remotePort3.TabIndex = 18;
            // 
            // textBox_lanPort3
            // 
            this.textBox_lanPort3.Location = new System.Drawing.Point(191, 140);
            this.textBox_lanPort3.Name = "textBox_lanPort3";
            this.textBox_lanPort3.Size = new System.Drawing.Size(50, 21);
            this.textBox_lanPort3.TabIndex = 19;
            // 
            // Form_ngrok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 330);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox_Url);
            this.Controls.Add(this.groupBox_Ngrokserver);
            this.Controls.Add(this.groupBox_AuthToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ngrok";
            this.Text = "Ngrok设置";
            this.Shown += new System.EventHandler(this.Form_ngrok_Shown);
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
        private System.Windows.Forms.TextBox textBox_serverAddr;
        private System.Windows.Forms.Label label_NgrokDomain;
        private System.Windows.Forms.TextBox textBox_lanHttp;
        private System.Windows.Forms.TextBox textBox_subDomain;
        private System.Windows.Forms.Label label_lanHttp;
        private System.Windows.Forms.Label label_subDomain;
        private System.Windows.Forms.TextBox textBox_lanPort2;
        private System.Windows.Forms.TextBox textBox_remotePort2;
        private System.Windows.Forms.TextBox textBox_lanPort1;
        private System.Windows.Forms.Label label_lanport;
        private System.Windows.Forms.Label label_remoteport;
        private System.Windows.Forms.Label label_tunnels;
        private System.Windows.Forms.TextBox textBox_remotePort1;
        private System.Windows.Forms.TextBox textBox_lanPort3;
        private System.Windows.Forms.TextBox textBox_remotePort3;
        private System.Windows.Forms.Label label_tunnel3;
        private System.Windows.Forms.Label label_tunnel2;
        private System.Windows.Forms.Label label_tunnel1;
    }
}