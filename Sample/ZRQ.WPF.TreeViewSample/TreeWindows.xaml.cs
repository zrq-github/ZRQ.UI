using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZRQ.WPF.TreeViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TreeWindows : Window
    {
        public TreeWindows()
        {
            InitializeComponent();
        }
    }

    public class TreeNodeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NodeCommondTemplate { get; set; }
        public DataTemplate NodeCategoryTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //CodingNodeModel nodeModel = item as CodingNodeModel;
            //if (null == nodeModel)
            //{
            //    return base.SelectTemplate(item, container);
            //}

            //if (nodeModel.CodingNoteType == DB.CodingNoteType.Category)
            //{
            //    return NodeCategoryTemplate;
            //}

            return NodeCommondTemplate;
        }
    }
}
