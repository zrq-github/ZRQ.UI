using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Test
{
    /// <summary>
    /// 净高填充元素
    /// </summary>
    /// <remarks>
    /// 针对revit内部填充元素的封装，净高平面
    /// </remarks>
    public class HWFillPattern : IEquatable<HWFillPattern>
    {
        private string uniqueId;
        private string name;

        public string UniqueId { get => uniqueId; set => uniqueId = value; }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public HWFillPattern()
        {
        }

        public HWFillPattern(string uniqueId, string name) : this()
        {
            this.name = name;
            this.uniqueId = uniqueId;
        }

        public bool Equals(HWFillPattern? other)
        {
            if (other == null)
                return false;

            if (this.Name != other.Name)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
