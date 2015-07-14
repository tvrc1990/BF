using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Config.Provider
{
    public interface IConfig
    {
        bool Set(string key, string value, string parentKey = "");

        string Get(string key);

        List<string> Gets(string parentKey);
    }
}
