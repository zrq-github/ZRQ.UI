﻿using System;
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
using ZRQ.UI.UIUtils;

namespace WpfApp1
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

        }

        private void btn_FindChildByBinding(object sender, RoutedEventArgs e)
        {
            TextBox dependencyObject = UIFinder.FindChild<TextBox>(this.mainWindow, TextBox.TextProperty, nameof(ViewModel.TestFindBingding));

            TextBox foundTextBox =
               UIFinder.FindChild<TextBox>(Application.Current.MainWindow, childName: "myTextBoxName");

            List<TextBox> textBoxes = UIFinder.FindChildsHasError<TextBox>(this.mainWindow);
        }
    }
}
