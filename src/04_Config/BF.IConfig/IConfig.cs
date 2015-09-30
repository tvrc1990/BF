using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.IConfig
{
    public class IConfig
    {
        bool Update(string key, object value);

        bool Add(string preKey, string key, object value);

        object Read(string key);

        List<object> NextRed(string key);

    }
}
