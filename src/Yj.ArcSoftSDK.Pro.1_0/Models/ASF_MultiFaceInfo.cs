namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// 多人脸检测结构体
    /// </summary>
    internal struct ASF_MultiFaceInfo
    {

        /// <summary>
        /// 结果集大小
        /// </summary>
        public int FaceNum;

        /// <summary>
        /// 人脸Rect结果集
        /// <see cref="MRECT"/>
        /// </summary>
        public nint FaceRects;

        /// <summary>
        /// 人脸角度结果集
        /// <see cref="ASF_OrientCode"/>
        /// </summary>
        public nint FaceOrients;

        /// <summary>
        /// face ID，一张人脸从进入画面直到离开画面，faceID不变。在VIDEO模式下有效，IMAGE模式下为空
        /// <see cref="int"/>
        /// </summary>
        public nint FaceID;

        /// <summary>
        /// 多张人脸信息 <see cref="ASF_FaceDataInfo"/>
        /// </summary>
        public nint FaceDataInfoList;

        /// <summary>
        /// 人脸是否在边界内 0 人脸溢出；1 人脸在图像边界内
        /// <see cref="int"/>
        /// </summary>
        public nint FaceIsWithinBoundary;

        /// <summary>
        /// 人脸额头区域
        /// <see cref="MRECT"/>
        /// </summary>
        public nint ForeheadRect;

        /// <summary>
        /// 人脸属性信息
        /// <see cref="ASF_FaceAttributeInfo"/>
        /// </summary>
        public nint FaceAttributeInfo;

        /// <summary>
        /// 人脸3D角度
        /// <see cref="ASF_Face3DAngle"/>
        /// </summary>
        public nint Face3DAngleInfo;
    }
}