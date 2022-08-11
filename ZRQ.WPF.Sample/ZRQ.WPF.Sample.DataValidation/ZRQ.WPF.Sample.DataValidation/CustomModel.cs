using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.Sample.DataValidation
{
    public class CustomModel : ValidateAsyncModelBase
    {
        private string name = "自定义异常";
        private string rangeValue = "100";

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string RangeValue
        {
            get => rangeValue; set
            {
                rangeValue = value;
                OnPropertyChanged();
            }
        }

        public Collection<ValidationRule> AAA { get; set; }
    }
}
