using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ZRQ.UI.UIValidationRule
{
    /// <summary>
    /// 数值范围验证
    /// </summary>
    /// <remarks>
    /// 默认转换成 double 进行比较
    /// 有最小值,无最大值 默认 大于等于最小值
    /// 无最小值,有最大致 默认 小于等于最大值
    /// </remarks>
    internal class RangeValidationRule : ValidationRule
    {
        public double Min { get; set; } = double.NaN;
        public double Max { get; set; } = double.NaN;

        /// <summary>
        /// 左闭区间
        /// </summary>
        public bool IsLeftClose { get; set; } = true;

        /// <summary>
        /// 右闭区间
        /// </summary>
        public bool IsRightClose { get; set; } = true;

        /// <summary>
        /// 提示
        /// </summary>
        private string Hint { get; set; } = string.Empty;

        /// <summary>
        /// 验证的类型
        /// </summary>
        /// <remarks>
        /// 目前来说只支持 int double
        /// </remarks>
        public Type ValidationType { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!double.TryParse(value.ToString(), out double equalValue))
            {
                return new ValidationResult(false, "请输入数字");
            }

            bool isMin = Min != double.NaN;
            bool isMax = Max != double.NaN;

            if (isMin && !CheckMin(equalValue))
            {
                if (this.IsLeftClose)
                {
                    return new ValidationResult(false, $"请输入大于等于 {this.Min} 的值");
                }
                else
                {
                    return new ValidationResult(false, $"请输入大于 {this.Min} 的值");
                }
            }
            if (isMax && !CheckMax(equalValue))
            {
                if (this.IsRightClose)
                {
                    return new ValidationResult(false, $"请输入小于等于 {this.Max} 的值");
                }
                else
                {
                    return new ValidationResult(false, $"请输入小于 {this.Max} 的值");
                }
            }

            return new ValidationResult(true, null);
        }

        private bool CheckMax(double value)
        {
            if (IsRightClose && value > Max)
            {
                return false;
            }
            if (!IsRightClose && value >= Max)
            {
                return false;
            }
            return true;
        }

        private bool CheckMin(double value)
        {
            if (IsLeftClose && value < Min)
            {
                return false;
            }
            if (!IsLeftClose && value <= Min)
            {
                return false;
            }
            return true;
        }
    }
}
