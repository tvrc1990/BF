using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BF.Unity.Extension
{

    public static class CryptoExtension
    {

        /// <summary>
        /// 必须是8位
        /// </summary>
        public static string SecretKey
        {
            set { value = SecretKey; }
            get { return "12345678"; }
        }

        /// <summary>
        /// 32位DESC加密
        /// </summary>
        public static string DESCEncrypt(this string strObj)
        {
            var des = new DESCryptoServiceProvider();
            byte[] valueByteArray = Encoding.Default.GetBytes(strObj);
            des.Key = Encoding.ASCII.GetBytes(SecretKey);//Key 必须是8位
            des.IV = Encoding.ASCII.GetBytes(SecretKey);
            using (var ms = new MemoryStream())
            {
                var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(valueByteArray, 0, valueByteArray.Length);
                cs.FlushFinalBlock();
                var result = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    result.AppendFormat("{0:X2}", b);
                }
                return result.ToString();
            }

        }

        /// <summary>
        /// 32位DESC解密
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static string DESCDecrypt(this string strObj)
        {
            var des = new DESCryptoServiceProvider();

            var valueByteArray = new byte[strObj.Length / 2];
            for (int x = 0; x < strObj.Length / 2; x++)
            {
                int i = (Convert.ToInt32(strObj.Substring(x * 2, 2), 16));
                valueByteArray[x] = (byte)i;
            }

            des.Key = Encoding.ASCII.GetBytes(SecretKey);
            des.IV = Encoding.ASCII.GetBytes(SecretKey);
            using (var ms = new MemoryStream())
            {
                var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(valueByteArray, 0, valueByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static string MD5Encrypt(this string strObj)
        {
            var md5 = new MD5CryptoServiceProvider();
            var fromData =Encoding.Unicode.GetBytes(strObj);
            var targetData = md5.ComputeHash(fromData);
            return targetData.Aggregate<byte, string>(null, (current, t) => current + t.ToString("x"));

        }

    }
}
