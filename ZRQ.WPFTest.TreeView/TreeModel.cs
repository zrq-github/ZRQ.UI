using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace ZRQ.WPFTest.TV
{
    public class TreeModel : UIModelBase
    {
        public ObservableCollection<League> Leagues { get; set; }

        public TreeModel()
        {
            this.Leagues = new ObservableCollection<League>();
        }
    }
}
