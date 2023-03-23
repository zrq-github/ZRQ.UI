using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.HighLightSample
{
    internal class Model : ModelBase
    {
        private string _name;
        private string _searchText;
        private TreeModels treeModels;

        public Model()
        {
            this._searchText = String.Empty;
            this._name = string.Empty;

            treeModels = new TreeModels();
            TreeModel oneTreeModel = new TreeModel("1", 0);
            treeModels.Add(oneTreeModel);
            {
                oneTreeModel.Childrens.Add(new TreeModel("11", 1));
                oneTreeModel.Childrens.Add(new TreeModel("12", 1));
            }
        }

        public string Name { get => _name; set => SetValue(ref _name, value); }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public TreeModels TreeModels { get => treeModels; set => treeModels = value; }
    }
}
