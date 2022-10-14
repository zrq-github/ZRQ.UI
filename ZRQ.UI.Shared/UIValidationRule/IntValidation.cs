using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZRQ.UI.UIValidationRule
{
    /// <summary>
    /// 整数验证
    /// </summary>
    public class IntValidation : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //You can do whatever you want here
            int check;
            if (!int.TryParse(value.ToString(), out check))
            {
                //ValidationResult(false,*) => in error
                return new ValidationResult(false, "请输入整数");
            }
            //ValidationResult(true,*) => is ok
            return new ValidationResult(true, null);
        }
    }
}
