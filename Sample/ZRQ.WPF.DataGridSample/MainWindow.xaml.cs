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
using ZRQ.WPF.DataGridSample.GroupSample;
using ZRQ.WPF.DataGridSample.Views;

namespace ZRQ.WPF.DataGridSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddGrouping(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveGrouping(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGroupSample_Click(object sender, RoutedEventArgs e)
        {
            DataGroupWindow dataGroupWindow = new()
            {
                Owner = this
            };
            dataGroupWindow.ShowDialog();
        }

        private void BtnBtnDynamicCell_Click(object sender, RoutedEventArgs e)
        {
            DynamicDataGrid dynamicDataGrid = new()
            {
                Owner = this
            };
            dynamicDataGrid.ShowDialog();
        }

        private void BtnBigData_OnClick(object sender, RoutedEventArgs e)
        {
            BigDataGrid bigDataGrid = new();
            bigDataGrid.ShowDialog();
        }
    }
}
