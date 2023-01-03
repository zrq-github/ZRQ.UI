using System.Windows;
using System.Windows.Controls;

namespace ZRQ.WPF.TreeViewSort;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class TreeWindows : Window
{
    private TreeViewModel _treeViewModel;

    public TreeWindows()
    {
        InitializeComponent();

        _treeViewModel = (TreeViewModel)this.DataContext;
    }

    private void btn_Sort(object sender, RoutedEventArgs e)
    {
        //this.treeView.Items.IsLiveSorting = true;
        //this.treeView.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription(nameof(TreeNode.ID), System.ComponentModel.ListSortDirection.Descending));
        _treeViewModel.Sort();
    }

    private void btn_Init(object sender, RoutedEventArgs e)
    {
        // 顶层级节点
        TreeNode node1 = new() { ID = "1", ParentID = "0" };
        TreeNode node2 = new() { ID = "2", ParentID = "0" };

        _treeViewModel.TreeNodeSource.Add(node1);
        _treeViewModel.TreeNodeSource.Add(node2);

        // 二层节点
        node1.Childrens.Add(new() { ID = "14", ParentID = "1" });
        node1.Childrens.Add(new() { ID = "15", ParentID = "1" });
        node1.Childrens.Add(new() { ID = "11", ParentID = "1" });
        node1.Childrens.Add(new() { ID = "12", ParentID = "1" });
        node1.Childrens.Add(new() { ID = "13", ParentID = "1" });
    }

    private void btn_ClearSort(object sender, RoutedEventArgs e)
    {
        this.treeView.Items.SortDescriptions.Clear();
    }

    private void treeView_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        e.Handled= true;
    }

    private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        var oldValue = e.OldValue;
        var newValue = e.NewValue;
        var source = e.Source;
        var a = e.RoutedEvent;
    }

    private void 排序_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {

    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {

    }
}

public class TreeNodeDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate NodeCommondTemplate { get; set; }
    public DataTemplate NodeCategoryTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        return NodeCommondTemplate;
    }
}
