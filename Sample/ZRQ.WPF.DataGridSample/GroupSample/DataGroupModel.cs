using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ZRQ.UI.UIModel;

namespace ZRQ.WPF.DataGridSample.GroupSample;

/// <summary>
/// 净高检测Model
/// </summary>
public class DataGroupModel : ViewModelBase
{
    private bool isIgnore;

    public DataGroupModel()
    {
        GroupName = string.Empty;
        Name = string.Empty;
        Name = string.Empty;
        ResultValue = string.Empty;
        isIgnore = false;
    }

    /// <summary>
    /// 设置文字颜色
    /// </summary>
    internal Brush Foreground => !isIgnore ? Brushes.Black : Brushes.Gray;

    /// <summary>
    /// 分组逻辑记录
    /// </summary>
    public string GroupName { get; set; }

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
    public string Name { get; set; }

    /// <summary>
    /// 结果值
    /// </summary>
    public string ResultValue { get; set; }

    /// <summary>
    /// 设置划线
    /// </summary>
    public TextDecorationCollection? TextDecoration => isIgnore ? TextDecorations.Strikethrough : null;
}
