using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZRQ.WPF.HighLightSample
{
    internal class TreeModel
    {
        private TreeModels _childrens;
        private string _name;
        private int _indexTemplate;

        public TreeModel(string name, int indexTemplate = 0)
        {
            _childrens = new TreeModels();
            _name = name;
            IndexTemplate = indexTemplate;
        }

        public TreeModels Childrens { get => _childrens; set => _childrens = value; }

        public string Name
        {
            get => _name;
        }
        public int IndexTemplate { get => _indexTemplate; set => _indexTemplate = value; }
    }

    internal class TreeModels : ObservableCollection<TreeModel>
    {

    }
}
