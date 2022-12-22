using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ZRQ.WPF.TreeViewSample
{
    public class TreeNode
    {
        private ObservableCollection<TreeNode> childrens = new();

        public TreeNode()
        {
            childrens = new ObservableCollection<TreeNode>();
            this.ID = String.Empty;
            this.ParentID = String.Empty;
        }

        public string ID { get; set; }

        public string ParentID { get; set; }

        public ObservableCollection<TreeNode> Childrens { get => childrens; set => childrens = value; }
    }

    public static class TreeNodeExtension
    {
        public static void Sort(this TreeNode node, Func<TreeNode, TreeNode, int> sorter)
        {
            //// Make sure the TreeView will allow reordering
            //if (node.TreeView != null)
            //{
            //    node.TreeView.Sorted = false;
            //}
            // Copy the nodes to a list
            var list = node.Childrens.ToList();
            // Sort the list however the `Sorter` says to.
            list.Sort(comparison: (a, b) => sorter(a, b));
            // Clear the 'old' order
            node.Childrens.Clear();
            // Install the 'new' order
            foreach (var sorted in list)
            {
                node.Childrens.Add(sorted);
            }
        }
    }
}
