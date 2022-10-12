using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ZRQ.UI.Test
{
    /// <summary>
    /// Interaction logic for TColorSelButton.xaml
    /// </summary>
    public partial class TColorSelButton : UserControl
    {
        public TColorSelButton()
        {
            InitializeComponent();
        }

        private void btn_LineColor_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class ColorSelBtnToStrConvt : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color)
            {
                Color color = (Color)value;
                string colorStr = "RGB  " + color.R.ToString() + "-" + color.G.ToString() + "-" + color.B.ToString();
                return colorStr;
            }
            return "<无替换>";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// ColorSolidColorBrush的颜色互相转化 主要是button的背景颜色需要
    /// </summary>
    class ColorSolidColorBrushConvt : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
            {
                SolidColorBrush brush = new
                     SolidColorBrush((Color)value);
                return brush;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                SolidColorBrush brush = (SolidColorBrush)value;
                Color color = brush.Color;
                return color;
            }
            return value;
        }
    }
}
