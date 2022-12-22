using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.TreeViewSort
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {

        }

        public ObservableCollection<TreeNode> TreeNodeSource { get; set; } = new();

        public void Sort()
        {
            Sort(TreeNodeSource);
        }

        void Sort(IEnumerable<TreeNode> treeNodes)
        {
            foreach (TreeNode node in treeNodes)
            {
                var children = node.Childrens;
                if (children.Count == 0) { continue; }

                Sort(children);

                node.Sort((a, b) =>
                {
                    return string.Compare(a.ID, b.ID);
                });
            }
        }
    }
}
