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
using System.Windows.Shapes;

namespace ZRQ.WPF.DataGridSample.Views
{
    /// <summary>
    /// Interaction logic for BigDataGrid.xaml
    /// </summary>
    public partial class BigDataGrid : Window
    {
        public BigDataGrid()
        {
            InitializeComponent();
        }

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("超链接");
        }
    }
}
