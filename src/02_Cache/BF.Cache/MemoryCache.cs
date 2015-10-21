using System;
using System.Runtime.Caching;
namespace BF.Cache
{


    public abstract class MemoryCache<T> : ICache<T>
    {
        private int _timeOut;

        public MemoryCache(ExpirationType expirationPolicy)
        {
            ExpirationPolicy = expirationPolicy;
        }

        ///
        /// 以秒为基础单位默认10分钟 ///
        public int TimeOut
        {
            //app config undefined
            get { return _timeOut == 0 ? 600 : _timeOut; }
            set { _timeOut = value; }
        }

        private ExpirationType ExpirationPolicy { set; get; }

        public void Add(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key) || value.Equals(null)) return;
            var expirationPolicy = new CacheItemPolicy();
            if (ExpirationPolicy == ExpirationType.Absolute)
                expirationPolicy.AbsoluteExpiration = DateTimeOffset.Now.Add(new TimeSpan(0, 0, TimeOut));
            else expirationPolicy.SlidingExpiration = new TimeSpan(0, 0, TimeOut);
            ;
            MemoryCache.Default.Set(key, value, expirationPolicy);
        }

        public T Get(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        public T Get(string key, Func<object[], T> loadFunc, params object[] loadParm)
        {
            var result = (T)MemoryCache.Default.Get(key);
            if (result == null && loadFunc != null)
            {
                result = loadFunc(loadParm);
                Add(key, result);
            }
            return result;
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            MemoryCache.Default.Remove(key);
        }

        public void Update(string key, T value)
        {
            Remove(key);
            Add(key, value);
        }
    }
}