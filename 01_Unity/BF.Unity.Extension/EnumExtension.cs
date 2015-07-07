using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace BF.Unity.Extension
{
    /// <summary>
    /// 针对枚举描述信息的扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举值的描述信息
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string Description(this Enum enumValue)
        {
            var descriptionAttribute = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            if (descriptionAttribute == null) return string.Empty;

            return descriptionAttribute.Description;
        }

        /// <summary>
        /// 获取枚举的所有值及描述
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<TKey, string> GetDescriptions<TKey>(this Type enumType)
        {
            if (!enumType.IsEnum) throw new ArgumentException("enumType");

            var dic = new Dictionary<TKey, string>();

            var values = Enum.GetValues(enumType);

            foreach (var value in values)
            {
                var itemKey = (TKey)value;

                var itemValue = Description((Enum)value);

                dic.Add(itemKey, itemValue);
            }

            return dic;
        }


        /// <summary>
        /// 根据枚举项获取值枚举值
        /// </summary>
        public static int GetValue(this Enum obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        ///根据字符串名称获取枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetValue<T>(this string obj)
        {
            return Enum.Parse(typeof(T), obj).GetHashCode();
        }

        /// <summary>
        /// 根据枚举项获取枚举名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetName<T>(this System.Enum obj)
        {
            return Enum.GetName(typeof(T), obj);
        }

        /// <summary>
        /// 根据值获取枚举名称
        /// </summary>
        /// <returns></returns>
        public static string GetName<T>(this System.Int32 value)
        {
            return Enum.GetName(typeof(T), value);
        }


        /// <summary>
        /// 根据名称转换为枚举
        /// </summary>
        /// <returns></returns>
        public static T EnumObj<T>(this string obj)
        {
            return (T)Enum.Parse(typeof(T), obj);
        }

        /// <summary>
        /// 根据值转换为枚举
        /// </summary>
        /// <returns></returns>
        public static T EnumObj<T>(this  System.Int32 value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }


       
    }
}