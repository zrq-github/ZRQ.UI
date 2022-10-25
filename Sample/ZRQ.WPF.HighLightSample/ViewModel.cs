using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.HighLightSample
{
    internal class ViewModel : ViewModelBase
    {
        private string _name;
        private string _searchText;


        public ViewModel()
        {
            this._searchText = String.Empty;
            this._name = string.Empty;
        }

        public string Name { get => _name; set => SetValue(ref _name, value); }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
    }
}
