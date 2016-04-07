using BF.Unity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Config
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigProvider<T>
    {

        private static IConfig<T> xmlConfigInstance;
        private static readonly object xmlConfigLock = new object();

        public static IConfig<T> Xml
        {
            get
            {
                if (xmlConfigInstance == null)
                {
                    lock (xmlConfigLock)
                    {
                        if (xmlConfigInstance == null)
                        {
                            xmlConfigInstance = Instance(AppSettings.XML_CONFIG_NAMESPACE);
                        }
                    }
                }
                return xmlConfigInstance;
            }
        }


        private static IConfig<T> Instance(string className)
        {
            return (IConfig<T>)Activator.CreateInstance(typeof(XmlConfig<T>));
        }


    }
}
