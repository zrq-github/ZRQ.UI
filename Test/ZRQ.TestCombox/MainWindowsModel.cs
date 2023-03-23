using System.Collections;
using ZRQ.UI.UIModel;

namespace ZRQ.TestCombobox
{
    internal class MainWindowsModel : ModelBase
    {
        private IEnumerable? comboBoxItems;

        public IEnumerable? ComboBoxItems { get => comboBoxItems; set => SetProperty(ref comboBoxItems, value); }

        private object? displayStyle;

        public object? DisplayStyle { get => displayStyle; set => SetProperty(ref displayStyle, value); }
    }
}
