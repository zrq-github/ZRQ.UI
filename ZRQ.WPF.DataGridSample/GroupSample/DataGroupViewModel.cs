using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZRQ.WPF.DataGridSample.Model;

namespace ZRQ.WPF.DataGridSample.GroupSample
{
    public class DataGroupViewModel : ViewModelBase
    {
        public ObservableCollection<DataGroupModel> DataGroupModels { get; set; }
        public bool IsDataGridGroupShow { get; set; }

        public DataGroupViewModel()
        {
            DataGroupModels = new ObservableCollection<DataGroupModel>();
            IsDataGridGroupShow = false;

            InitDataGourpModels(this.DataGroupModels);
        }

        private void InitDataGourpModels(ObservableCollection<DataGroupModel> dataGroupModels)
        {
            if (null == dataGroupModels)
            {
                dataGroupModels = new ObservableCollection<DataGroupModel>();
            }

            DataGroupModel dataGroupModel = new DataGroupModel();

            string groupNameOne = $"分组1";
            string groupNameTow = $"分组2";
            string groupNameThree = $"分组3";

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameOne;
            dataGroupModel.Name = "张三";
            dataGroupModel.IsIgnore = true;
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameOne;
            dataGroupModel.Name = "李四";
            dataGroupModel.IsIgnore = false;
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameTow;
            dataGroupModel.Name = "王麻子";
            dataGroupModel.IsIgnore = true;
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameThree;
            dataGroupModel.Name = "上官";
            dataGroupModel.IsIgnore = true;
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameThree;
            dataGroupModel.Name = "欧阳";
            dataGroupModel.IsIgnore = false;
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel();
            dataGroupModel.GroupName = groupNameThree;
            dataGroupModel.Name = "欧耶";
            dataGroupModel.IsIgnore = true;
            dataGroupModels.Add(dataGroupModel);
        }
    }
}
