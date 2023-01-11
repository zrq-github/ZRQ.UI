using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZRQ.UI.UIConverter;

namespace ZRQ.TestCombox
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
