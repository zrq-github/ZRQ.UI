using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZRQ.UI.UIValidationRule
{
    public class DoubleValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            //You can do whatever you want here
            double check;
            if (!double.TryParse(value.ToString(), out check))
            {
                //ValidationResult(false,*) => in error
                return new ValidationResult(false, "请输入数字");
            }
            //ValidationResult(true,*) => is ok
            return new ValidationResult(true, null);
        }
    }
}
