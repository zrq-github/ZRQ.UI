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

            List<DataGridModel> dataGridModels = new()
            {
                new DataGridModel() { Id = 1, Name = "1" },
                new DataGridModel() { Id = 2, Name = "2" },
                new DataGridModel() { Id = 3, Name = "3" }
            };

            CollectionViewSource collectionViewSource = new()
            {
                Source = dataGridModels
            };
            collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription(nameof(DataGridModel.Name)));
            collectionViewSource.View.Refresh();

            //this.dataGrid.ItemsSource = viewSource.View;
        }
    }
}
