using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ZRQ.UI.UIUtils
{
    public static class TreeViewUtils
    {
        public static void ExpandAll(this TreeView treeView)
        {
            foreach (var item in treeView.Items)
            {
                if (treeView.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem treeViewItem)
                    treeViewItem.ExpandSubtree();
            }
        }

        public static void CollapseAll(this TreeView treeView)
        {
            foreach (var item in treeView.Items)
            {
                if (treeView.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem treeViewItem)
                    treeViewItem.IsExpanded = false;
            }
        }

        public static void CollapseAll(this TreeViewItem treeViewItem)
        {
            foreach (var item in treeViewItem.Items)
            {
                if (treeViewItem.ItemContainerGenerator.ContainerFromItem(item) is TreeViewItem subTreeViewItem)
                    subTreeViewItem.IsExpanded = false;
            }
        }
    }
}
