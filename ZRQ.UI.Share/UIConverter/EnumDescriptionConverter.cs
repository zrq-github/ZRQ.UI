using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZRQ.UI.UIConverter
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public static readonly EnumDescriptionConverter Instance = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = (Enum)value;
            string description = GetEnumDescription(myEnum);
            return description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        private string GetEnumDescription(Enum enumObj)
        {
            Type type = enumObj.GetType();
            FieldInfo? fieldInfo = type.GetField(enumObj.ToString());
            if (null == fieldInfo) return enumObj.ToString();

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute? attrib = attributes[0] as DescriptionAttribute;
                return attrib?.Description ?? string.Empty;
            }
        }
    }
}
