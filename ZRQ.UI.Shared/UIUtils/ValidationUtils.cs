using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ZRQ.UIShared.UIUtils
{
    /// <summary>
    /// 一些验证规则
    /// </summary>
    internal static class ValidationUtils
    {
        public static bool IsHasErrors(DependencyObject element)
        {
            return System.Windows.Controls.Validation.GetHasError(element);
        }

        public static ReadOnlyObservableCollection<ValidationError> GetValidationErrors(DependencyObject element)
        {
            return System.Windows.Controls.Validation.GetErrors(element);
        }
    }
}
