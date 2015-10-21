using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Log
{
    /// <summary>
    /// 
    /// </summary>
    public class LogProvider
    {

        private static ILog errorInstance;
        private static readonly object ErrorLock = new object();

        private static ILog debugInstance;
        private static readonly object DebugLock = new object();

        private static ILog infoInstance;
        private static readonly object InfoLock = new object();

        private static ILog warnInstance;
        private static readonly object WarnLock = new object();

        //app config undefined
        //需要移动到配置系统
        private static string errorLogConfig = "BF.Log.ErrorLog";
        private static string InfoLogConfig = "BF.Log.InfoLog";
        private static string debugLogConfig = "BF.Log.DebugLog";
        private static string warmLogConfig = "BF.Log.WarnLog";

        public static ILog Error
        {
            get
            {
                if (errorInstance == null)
                {
                    lock (ErrorLock)
                    {
                        if (errorInstance == null)
                        {
                            errorInstance = Instance(errorLogConfig);
                        }
                    }
                }
                return errorInstance;
            }
        }

        public static ILog Info
        {
            get
            {
                if (infoInstance == null)
                {
                    lock (InfoLock)
                    {
                        if (infoInstance == null)
                        {
                            infoInstance = Instance(InfoLogConfig);
                        }
                    }
                }
                return infoInstance;
            }
        }

        public static ILog Debug
        {
            get
            {
                if (debugInstance == null)
                {
                    lock (DebugLock)
                    {
                        if (debugInstance == null)
                        {
                            debugInstance = Instance(debugLogConfig);
                        }
                    }
                }
                return debugInstance;
            }
        }

        public static ILog Warn
        {
            get
            {
                if (warnInstance == null)
                {
                    lock (WarnLock)
                    {
                        if (warnInstance == null)
                        {
                            warnInstance = Instance(warmLogConfig);
                        }
                    }
                }
                return warnInstance;
            }
        }

        private static ILog Instance(string className)
        {
            return (ILog)Activator.CreateInstance(Type.GetType(className));
        }


    }
}
