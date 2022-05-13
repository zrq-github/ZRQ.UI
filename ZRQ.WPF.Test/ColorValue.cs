using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Test
{
    /// <summary>
    /// 净高颜色 RGB
    /// </summary>
    public class ColorValue
    {
        public int R { get; set; } = 255;
        public int G { get; set; } = 255;
        public int B { get; set; } = 255;

        public ColorValue()
        {

        }

        public ColorValue(int r, int g, int b) : this()
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
