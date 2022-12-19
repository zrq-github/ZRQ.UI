using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ZRQ.UI.UIConverter
{
    /// <summary>
    /// bool -> Visibility
    /// </summary>
    /// <remarks>
    /// false -> Visibility.Hidden
    /// true -> Visibility.Visible
    /// </remarks>
    public class BoolToVisibilityConverter : System.Windows.Data.IValueConverter
    {
        public static readonly BoolToVisibilityConverter Instance = new();

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                bool isShow = (bool)value;
                if (isShow)
                {
                    return System.Windows.Visibility.Visible;
                }
                else
                {
                    return System.Windows.Visibility.Hidden;
                }
            }
            else
            {
                return System.Windows.Visibility.Hidden;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Visibility)
            {
                System.Windows.Visibility visibility = (System.Windows.Visibility)value;
                if (visibility == System.Windows.Visibility.Visible)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
