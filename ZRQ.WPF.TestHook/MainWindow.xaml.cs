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

namespace ZRQ.WPF.TestHook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MouseKeyHookUsage mouseKeyHook = new MouseKeyHookUsage();
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;

            mouseKeyHook.Subscribe();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            mouseKeyHook.Unsubscribe();
        }
    }
}
