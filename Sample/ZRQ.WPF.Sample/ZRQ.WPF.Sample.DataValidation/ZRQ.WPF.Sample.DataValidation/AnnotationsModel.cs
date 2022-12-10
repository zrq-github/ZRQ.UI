using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.Sample.DataValidation
{
    public class AnnotationsModel : ValidateAsyncModelBase
    {
        private string tBContent = "Annotations用法";

        [Required(ErrorMessage = "不能为空")]
        public string TBContent
        {
            get => tBContent; set
            {
                tBContent = value;
                OnPropertyChanged();
            }
        }
    }
}
