using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.Sample.Validation
{
    public class Model : UIModelBase
    {
        private string name;
        private string simpleVerify;
        private string validationRule;
        private string numericValidation = "数字类型验证";

        public string NumericValidation
        {
            get => numericValidation; set
            {
                OnPropertyChanged();
                numericValidation = value;
            }
        }

        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string SimpleVerify
        {
            get => simpleVerify; set
            {
                simpleVerify = value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("异常验证");
                }
                OnPropertyChanged();
            }
        }

        public string ValidationRule
        {
            get => validationRule;
            set
            {
                validationRule = value;
                OnPropertyChanged();
            }
        }
        public Model()
        {
            name = "No Name";
            simpleVerify = "简单的验证";
            this.validationRule = "Validation Rule";
        }
    }
}
