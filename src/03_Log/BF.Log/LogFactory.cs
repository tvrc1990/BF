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
    public class LogFactory
    {

        private static ILog errorInstance;
        private static readonly object ErrorLock = new object();

        private static ILog operateInstance;
        private static readonly object OperateLock = new object();

        private static ILog trackInstance;
        private static readonly object TrackLock = new object();

        //app config undefined
        //需要移动到配置系统
        private static string errorLogConfig = "BF.Log.ErrorLog";
        private static string trackLogConfig = "BF.Log.TrackLog";
        private static string operateLogConfig = "BF.Log.OperateLog";


        public static ILog ErrorInstance()
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

        public static ILog TrackFactory()
        {
            if (trackInstance == null)
            {
                lock (TrackLock)
                {
                    if (trackInstance == null)
                    {
                        trackInstance = Instance(trackLogConfig);
                    }
                }
            }
            return trackInstance;
        }

        public static ILog OperateFactory()
        {
            if (operateInstance == null)
            {
                lock (OperateLock)
                {
                    if (operateInstance == null)
                    {
                        operateInstance = Instance(operateLogConfig);
                    }
                }
            }
            return operateInstance;
        }

        private static ILog Instance(string className)
        {
            return (ILog)Activator.CreateInstance(Type.GetType(className));
        }


    }
}
