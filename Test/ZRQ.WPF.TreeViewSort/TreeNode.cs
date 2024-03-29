﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.TreeViewSort
{
    public class TreeNode : ModelBase,IEqualityComparer<TreeNode>
    {
        private ObservableCollection<TreeNode> childrens = new();
        private bool _isExpanded = true;

        public TreeNode()
        {
            childrens = new ObservableCollection<TreeNode>();
            this.ID = String.Empty;
            this.ParentID = String.Empty;
        }

        public string ID { get; set; }

        public string ParentID { get; set; }

        public ObservableCollection<TreeNode> Childrens { get => childrens; set => childrens = value; }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        public bool Equals(TreeNode x, TreeNode y)
        {
            return x.ID.Equals(y.ID);
        }

        public int GetHashCode([DisallowNull] TreeNode obj)
        {
            return HashCode.Combine(ID);
        }

        //public override bool Equals(object obj)
        //{
        //    TreeNode treeNode = obj as TreeNode;
        //    if (null == treeNode) return false;

        //    return ID.Equals(((TreeNode)obj).ID);
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine( ID);
        //}
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
