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
using System.Windows.Shapes;

namespace ZRQ.WPF.DataGridSample.GroupSample
{
    /// <summary>
    /// Interaction logic for DataGroupWindow.xaml
    /// </summary>
    public partial class DataGroupWindow : Window
    {
        DataGroupViewModel viewModel;

        public DataGroupWindow()
        {
            InitializeComponent();
            viewModel = new DataGroupViewModel();
            this.DataContext = viewModel;
        }

        private void AddGrouping(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveGrouping(object sender, RoutedEventArgs e)
        {

        }
    }
}
