using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZRQ.UI.Utils
{
    /// <summary>
    /// 正则表达式的一些合集
    /// </summary>
    /// <remarks>
    /// 存放一些正则表达式的用处
    /// </remarks>
    public static class RegexMatch
    {
        public static bool IsTelePhone(string telePhone)
        {
            return Regex.IsMatch(telePhone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        public static bool IsMobilePhone(string mobilePhone)
        {
            return Regex.IsMatch(mobilePhone, @"^[1]([3][0-9]{1}|59|58|88|89)[0-9]{8}$");
        }

        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        public static bool IsHomePage(string email)
        {
            return Regex.IsMatch(email, @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}
