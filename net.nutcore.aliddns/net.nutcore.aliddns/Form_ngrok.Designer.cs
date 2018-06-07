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
            this.groupBox_ProtocolPort = new System.Windows.Forms.GroupBox();
            this.groupBox_Url = new System.Windows.Forms.GroupBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_AuthToken = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_NgrokDownloadUrl = new System.Windows.Forms.TextBox();
            this.groupBox_AuthToken.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // groupBox_ProtocolPort
            // 
            this.groupBox_ProtocolPort.Location = new System.Drawing.Point(6, 68);
            this.groupBox_ProtocolPort.Name = "groupBox_ProtocolPort";
            this.groupBox_ProtocolPort.Size = new System.Drawing.Size(273, 65);
            this.groupBox_ProtocolPort.TabIndex = 1;
            this.groupBox_ProtocolPort.TabStop = false;
            this.groupBox_ProtocolPort.Text = "协议端口";
            // 
            // groupBox_Url
            // 
            this.groupBox_Url.Location = new System.Drawing.Point(6, 139);
            this.groupBox_Url.Name = "groupBox_Url";
            this.groupBox_Url.Size = new System.Drawing.Size(273, 90);
            this.groupBox_Url.TabIndex = 2;
            this.groupBox_Url.TabStop = false;
            this.groupBox_Url.Text = "访问域名";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(40, 291);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(80, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(156, 291);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(80, 23);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_AuthToken
            // 
            this.textBox_AuthToken.Location = new System.Drawing.Point(11, 21);
            this.textBox_AuthToken.Name = "textBox_AuthToken";
            this.textBox_AuthToken.Size = new System.Drawing.Size(250, 21);
            this.textBox_AuthToken.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_NgrokDownloadUrl);
            this.groupBox1.Location = new System.Drawing.Point(6, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 50);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ngrok下载地址";
            // 
            // textBox_NgrokDownloadUrl
            // 
            this.textBox_NgrokDownloadUrl.Location = new System.Drawing.Point(11, 22);
            this.textBox_NgrokDownloadUrl.Name = "textBox_NgrokDownloadUrl";
            this.textBox_NgrokDownloadUrl.Size = new System.Drawing.Size(250, 21);
            this.textBox_NgrokDownloadUrl.TabIndex = 0;
            this.textBox_NgrokDownloadUrl.Text = "https://ngrok.com/download";
            // 
            // Form_ngrok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 319);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.groupBox_Url);
            this.Controls.Add(this.groupBox_ProtocolPort);
            this.Controls.Add(this.groupBox_AuthToken);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ngrok";
            this.Text = "Ngrok设置";
            this.groupBox_AuthToken.ResumeLayout(false);
            this.groupBox_AuthToken.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_AuthToken;
        private System.Windows.Forms.GroupBox groupBox_ProtocolPort;
        private System.Windows.Forms.GroupBox groupBox_Url;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_AuthToken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_NgrokDownloadUrl;
    }
}