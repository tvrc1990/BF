using BF.Unity.Common;
using BF.Unity.Helper;
using BF.Unity.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Config
{
    public class XmlConfig<T> : IConfig<T>
    {
        private string xmlPath = string.Empty;

        public XmlConfig()
        {
            this.xmlPath = string.Format("{0}\\{1}.config", AppDomain.CurrentDomain.BaseDirectory, typeof(T).Name);
        }

        public T Get(string key = "")
        {
            var xml = XmlHelper.GetInnerXML(xmlPath, key).LastOrDefault();
            return xml.ToObject<T>();
        }


    }
}
