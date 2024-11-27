namespace Yj.ArcSoftSDK.Pro._1_0.Models
{
    /// <summary>
    /// </summary>
    public enum ASF_ImagePixelFormat
    {
        /// <summary>
        /// 8-bit Y 通道，8-bit 2x2 采样 V 与 U 分量交织通道
        /// </summary>
        ASVL_PAF_NV21 = 0x802,//2050

        /// <summary>
        /// 8-bit Y 通道，8-bit 2x2 采样 U 与 V 分量交织通道
        /// </summary>
        ASVL_PAF_NV12 = 0x801,//2049

        /// <summary>
        /// RGB 分量交织，按 B, G, R, B 字节序排布
        /// <para>R	R  R  R	 R	R  R  R  G  G  G  G  G  G  G  G  B  B  B  B  B  B  B  B</para>
        /// </summary>
        ASVL_PAF_RGB24_B8G8R8 = 0x201,//513

        /// <summary>
        /// 8-bit Y 通道， 8-bit 2x2 采样 U 通道， 8-bit 2x2 采样 V 通道
        /// </summary>
        ASVL_PAF_I420 = 0x601, //1537

        /// <summary>
        /// 8-bit IR图像
        /// </summary>
        ASVL_PAF_GRAY = 0x701, // 1793
    }
}