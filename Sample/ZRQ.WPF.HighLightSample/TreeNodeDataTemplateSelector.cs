using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ZRQ.WPF.HighLightSample;

public class TreeNodeDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate NodeCategoryTemplate { get; set; }

    public DataTemplate NodeCommondTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        TreeModel nodeModel = item as TreeModel;
        if (null == nodeModel)
        {
            return base.SelectTemplate(item, container);
        }

        if (nodeModel.IndexTemplate == 1)
        {
            return NodeCategoryTemplate;
        }

        return NodeCommondTemplate;
    }
}
