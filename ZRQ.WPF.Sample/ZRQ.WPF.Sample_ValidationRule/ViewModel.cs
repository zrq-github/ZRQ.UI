using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.WPF.Sample.Validation;

namespace ZRQ.WPF.Sample_ValidationRule
{
    public class ViewModel
    {
        public Model Model { get; set; }

        public ViewModel()
        {
            Model = new Model();
        }
    }
}
