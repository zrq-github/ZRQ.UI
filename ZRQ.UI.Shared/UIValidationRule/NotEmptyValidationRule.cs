using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZRQ.UIShared.UIValidationRule
{
    /// <summary>
    /// 不会为空
    /// </summary>
    internal class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString()) ?
                new ValidationResult(false, "不能为空") : new ValidationResult(true, null);
        }
    }
}
