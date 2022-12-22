using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.TreeViewSort
{
    public class TreeViewModel : ViewModelBase
    {
        private string _searchText;

        public TreeViewModel()
        {

        }

        public ObservableCollection<TreeNode> TreeNodeSource { get; set; } = new();

        public void Sort()
        {
            Sort(TreeNodeSource);
        }

        /// <summary>
        /// 搜索Text
        /// </summary>
        public string SearchText { get => _searchText; set => SetProperty(ref _searchText, value); }

        /// <summary>
        /// 是否在搜索状态
        /// </summary>
        public bool IsSearching { get => string.IsNullOrEmpty(_searchText); }

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
