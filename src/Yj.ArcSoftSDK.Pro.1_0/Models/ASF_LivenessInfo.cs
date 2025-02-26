﻿using System;

namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// </summary>
    internal struct ASF_LivenessInfo
    {
        /// <summary>
        /// 是否是真人
        /// 0：非真人；1：真人；-1：不确定；-2:传入人脸数>1；-3: 人脸过小 -4: 角度过大 -5: 人脸超出边界  -6: 深度图错误 -7: 红外图太亮了 -8：红外图过暗；-100：人脸质量错误
        /// <see cref="int"/>
        /// </summary>
        public nint IsLive;

        /// <summary>
        /// 结果集大小
        /// </summary>
        public int Num;
    }
}