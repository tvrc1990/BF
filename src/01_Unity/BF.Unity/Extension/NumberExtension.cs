using System;
using System.ComponentModel;
namespace BF.Unity.Extension
{
    /// <summary>
    /// 数据操作四舍五入类型
    /// </summary>
    public enum RoundType
    {
        [Description("不采用四舍五入")]
        None = 0,
        [Description("四舍六入五凑偶算法(国际通用)")]
        BankerRound = 1,
        [Description("中国常规算法大于4都入1位")]
        Normal = 2
    }
    /// <summary>
    /// 类型转换&值形态转换
    /// </summary>
    public static class NumberExtension
    {
        /// <summary>
        /// 转换为日期默认格式为（转换失败就返回最小时间：0001/1/1 0:00:00）
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static DateTime ToDate(this string strObj)
        {
            var result = DateTime.MinValue;
            DateTime.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Int32
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static int ToInteger(this string strObj, int defavultValue = 0)
        {
            var result = defavultValue;
            int.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Int64
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static long ToLong(this string strObj, long defavultValue = 0)
        {
            long result;
            long.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Byte
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static byte ToByte(this string strObj, byte defavultValue = 0)
        {
            byte result;
            byte.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Decimal
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string strObj, decimal defavultValue = 0)
        {
            decimal result;
            decimal.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Double
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static double ToDouble(this string strObj, double defavultValue = 0)
        {
            double result;
            double.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 字符串转换为Float
        /// </summary>
        /// <param name="strObj"></param>
        /// <param name="defavultValue"></param>
        /// <returns></returns>
        public static float ToFloat(this string strObj, float defavultValue = 0)
        {
            float result;
            float.TryParse(strObj, out result);
            return result;
        }
        /// <summary>
        /// 保留double指定位数并且指定四舍五入的方式
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keepCount">保留位数</param>
        /// <param name="roundType">四舍五入的方式</param>
        /// <returns></returns>
        public static double ToRound(this double value, int keepCount = 2, RoundType roundType = RoundType.Normal)
        {
            double result = 0;
            switch (roundType)
            {
                case RoundType.BankerRound:
                    result = Math.Round(value, keepCount);
                    break;
                case RoundType.Normal:
                    result = Math.Round(value, keepCount, MidpointRounding.AwayFromZero);
                    break;
                case RoundType.None:
                    int factor = 1;
                    for (int i = 1; i <= keepCount; i++)
                    {
                        factor = factor * 10;
                    }
                    int tempNum = (int)(value * factor);
                    result = (tempNum * 1.0) / factor;
                    break;
            }
            return result;
        }
        /// <summary>
        /// 保留float指定位数并且指定四舍五入的方式
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keepCount">保留位数</param>
        /// <param name="roundType">四舍五入的方式</param>
        /// <returns></returns>
        public static float ToRound(this float value, int keepCount = 2, RoundType roundType = RoundType.Normal)
        {
            float result = 0f;
            switch (roundType)
            {
                case RoundType.BankerRound:
                    result = (float)Math.Round(value, keepCount);
                    break;
                case RoundType.Normal:
                    result = (float)Math.Round(value, keepCount, MidpointRounding.AwayFromZero);
                    break;
                case RoundType.None:
                    int factor = 1;
                    for (int i = 1; i <= keepCount; i++)
                    {
                        factor = factor * 10;
                    }
                    int tempNum = (int)(value * factor);
                    result = (float)(tempNum * 1.0) / factor;
                    break;
            }
            return result;
        }
        /// <summary>
        /// 保留decimal指定位数并且指定四舍五入的方式
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keepCount">保留位数</param>
        /// <param name="roundType">四舍五入的方式</param>
        /// <returns></returns>
        public static decimal ToRound(this decimal value, int keepCount = 2, RoundType roundType = RoundType.Normal)
        {
            decimal result = 0m;
            switch (roundType)
            {
                case RoundType.BankerRound:
                    result = Math.Round(value, keepCount);
                    break;
                case RoundType.Normal:
                    result = Math.Round(value, keepCount, MidpointRounding.AwayFromZero);
                    break;
                case RoundType.None:
                    int factor = 1;
                    for (int i = 1; i <= keepCount; i++)
                    {
                        factor = factor * 10;
                    }
                    int tempNum = (int)(value * factor);
                    result = (decimal)(tempNum * 1.0) / factor;
                    break;
            }
            return result;
        }
    }
}