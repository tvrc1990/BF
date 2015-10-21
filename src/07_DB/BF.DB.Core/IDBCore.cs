using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.DB.Core
{
    public interface IDbCore<T> where T : class, new()
    {

        object Add(T t);

        bool Change(T t);

        bool Delete(T t);

        IEnumerable<T> Query(object command, object param = null);

        object Execute(object command, object param = null);

    }
}
