using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZRQ.UI.UIModel;
using ZRQ.WPF.DataGridSample.Views;

namespace ZRQ.WPF.DataGridSample.ViewModels
{
    public class DynamicDataGridViewModel : ViewModelBase
    {
        private System.Collections.ObjectModel.ObservableCollection<System.Windows.Controls.DataGridColumn> _dataGridColumns = new();
        private ObservableCollection<ObservableCollection<string>> _dataGridItems = new();
        private ActionCommand addad;
        private ActionCommand? bindingColData;
        private ActionCommand? clearItemsSource;
        private ActionCommand? createDynamicCol;

        private ActionCommand? createItemsSource;
        public ICommand Addad => addad ??= new ActionCommand(PerformAddad);
        public ICommand BindingColData => bindingColData ??= new ActionCommand(PerformBindingColData);
        public ICommand ClearItemsSource => clearItemsSource ??= new ActionCommand(PerformClearItemsSource);
        public ICommand CreateDynamicCol => createDynamicCol ??= new ActionCommand(PerformCreateDynamicCol);
        public ICommand CreateItemsSource => createItemsSource ??= new ActionCommand(PerformCreateItemsSource);

        public System.Collections.ObjectModel.ObservableCollection<System.Windows.Controls.DataGridColumn> DataGridColumns { get => _dataGridColumns; set => SetProperty(ref _dataGridColumns, value); }

        public ObservableCollection<ObservableCollection<string>> DataGridItems { get => _dataGridItems; set => SetProperty(ref _dataGridItems, value); }


        private void PerformAddad()
        {
            DataGridItems.Clear();
            for (int i = 0; i < 20; i++)
            {
                ObservableCollection<string> items = new();

                for (int j = 0; j < 100; j++)
                {
                    items.Add($"{i}_{j}");
                }
                DataGridItems.Add(items);
            }

            DataGridColumns.Clear();

            for (int i = 0; i < 20; i++)
            {
                var col = GridColumnCreate.CreateTextColum();
                col.Header = $"列{i}";

                DataGridColumns.Add(col);
            }

            for (int i = 0; i < DataGridColumns.Count; i++)
            {
                var column = DataGridColumns[i];

                DataGridTextColumn textColumn = (DataGridTextColumn)column;
                System.Windows.Data.Binding binding = new($"[{i}]")
                {
                    UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                };
                textColumn.Binding = binding;
            }

            //PerformCreateItemsSource();


            //PerformCreateDynamicCol();
            //PerformBindingColData();
        }

        /// <summary>
        /// 绑定列数据
        /// </summary>
        private void PerformBindingColData()
        {
            for (int i = 0; i < DataGridColumns.Count; i++)
            {
                var column = DataGridColumns[i];

                DataGridTextColumn textColumn = (DataGridTextColumn)column;
                System.Windows.Data.Binding binding = new($"[{i}]")
                {
                    UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                };
                textColumn.Binding = binding;
            }
        }

        private void PerformClearItemsSource()
        {
            DataGridItems.Clear();
        }

        /// <summary>
        /// 创建动态列
        /// </summary>
        private void PerformCreateDynamicCol()
        {
            DataGridColumns.Clear();

            for (int i = 0; i < 20; i++)
            {
                var col = GridColumnCreate.CreateTextColum();
                col.Header = $"列{i}";

                DataGridColumns.Add(col);
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void PerformCreateItemsSource()
        {
            DataGridItems.Clear();
            for (int i = 0; i < 20; i++)
            {
                ObservableCollection<string> items = new();

                for (int j = 0; j < 100; j++)
                {
                    items.Add($"{i}_{j}");
                }
                DataGridItems.Add(items);
            }

            //DynamicDataGrid.dynamicDataGrid.dg_Table.ItemsSource = new ObservableCollection<ObservableCollection<string>>();

            //DynamicDataGrid.dynamicDataGrid.dg_Table.ItemsSource = DataGridItems;
        }
    }

    internal static class GridColumnCreate
    {
        /// <summary>
        /// 默认创建的
        /// </summary>
        /// <returns> </returns>
        public static DataGridTextColumn CreateTextColum()
        {
            System.Windows.Style headerStyle = new System.Windows.Style(typeof(System.Windows.Controls.Primitives.DataGridColumnHeader));
            Setter setterVerAlignment = new(System.Windows.Controls.Primitives.DataGridColumnHeader.VerticalContentAlignmentProperty, VerticalAlignment.Center);
            Setter setterHorAlignment = new(System.Windows.Controls.Primitives.DataGridColumnHeader.HorizontalContentAlignmentProperty, HorizontalAlignment.Center);
            headerStyle.Setters.Add(setterVerAlignment);
            headerStyle.Setters.Add(setterHorAlignment);

            DataGridTextColumn dataGridTextColumn = new()
            {
                IsReadOnly = false,
                //Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                MinWidth = 75,
                Width = 75,
                HeaderStyle = headerStyle,
            };
            return dataGridTextColumn;
        }
    }
}
