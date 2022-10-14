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

namespace ZRQ.WPF.DataGridSample
{
    /// <summary>
    /// Interaction logic for TGroupSample.xaml
    /// </summary>
    public partial class TGroupSample : Window
    {
        public TGroupSample()
        {
            InitializeComponent();
        }

        CollectionView myView;
        private void AddGrouping(object sender, RoutedEventArgs e)
        {
            myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
            if (myView.CanGroup == true)
            {
                PropertyGroupDescription groupDescription
                    = new PropertyGroupDescription("@Type");
                myView.GroupDescriptions.Add(groupDescription);
            }
            else
            {
                return;
            }
        }

        private void RemoveGrouping(object sender, RoutedEventArgs e)
        {
            myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
            myView.GroupDescriptions.Clear();
        }
    }
}
