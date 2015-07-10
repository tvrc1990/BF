using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF.Log
{
    /// <summary>
    /// 表示日志输出级别的枚举
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 跟踪日志
        /// </summary>
        Track = 0,

        /// <summary>
        /// 错误日志
        /// </summary>
        Error = 2,

        /// <summary>
        /// 操作日志
        /// </summary>
        Operate = 3

    }
}
