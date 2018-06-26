using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace net.nutcore.aliddns
{
    public class AppConfigHelper
    {
        public AppConfigHelper(String configFilePath)
        {
            if (!File.Exists(configFilePath))
            {

            }
                System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configFilePath);
        }
        public static string GetValueByKey(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];
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
