using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using static Aliyun.Acs.Alidns.Model.V20150109.DescribeSubDomainRecordsResponse;

namespace net.nutcore.aliddns
{
    public partial class mainForm : Form
    {
        static IClientProfile clientProfile;
        static DefaultAcsClient client;

        public mainForm()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try //检查设置文件，如果没有则新建，并赋值默认值
            {
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                if (File.Exists(config_file) != true) //当设置文件aliddns_config.xml不存在时，创建一个新的。
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "没有找到设置文件 aliddns_config.xml，重新创建！" + "\r\n");
                    if (saveConfigFile())
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件 aliddns_config.xml 创建成功！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件设置项目默认赋值完成！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请填写正确内容，点击“测试并保存”完成设置！" + "\r\n");
                    }
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息：" + error + "\r\n");
                this.Dispose();
            }
            
            //读取设置文件config.xml
            readConfigFile();
            //窗体根据参数判断是否最小化驻留系统托盘
            if (checkBox_minimized.Checked == true)
            {
                this.ShowInTaskbar = false; //从状态栏清除
                this.WindowState = FormWindowState.Minimized; //窗体最小化
                this.Hide(); //窗体隐藏
            }
            else if (checkBox_minimized.Checked == false)
            {
                this.Show(); //窗体显示
                this.WindowState = FormWindowState.Normal; //窗体正常化
                this.ShowInTaskbar = true; //从状态栏显示
            }
                
            try //获取WAN口IP
            {
                localIP.Text = getLocalIP();
            }
            catch (Exception)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败！" + "\r\n");
            }

            try //获取域名绑定IP
            {
                clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text, accessKeySecret.Text);
                client = new DefaultAcsClient(clientProfile);
                domainIP.Text = getDomainIP();
            }
            catch (Exception)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名和绑定IP失败，请检查设置项目内容和网络状态！" + "\r\n");
            }
            if (localIP.Text == domainIP.Text) //如果WAN口IP与域名绑定IP一致，刷新系统托盘图标
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
        }

        private void readConfigFile()
        {
            try
            {
                //Create xml object
                XmlDocument xmlDOC = new XmlDocument();
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                xmlDOC.Load(config_file);
                XmlNodeReader readXML = new XmlNodeReader(xmlDOC);
                XmlNodeList nodes = xmlDOC.SelectSingleNode("Config").ChildNodes; //读取config节点下所有元素
                /*
                for (int i = 0; i < nodes.Count; i++)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + nodes[i].Name + ":" + nodes[i].InnerText + "\r\n"); //显示读取内容，用于调试DEBUG。
                }
                string[] config = new string[nodes.Count]; //创建一个设置读取数组用于存储读取内容
                int i = 0;
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件找到，开始读取..." + "\r\n");
                while (readXML.Read())
                {
                    readXML.MoveToElement(); //Forward
                    if (readXML.NodeType == XmlNodeType.Text) //(node.NodeType 是Text时，即是最内层 即innertext值，node.Attributes为null。
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + readXML.NodeType + "\r\n"); //显示读取内容，用于调试DEBUG。
                        config[i] = readXML.Value;
                        //此行用于调试读取内容
                        //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "项目[" + i + "]: " + config[i] + "\r\n"); //显示读取内容，用于调试DEBUG。
                        i++;
                    }
                }*/
                accessKeyId.Text = nodes[0].InnerText;
                accessKeySecret.Text = nodes[1].InnerText;
                recordId.Text = nodes[2].InnerText;
                fullDomainName.Text = nodes[3].InnerText;
                label_nextUpdateSeconds.Text = newSeconds.Text = nodes[4].InnerText;
                if (nodes[5].InnerText == "On") checkBox_autoUpdate.Checked = true;
                else checkBox_autoUpdate.Checked = false;
                //if ( config[5] == "On" ) autoUpdateOn.Checked = true;
                //if ( config[5] == "Off ") autoUpdateOff.Checked = true;
                comboBox_whatIsUrl.Text = nodes[6].InnerText;
                if (nodes[7].InnerText == "On") checkBox_autoBoot.Checked = true;
                else checkBox_autoBoot.Checked = false;
                if (nodes[8].InnerText == "On") checkBox_minimized.Checked = true;
                else checkBox_minimized.Checked = false;
                if (nodes[9].InnerText == "On")
                    checkBox_logAutoSave.Checked = true;
                else
                    checkBox_logAutoSave.Checked = false;

                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件读取成功！" + "\r\n");
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }

        }

        private bool saveConfigFile()
        {
            try
            {
                if (accessKeyId.Text == "" || accessKeySecret.Text == "" || recordId.Text == "" || fullDomainName.Text == "" || newSeconds.Text == "" || comboBox_whatIsUrl.Text == "")
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "任何值都不能为空！无法填写请输入null或0！" + "\r\n");
                    return false;
                }
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string config_file = ExePath + "aliddns_config.xml";
                XmlTextWriter textWriter = new XmlTextWriter(config_file, null);
                textWriter.WriteStartDocument(); //文档开始

                textWriter.WriteComment("AlidnsAutoCheckTool");
                textWriter.WriteComment("Version:Beta 1.0");
                //Start config file
                textWriter.WriteStartElement("Config"); //设置项目开始

                textWriter.WriteStartElement("AccessKeyID", "");
                textWriter.WriteString(accessKeyId.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("AccessKeySecret", "");
                textWriter.WriteString(accessKeySecret.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("RecordID", "");
                textWriter.WriteString(recordId.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("fullDomainName", "");
                textWriter.WriteString(fullDomainName.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("WaitingTime", "");
                textWriter.WriteString(newSeconds.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("autoUpdate", "");
                if (checkBox_autoUpdate.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                /*if (autoUpdateOn.Checked == true)
                    textWriter.WriteString("On");
                if (autoUpdateOff.Checked)
                    textWriter.WriteString("Off");*/
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("whatIsUrl", "");
                textWriter.WriteString(comboBox_whatIsUrl.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("autoBoot", "");
                if (checkBox_autoBoot.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("minimized", "");
                if (checkBox_minimized.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("logautosave", "");
                if (checkBox_logAutoSave.Checked == true)
                    textWriter.WriteString("On");
                else
                    textWriter.WriteString("Off");
                textWriter.WriteEndElement();

                textWriter.WriteEndElement(); //设置项目结束
                textWriter.WriteEndDocument();//文档结束
                textWriter.Close(); //文档保存关闭

                label_nextUpdateSeconds.Text = newSeconds.Text;

                return true;
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                return false;
            }

        }

        private string getLocalIP()
        {
            try
            {
                string strUrl = comboBox_whatIsUrl.Text; //"http://whatismyip.akamai.com/";
                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);
                Stream s = webreq.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd();
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "DEBUG信息:" + all + "\r\n");
                //Cut the string
                /*
                string[] symbols = new string[2] { "[", "]" };
                string[] data = all.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
                string ip = data[1];*/
                all = Regex.Replace(all, @"(\d+)", "000$1");
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "DEBUG信息:" + all + "\r\n");
                all = Regex.Replace(all, @"0+(\d{1,4})", "$1");
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "DEBUG信息:" + all + "\r\n");
                string reg = @"(\d{1,4}\.\d{1,4}\.\d{1,4}\.\d{1,4})";
                Regex regex = new Regex(reg);
                Match match = regex.Match(all);
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "DEBUG信息:" + match + "\r\n");
                string ip = match.Groups[1].Value;
                //textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "DEBUG信息:" + ip + "\r\n");
                //return Regex.Replace(ip, @"0*(\d+)", "$1");

                //string ip = all;
                if (ip.Length > 0)
                {
                    label_localIpStatus.Text = "已连接";
                    label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "成功获取WAN口IP:" + ip + "\r\n");
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                }
                //return ip;
                return Regex.Replace(ip, @"0*(\d+)", "$1");
            }
            catch (Exception)
            {
                
                label_localIpStatus.Text = "无连接";
                label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255,255,0,0);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败，请检查设置！" + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_gray;
                return "0.0.0.0";
            }
        }

        private bool setRecordId()
        {
            DescribeSubDomainRecordsRequest request = new DescribeSubDomainRecordsRequest();
            request.SubDomain = fullDomainName.Text;
            try
            {
                DescribeSubDomainRecordsResponse response = client.GetAcsResponse(request);
                List<Record> list = response.DomainRecords;

                if (list.Count == 0)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问成功，但没有找到对应域名信息！" + "\r\n");
                    if (addDomainRecord())
                        return true;
                    else
                        return false;
                }

                int i = 0;

                foreach (Record record in list)
                {
                    i++;
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务返回RecordId:" + i.ToString() + " RecordId：" + record.RecordId + "\r\n");
                    recordId.Text = record.RecordId;
                    globalRR.Text = record.RR;
                    globalDomainType.Text = record.Type;
                    globalValue.Text = domainIP.Text = record.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                }
                return true;
            }
            //处理错误
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return false;
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return false;
            }
        }

        private string getDomainIP()
        {
            DescribeDomainRecordInfoRequest request = new DescribeDomainRecordInfoRequest();
            request.RecordId = recordId.Text;
            try
            {
                DescribeDomainRecordInfoResponse response = client.GetAcsResponse(request);
                if (response.Value != "0.0.0.0")
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名:" + response.RR + "." + response.DomainName + " 已经绑定IP:" + response.Value + "\r\n");
                    recordId.Text = response.RecordId;
                    globalRR.Text = response.RR;
                    globalDomainType.Text = response.Type;
                    globalValue.Text = response.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return response.Value;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名绑定IP失败！" + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return "0.0.0.0";
            }
            //处理错误 
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return "0.0.0.0";
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return "0.0.0.0";
            }
        }

        private void updateDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            UpdateDomainRecordRequest request = new UpdateDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.RecordId = recordId.Text;
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在将WAN口IP:" + localIP.Text + "与域名" + fullDomainName.Text + "绑定..." + "\r\n");
                UpdateDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    domainIP.Text = localIP.Text; //更新窗体数据
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新成功！" + "\r\n");
                }
                recordId.Text = response.RecordId;
            }
            //处理错误
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
            }
        }

        private bool addDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            AddDomainRecordRequest request = new AddDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.DomainName = domainName;
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在向阿里云DNS服务添加域名:" + fullDomainName.Text + "\r\n");
                AddDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "RecordId:" + response.RecordId + " 域名：" + fullDomainName.Text + "添加成功！" + "\r\n");
                recordId.Text = response.RecordId; 
                globalDomainType.Text = request.Type;
                globalRR.Text = request.RR; 
                globalValue.Text = domainIP.Text = request.Value;
                label_DomainIpStatus.Text = "已绑定";
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                return true;
            }
            //处理错误
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return false;
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                return false;
            }
        }

        private void updatePrepare()
        {
            label_nextUpdateSeconds.Text = newSeconds.Text;
            try
            {
                localIP.Text = getLocalIP();
                domainIP.Text = getDomainIP();
                if (domainIP.Text == localIP.Text)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "一致，无需更新！" + "\r\n");
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "不一致，需要更新！" + "\r\n");
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                    updateDomainRecord();
                }
              
                //localIP.Text = getLocalIP();
                //domainIP.Text = getDomainIP();
            }
            catch (Exception)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新失败！" + "\r\n");
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
            }
        }

        //Events in form
        private void updateNow_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---立即开始WAN口IP和域名绑定IP进行查询比较---" + "\r\n");
            this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
            updatePrepare();
        }

        private void checkConfig_Click(object sender, EventArgs e)
        {
            try
            {
                localIP.Text = getLocalIP(); //读取WAN口IP
                //domainIP.Text = getDomainIP(); //读取AliDDNS已经绑定IP

                clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text, accessKeySecret.Text);
                client = new DefaultAcsClient(clientProfile);
                if (setRecordId()) //检查能否从服务器返回RecordId，返回则设置正确，否则设置不正确
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置项目内容填写正确，即将保存到设置文件！ " + "\r\n");

                    if (saveConfigFile()) //检查设置文件是否保存成功
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件保存成功！ " + "\r\n");
                    else
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件保存失败，请检查文件权限！ " + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务没有返回RecordId，设置项目内容没有保存！" + "\r\n");
                }
                   
            }
            catch (Exception) {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问失败，请检查账户accessKeyId和accessKeySecret！" + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                domainIP.Text = "0.0.0.0";
                recordId.Text = "null";
                globalRR.Text = "null";
                globalDomainType.Text = "null";
                globalValue.Text = "null";
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            }
        }
       
        private void autoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_autoUpdate.Checked == true && label_nextUpdateSeconds.Text != "")
                {
                    int seconds = Convert.ToInt32(label_nextUpdateSeconds.Text);
                    if (seconds > 0) seconds--;
                    label_nextUpdateSeconds.Text = seconds.ToString();

                    if (seconds == 0)
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---计划任务被触发，开始WAN口IP和域名IP查询比较---" + "\r\n");
                        updatePrepare();
                    }
                }
                if (checkBox_logAutoSave.Checked == true)
                {
                    if ( textBox_log.GetLineFromCharIndex(textBox_log.Text.Length) >10000 )
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---运行日志超过10000行，开始日志转储---" + "\r\n");
                        logToFiles();
                    }
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void notifyIcon_sysTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show(); //窗体显示
                this.WindowState = FormWindowState.Normal; //窗体正常化
                this.ShowInTaskbar = true; //从状态栏显示
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = false; //从状态栏清除
                this.WindowState = FormWindowState.Minimized; //窗体最小化
                this.Hide(); //窗体隐藏
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; //取消关闭窗体
            this.WindowState = FormWindowState.Minimized; //窗体最小化
            this.Hide(); //窗体隐藏
        }

        private void button_whatIsTest_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "开始向网址发起查询... " + "\r\n");
            localIP.Text = getLocalIP();
        }

        private void button_ShowHide_Click(object sender, EventArgs e)
        {
            if (button_ShowHide.Text == "显示录入")
            {
                button_ShowHide.Text = "隐藏录入";
                accessKeyId.PasswordChar = (char)0;
                accessKeySecret.PasswordChar = (char)0;
            }
            else
            {
                button_ShowHide.Text = "显示录入";
                accessKeyId.PasswordChar = '*';
                accessKeySecret.PasswordChar = '*';
            }
        }

        private void fullDomainName_ModifiedChanged(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名修改后请测试并保存！" + "\r\n");
        }

        private void checkBox_autoBoot_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_autoBoot.Checked == true)
            {
                //获取执行该方法的程序集，并获取该程序集的文件路径（由该文件路径可以得到程序集所在的目录）
                string thisExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;//this.GetType().Assembly.Location;
                //SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run注册表中这个路径是开机自启动的路径
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                Rkey.SetValue("AliDDNS Tray", thisExecutablePath);
                Rkey.Close();
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行设置成功！" + "\r\n");
            }
            else
            {
                Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true);
                Rkey.DeleteValue("AliDDNS Tray");
                Rkey.Close();
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行取消！" + "\r\n");
            }
                
            
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
            Form_About about = new Form_About();
            about.Show(this);
        }

        private void checkBox_logAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_logAutoSave.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储启用成功！日志超过1万行将自动转储。" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储取消！" + "\r\n");
        }

        private void logToFiles()
        {
            string logPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logfile = logPath + DateTime.Now.ToString("yyyyMMddHHmmss") + "aliddns_log.txt";
            if (!File.Exists(logfile))
            {
                //using (File.Create(logPath)) { }
                System.IO.StreamWriter sw = System.IO.File.AppendText(logfile);
                sw.WriteLine(textBox_log.Text);
                sw.Close();
                sw.Dispose();
                textBox_log.Clear();
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志转储为: " + logfile + "\r\n");
            }
        }

        private void checkBox_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_autoUpdate.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新启用成功！" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新取消！" + "\r\n");
        }

        private void checkBox_minimized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_minimized.Checked == true)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘启用！" + "\r\n");
            else
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘取消！" + "\r\n");
        }

        private void button_setIP_Click(object sender, EventArgs e)
        {
            try
            {
                string strIn = maskedTextBox_setIP.Text;
                if (Regex.IsMatch(strIn, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"))
                {
                    localIP.Text = maskedTextBox_setIP.Text;
                    updateDomainRecord();
                    //getDomainIP();
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查输入格式是否正确！IP地址示例格式:255.255.255.255" + "\r\n");
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "出错:" + error + "\r\n");
            }
                
        }

    }
}
