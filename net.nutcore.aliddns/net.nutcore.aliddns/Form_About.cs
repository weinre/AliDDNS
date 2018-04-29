using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace net.nutcore.aliddns
{
    public partial class Form_About : Form
    {
        public Form_About()
        {

            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
            label_currentVer.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); //获取当前版本
            if (mainForm.checkUpdate == true)
            {
                checkBox_autoCheckUpdate.Checked = true;
                //获取远程版本信息
                /*
                string strUrl = "https://api.github.com/respo/wisdomwei201804/AliDDNS/releases/latest"; //从控件获取WAN口IP查询网址，默认值为："http://whatismyip.akamai.com/";
                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);
                Stream s = webreq.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd();*/

                try
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    HttpContent httpContent = new StringContent("");
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    httpContent.Headers.ContentType.CharSet = "utf-8";
                    httpContent.Headers.Add("token", "11111111111");
                    // httpContent.Headers.Add("appId", appId);
                    //httpContent.Headers.Add("serviceURL", serviceURL);
                    HttpClient httpClient = new HttpClient();
                    //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");
                    HttpResponseMessage response = httpClient.PostAsync("https://api.github.com/respo/wisdomwei201804/AliDDNS/releases/latest", httpContent).Result;
                    //statusCode = response.StatusCode.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                       // return result;
                    }
                }
                catch( Exception error)
                {
                    MessageBox.Show(error.ToString());
                }

            }
            else checkBox_autoCheckUpdate.Checked = false;
            textBox_updateInfo.ReadOnly = true;
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string updateInfoFile = filePath + "updateinfo.txt";
            if (File.Exists(updateInfoFile))
                textBox_updateInfo.Text = File.ReadAllText(updateInfoFile, Encoding.Default);
            else
                textBox_updateInfo.Text = "软件运行目录下没有找到updateinfo.txt文件！";
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
            string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string config_file = ExePath + "aliddns_config.xml";
            if(File.Exists(config_file))
            {
                XmlDocument xmlDOC = new XmlDocument();
                xmlDOC.Load(config_file);
                if (xmlDOC.GetElementsByTagName("autoCheckUpdate")[0] == null)
                {
                    XmlNode node = xmlDOC.CreateNode(XmlNodeType.Element, "autoCheckUpdate",null);
                    if (checkBox_autoCheckUpdate.Checked == true)
                        node.InnerText = "On";
                    else
                        node.InnerText = "Off";
                    xmlDOC.DocumentElement.AppendChild(node);
                    xmlDOC.Save(config_file);
                }
                else
                {
                    XmlNode node = xmlDOC.GetElementsByTagName("autoCheckUpdate")[0];
                    if (checkBox_autoCheckUpdate.Checked == true)
                        node.InnerText = "On";
                    else
                        node.InnerText = "Off";
                    xmlDOC.DocumentElement.AppendChild(node);
                    xmlDOC.Save(config_file);
                }
            }
            /*
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = config_file;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            if(checkBox_autoCheckUpdate.Checked == true)
            {
                if (config.AppSettings.Settings["autoCheckUpdate"] == null)
                {
                    config.AppSettings.Settings.Add("autoCheckUpdate", "On");
                }
                else
                {
                    config.AppSettings.Settings["autoCheckUpdate"].Value = "On";
                }
            }
            else
            {
                if (config.AppSettings.Settings["autoCheckUpdate"] == null)
                {
                    config.AppSettings.Settings.Add("autoCheckUpdate", "Off");
                }
                else
                {
                    config.AppSettings.Settings["autoCheckUpdate"].Value = "Off";
                }
            }
            config.Save();
            */
        }
    }
}
