using System;
using System.Collections.Generic;
using ZRQ.UI.Test.EnumTest;

namespace HW.Revit.Collaborate.ComponentCoding.DB
{
    /// <summary>
    /// 节点参数结构
    /// </summary>
    public class CodingParam : ICodingParam, ICloneable
    {
        private string _groupID = string.Empty;
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _parmUnit = string.Empty;
        private RvtParamGroupType _rvtParmGroupType = RvtParamGroupType.Text;
        private RvtParamType _rvtParmType = RvtParamType.Category;
        private string _value = string.Empty;

        public CodingParam(string id)
        {
            this._id = id;
        }

        /// <summary>
        /// 参数分组
        /// </summary>
        public string GroupName { get => _groupID; set => _groupID = value; }

        /// <summary>
        /// 编码参数ID
        /// </summary>
        /// <remarks> 用于内部标识 </remarks>
        public string ID { get => _id; private set => _id = value; }

        /// <summary>
        /// 名字
        /// </summary>
        /// <remarks> 显示的名字 </remarks>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// 参数单位
        /// </summary>
        public string ParmUnit { get => _parmUnit; set => _parmUnit = value; }

        /// <summary>
        /// Revit参数分组
        /// </summary>
        public RvtParamGroupType RvtParmGroupType { get => _rvtParmGroupType; set => _rvtParmGroupType = value; }

        /// <summary>
        /// Rvt参数类型
        /// </summary>
        public RvtParamType RvtParmType { get => _rvtParmType; set => _rvtParmType = value; }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <remarks> 只有基本类型所以浅拷贝 </remarks>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 节点参数数组
    /// </summary>
    public class CodingParams : List<CodingParam>
    {
        private string parentId;

        public CodingParams()
        {
            this.parentId = String.Empty;
        }

        /// <summary>
        /// 父节点 -&gt; 结点的GUID
        /// </summary>
        public string ParentID { get => parentId; set => parentId = value; }
    }
}
