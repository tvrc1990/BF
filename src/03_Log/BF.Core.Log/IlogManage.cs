using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Log
{
    public interface IlogManage
    {
        string Get(string key);
        bool Update(string key, string content);
        bool Delete(string key);
        Dictionary<string, string> GetList(string[] key = null);
    }
}
