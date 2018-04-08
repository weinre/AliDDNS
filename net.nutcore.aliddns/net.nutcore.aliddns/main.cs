using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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
            try //检查配置文件，如果没有则新建，并赋值默认值
            {
                if (File.Exists("config.xml") != true)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "没有找到配置文件 config.xml，重新创建！" + "\r\n");
                    if (saveConfigFile())
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件 config.xml 创建成功！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件 config.xml 设置项目默认赋值完成！" + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请填写正确内容，点击“验证并保存”完成设置！" + "\r\n");
                    }
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件 config.xml 错误！信息：" + error + "\r\n");
            }
            
            //读取配置文件config.xml
            readConfigFile();

            try //获取WAN口IP
            {
                localIP.Text = getLocalIP();
            }
            catch (Exception)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败！" + "\r\n");
            }

            try
            {
                clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text, accessKeySecret.Text);
                client = new DefaultAcsClient(clientProfile);
                domainIP.Text = getDomainIP();
            }
            catch (Exception)
            {
                
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名和绑定IP失败，请检查设置项目内容和网络状态！" + "\r\n");
            }
        }

        private void readConfigFile()
        {
            string[] config = new string[7]; //需要根据config.xml文件内设置项目数量设置读取数量，目前config.xml配置文件内存储了7个设置项目
            int i = 0;

            //Create xml object
            XmlDocument xmlDOC = new XmlDocument();
            xmlDOC.Load("config.xml");
            XmlNodeReader readXML = new XmlNodeReader(xmlDOC);
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "开始读取配置文件config.xml..." + "\r\n");
            while (readXML.Read())
            {
                readXML.MoveToElement(); //Forward
                if (readXML.NodeType == XmlNodeType.Text) //Only save config
                {
                    config[i] = readXML.Value;
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "项目[" + i + "]: " + config[i] + "\r\n"); //显示读取内容，用于调试DEBUG。
                    i++;
                }
            }
            accessKeyId.Text = config[0];
            accessKeySecret.Text = config[1];
            recordId.Text = config[2];
            fullDomainName.Text = config[3];
            nextUpdateSeconds.Text = newSeconds.Text = config[4];
            if ( config[5] == "On" ) autoUpdateOn.Checked = true;
            if ( config[5] == "Off ") autoUpdateOff.Checked = true;
            text_whatIsUrl.Text = config[6];
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件 config.xml读取成功！" + "\r\n");
        }

        private bool saveConfigFile()
        {
            if (accessKeyId.Text == "" || accessKeySecret.Text == "" || recordId.Text == "" || fullDomainName.Text == "" || newSeconds.Text == "" || text_whatIsUrl.Text == "")
            {
                //MessageBox.Show("任何值都不能为空！无法填写请输入null或0");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "任何值都不能为空！无法填写请输入null或0！" + "\r\n");
                return false;
            }

            XmlTextWriter textWriter = new XmlTextWriter("config.xml", null);
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
            if (autoUpdateOn.Checked == true)
                textWriter.WriteString("On");
            if (autoUpdateOff.Checked)
                textWriter.WriteString("Off");
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("whatIsUrl", "");
            textWriter.WriteString(text_whatIsUrl.Text);
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //设置项目结束
            textWriter.WriteEndDocument();//文档结束
            textWriter.Close(); //文档保存关闭

            nextUpdateSeconds.Text = newSeconds.Text;
            
            return true;
        }

        private string getLocalIP()
        {
            try
            {
                string strUrl = text_whatIsUrl.Text; //"http://whatismyip.akamai.com/";
                Uri uri = new Uri(strUrl);
                WebRequest webreq = WebRequest.Create(uri);
                Stream s = webreq.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd();

                //Cut the string
                /*
                string[] symbols = new string[2] { "[", "]" };
                string[] data = all.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
                string ip = data[1];
                */
                string ip = all;
                if(ip.Length > 0)
                {
                    label_localIpStatus.Text = "已连接";
                    label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "成功获取WAN口IP:" + ip + "\r\n");
                }
                return ip;
            }
            catch (Exception)
            {
                
                label_localIpStatus.Text = "无连接";
                label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255,255,0,0);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取WAN口IP失败，请检查设置！" + "\r\n");
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
                    addDomainRecord();
                    return false;
                }

                int i = 0;

                foreach (Record record in list)
                {
                    i++;
                    //MessageBox.Show("Record" + i.ToString());
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "服务器返回Record:" + i.ToString() + " RecordId：" + record.RecordId + "\r\n");
                    recordId.Text = record.RecordId;
                    globalRR.Text = record.RR;
                    globalDomainType.Text = record.Type;
                    globalValue.Text = domainIP.Text = record.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                }
                return true;
            }
            //处理错误
            catch (ServerException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                return false;
            }
            catch (ClientException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
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
                if (response.Value.Length > 0)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名:" + response.RR + "." + response.DomainName + " 已经绑定IP:" + response.Value + "\r\n");
                    recordId.Text = response.RecordId;
                    globalRR.Text = response.RR;
                    globalDomainType.Text = response.Type;
                    globalValue.Text = response.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return response.Value;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名绑定IP失败！" + "\r\n");
                return "0.0.0.0";
            }
            //处理错误 
            catch (ServerException e)
            {
                //MessageBox.Show("Server Exception: " + e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                return "0.0.0.0";
            }
            catch (ClientException e)
            {
                //MessageBox.Show("Client Exception: " + e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
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
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在将WAN口IP:" + localIP.Text + "与域名" + domainName + "绑定..." + "\r\n");
                UpdateDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    domainIP.Text = localIP.Text; //更新窗体数据
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新成功！" + "\r\n");
                }
                recordId.Text = response.RecordId;
            }
            //处理错误
            catch (ServerException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");

            }
            catch (ClientException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
        }

        private void addDomainRecord()
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
                AddDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "RecordId:" + response.RecordId + "添加成功！" + "\r\n");
                recordId.Text = response.RecordId;
                label_DomainIpStatus.Text = "已绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
            }
            //处理错误
            catch (ServerException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                //MessageBox.Show(e.ErrorCode + e.ErrorMessage);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
        }

        private void updatePrepare()
        {
            nextUpdateSeconds.Text = newSeconds.Text;
            try
            {
                localIP.Text = getLocalIP();
                domainIP.Text = getDomainIP();
                if (domainIP.Text == localIP.Text)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "一致，无需更新！" + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "不一致，需要更新！" + "\r\n");
                    updateDomainRecord();
                }

                //localIP.Text = getLocalIP();
                //domainIP.Text = getDomainIP();
            }
            catch (Exception) {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新失败！" + "\r\n");
            }
        }

        //Events in form
        private void updateNow_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---立即开始WAN口IP和域名IP查询比较---" + "\r\n");
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
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置项目内容填写正确！ " + "\r\n");

                    if (saveConfigFile()) //检查配置文件是否保存成功
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件更新成功！ " + "\r\n");
                    else
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件更新失败，请检查文件权限！ " + "\r\n");
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云访问成功，但没有找到对应域名信息，设置文件没有更新！ " + "\r\n");
                }
                   
            }
            catch (Exception) {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云访问失败，请检查账户accessKeyId和accessKeySecret！" + "\r\n");
                label_DomainIpStatus.Text = "未绑定";
                label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            }
        }
        
        private void PubilishLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/wisdomwei201804/AliDDNS/");
        }

        private void personalWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "http://www.nutcore.net/");
        }

        private void autoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (autoUpdateOn.Checked == true && nextUpdateSeconds.Text != "")
                {
                    int seconds = Convert.ToInt32(nextUpdateSeconds.Text);
                    if (seconds > 0)
                        seconds--;
                    else
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查时间设置！" + "\r\n");
                    nextUpdateSeconds.Text = seconds.ToString();

                    if (seconds == 0)
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---计划任务被触发，开始WAN口IP和域名IP查询比较---" + "\r\n");
                        updatePrepare();
                    }
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show("请检查设置中的秒数是否为整数！错误信息：" + error);
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查设置中的秒数是否为整数！错误信息： " + error + "\r\n");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
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
    }
}
