using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace ZRQ.UI.UIConverter
{
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type type) : base(type)
        {
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (null == value) { return null; }
                string? strValue = value.ToString();
                if (null == strValue) { return null; }

                FieldInfo? fi = value.GetType().GetField(strValue);
                if (null == fi) { return null; }

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return ((attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description)))
                    ? attributes[0].Description
                    : value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
