using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Configuration
{
    public interface IConfig<T>
    {

        bool Update(string key, string value, string preKey = "");

        bool Add(string key, string value, string preKey = "");

        T Get(string key, string preKey = "");

        List<T> GetArray(string key, string preKey = "");

    }
}
