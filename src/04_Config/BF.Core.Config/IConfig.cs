using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Core.Config
{
    public interface IConfig<T>
    {

        bool Update(T value, string key = "");

        bool Delete(string key = "");

        T Get(string key = "");

    }
}
