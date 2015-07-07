using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Cache
{
    public enum ExpirationType
    {
        //指定时间内没被使用就过期（动态延长）
        Sliding = 0,

        //指定时间的时候准时过期（固定）
        Absolute = 1,
    }
}
