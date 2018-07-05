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
using static Aliyun.Acs.Alidns.Model.V20150109.DescribeSubDomainRecordsResponse;

namespace net.nutcore.aliddns
{
    public partial class mainForm : Form
    {
        public static bool checkUpdate;
        static IClientProfile clientProfile;
        static DefaultAcsClient client;
        //初始化ngrok操作类
        private NgrokHelper ngrok = new NgrokHelper();
        private AppConfigHelper cfg = new AppConfigHelper();

        public mainForm()
        {
            InitializeComponent();
            this.MinimizeBox = false; //取消窗口最小化按钮
            this.MaximizeBox = false; //取消窗口最大化按钮
        }

        /// <summary>
        /// mainForm窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            //获取当前用户名和计算机名并写入日志
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "计算机名: " + System.Environment.UserDomainName + "\r\n");
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户: " + System.Environment.UserName + "\r\n");
            //检查当前用户权限
            System.Security.Principal.WindowsIdentity wid = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal printcipal = new System.Security.Principal.WindowsPrincipal(wid);
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "角色信息:" + printcipal.Identity.Name.ToString() + "\r\n");
            /*
            bool isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Administrator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.User));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: User" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.AccountOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: AccountOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.BackupOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: BackupOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Guest));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Guest" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PowerUser));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: PowerUser" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.PrintOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: PrintOperator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Replicator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: Replicator" + "\r\n");
            isUser = (printcipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.SystemOperator));
            if (isUser)
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户角色: SystemOperator" + "\r\n");
            */
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "当前用户需要文件写入和注册表操作权限，否则相关参数不起作用！" + "\r\n");
            
            //读取设置文件aliddns_config.xml
            if (readConfigFile())
            {
                string ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string updateExe = ExePath + "update.exe";
                if(checkUpdate == true)
                {
                    if (File.Exists(updateExe))
                    {
                        //执行update.exe
                    }
                    else
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "版本检测程序update.exe未找到，跳过版本检测！ " + "\r\n");
                    }
                }
                
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

                //获取阿里云域名记录绑定IP
                //domainIP.Text = getAliDnsRecordDomainIP();
                //获取WAN口IP
                //localIP.Text = getWanIP();
                if (checkBox_autoBoot.Checked == true)
                {
                    updatePrepare();
                }
            }
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }

        /// <summary>
        /// 读取配置文件并初始化控件
        /// </summary>
        /// <returns></returns>
        private bool readConfigFile()
        {
            try
            {
                accessKeyId.Text = EncryptHelper.AESDecrypt(cfg.GetAppSetting("AccessKeyID").ToString());
                accessKeySecret.Text = EncryptHelper.AESDecrypt(cfg.GetAppSetting("AccessKeySecret").ToString());
                recordId.Text = cfg.GetAppSetting("RecordID").ToString();
                fullDomainName.Text = cfg.GetAppSetting("fullDomainName").ToString();
                label_nextUpdateSeconds.Text = newSeconds.Text = cfg.GetAppSetting("WaitingTime").ToString();
                if (cfg.GetAppSetting("autoUpdate").ToString() == "On") checkBox_autoUpdate.Checked = true;
                else checkBox_autoUpdate.Checked = false;
                if(cfg.GetAppSetting("whatIsUrl").ToString() != null)
                {
                    string[] arrayUrl = cfg.GetAppSetting("whatIsUrl").ToString().Split(',');
                    foreach(string strUrl in arrayUrl)
                    {
                        comboBox_whatIsUrl.Items.Add(strUrl.ToString().Trim());
                    }
                    comboBox_whatIsUrl.SelectedIndex = 0;
                }
                
                if (cfg.GetAppSetting("autoBoot").ToString() == "On") checkBox_autoBoot.Checked = true;
                else checkBox_autoBoot.Checked = false;

                if (cfg.GetAppSetting("minimized").ToString() == "On") checkBox_minimized.Checked = true;
                else checkBox_minimized.Checked = false;

                if (cfg.GetAppSetting("logautosave").ToString() == "On") checkBox_logAutoSave.Checked = true;
                else checkBox_logAutoSave.Checked = false;

                textBox_TTL.Text = cfg.GetAppSetting("TTL").ToString();

                if (cfg.GetAppSetting("autoCheckUpdate").ToString() == "On") checkUpdate = true;
                else checkUpdate = false;

                if (cfg.GetAppSetting("ngrokauto").ToString() == "On")
                {
                    checkBox_ngrok.Checked = true;
                    button_ngrok.Enabled = false;
                }
                else
                {
                    checkBox_ngrok.Checked = false;
                    button_ngrok.Enabled = true;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "设置文件读取成功！" + "\r\n");
                return true;
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                return false;
            }

        }

        /// <summary>
        /// 获取网络出口公网IP
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        private string getWanIP(string strUrl)
        {
            try
            {
                if (strUrl != null)
                {
                    Uri uri = new Uri(strUrl);
                    WebRequest webreq = WebRequest.Create(uri);
                    Stream s = webreq.GetResponse().GetResponseStream();
                    StreamReader sr = new StreamReader(s, Encoding.Default);
                    string all = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    all = Regex.Replace(all, @"(\d+)", "000$1");
                    all = Regex.Replace(all, @"0+(\d{1,4})", "$1");
                    string reg = @"(\d{1,4}\.\d{1,4}\.\d{1,4}\.\d{1,4})";
                    Regex regex = new Regex(reg);
                    Match match = regex.Match(all);
                    string ip = match.Groups[1].Value;
                    if ((ip.Length > 0) && (ip.ToString() != "0.0.0.0"))
                    {
                        label_localIpStatus.Text = "已连接";
                        label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "从" + strUrl + "成功获取WAN口IP:" + ip + "\r\n");
                        //return ip;
                        return Regex.Replace(ip, @"0*(\d+)", "$1");
                    }
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "从" + strUrl + "返回IP是空值，查询失败！" + "\r\n");
                    label_localIpStatus.Text = "未连接";
                    label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                    return "0.0.0.0";
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "请检查配置文件查询网址设置！" + "\r\n");
                    return "0.0.0.0";
                }
                return "0.0.0.0";
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
                label_localIpStatus.Text = "未连接";
                label_localIpStatus.ForeColor = System.Drawing.Color.FromArgb(255,255,0,0);
                return "0.0.0.0";
            }
        }

        /// <summary>
        /// 从阿里云获取域名记录
        /// </summary>
        /// <returns></returns>
        private bool getRecordId() //获取阿里云解析返回recordId
        {
            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text.ToString(), accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            DescribeSubDomainRecordsRequest request = new DescribeSubDomainRecordsRequest();
            request.SubDomain = fullDomainName.Text;
            try
            {                
                DescribeSubDomainRecordsResponse response = client.GetAcsResponse(request);
                List<Record> list = response.DomainRecords;

                if (list.Count == 0) //当不存在域名记录时，添加一个
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务访问成功，但没有找到对应域名记录，请添加域名后重试！" + "\r\n");
                    return false;
                }
                else
                {
                    int i = 0;
                    foreach (Record record in list) //当存在域名记录时，返回域名记录信息
                    {
                        i++;
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS服务返回RecordId:" + i.ToString() + " RecordId：" + record.RecordId + "\r\n");
                        recordId.Text = record.RecordId;
                        globalRR.Text = record.RR;
                        globalDomainType.Text = record.Type;
                        globalValue.Text = domainIP.Text = record.Value;
                        label_TTL.Text = Convert.ToString(record.TTL);
                        label_DomainIpStatus.Text = "已绑定";
                        label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    }
                    return true;
                }
            }
            //处理错误
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
            return false;
        }

        /// <summary>
        /// 从阿里云服务器获取域名记录信息
        /// </summary>
        /// <returns></returns>
        private string getAliDnsRecordDomainIP()
        {
            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text.ToString(), accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            DescribeDomainRecordInfoRequest request = new DescribeDomainRecordInfoRequest();
            request.RecordId = recordId.Text.ToString();
            try
            {
                DescribeDomainRecordInfoResponse response = client.GetAcsResponse(request);
                string fullDomain = response.RR.ToString() + "." + response.DomainName.ToString();
                if (response.Value != "0.0.0.0")
                {
                    if(fullDomain != fullDomainName.Text.ToString())
                    {
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "阿里云DNS域名记录:"+ response.RecordId + " 对应域名为:" + fullDomain + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件域名记录:" + recordId.Text.ToString() + " 对应域名为:" + fullDomainName.Text.ToString() + "\r\n");
                        textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "配置文件设置错误！可能原因是修改域名记录后未及时添加，已经自动修改配置文件与服务器记录一致！" + "\r\n");
                        fullDomainName.Text = fullDomain;
                        cfg.SaveAppSetting("fullDomainName", fullDomain);
                    }
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名:" + response.RR + "." + response.DomainName + " 已经绑定IP:" + response.Value + "\r\n");
                    recordId.Text = response.RecordId;
                    globalRR.Text = response.RR;
                    globalDomainType.Text = response.Type;
                    globalValue.Text = response.Value;
                    label_TTL.Text = Convert.ToString(response.TTL);
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return response.Value;
                }
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "获取域名绑定IP失败！" + "\r\n");
            }
            //处理错误 
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "getAliDnsRecordDomainIP() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
            label_DomainIpStatus.Text = "未绑定";
            label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            return "0.0.0.0";
        }

        /// <summary>
        /// 更新域名记录
        /// </summary>
        private void updateDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text.ToString(), accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            UpdateDomainRecordRequest request = new UpdateDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.RecordId = recordId.Text;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在将WAN口IP:" + localIP.Text + "与域名" + fullDomainName.Text + "绑定..." + "\r\n");
                UpdateDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    domainIP.Text = localIP.Text; //更新窗体数据
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名绑定IP更新成功！" + "\r\n");
                }
                recordId.Text = response.RecordId;
            }
            //处理错误
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
        }

        /// <summary>
        /// 添加域名记录
        /// </summary>
        /// <returns></returns>
        private bool addDomainRecord()
        {
            string[] symbols = new string[1] { "." };
            string[] data = fullDomainName.Text.Split(symbols, 30, StringSplitOptions.RemoveEmptyEntries);
            string domainRR = data[0];
            string domainName = data[1] + "." + data[2];

            clientProfile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId.Text.ToString(), accessKeySecret.Text.ToString());
            client = new DefaultAcsClient(clientProfile);
            AddDomainRecordRequest request = new AddDomainRecordRequest();
            request.Type = "A";
            request.RR = domainRR;
            request.DomainName = domainName;
            request.TTL = Convert.ToInt32(textBox_TTL.Text);
            request.Value = localIP.Text;
            try
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "正在向阿里云DNS服务添加域名:" + fullDomainName.Text + "\r\n");
                AddDomainRecordResponse response = client.GetAcsResponse(request);
                if (response.RecordId != null)
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + " 域名：" + fullDomainName.Text + "添加成功！" + "服务器返回RecordId:" + response.RecordId  + "\r\n");
                    recordId.Text = response.RecordId.ToString();
                    cfg.SaveAppSetting("RecordID", response.RecordId.ToString());
                    globalDomainType.Text = request.Type;
                    globalRR.Text = request.RR;
                    globalValue.Text = domainIP.Text = request.Value;
                    label_DomainIpStatus.Text = "已绑定";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 255);
                    return true;
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + " 域名：" + fullDomainName.Text + "添加失败！" + "\r\n");
                    label_DomainIpStatus.Text = "未绑定";
                    domainIP.Text = "0.0.0.0";
                    recordId.Text = "null";
                    globalRR.Text = "null";
                    globalDomainType.Text = "null";
                    globalValue.Text = "null";
                    label_TTL.Text = "null";
                    label_DomainIpStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 0, 0);
                    return false;
                }
                    
            }
            //处理错误
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "updateDomainRecord() Exception:  " + error + "\r\n");
            }
            /*
            catch (ServerException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Server Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }
            catch (ClientException e)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Client Exception:  " + e.ErrorCode + e.ErrorMessage + "\r\n");
            }*/
            return false;
        }

        /// <summary>
        /// 比较是否需要更新域名信息
        /// </summary>
        private void updatePrepare()
        {
            label_nextUpdateSeconds.Text = newSeconds.Text;
            string[] arrayUrl = cfg.GetAppSetting("whatIsUrl").ToString().Split(',');
            foreach (string strUrl in arrayUrl)
            {
                if ((localIP.Text = getWanIP(strUrl)) != "0.0.0.0")
                {
                    break;
                }
            }
            if(localIP.Text.ToString() == "0.0.0.0")
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + "，域名绑定IP更新停止，请检查查询网址设置或者手工指定IP！" + "\r\n");
                return;
            }
            domainIP.Text = getAliDnsRecordDomainIP();
            if (domainIP.Text == localIP.Text)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "一致，无需更新！" + "\r\n");
            }
            else
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "WAN口IP:" + localIP.Text + " 与域名绑定IP:" + domainIP.Text + "不一致，需要更新！" + "\r\n");
                updateDomainRecord();
            }
            //localIP.Text = getWanIP();
            //domainIP.Text = getAliDnsRecordDomainIP();
            //监测网络状态、刷新系统托盘图标
            notifyIcon_sysTray_Update(); 
        }

        private void updateNow_Click(object sender, EventArgs e)
        {
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---立即开始WAN口IP和域名绑定IP进行查询比较---" + "\r\n");
            updatePrepare();
        }

        private void checkConfig_Click(object sender, EventArgs e)
        {
            if (getRecordId()) 
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "测试结果->成功！" + "\r\n");
            }
            else
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "测试结果->失败！请检查设置项目是否正确！" + "\r\n");
            }
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
        }
       
        private void autoUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (checkBox_autoUpdate.Checked == true)
            {
                if(Convert.ToInt32(label_nextUpdateSeconds.Text) > 0)
                {
                    label_nextUpdateSeconds.Text = Convert.ToString((Convert.ToInt32(label_nextUpdateSeconds.Text) - 1));
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---计划任务被触发，开始WAN口IP和域名IP查询比较---" + "\r\n");
                    updatePrepare();
                }
            }
            
            if (checkBox_logAutoSave.Checked == true && textBox_log.GetLineFromCharIndex(textBox_log.Text.Length) > 10000)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "---运行日志超过10000行，开始日志转储---" + "\r\n");
                logToFiles();
            }
        }

        private async void toolStripMenuItem_Quit_Click(object sender, EventArgs e)
        {
            await ngrok.Stop();
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
            localIP.Text = getWanIP(comboBox_whatIsUrl.Text.ToString().Trim());
            notifyIcon_sysTray_Update(); //监测网络状态、刷新系统托盘图标
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

        private void checkBox_autoBoot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_autoBoot.Checked == true)
                {
                    //获取执行该方法的程序集，并获取该程序集的文件路径（由该文件路径可以得到程序集所在的目录）
                    string thisExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;//this.GetType().Assembly.Location;
                                                                                                           //SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run注册表中这个路径是开机自启动的路径
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    Rkey.SetValue("AliDDNS Tray", thisExecutablePath);
                    Rkey.Close();
                    cfg.SaveAppSetting("autoBoot", "On");
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行设置成功！" + "\r\n");
                }
                else
                {
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    Rkey.DeleteValue("AliDDNS Tray");
                    Rkey.Close();
                    cfg.SaveAppSetting("autoBoot", "Off");
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "随系统启动自动运行取消！" + "\r\n");
                }
            }
            catch (Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            Form_About about = new Form_About();
            about.Show(this);
        }

        private void checkBox_logAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_logAutoSave.Checked == true)
            {
                cfg.SaveAppSetting("logautosave", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储启用成功！日志超过1万行将自动转储。" + "\r\n");
            }
            else
            {
                cfg.SaveAppSetting("logautosave", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志自动转储取消！" + "\r\n");
            }
        }

        private void logToFiles()
        {
            try
            {
                string logPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string logfile = logPath + DateTime.Now.ToString("yyyyMMddHHmmss") + "aliddns_log.txt";
                if (!File.Exists(logfile))
                {
                    StreamWriter sw = new StreamWriter(logfile); 
                    sw.WriteLine(textBox_log.Text);
                    sw.Close();
                    sw.Dispose();
                    textBox_log.Clear();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志转储为: " + logfile + "\r\n");
                }
                else
                {
                    StreamWriter sw = File.AppendText(logfile);
                    sw.WriteLine(textBox_log.Text);
                    sw.Close();
                    sw.Dispose();
                    textBox_log.Clear();
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "日志转储为: " + logfile + "\r\n");
                }
            }
            catch(Exception error)
            {
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
            
        }

        private void checkBox_autoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_autoUpdate.Checked == true)
            {
                cfg.SaveAppSetting("autoUpdate", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新启用成功！" + "\r\n");
            }
            else
            {
                cfg.SaveAppSetting("autoUpdate", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名记录自动更新取消！" + "\r\n");
            }
        }

        private void checkBox_minimized_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_minimized.Checked == true)
            {
                cfg.SaveAppSetting("minimized", "On");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘启用！" + "\r\n");
            }
            else
            {
                cfg.SaveAppSetting("minimized", "Off");
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "软件启动时驻留到系统托盘取消！" + "\r\n");
            }
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
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "运行出错！信息: " + error + "\r\n");
            }
            //监测网络状态、刷新系统托盘图标
            notifyIcon_sysTray_Update(); 
        }

        private void notifyIcon_sysTray_Update()
        {
            if ( label_localIpStatus.Text == "未连接" )
            {
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_gray;
            }
            else
            {
                this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                if ( label_DomainIpStatus.Text == "未绑定" )
                {
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_red;
                }
                else
                {
                    this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_yellow;
                    if( localIP.Text == domainIP.Text )
                        this.notifyIcon_sysTray.Icon = Properties.Resources.alidns_green;
                }
            }

        }

        public static string verCheckUpdate()
        {
            try
            {
                string strUrl = "https://github.com/wisdomwei201804/AliDDNS/releases/latest";
                if (strUrl.StartsWith("https"))
                    System.Net.ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;  // SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls1.2 | SecurityProtocolType.Tls12;
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient(
                    new System.Net.Http.HttpClientHandler
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
                System.Net.Http.HttpResponseMessage response = httpClient.GetAsync(strUrl).Result;
                //var statusCode = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    string ver = System.Text.RegularExpressions.Regex.Match(result, @"""tag_name"":""([^""]*)""").Groups[1].Value;
                    //MessageBox.Show(ver);
                    return ver.ToString();
                }
                else
                    return null;
                //httpClient.Dispose();
                //response.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return null;
            }
        }

        private void ToolStripMenuItem_checkUPdate_Click(object sender, EventArgs e)
        {
            string strVer = verCheckUpdate();
            if (strVer != null)
            {
                Version remoteVer = new Version(strVer);
                Version localVer = new Version(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if (remoteVer > localVer)
                    MessageBox.Show("发现新版本: " + remoteVer);
                else
                    MessageBox.Show("没有新版本，无需升级！");
            }
            else
                MessageBox.Show("获取新版本信息失败！");
        }

        private async void checkBox_ngrok_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox_ngrok.Checked == true)
            {
                button_ngrok.Enabled = false;
                cfg.SaveAppSetting("ngrokauto", "On");
                //检测ngrok.exe是否存在
                if (ngrok.IsExists())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，ngrok.exe将自动加载！本机浏览器打开：http://127.0.0.1:4040 查看运行状态。" + "\r\n");
                    await ngrok.Start();
                }
                else
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能启用，但当前目录没有发现ngrok.exe，请往官网下载自行编译：https://ngrok.com/download" + "\r\n");
                }
            }
            else
            {
                cfg.SaveAppSetting("ngrokauto", "Off");
                await ngrok.Stop();
                button_ngrok.Enabled = true;
                textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "Ngrok功能关闭，再次启动将不会加载！" + "\r\n");
            }
        }

        private void button_ngrok_Click(object sender, EventArgs e)
        {
            Form_ngrok ngrok = new Form_ngrok();
            ngrok.Show(this);
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            //检测ngrok.exe是否存在
            if (( checkBox_ngrok.Checked == true ) && ( !ngrok.IsExists() ))
            {
                MessageBox.Show("软件运行目录没有发现ngrok.exe，请往官网下载自行编译。\nNgrok官网：https://ngrok.com/download");
            }
        }

        private void fullDomainName_Leave(object sender, EventArgs e)
        {
            cfg.SaveAppSetting("fullDomainName", this.fullDomainName.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "域名已经保存，点击测试连接将查询域名是否存在，当不存在时点击添加域名会创建新域名记录！" + "\r\n");
        }

        private void accessKeyId_Leave(object sender, EventArgs e)
        {
            cfg.SaveAppSetting("AccessKeyID", EncryptHelper.AESEncrypt(this.accessKeyId.Text.ToString()));
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "accessKeyId已经保存，请完成设置录入后点击测试连接！" + "\r\n");
        }

        private void accessKeySecret_Leave(object sender, EventArgs e)
        {
            cfg.SaveAppSetting("AccessKeySecret", EncryptHelper.AESEncrypt(this.accessKeySecret.Text.ToString()));
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "accessKeySecret已经保存，请完成设置录入后点击测试连接！" + "\r\n");
        }

        private void textBox_TTL_Leave(object sender, EventArgs e)
        {
            cfg.SaveAppSetting("TTL",this.textBox_TTL.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "TTL设置修改保存成功！" + "\r\n");
        }

        private void newSeconds_Leave(object sender, EventArgs e)
        {
            cfg.SaveAppSetting("WaitingTime", this.textBox_TTL.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "自动更新倒计时设置修改保存成功！" + "\r\n");
        }

        private void comboBox_whatIsUrl_Leave(object sender, EventArgs e)
        {
            //cfg.SaveAppSetting("whatIsUrl", this.comboBox_whatIsUrl.Text.ToString());
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "公网IP查询网址已经修改，请测试并确定是否添加进配置文件！" + "\r\n");
        }

        private void button_addNewDomain_Click(object sender, EventArgs e)
        {
            addDomainRecord();
        }

        private void button_addUrl_Click(object sender, EventArgs e)
        {
            string newItem = comboBox_whatIsUrl.Text.Trim().ToLower().ToString();
            for(int i = 0; i < comboBox_whatIsUrl.Items.Count; i++)
            {
                if (newItem == comboBox_whatIsUrl.Items[i].ToString())
                {
                    textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "填写的公网IP查询网址已经存在，无需重复添加！" + "\r\n");
                    return;
                }
            }
            comboBox_whatIsUrl.Items.Add(newItem);
            cfg.AddAppSetting("whatIsUrl", newItem);
            textBox_log.AppendText(System.DateTime.Now.ToString() + " " + "新增公网IP查询网址保存成功！" + "\r\n");
        }
    }
}
