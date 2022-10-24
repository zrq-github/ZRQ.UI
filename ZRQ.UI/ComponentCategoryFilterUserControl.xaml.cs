using System;
using System.Collections.Generic;
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

namespace ZRQ.UI
{
    /// <summary>
    /// ComponentCategoryFilterUserControl.xaml 的交互逻辑
    /// 类别
    /// </summary>
    public partial class ComponentCategoryFilterUserControl : UserControl
    {
        public ComponentCategoryFilterUserControl()
        {
            InitializeComponent();

        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            //this.TextBox_SearchContent.Focus();
            //var config = this.DataContext as CateTreeShow;
            //config.Search();
        }

        /// <summary>
        ///  支持响应回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_SearchContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Button_Search.Focus();
            }
        }
    }
}
