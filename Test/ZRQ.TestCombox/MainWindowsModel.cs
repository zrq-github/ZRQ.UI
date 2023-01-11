using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace ZRQ.TestCombox
{
    internal class MainWindowsModel : ViewModelBase
    {

        private System.Collections.IEnumerable comboBoxItems;

        public System.Collections.IEnumerable ComboBoxItems { get => comboBoxItems; set => SetProperty(ref comboBoxItems, value); }

        private object displayStyle;

        public object DisplayStyle { get => displayStyle; set => SetProperty(ref displayStyle, value); }

    }
}
