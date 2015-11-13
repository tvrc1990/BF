using BF.Cache.Core;
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
    public class CacheProvider<T>
    {

        private static ICache<T> memoryCacheInstance;
        private static readonly object memoryCacheLock = new object();

        public static ICache<T> XmlConfig
        {
            get
            {
                if (memoryCacheInstance == null)
                {
                    lock (memoryCacheLock)
                    {
                        if (memoryCacheInstance == null)
                        {
                            memoryCacheInstance = Instance(AppSettings.MEMORY_CACHE_NAMESPACE);
                        }
                    }
                }
                return memoryCacheInstance;
            }
        }


        private static ICache<T> Instance(string className)
        {
            return (ICache<T>)Activator.CreateInstance(Type.GetType(className));
        }


    }
}
