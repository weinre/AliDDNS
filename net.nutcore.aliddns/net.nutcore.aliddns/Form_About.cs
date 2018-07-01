using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace net.nutcore.aliddns
{
    public partial class Form_About : Form
    {
        private AppConfigHelper cfg = new AppConfigHelper();
        public Form_About()
        {

            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
            
        }

        private void PublishLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/wisdomwei201804/AliDDNS/");
        }

        private void personalWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://www.nutcore.net/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://bbs.aliyun.com/read/289624.html");
        }

        private void checkBox_autoCheckUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_autoCheckUpdate.Checked == true)
            {
                cfg.SaveAppSetting("autoCheckUpdate", "On");
                //mainForm.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件自动检测升级启用！" + "\r\n");
            }
            else
            {
                cfg.SaveAppSetting("autoCheckUpdate", "Off");
                //mainForm.textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件自动检测升级关闭！" + "\r\n");
            }
           
        }

        private void Form_About_Load(object sender, EventArgs e)
        {
            //读取updateinfo.txt文件
            textBox_updateInfo.ReadOnly = true;
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string updateInfoFile = filePath + "updateinfo.txt";
            if (File.Exists(updateInfoFile))
                textBox_updateInfo.Text = File.ReadAllText(updateInfoFile, Encoding.Default);
            else
                textBox_updateInfo.Text = "软件运行目录下没有找到updateinfo.txt文件！";
            
            //版本检查
            label_currentVer.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //获取当前版本
            if (mainForm.checkUpdate == true)
            {
                checkBox_autoCheckUpdate.Checked = true;
                //获取远程版本信息
                string strVer = mainForm.verCheckUpdate();
                label_latestVer.Text = strVer.ToString();
            }
            else checkBox_autoCheckUpdate.Checked = false;
        }
    }
}
