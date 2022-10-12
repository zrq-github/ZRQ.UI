using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ZRQ.UIShared._Test
{
    internal class _获取鼠标点击的对象
    {
        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid == null) return;

            Point aP = e.GetPosition(dataGrid);
            IInputElement obj = dataGrid.InputHitTest(aP);
            DependencyObject target = obj as DependencyObject;

            while (target != null)
            {
                if (target is DataGrid) break;

                if (target is CheckBox) break;

                if (target is DataGridRow)
                {
                    break;
                }
                target = VisualTreeHelper.GetParent(target);
            }
        }
    }
}
