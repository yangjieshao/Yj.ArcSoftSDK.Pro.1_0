namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// 活体置信度
    /// </summary>
    internal struct ASF_LivenessThreshold
    {
        /// <summary>
        /// BGR活体检测阈值设置，默认值0.5
        /// </summary>
        public float Thresholdmodel_BGR;
        /// <summary>
        /// IR活体检测阈值设置，默认值0.7
        /// </summary>
        public float Thresholdmodel_IR;
        /// <summary>
        /// BGR活体人脸质量置信度，默认值0.65
        /// </summary>
        public float Thresholdmodel_FQ;
    }
}