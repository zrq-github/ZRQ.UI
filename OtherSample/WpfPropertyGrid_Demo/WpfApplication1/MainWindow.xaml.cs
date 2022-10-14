using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace WpfApplication1
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

        private void ButtonPerson_Click(object sender, RoutedEventArgs e)
        {
   
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e)
        {
            PropertyGrid1.SelectedObject = radioButton1;
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PropertyGrid1.SelectedObject = label1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PropertyGrid1.SelectedObject = button1;
        }
    }
}
