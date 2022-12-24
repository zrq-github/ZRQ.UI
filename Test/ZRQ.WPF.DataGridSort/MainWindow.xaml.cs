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

namespace ZRQ.WPF.DataGridSort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<DataGridModel> dataGridModels = new();

            dataGridModels.Add(new DataGridModel() { Id = 1, Name = "1" });
            dataGridModels.Add(new DataGridModel() { Id = 2, Name = "2" });
            dataGridModels.Add(new DataGridModel() { Id = 3, Name = "3" });

            this.dataGrid.ItemsSource = dataGridModels;
        }

        private void btn_Init(object sender, RoutedEventArgs e)
        {

        }
    }
}
