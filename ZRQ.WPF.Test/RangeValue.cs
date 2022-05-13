using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Test
{
    /// <summary>
    /// 范围值
    /// </summary>
    /// <remarks>
    /// 封装一个范围数据
    /// 最高点，最低点
    /// </remarks>
    public class RangeValue
    {
        private static readonly string Less = "<";
        private static readonly string LessEqual = "<=";
        private bool isLeftClose;
        private bool isRightClose;
        private double maxHeight = double.PositiveInfinity; // 正无穷
        private double minHeight = double.NegativeInfinity; // 负无穷

        public RangeValue()
        {
            isLeftClose = true;
            isRightClose = true;
        }

        public RangeValue(double? minValue, double? maxValue, bool isLefClose = true, bool isRightClose = true)
            : base()
        {
            if (minValue == null)
            {
                minHeight = double.NegativeInfinity;
            }
            else
            {
                minHeight = minValue.Value;
            }

            if (maxValue == null)
            {
                maxHeight = double.PositiveInfinity;
            }
            else
            {
                maxHeight = maxValue.Value;
            }

            this.isLeftClose = isLefClose;
            this.isRightClose = isRightClose;
        }

        public bool IsLeftClose { get => isLeftClose; set => isLeftClose = value; }
        public bool IsRightClose { get => isRightClose; set => isRightClose = value; }
        public double MaxHeight { get => maxHeight; set => maxHeight = value; }
        public double MinHeight { get => minHeight; set => minHeight = value; }

        /// <summary>
        /// 将范围值转换成字符串
        /// </summary>
        /// <remarks>
        /// </remarks>
        public string ToString(string name)
        {
            if (this.MinHeight == double.NegativeInfinity &&
                this.MaxHeight != double.PositiveInfinity)
            {
                if (this.IsRightClose)
                {
                    return $"{name} {LessEqual} {this.MaxHeight}";
                }
                else
                {
                    return $"{name} {Less} {this.MaxHeight}";
                }
            }

            if (this.MinHeight != double.PositiveInfinity &&
                this.MaxHeight != double.PositiveInfinity)
            {
                if (this.IsLeftClose && this.IsRightClose)
                {
                    return $"{this.MinHeight} {LessEqual} {name} {LessEqual} {this.MaxHeight}";
                }
                else if (this.IsLeftClose && !this.IsRightClose)
                {
                    return $"{this.MinHeight} {LessEqual} {name} {Less} {this.MaxHeight}";
                }
                else if (!this.IsLeftClose && this.IsRightClose)
                {
                    return $"{this.MinHeight} {Less} {name} {LessEqual} {this.MaxHeight}";
                }
                else
                {
                    return $"{this.MinHeight} {Less} {name} {Less} {this.MaxHeight}";
                }
            }

            if (this.MinHeight != double.NegativeInfinity &&
                this.MaxHeight == double.PositiveInfinity)
            {
                if (this.IsLeftClose)
                {
                    return $"{this.MinHeight} {LessEqual} {name}";
                }
                else
                {
                    return $"{this.MinHeight} {Less} {name}";
                }
            }
            return string.Empty;
        }
    }
}
