using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ZRQ.WPF.DataGridSample.Model;

namespace ZRQ.WPF.DataGridSample.GroupSample;

/// <summary>
/// 净高检测Model
/// </summary>
public class DataGroupModel : ViewModelBase
{
    private string groupName;
    private bool isIgnore;
    private string name;
    private string resultValue;

    public DataGroupModel()
    {
        groupName = string.Empty;
        name = string.Empty;
        name = string.Empty;
        resultValue = string.Empty;
        isIgnore = false;
    }

    /// <summary>
    /// 设置文字颜色
    /// </summary>
    internal Brush Foreground
    {
        get
        {
            if (!isIgnore)
            {
                return Brushes.Black;
            }
            else return Brushes.Gray;
        }
    }

    /// <summary>
    /// 分组逻辑记录
    /// </summary>
    public string GroupName { get => groupName; set => groupName = value; }

    /// <summary>
    /// 是否忽略
    /// </summary>
    public bool IsIgnore
    {
        get => isIgnore;
        set
        {
            isIgnore = value;
            OnPropertyChanged(nameof(IsIgnore));
            OnPropertyChanged(nameof(Foreground));
            OnPropertyChanged(nameof(TextDecoration));
        }
    }

    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get => name; set => name = value; }

    /// <summary>
    /// 结果值
    /// </summary>
    public string ResultValue { get => resultValue; set => resultValue = value; }

    /// <summary>
    /// 设置划线
    /// </summary>
    public TextDecorationCollection TextDecoration
    {
        get
        {
            if (isIgnore)
            {
                return TextDecorations.Strikethrough;
            }
            else
            {
                return null;
            }
        }
    }
}
