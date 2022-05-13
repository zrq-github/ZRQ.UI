using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRQ.WPF.Test
{
    public class WindowViewModel
    {
        private List<ComBoxModel> comBoxModels;

        public List<ComBoxModel> ComBoxModels { get => comBoxModels; set => comBoxModels = value; }

        //public BindingList<HWFillPattern> AllHWFillPattern { get; set; }

        public ObservableCollection<HWFillPattern> AllHWFillPattern { get; set; }

        public WindowViewModel()
        {
            AllHWFillPattern = new ObservableCollection<HWFillPattern>();
            AllHWFillPattern.Add(new HWFillPattern() { Name = "1" });
            AllHWFillPattern.Add(new HWFillPattern() { Name = "2" });
            AllHWFillPattern.Add(new HWFillPattern() { Name = "3" });
            AllHWFillPattern.Add(new HWFillPattern() { Name = "4" });
            AllHWFillPattern.Add(new HWFillPattern() { Name = "5" });
            AllHWFillPattern.Add(new HWFillPattern() { Name = "6" });

            ComBoxModels = new List<ComBoxModel>();
            ComBoxModels.Add(new ComBoxModel(new HWFillPattern(String.Empty, "1")));
            ComBoxModels.Add(new ComBoxModel(new HWFillPattern(String.Empty, "2")));
            ComBoxModels.Add(new ComBoxModel(new HWFillPattern(String.Empty, "3")));
        }
    }
}
