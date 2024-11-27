using System;

/* 项目“Yj.ArcSoftSDK.Pro.1_0 (NET8.0)”的未合并的更改
在此之前:
using Yj.ArcSoftSDK.Pro._1_0.Models;
在此之后:
using Yj;
using Yj.ArcSoftSDK;
using Yj.ArcSoftSDK._4_0;
using Yj.ArcSoftSDK._4_0.Models;
using Yj.ArcSoftSDK.Pro._1_0.Models;
*/

namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    ///
    /// </summary>
    public class ImageInfo
    {
        /// <summary>
        /// 图片的像素数据
        /// </summary>
        public nint ImgData { get; set; }

        /// <summary>
        /// 图片像素宽
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 图片像素高
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 图片格式
        /// </summary>
        public ASF_ImagePixelFormat Format { get; set; }
        /// <summary>
        /// 步长
        /// </summary>
        public int WidthStep { get; set; }
    }
}