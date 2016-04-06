using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Unity.Common
{
    public class AppSettings
    {
        /// <summary>
        /// 自定义配置文件
        /// </summary>
        public static readonly string DEFINED_CONFIG_PATH = "";//ConfigurationSettings.AppSettings["DefinedConfigPath"];

        /// <summary>
        /// 缓存保持时间
        /// </summary>
        public static readonly int CACHE_KEEP_TIME = 100;

        #region 动态加载对象的名称空间配置

        /// <summary>
        /// 内存缓存名称空间
        /// </summary>
        public static readonly string MEMORY_CACHE_NAMESPACE = "BF.Cache.Core.MemoryCache";

        /// <summary>
        /// XML配置处理名称空间
        /// </summary>
        public static readonly string XML_CONFIG_NAMESPACE = "BF.Config.Core.XmlConfig";

        /// <summary>
        /// 错误日志名称空间
        /// </summary>
        public static readonly string ERROR_lOG_NAMESPACE = "BF.Core.Log.ErrorLog";

        /// <summary>
        /// 信息日志名称空间
        /// </summary>
        public static readonly string INFO_LOG_NAMESPACE = "BF.Core.Log.InfoLog";

        /// <summary>
        /// DEBUG日志名称空间
        /// </summary>
        public static readonly string DEBUG_LOG_NAMESPACE = "BF.Core.Log.DebugLog";

        /// <summary>
        /// 警告日志名称空间
        /// </summary>
        public static readonly string WARM_LOG_NAMESPACE = "BF.Core.Log.WarnLog"; 

        #endregion
    }
}
