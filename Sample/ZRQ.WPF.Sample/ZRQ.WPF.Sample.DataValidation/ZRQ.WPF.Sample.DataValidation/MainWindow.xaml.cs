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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZRQ.WPF.Sample.DataValidation
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Page1 page = new Page1();

            Window window = new Window();
            window.Height = 500;
            window.Width = 500;
            window.Name = "Page验证测试";
            window.Content = page;

            window.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
