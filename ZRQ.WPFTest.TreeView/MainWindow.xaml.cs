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

namespace ZRQ.WPFTest.TV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel ViewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.InitTree();
        }

        private void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            System.Windows.Point aP = e.GetPosition(treeView);
            IInputElement obj = treeView.InputHitTest(aP);
            DependencyObject target = obj as DependencyObject;

            TreeViewItem treeViewItem = null;
            DataGridRow dataGridRow = null;
            while (target != null)
            {
                if (target is DataGridRow)
                {
                    dataGridRow = (DataGridRow)target;
                    break;
                }
                if (target is TreeViewItem)
                {
                    treeViewItem = (TreeViewItem)target;
                    var a = treeViewItem.DataContext;
                }

                target = VisualTreeHelper.GetParent(target);
            }
            e.Handled = true;
        }
    }
}
