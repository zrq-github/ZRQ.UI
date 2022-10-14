using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.TreeViewSample
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {

        }

        public ObservableCollection<TreeNode> TreeNodeSource { get; set; }
    }
}
