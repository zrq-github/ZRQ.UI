using System.ComponentModel;
using System.Windows;
using ZRQ.UI.UIConverter;

namespace ZRQ.TestCombobox
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum DisplayStyle
    {
        [Description("没有")]
        None,

        [Description("一")]
        One,

        [Description("二")]
        Tow,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
