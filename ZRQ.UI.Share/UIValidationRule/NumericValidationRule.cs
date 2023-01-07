using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZRQ.UI.UIValidationRule
{
    public class NumericValidationRule : ValidationRule
    {
        public Type? ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string? strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");

            bool canConvert = false;
            switch (ValidationType?.Name)
            {
                case "Boolean":
                    canConvert = bool.TryParse(strValue, out bool boolVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"请输入是或否");
                case "Int32":
                    canConvert = int.TryParse(strValue, out int intVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"请输入整数");
                case "Double":
                    canConvert = double.TryParse(strValue, out double doubleVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"请输入数字");
                case "Int64":
                    canConvert = long.TryParse(strValue, out long longVal);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of Int64");
                default:
                    throw new InvalidCastException($"{ValidationType?.Name} is not supported");
            }
        }
    }
}
