using System;
using System.Runtime.Caching;
namespace BF.Cache
{
    public interface ICache<T>
    {
        int TimeOut { get; set; }

        void Add(string key, T value);

        T Get(string key);

        T Get(string key, Func<object[], T> loadFunc, params object[] loadParm);

        void Remove(string key);

        void Update(string key, T value);

    }
}