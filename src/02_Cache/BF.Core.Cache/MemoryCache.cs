using BF.Unity.Common;
using System;
using System.Runtime.Caching;
namespace BF.Core.Cache
{
    

    public abstract class Cache<T>
    {
        private int _timeOut;

        public Cache(ExpirationType expirationPolicy)
        {
            ExpirationPolicy = expirationPolicy;
        }

        ///ttt
        /// 以秒为基础单位默认10分钟 ///
        public int TimeOut
        {
            //app config undefined
            get { return _timeOut == 0 ? AppSettings.CACHE_KEEP_TIME : _timeOut; }
            set { _timeOut = value; }
        }

        private ExpirationType ExpirationPolicy { set; get; }

        public virtual void Set(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key) || value.Equals(null)) return;
            var expirationPolicy = new CacheItemPolicy();
            if (ExpirationPolicy == ExpirationType.Absolute)
                expirationPolicy.AbsoluteExpiration = DateTimeOffset.Now.Add(new TimeSpan(0, 0, TimeOut));
            else expirationPolicy.SlidingExpiration = new TimeSpan(0, 0, TimeOut);
            ;
            MemoryCache.Default.Set(key, value, expirationPolicy);
        }

        public virtual T Get(string key)
        {
            return (T) MemoryCache.Default.Get(key);
        }

        public virtual T Get(string key, Func<object[], T> loadFunc, params object[] loadParm)
        {
            var result = (T) MemoryCache.Default.Get(key);
            if (result == null && loadFunc != null)
            {
                result = loadFunc(loadParm);
                Set(key, result);
            }
            return result;
        }

        public virtual void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            MemoryCache.Default.Remove(key);
        }

        public virtual void Update(string key, T value)
        {
            Remove(key);
            Set(key, value);
        }
    }
}