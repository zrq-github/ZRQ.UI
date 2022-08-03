using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace Validation_ByDataErrorInfo
{
    public class ValidationModel : UIModelBase, IDataErrorInfo
    {
        private string _username = "Validation_ByDataErrorInfo";
        private string phone = "1234556789";
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string Phone { get => phone; set => SetValue(ref phone, value); }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }


        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case nameof(Username):
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Username cannot be empty";
                        //else if (Username.Length < 5)
                        //    result = "Username must be a minimum of 5 characters.";
                        break;
                    default:
                        result = "No Error";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
    }
}
