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
    public class RangeValidationRule : ValidationRule
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

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!double.TryParse(value.ToString(), out double equalValue))
            {
                return new ValidationResult(false, "请输入数字");
            }

            bool isMin = this.Min != double.NaN;
            bool isMax = this.Max != double.NaN;

            if (isMin && !CheckMin(equalValue))
            {
                return new ValidationResult(false, $"不满足最小值: {this.Min}");
            }
            if (isMax && !CheckMax(equalValue))
            {
                return new ValidationResult(false, $"不满足最大值: {this.Min}");
            }

            return new ValidationResult(true, null);
        }

        private bool CheckMax(double value)
        {
            if (IsRightClose && value > this.Max)
            {
                return false;
            }
            if (!IsRightClose && value >= this.Max)
            {
                return false;
            }
            return true;
        }

        private bool CheckMin(double value)
        {
            if (IsLeftClose && value < this.Min)
            {
                return false;
            }
            if (!IsLeftClose && value <= this.Min)
            {
                return false;
            }
            return true;
        }
    }
}
