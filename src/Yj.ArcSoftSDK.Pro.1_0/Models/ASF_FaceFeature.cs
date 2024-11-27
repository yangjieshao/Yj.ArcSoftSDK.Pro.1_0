using System;

namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// 人脸特征结构体
    /// </summary>
    internal struct ASF_FaceFeature
    {
        /// <summary>
        /// 特征值 byte[]
        /// </summary>
        public nint Feature;

        /// <summary>
        /// 结果集大小
        /// </summary>
        public int FeatureSize;
    }
}