using System.ComponentModel;

namespace ZRQ.UI.Test.EnumTest
{
    /// <summary>
    /// Revit参数类型
    /// </summary>
    public enum RvtParamType
    {
        [Description("类型参数")]
        Category = 0,

        [Description("实例参数")]
        Inst,
    }
}
