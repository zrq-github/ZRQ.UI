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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            this.Loaded += Page1_Loaded;
        }

        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<DataGridModel> dataGridModels = new();

            dataGridModels.Add(new DataGridModel() { Id = 1, Name = "1" });
            dataGridModels.Add(new DataGridModel() { Id = 2, Name = "2" });
            dataGridModels.Add(new DataGridModel() { Id = 3, Name = "3" });


            CollectionViewSource viewSource = new();
            viewSource.Source = dataGridModels;
            viewSource.GroupDescriptions.Add(new PropertyGroupDescription(nameof(DataGridModel.Name)));
            viewSource.View.Refresh();

            this.dataGrid.ItemsSource = viewSource.View;
        }
    }
}
