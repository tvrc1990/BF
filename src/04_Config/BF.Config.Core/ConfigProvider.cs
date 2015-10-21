using BF.Unity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Config.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigProvider
    {

        private static IConfig<string> xmlConfigInstance;
        private static readonly object xmlConfigLock = new object();

        public static IConfig<string> XmlConfig
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


        private static IConfig<string> Instance(string className)
        {
            return (IConfig<string>)Activator.CreateInstance(Type.GetType(className));
        }


    }
}
