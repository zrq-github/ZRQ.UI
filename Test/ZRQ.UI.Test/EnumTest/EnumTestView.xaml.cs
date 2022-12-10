using HW.Revit.Collaborate.ComponentCoding.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZRQ.UI.Test.EnumTest;

namespace ZRQ.UI.Test
{
    /// <summary>
    /// Interaction logic for ApplyParmView.xaml
    /// </summary>
    public partial class EnumTestView : Window
    {
        public EnumTestView()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                CodingParam codingParam = new(i.ToString())
                {
                    Name = $"属性:{i.ToString()}",
                    RvtParmType = RvtParamType.Inst,
                    RvtParmGroupType = RvtParamGroupType.Text,
                };
                CodingParams.Add(codingParam);
            }

            var rvtParamTypes = Enum.GetValues(typeof(RvtParamType));
            foreach (RvtParamType rvtParamType in rvtParamTypes)
            {
                RvtParamTypes.Add(rvtParamType);
            }

            this.DataContext = this;
        }

        public string TB_Text { get; set; } = "TB_Text";

        public ObservableCollection<CodingParam> CodingParams { get; set; } = new();

        public ObservableCollection<RvtParamType> RvtParamTypes { get; set; }=new();
    }
}
