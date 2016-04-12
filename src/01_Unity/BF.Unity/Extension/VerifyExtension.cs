using System;
using System.Text.RegularExpressions;
namespace BF.Unity.Extension
{
    /// <summary>
    /// http://blog.bossma.cn/all/csharp-filter-or-strip-script-by-regular-expression/
    /// </summary>
    public static class VerifyExtension
    {
        /// <summary>
        /// IP验证(格式：xxx.xxx.xxx.xxx || xxx-xxx-xxx-xxx)
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsIP(this string strObj)
        {
            var result = Regex.IsMatch(strObj, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            if (!result)
            {
                result = Regex.IsMatch(strObj, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\-(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\-(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\-(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            }
            return result;
        }
        /// <summary>
        /// 检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。
        /// </summary>
        /// <param name="strObj">需验证的字符串。</param>
        /// <returns>是否可以转化为日期的bool值。</returns>
        public static bool IsDate(this string strObj)
        {
            DateTime dateTime;
            return DateTime.TryParse(strObj, out dateTime);
        }

        /// <summary>
        /// 检测是否全是中文字符
        /// </summary>
        /// <returns></returns>
        public static bool IsHasCHZN(this string strObj)
        {
            var regCHZN = new Regex("^[\u4e00-\u9fa5]+$");
            var m = regCHZN.Match(strObj);
            return m.Success;
        }
        /// <summary>
        /// 检查一个字符串是否是纯数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="strObj">需验证的字符串。。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsNumeric(this string strObj)
        {
            var result = strObj.IsInt();
            if (!result)
            {
                result = strObj.IsDecimal();
            }
            return result;
        }
        /// <summary>
        /// 检查一个字符串是否是纯字母和数字构成的，一般用于查询字符串参数的有效性验证。
        /// </summary>
        /// <param name="strObj">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsLetterOrNumber(string strObj)
        {
            return QuickValidate("^[a-zA-Z0-9_]*$", strObj);
        }
        /// <summary>
        /// 判断是否是小数
        /// </summary>
        /// <param name="strObj">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool IsDecimal(this string strObj)
        {
            return Regex.IsMatch(strObj, "^([0-9]{1,}[.][0-9]*)$");
        }
        /// <summary>
        /// 快速验证一个字符串是否符合指定的正则表达式。
        /// </summary>
        /// <param name="express">正则表达式的内容。</param>
        /// <param name="strObj">需验证的字符串。</param>
        /// <returns>是否合法的bool值。</returns>
        public static bool QuickValidate(this string strObj, string express)
        {
            var regex = new System.Text.RegularExpressions.Regex(express);
            if (strObj.Length == 0)
            {
                return false;
            }
            return regex.IsMatch(strObj);
        }
        /// <summary>
        /// 判断一个字符串是否为邮件
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsEmail(this string strObj)
        {
            var r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (r.IsMatch(strObj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断一个字符串是否为Int
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsInt(this string strObj)
        {
            return Regex.IsMatch(strObj, "^([0-9]{1,})$");
        }
        /// <summary>
        /// 判断一个字符串是否为手机号码
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsMobile(this string strObj)
        {
            //Regex regex = new Regex(@"^13/d$", RegexOptions.IgnoreCase);
            //return regex.Match(strObj).Success;
            //电信手机号码正则
            string dianxin = @"^1[3578][01379]\d{8}$";
            var dReg = new Regex(dianxin);
            //联通手机号正则
            string liantong = @"^1[34578][01256]\d{8}$";
            var tReg = new Regex(liantong);
            //移动手机号正则       
            string yidong = @"^(134[012345678]\d{7}|1[34578][012356789]\d{8})$";
            var yReg = new Regex(yidong);
            if (dReg.IsMatch(strObj) || tReg.IsMatch(strObj) || yReg.IsMatch(strObj))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断一个字符串是否为座机
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsTel(this string strObj)
        {
            var regex = new Regex(@"(\(\d{3,4}\)|\d{3,4}-|\s)?\d{8}");
            return regex.IsMatch(strObj);
        }
        /// <summary>
        /// 判断一个字符串是否为电话号码（手机或者座机）
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsPhone(this string strObj)
        {
            var result = strObj.IsMobile();
            //不是手机就判断是否是座机
            if (!result)
            {
                result = strObj.IsTel();
            }
            return result;
        }
        /// <summary>
        /// 判断一个字符串是否为字母加数字
        /// Regex("[a-zA-Z0-9]?"
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static bool IsLetterAndNum(this string strObj)
        {
            var regex = new Regex("[a-zA-Z0-9]?");
            return regex.Match(strObj).Success;
        }
        /// <summary>
        /// 判断一个字符串是否为省份证格式
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsIDCard(this string strObj)
        {
            switch (strObj.Length)
            {
                case 18:
                    return CheckIdCard18(strObj);
                case 15:
                    return CheckIdCard15(strObj);
                default:
                    return false;
            }
        }

        /// <summary>
        /// 验证18位身份证格式
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns>返回字符串,出错信息</returns>
        public static bool CheckIdCard18(string strObj)
        {
            var aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            double iSum = 0;
            var rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|X|x)$");
            var mc = rg.Match(strObj);
            if (!mc.Success)
            {
                return false;///"- 您的身份证号码格式有误!";
            }
            strObj = strObj.ToLower();
            strObj = strObj.Replace("x", "a");
            if (aCity[int.Parse(strObj.Substring(0, 2))] == null)
            {
                return false;//"- 您的身份证号码格式有误!";//非法地区
            }
            try
            {
                DateTime.Parse(strObj.Substring(6, 4) + "-" + strObj.Substring(10, 2) + "-" + strObj.Substring(12, 2));
            }
            catch
            {
                return false;//"- 您的身份证号码格式有误!";//非法生日
            }
            for (int i = 17; i >= 0; i--)
            {
                iSum += (System.Math.Pow(2, i) % 11) * int.Parse(strObj[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            if (iSum % 11 != 1)
                return false;//("- 您的身份证号码格式有误!");//非法证号
            return true;
        }
        /// <summary>
        /// 验证15位身份证格式
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool CheckIdCard15(string strObj)
        {
            var aCity = new string[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };
            var rg = new System.Text.RegularExpressions.Regex(@"^\d{15}$");
            var mc = rg.Match(strObj);
            if (!mc.Success)
            {
                return false;
            }
            strObj = strObj.ToLower();
            strObj = strObj.Replace("x", "a");
            if (int.Parse(strObj.Substring(0, 2)) > aCity.Length)
            {
                return false;//非法地区
            }
            if (aCity[int.Parse(strObj.Substring(0, 2))] == null)
            {
                return false;//非法地区
            }
            try
            {
                DateTime.Parse(strObj.Substring(6, 2) + "-" + strObj.Substring(8, 2) + "-" + strObj.Substring(10, 2));
            }
            catch
            {
                return false;//非法生日
            }
            return true;
        }
        /// <summary>
        /// 检查是否包含特定的字符串
        /// </summary>
        /// <param name="strObj"></param>
        /// <returns></returns>
        public static bool IsSensitive(this string strObj)
        {
            var regexExpression = "(<script>)|(</script>)|(<div>)|(</div>)";
            var regex = new Regex(regexExpression, RegexOptions.IgnoreCase);
            var result = regex.IsMatch(strObj);
            return result;
        }
    }
}