using BF.Unity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Log
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
                            errorInstance = Instance(AppSettings.ERROR_lOG_NAMESPACE);
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
                            infoInstance = Instance(AppSettings.INFO_LOG_NAMESPACE);
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
                            debugInstance = Instance(AppSettings.DEBUG_LOG_NAMESPACE);
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
                            warnInstance = Instance(AppSettings.WARM_LOG_NAMESPACE);
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
