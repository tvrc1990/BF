using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BF.Unity.Common
{
    public class AppSettings
    {
        private static Dictionary<string, string> ConfigDictionary = new Dictionary<string, string>();

        public static string Get(string key)
        {

            var value = string.Empty;

            if (ConfigDictionary.ContainsKey(key))
            {
                value = ConfigDictionary[key];
            }
            else
            {
                value = System.Configuration.ConfigurationManager.AppSettings[key];
                value = string.IsNullOrEmpty(value) ? "" : value;
                ConfigDictionary.Add(key, value);
            }

            return value;
        }

        public static int GetInt(string key)
        {
            var temp = Get(key);
            int value = 0;
            return int.TryParse(temp, out value) ? value : 0;
        }

        /// <summary>
        /// 自定义配置文件
        /// </summary>
        public static readonly string DEFINED_CONFIG_PATH = Get("DEFINED_CONFIG_PATH");

        /// <summary>
        /// 缓存保持时间
        /// </summary>
        public static readonly int CACHE_KEEP_TIME = GetInt("CACHE_KEEP_TIME");

        #region 动态加载对象的名称空间配置

        /// <summary>
        /// 内存缓存名称空间
        /// </summary>
        public static readonly string MEMORY_CACHE_NAMESPACE = Get("MEMORY_CACHE_NAMESPACE");

        /// <summary>
        /// XML配置处理名称空间
        /// </summary>
        public static readonly string XML_CONFIG_NAMESPACE = Get("XML_CONFIG_NAMESPACE");

        /// <summary>
        /// 错误日志名称空间
        /// </summary>
        public static readonly string ERROR_lOG_NAMESPACE = Get("ERROR_lOG_NAMESPACE");

        /// <summary>
        /// 信息日志名称空间
        /// </summary>
        public static readonly string INFO_LOG_NAMESPACE = Get("INFO_LOG_NAMESPACE");

        /// <summary>
        /// DEBUG日志名称空间
        /// </summary>
        public static readonly string DEBUG_LOG_NAMESPACE = Get("DEBUG_LOG_NAMESPACE");

        /// <summary>
        /// 警告日志名称空间
        /// </summary>
        public static readonly string WARM_LOG_NAMESPACE = Get("WARM_LOG_NAMESPACE");

        #endregion
    }
}
