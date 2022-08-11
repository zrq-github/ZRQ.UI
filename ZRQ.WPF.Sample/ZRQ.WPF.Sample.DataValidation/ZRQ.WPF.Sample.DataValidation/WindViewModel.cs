using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Sample.DataValidation
{
    public class WindViewModel
    {
        public WindViewModel()
        {
            this.AnnotationsModel = new AnnotationsModel();
            this.CustomModel = new CustomModel();
        }

        public AnnotationsModel AnnotationsModel { get; set; }

        public CustomModel CustomModel { get; set; }
    }
}
