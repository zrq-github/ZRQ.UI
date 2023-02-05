using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.DataGridSample.GroupSample
{
    public class DataGroupViewModel : ViewModelBase
    {
        public ObservableCollection<DataGroupModel> DataGroupModels { get; set; } = new();
        public bool IsDataGridGroupShow { get; set; } = false;

        public DataGroupViewModel()
        {
            InitDataGourpModels(this.DataGroupModels);
        }

        private static void InitDataGourpModels(ObservableCollection<DataGroupModel>? dataGroupModels)
        {
            dataGroupModels ??= new ObservableCollection<DataGroupModel>();

            DataGroupModel dataGroupModel;

            const string groupNameOne = $"group_1";
            const string groupNameTow = $"group_2";
            const string groupNameThree = $"group_3";

            // 分组1
            for (int i = 0; i < 100; i++)
            {
                dataGroupModel = new DataGroupModel
                {
                    GroupName = groupNameOne,
                    Name = $"{groupNameOne}_张三{i}",
                    IsIgnore = true
                };
                dataGroupModels.Add(dataGroupModel);

                dataGroupModel = new DataGroupModel
                {
                    GroupName = groupNameOne,
                    Name = $"{groupNameOne}_李四{i}",
                    IsIgnore = false
                };
                dataGroupModels.Add(dataGroupModel);
            }

            for (int i = 0; i < 100; i++)
            {
                dataGroupModel = new DataGroupModel
                {
                    GroupName = groupNameTow,
                    Name = $"{groupNameTow}_王麻子{i}",
                    IsIgnore = true
                };
                dataGroupModels.Add(dataGroupModel);
            }


            dataGroupModel = new DataGroupModel
            {
                GroupName = groupNameThree,
                Name = "上官",
                IsIgnore = true
            };
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel
            {
                GroupName = groupNameThree,
                Name = "欧阳",
                IsIgnore = false
            };
            dataGroupModels.Add(dataGroupModel);

            dataGroupModel = new DataGroupModel
            {
                GroupName = groupNameThree,
                Name = "欧耶",
                IsIgnore = true
            };
            dataGroupModels.Add(dataGroupModel);
        }
    }
}
