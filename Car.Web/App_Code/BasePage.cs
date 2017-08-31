using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car.Web
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            //检测是否登陆
            CommonUtility.CheckUserLogin();
        }

        /// <summary>
        /// 获取指定参数的整数形式
        /// </summary>
        /// <param name="RequestStr">请求参数名称</param>
        /// <param name="DefaultValue">默认值（请求参数为空）</param>
        /// <returns></returns>
        public static int GetQueryInt(string RequestStr, int DefaultValue)
        {
            try
            {
                return GetQueryString(RequestStr) != "" ? Convert.ToInt32(GetQueryString(RequestStr)) : DefaultValue;
            }
            catch (Exception ex) { return 0; }
        }

        /// <summary>
        /// 根据请求字符串参数名获取该参数的值
        /// </summary>
        /// <param name="RequestStr">请求的参数名</param>
        /// <param name="IsSafeCheck">是否进行参数的安全检测</param>
        /// <returns></returns>
        public static string GetQueryString(string RequestStr, bool IsSafeCheck)
        {
            if (IsSafeCheck)
            {
                return IsSafeRequestString(GetQueryString(RequestStr)) ? GetQueryString(RequestStr) : "";
            }
            return GetQueryString(RequestStr);
        }

        public static string GetQueryString(string RequestStr)
        {
            return HttpContext.Current.Request[RequestStr] != null ? HttpContext.Current.Request[RequestStr].ToString().Trim() : "";
        }

        public static string GetFormString(string RequestStr, bool IsSafeCheck)
        {
            if (IsSafeCheck)
                return (FilterSQLKeys(GetFormString(RequestStr)) == GetFormString(RequestStr)) ? GetFormString(RequestStr) : "";
            return GetFormString(RequestStr);
        }

        public static string GetFormString(string RequestStr)
        {
            return (HttpContext.Current.Request.Form != null && HttpContext.Current.Request.Form[RequestStr] != null) ? HttpContext.Current.Request.Form[RequestStr].ToString().Trim() : "";
        }

        /// <summary>
        /// 检测该字符串是否安全
        /// </summary>
        /// <param name="checkText">要检查的文本</param>
        /// <returns></returns>
        public static bool IsSafeRequestString(string checkText)
        {
            //说明：不能存在'+空格的存在，并且，不能有空格+字符+空格的命令存在
            string sqlString = @" |and|exec|insert|select|delete|update|count|\*|\%|chr|mid|master|truncate|char|declare|from|drop|char|xp_cmdshell|exec master|net localgroup administrators|not user|or|net|-|<|>|'|""|script";
            bool isSafe = true;
            for (int i = 0; i < sqlString.Split('|').Length; i++)
            {
                if (checkText.ToLower().IndexOf(sqlString.Split('|')[i]) > 0)
                {
                    isSafe = false; break;//发现不安全字符，退出循环，直接返回
                }
            }
            return isSafe;
        }

        /// <summary>
        /// 过滤请求的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterSQLKeys(string str)
        {
            if (str == null || str.Trim() == "")
                return "";
            str = str.Replace(";", "");
            str = str.Replace("'", "");
            str = str.Replace("&", "");
            str = str.Replace("%20", "");
            str = str.Replace("--", "");
            str = str.Replace("==", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            str = str.Replace("%", "");
            str = str.Replace("+", "");
            //str = str.Replace("-", "");
            str = str.Replace("=", "");
            str = str.Replace(",", "");
            return str;
        }

    }
}