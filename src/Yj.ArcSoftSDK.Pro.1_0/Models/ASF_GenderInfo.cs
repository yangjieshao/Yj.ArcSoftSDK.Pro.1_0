using System;

namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// 性别结构体
    /// </summary>
    internal struct ASF_GenderInfo
    {
        /// <summary>
        /// 性别检测结果集合 0:男性; 1:女性; -1:未知
        /// <see cref="int"/>
        /// </summary>
        public nint GenderArray;

        /// <summary>
        /// 结果集大小
        /// </summary>
        public int Num;
    }
}