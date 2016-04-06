using BF.Unity.Common;
using BF.Unity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Config
{
    public class XmlConfig : IConfig<string>
    {
        private string xmlPath = "";
        public XmlConfig()
        {
            this.xmlPath = AppSettings.DEFINED_CONFIG_PATH;
        }
        public bool Update(string key, string value, string preKey = "configuration/appSettings")
        {
            return XmlHelper.UpdateAttribute(xmlPath, key, value, preKey);
        }

        public bool Add(string key, string value, string preKey = "configuration/appSettings")
        {
           return XmlHelper.Insert(xmlPath, key, value, key, preKey);
        }

        public string Get(string key, string preKey = "configuration/appSettings")
        {
            return XmlHelper.GetElementValues(xmlPath, preKey).FirstOrDefault();
        }

        public List<string> GetArray(string key, string preKey = "configuration/appSettings")
        {
            return XmlHelper.GetElementValues(xmlPath, preKey,"value");
        }
    }
}
