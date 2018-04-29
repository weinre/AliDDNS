using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace net.nutcore.aliddns
{
    public partial class Form_About : Form
    {
        public static bool RemoteCertificateValidationCallback(Object sender,
           X509Certificate certificate,
           X509Chain chain,
           SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
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
                try
                {

                    string strUrl = "https://api.github.com/wisdomwei201804/AliDDNS/releases/latest"; //从控件获取WAN口IP查询网址，默认值为："http://whatismyip.akamai.com/";
                    Uri uri = new Uri(strUrl);
                    if (strUrl.StartsWith("https"))
                        System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    WebRequest webreq = WebRequest.Create(uri);
                    Stream s = webreq.GetResponse().GetResponseStream();
                    StreamReader sr = new StreamReader(s, Encoding.Default);
                    string all = sr.ReadToEnd();
                    MessageBox.Show(all.ToString());
                }
                /*try
                {
                    string strUrl = "https://github.com/wisdomwei201804/AliDDNS/releases/latest";
                    if(strUrl.StartsWith("https"))
                        System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls1.2 | SecurityProtocolType.Tls12;
                    HttpClient httpClient = new HttpClient();
                    HttpContent httpContent = new StringContent("Authorization: token 7e5aaa4649a6bdb9d5459abd221ef15ec484da79");
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    httpContent.Headers.ContentType.CharSet = "utf-8";
                    //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                    //httpContent.Headers.Add("token", "7e5aaa4649a6bdb9d5459abd221ef15ec484da79");
                    // httpContent.Headers.Add("appId", appId);
                    //httpContent.Headers.Add("serviceURL", serviceURL);

                    //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    //httpClient..setParameter(HttpMethodParams.HTTP_CONTENT_CHARSET, "utf-8");
                    HttpResponseMessage response = httpClient.PostAsync(strUrl, httpContent).Result;
                    //statusCode = response.StatusCode.ToString();
                   // if (response.IsSuccessStatusCode)
                    //{
                        string result = response.Content.ReadAsStringAsync().Result;
                        MessageBox.Show(result.ToString());
                       // return result;
                    //}
                }*/
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
