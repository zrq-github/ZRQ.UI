namespace HW.Revit.Collaborate.ComponentCoding.DB
{
    /// <summary>
    /// 编码参数
    /// </summary>
    internal interface ICodingParam
    {
        /// <summary>
        /// GroupName
        /// </summary>
        string GroupName { get; }

        /// <summary>
        /// ID
        /// </summary>
        string ID { get; }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 单位
        /// </summary>
        string ParmUnit { get; }
    }
}
