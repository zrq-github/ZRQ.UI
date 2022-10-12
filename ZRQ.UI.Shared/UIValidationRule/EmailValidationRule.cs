using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZRQ.UI.UIValidationRule
{
    /// <summary>
    /// 邮箱验证
    /// </summary>
    internal class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex emailRegex = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            string str = (value ?? "").ToString();
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (!emailRegex.IsMatch(str))
                {
                    return new ValidationResult(false, "邮箱地址错误！");
                }
            }
            return new ValidationResult(true, null);
        }
    }
}
