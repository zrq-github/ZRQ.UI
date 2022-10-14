using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoData
{
    /// <summary>
    /// 编码库节点
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// 自己的节点
        /// </summary>
        /// <remarks>唯一标识</remarks>
        string ID { get; }

        /// <summary>
        /// 父节点
        /// </summary>
        /// <remarks>父节点的唯一标识</remarks>
        string ParentID { get; }
    }
}