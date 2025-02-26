﻿namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// 图片检测模式
    /// </summary>
    internal enum ASF_DetectMode : uint
    {
        /// <summary>
        /// Video模式，一般用于多帧连续检测
        /// </summary>
        ASF_DETECT_MODE_VIDEO = 0x00000000,

        /// <summary>
        /// Image模式，一般用于静态图的单次检测
        /// </summary>
        ASF_DETECT_MODE_IMAGE = 0xFFFFFFFF
    }
}