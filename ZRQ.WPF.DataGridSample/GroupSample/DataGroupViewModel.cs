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

            string groupNameOne = $"group_1";
            string groupNameTow = $"group_2";
            string groupNameThree = $"group_3";

            // 分组1
            for (int i = 0; i < 1000; i++)
            {
                dataGroupModel = new DataGroupModel();
                dataGroupModel.GroupName = groupNameOne;
                dataGroupModel.Name = $"{groupNameOne}_张三{i}";
                dataGroupModel.IsIgnore = true;
                dataGroupModels.Add(dataGroupModel);

                dataGroupModel = new DataGroupModel();
                dataGroupModel.GroupName = groupNameOne;
                dataGroupModel.Name = $"{groupNameOne}_李四{i}";
                dataGroupModel.IsIgnore = false;
                dataGroupModels.Add(dataGroupModel);
            }

            for (int i = 0; i < 1000; i++)
            {
                dataGroupModel = new DataGroupModel();
                dataGroupModel.GroupName = groupNameTow;
                dataGroupModel.Name = $"{groupNameTow}_王麻子{i}";
                dataGroupModel.IsIgnore = true;
                dataGroupModels.Add(dataGroupModel);
            }


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
