﻿using System;
using System.Text;
using System.Web;

namespace BF.Unity.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 将特定字符分隔的字符串转换为INT数组
        /// </summary>
        public static int[] ToIntArray(this string strObj, char splitChar)
        {
            if (strObj.Length == 0)
            {
                return new int[] { };
            }

            var strArray = strObj.Split(new char[] { splitChar }, StringSplitOptions.RemoveEmptyEntries);
            var intArray = new int[strArray.Length];

            for (var i = 0; i < strArray.Length; i++)
                intArray[i] = int.Parse(strArray[i]);

            return intArray;
        }

        /// <summary>
        /// 将特定字符分隔的字符串转换为String数组
        /// </summary>
        public static string[] ToStrArray(this string strObj, char splitChar)
        {
            if (strObj.Length == 0)
            {
                return new string[] { };
            }

          return strObj.Split(new char[] { splitChar }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 获取字符串左边指定的字节个数
        /// </summary>
        public static string Left(this string strObj, int leftCount, string appendString = "")
        {
            if (string.IsNullOrEmpty(strObj))
                return string.Empty;
            int i = 0, j = 0;
            foreach (char c in strObj)
            {
                if (c > 127)
                {
                    i += 2;
                }
                else
                {
                    i++;
                }

                if (i > leftCount)
                {
                    return strObj.Substring(0, j) + appendString;
                }

                j++;
            }

            return strObj;
        }

        /// <summary>
        /// 字符串真实长度 如:一个汉字为两个字节
        /// </summary>
        public static int GetSize(this string strObj)
        {
            return Encoding.Default.GetBytes(strObj).Length;
        }      

        /// <summary>
        /// 对 HTML 编码的字符串进行编码，并返回已编码的字符串。
        /// </summary>
        public static string HtmlEncode(this string strObj)
        {
            return HttpUtility.HtmlEncode(strObj);
        }

        /// <summary>
        /// 对 HTML 编码的字符串进行解码，并返回已解码的字符串。
        /// </summary>
        public static string HtmlDecode(this string strObj)
        {
            return HttpUtility.HtmlDecode(strObj);
        }

    }
}
