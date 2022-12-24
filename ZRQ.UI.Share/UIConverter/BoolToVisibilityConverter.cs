using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ZRQ.UI.UIConverter
{
    /// <summary>
    /// 转换枚举
    /// </summary>
    public enum ConvertEnum
    {
        #region bool
        TrueToVisible,
        TrueToHidden,
        #endregion
    }

    /// <summary>
    /// bool -> Visibility
    /// </summary>
    /// <remarks>
    /// false -> Visibility.Hidden
    /// true -> Visibility.Visible
    /// </remarks>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public static readonly BoolToVisibilityConverter Instance = new();

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool convertValue) return false;

            if (parameter is ConvertEnum convertEnum)
            {
                return Convert(convertValue, convertEnum);
            }

            // 不反转
            return Convert(convertValue, ConvertEnum.TrueToVisible);
        }

        private static object Convert(bool convertValue, ConvertEnum convertEnum)
        {
            if (convertValue)
            {
                if (convertEnum == ConvertEnum.TrueToVisible) return Visibility.Visible;
                if (convertEnum == ConvertEnum.TrueToHidden) return Visibility.Hidden;
            }

            if (!convertValue)
            {
                if (convertEnum == ConvertEnum.TrueToVisible) return Visibility.Hidden;
                if (convertEnum == ConvertEnum.TrueToHidden) return Visibility.Visible;
            }

            throw new NotImplementedException();
        }

        private static object ConvertBack(Visibility visibility, ConvertEnum convertEnum = ConvertEnum.TrueToVisible)
        {
            if (visibility == Visibility.Visible)
            {
                if (convertEnum == ConvertEnum.TrueToVisible)
                    return Visibility.Visible;

                if (convertEnum == ConvertEnum.TrueToHidden)
                    return Visibility.Hidden;
            }

            if(visibility == Visibility.Hidden)
            {
                if (convertEnum == ConvertEnum.TrueToVisible)
                    return Visibility.Hidden;

                if (convertEnum == ConvertEnum.TrueToHidden)
                    return Visibility.Visible;
            }

            throw new NotImplementedException();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Visibility visibility)
            {
                throw new NotImplementedException();
            }

            if(parameter is ConvertEnum convertEnum)
            {
                return ConvertBack(visibility, convertEnum);
            }

            return ConvertBack(visibility);
        }
    }
}
