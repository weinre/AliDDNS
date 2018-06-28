using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace net.nutcore.aliddns
{
    internal class AppConfigHelper
    {
        System.Configuration.Configuration configFile = null;
        private static readonly string fileName = "aliddns_config1.xml";
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppConfigHelper()
        {
            string configFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, fileName);
            try
            {
                if (!File.Exists(configFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", string.Empty));
                    XmlNode rootNode = xmlDoc.CreateElement("configuration");
                    //rootNode.AppendChild();
                    xmlDoc.AppendChild(rootNode);
                    xmlDoc.Save(configFilePath);
                   // XmlNode rootNode = xmlDoc.CreateElement("appSettings");
                    //XmlTextWriter textWriter = new XmlTextWriter(config_file, null);
                    //textWriter.WriteStartDocument(); //文档开始
                }
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = configFilePath;
                configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            }
            catch(Exception)
            {
                Console.WriteLine("Class AppConfigHelper running error!");
            }
        }

        /// <summary>
        /// //添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddAppSetting(string key, string value)
        {
            configFile.AppSettings.Settings.Add(key, value);
            configFile.Save();
        }

        /// <summary>
        /// //修改键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SaveAppSetting(string key, string value)
        {
            configFile.AppSettings.Settings.Remove(key);
            configFile.AppSettings.Settings.Add(key, value);

            configFile.Save();
        }

        /// <summary>
        /// //获得键值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetAppSetting(string key)
        {
            return configFile.AppSettings.Settings[key].Value;
        }

        /// <summary>
        /// //移除键值
        /// </summary>
        /// <param name="key"></param>
        public void DelAppSetting(string key)
        {
            configFile.AppSettings.Settings.Remove(key);
            configFile.Save();
        }

        public ArrayList GetXmlElements(string strElem)
        {
            ArrayList list = new ArrayList();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            XmlNodeList listNode = xmlDoc.SelectNodes(strElem);
            foreach (XmlElement el in listNode)
            {
                list.Add(el.InnerText);
            }
            return list;
        }

        /// <summary>
        /// 使用当前路径中的指定文件作为配置文件
        /// </summary>
        /// <param name="configFileName">配置文件名</param>
        public void SetConfigFile(string configFileName)
        {
            string configFilePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,    configFileName);
            System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configFilePath);
            //ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            //map.ExeConfigFilename = configFilePath;
            //configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// 使用指定路径中的指定文件作为配置文件
        /// </summary>
        /// <param name="configFileName">配置文件名</param>
        /// <param name="configFileDirectory">配置文件路径</param>
        public void SetConfigFile(string configFileName, string configFileDirectory)
        {
            string configFilePath = System.IO.Path.Combine(configFileDirectory, configFileName);
            System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configFilePath);
            //ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            //map.ExeConfigFilename = configFilePath;
            //configFile = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// 读取配置文件所有内容
        /// </summary>
        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        /// <summary>
        /// 判断appSettings中是否有此项键名
        /// </summary>
        /// /// <param name="strKey">键名</param>
        public bool AppSettingsKeyExists(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                if (key == strKey)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取设置文件中某个键的值
        /// </summary>
        /// <param name="strKey">键名</param>
        public static string GetValueByKey(string strKey)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[strKey];
        }
        public static void ModifyAppSettings(string strKey, string value)
        {
            var doc = new XmlDocument();
            //获得配置文件的全路径    
            var strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            doc.Load(strFileName);

            //找出名称为“add”的所有元素    
            var nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性    
                var xmlAttributeCollection = nodes[i].Attributes;
                if (xmlAttributeCollection != null)
                {
                    var att = xmlAttributeCollection["key"];
                    if (att == null) continue;
                    //根据元素的第一个属性来判断当前的元素是不是目标元素    
                    if (att.Value != strKey) continue;
                    //对目标元素中的第二个属性赋值    
                    att = xmlAttributeCollection["value"];
                    att.Value = value;
                }
                break;
            }
            //保存上面的修改    
            doc.Save(strFileName);
            ConfigurationManager.RefreshSection("appSettings");
        }
        static class ConfigurationUtil
        {
            public static void Synchronize<T>() where T : SettingsBase
            {
                Type type = typeof(T);
                System.Reflection.FieldInfo fieldInfo = type.GetField("defaultInstance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

                SettingsBase newInstance = global::System.Configuration.ApplicationSettingsBase.Synchronized(Activator.CreateInstance<T>());

                fieldInfo.SetValue(null, newInstance);

            }
            public static System.Configuration.Configuration OpenConfiguration(string fileName)
            {
                string extention = Path.GetExtension(fileName);

                string file = fileName.Substring(0, fileName.Length - extention.Length);
                bool createproxyFile = false;
                if (!File.Exists(file))
                {
                    createproxyFile = true;
                    File.CreateText(file).Dispose();
                }
                if (!File.Exists(fileName))
                {
                    File.WriteAllText(fileName, "<configuration/>", Encoding.UTF8);
                }
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(file);
                if (createproxyFile)
                {
                    File.Delete(file);
                }
                return config;
            }
            public static ConfigurationSectionGroup CreateApplicationSettingsGroup(System.Configuration.Configuration config)
            {
                ConfigurationSectionGroup appsg = config.RootSectionGroup.SectionGroups.Get("applicationSettings");
                if (appsg == null)
                {
                    appsg = new ApplicationSettingsGroup();
                    //appsg.Type = typeof(ApplicationSettingsGroup).AssemblyQualifiedName;  
                    config.RootSectionGroup.SectionGroups.Add("applicationSettings", appsg);
                    //创建节点  
                }
                return appsg;

            }

            public static void WriteSettingElement(Configuration config, ConfigurationSectionGroup sectionGroup, SettingsSerializeAs sas, string name, string value, string namespaceclass)
            {

                ConfigurationSection sec = sectionGroup.Sections.Get(namespaceclass);

                System.Configuration.ClientSettingsSection clisec = sec as ClientSettingsSection;
                if (clisec == null)
                {
                    //创建节  
                    clisec = new ClientSettingsSection();
                    sectionGroup.Sections.Add(namespaceclass, clisec);
                }

                SettingElement secEle = clisec.Settings.Get(name);
                if (secEle == null)
                {
                    secEle = new SettingElement(name, sas);
                    clisec.Settings.Add(secEle);

                }
                secEle.Value.ValueXml = new XmlDocument().CreateElement("value");
                if (sas == SettingsSerializeAs.Xml)
                {

                    XmlDocument xmdoc = new XmlDocument();
                    xmdoc.LoadXml(value);
                    secEle.Value.ValueXml.InnerXml = xmdoc.DocumentElement.OuterXml;

                }
                else
                {
                    secEle.Value.ValueXml.InnerText = value;
                }
            }
        }
    }
}
