using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Http;

namespace net.nutcore.aliddns
{
    public partial class Form_About : Form
    {
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
                try
                {
                    string strUrl = "https://github.com/wisdomwei201804/AliDDNS/releases/latest";
                    if (strUrl.StartsWith("https"))
                        System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls1.2 | SecurityProtocolType.Tls12;
                    HttpClient httpClient = new HttpClient(
                        new HttpClientHandler
                        {
                            //CookieContainer = cookies,
                            AutomaticDecompression = DecompressionMethods.GZip //防止返回的json乱码
                                                   | DecompressionMethods.Deflate
                        });
                    httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/4.0(compatible;MSIE6.0;WindowsNT5.1)");
                    httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8,en-US;q=0.6,en;q=0.4");
                    httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, sdch");
                    httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/x-www-form-urlencoded,application/xhtml+xml,application/json,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("UTF-8"));
                    HttpResponseMessage response = httpClient.GetAsync(strUrl).Result;
                    //var statusCode = response.StatusCode.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        string ver = System.Text.RegularExpressions.Regex.Match(result, @"""tag_name"":""([^""]*)""").Groups[1].Value;
                        label_latestVer.Text = ver.ToString();
                        //MessageBox.Show(ver);
                        //return result;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }

            }
            else checkBox_autoCheckUpdate.Checked = false;
        }
    }
}
