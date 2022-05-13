using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Test
{
    public class ComBoxModel
    {
        public ColorValue ColorValue { get; set; } = new ColorValue();
        public HWFillPattern HWFillPattern { get; set; } = new HWFillPattern();
        public RangeValue RangeValue { get; set; } = new RangeValue();

        public String Name { get; set; }

        public ComBoxModel(HWFillPattern fillPattern)
        {
            ColorValue = new ColorValue();
            RangeValue = new RangeValue();
            HWFillPattern = fillPattern;
            Name = fillPattern.Name;
        }
    }
}
