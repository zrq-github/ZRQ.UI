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

        public DataGroupViewModel()
        {
            DataGroupModels = new ObservableCollection<DataGroupModel>();
        }
    }
}
