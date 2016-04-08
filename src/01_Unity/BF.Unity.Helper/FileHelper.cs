// -----------------------------------------------------------------------
//  <copyright file="FileHelper.cs" company="OSharp开源团队">
//      Copyright (c) 2014 OSharp. All rights reserved.
//  </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-07-18 18:25</last-date>
// -----------------------------------------------------------------------

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace BF.Unity.Helper
{
    /// <summary>
    /// 文件辅助操作类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 删除文件（到回收站[可选]）
        /// </summary>
        /// <param name="filePath">要删除的文件名</param>
        /// <param name="isSendToRecycleBin">是否删除到回收站</param>
        public static void Delete(string filePath, bool isSendToRecycleBin = false)
        {
            if (isSendToRecycleBin)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
            }
            else
            {
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// 设置或取消文件的指定<see cref="FileAttributes"/>属性
        /// </summary>
        /// <param name="filePath">文件名</param>
        /// <param name="attribute">要设置的文件属性</param>
        /// <param name="isSet">true为设置，false为取消</param>
        public static void SetAttribute(string filePath, FileAttributes attribute, bool isSet)
        {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists)
            {
                throw new FileNotFoundException("要设置属性的文件不存在。", filePath);
            }
            if (isSet)
            {
                fi.Attributes = fi.Attributes | attribute;
            }
            else
            {
                fi.Attributes = fi.Attributes & ~attribute;
            }
        }

        /// <summary>
        /// 获取文件版本号
        /// </summary>
        /// <param name="filePath"> 完整文件名 </param>
        /// <returns> 文件版本号 </returns>
        public static string GetVersion(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(filePath);
                return fvi.FileVersion;
            }
            return null;
        }

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="filePath"> 文件名 </param>
        /// <returns> 32位MD5 </returns>
        public static string GetFileMd5(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            const int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize];

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();

            long offset = 0;
            while (offset < fs.Length)
            {
                long readSize = bufferSize;
                if (offset + readSize > fs.Length)
                {
                    readSize = fs.Length - offset;
                }
                fs.Read(buffer, 0, (int)readSize);
                if (offset + readSize < fs.Length)
                {
                    md5.TransformBlock(buffer, 0, (int)readSize, buffer, 0);
                }
                else
                {
                    md5.TransformFinalBlock(buffer, 0, (int)readSize);
                }
                offset += bufferSize;
            }
            fs.Close();
            byte[] result = md5.Hash;
            md5.Clear();
            StringBuilder sb = new StringBuilder(32);
            foreach (byte b in result)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">写入内容</param>
        /// <param name="isAppend">追加/覆盖</param>
        /// <returns></returns>
        public static bool Write(string filePath, string content, bool isAppend = false)
        {
            using (var fileStream = new FileStream(filePath, isAppend ? FileMode.Append : FileMode.Truncate))
            {
                var contentBytes = new byte[content.Length];
                Encoding.UTF8.GetEncoder().GetBytes(content.ToCharArray(), 0, content.Length, contentBytes, 0, true);
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.Write(contentBytes, 0, contentBytes.Length);
            }
            return true;
        }

    }
}