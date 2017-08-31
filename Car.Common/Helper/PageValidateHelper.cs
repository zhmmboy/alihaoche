using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Common
{
    public static class PageValidateHelper
    {

        /// <summary>
        /// 过滤SQL语句,防止注入
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>true - 没有注入, false - 有注入 </returns>
        public static bool IsSafeKey(string key)
        {
            int srcLen, decLen = 0;
            key = key.ToLower().Trim();
            srcLen = key.Length;
            key = key.Replace("exec", "");
            key = key.Replace("delete", "");
            key = key.Replace("master", "");
            key = key.Replace("truncate", "");
            key = key.Replace("declare", "");
            key = key.Replace("create", "");
            key = key.Replace("xp_", "no");
            decLen = key.Length;
            if (srcLen == decLen)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 过滤SQL关键字,防止注入
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>返回过滤后的安全的字符串 </returns>
        public static string Filter(string key)
        {
            int srcLen, decLen = 0;
            key = key.ToLower().Trim();
            srcLen = key.Length;
            key = key.Replace("exec", "");
            key = key.Replace("delete", "");
            key = key.Replace("master", "");
            key = key.Replace("truncate", "");
            key = key.Replace("declare", "");
            key = key.Replace("create", "");
            key = key.Replace("xp_", "no");
            decLen = key.Length;

            return key;
        }
    }
}
