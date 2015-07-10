using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
namespace BF.Unity.Helper
{
    public class Reflex
    {


        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetProperty(object obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null && property.CanRead)
            {
                property.SetValue(obj, value, null);

                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetProperty(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                return property.GetValue(obj, null);

            }
            return null;
        }


        /// <summary>
        /// 动态创建指定程序集的对象
        /// </summary>
        /// <param name="loadPath"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static object InstanceObj(string loadPath, string className)
        {
            Assembly assembly = Assembly.LoadFile(loadPath); // 加载程序集（EXE 或 DLL）
            var obj = assembly.CreateInstance(className); // 创建类的实例
            return obj;
        }

    }
}