﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
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

namespace ZRQ.UIShared.Test
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

        private void btnInternal_Click(object sender, RoutedEventArgs e)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Name = "JsonSerializer";
            JsonSerializer jsonSerializer = new JsonSerializer();

           string str =   JsonConvert.SerializeObject(viewModel);
        }
    }
}
