using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPFTest.TreeView
{
    public class ViewModel
    {
        public TreeModel ShowModel { get; set; }

        public ViewModel()
        {
            ShowModel = new TreeModel();
        }

        internal void InitTree()
        {
            ShowModel = new TreeModel();
            ObservableCollection<League> leagues = new ObservableCollection<League>();

            League l;
            Division d;

            for (int index = 1; index < 4; index++)
            {
                leagues.Add(l = new League($"League{index}"));
                for (int index2 = 1; index2 < 10; index2++)
                {
                    l.Divisions.Add(d = new Division($"Division{index}"));

                    for (int index3 = 1; index3 < 10000; index3++)
                    {
                        d.Teams.Add(new Team("Team I"));
                    }
                }
            }

            this.ShowModel.Leagues = leagues;
        }
    }
}
