using DemoData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZRQ.WPF.TreeViewSample
{
    public class TreeNode : INode
    {
        private ObservableCollection<object> childrens;

        public TreeNode()
        {
            childrens = new ObservableCollection<object>();
            this.ID = String.Empty;
            this.ParentID = String.Empty;
        }

        public string ID { get; }
        
        public string ParentID { get; }

        /// <summary>
        /// 数据源
        /// </summary>
        public object Data { get; set; }

        public ObservableCollection<Object> Childrens { get => childrens; set => childrens = value; }
    }
}
