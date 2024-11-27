using System;
using System.Runtime.InteropServices;
using Yj.ArcSoftSDK.Pro._1_0.Models;

namespace Yj.ArcSoftSDK.Pro._1_0
{
    internal static partial class ASFFunctions_Pro_Linux
    {
        /// <summary>
        /// SDK动态链接库路径 自行复制至 /usr/lib
        /// <![CDATA[cp -Rf /mnt/d/Linux_x64/ArcLib/4.0/* /usr/lib]]>
        /// </summary>
        public const string Dll_PATH = "libarcsoft_face_engine.so";


        /// <summary>
        /// 获取激活文件信息接口
        /// </summary>
        /// <param name="activeFileInfo"><see cref="ASF_ActiveFileInfo "/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetActiveFileInfo(IntPtr activeFileInfo);

        /// <summary>
        /// 激活人脸识别SDK引擎函数
        /// </summary>
        /// <param name="appId">SDK对应的AppID</param>
        /// <param name="sdkKey">SDK对应的SDKKey</param>
        /// <param name="activeKey">授权码</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ASFOnlineActivation(string appId, string sdkKey, string activeKey);

        /// <summary>
        /// 采集当前设备信息
        /// </summary>
        /// <param name="deviceInfo">返回设备信息 <see cref="string"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ASFGetActiveDeviceInfo(ref IntPtr deviceInfo);

        /// <summary>
        /// 离线激活SDK
        /// </summary>
        /// <param name="filePath">许可文件路径(虹软开放平台开发者中心端获取的文件)</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int ASFOfflineActivation(string filePath);

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="detectMode">AF_DETECT_MODE_VIDEO 视频模式 | AF_DETECT_MODE_IMAGE 图片模式</param>
        /// <param name="detectFaceOrientPriority">检测脸部的角度优先值 <see cref="ASF_OrientPriority"/></param>
        /// <param name="detectFaceMaxNum">最大需要检测的人脸个数</param>
        /// <param name="combinedMask">用户选择需要检测的功能组合，可单个或多个 <see cref="FaceEngineMask"/></param>
        /// <param name="recModel">用户选择需要的人脸识别模型 <see cref="ASF_RecModel"/></param>
        /// <param name="pEngine">初始化返回的引擎handle</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFInitEngine(uint detectMode, int detectFaceOrientPriority, int detectFaceMaxNum, int combinedMask,int recModel, ref IntPtr pEngine);

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="format">图像颜色空间  <see cref="ASF_ImagePixelFormat"/></param>
        /// <param name="imgData">图像数据</param>
        /// <param name="detectedFaces">人脸检测结果</param>
        /// <param name="detectModel">预留字段 暂时使用 <see cref="ASF_DetectModel.ASF_DETECT_MODEL_RGB"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFDetectFaces(IntPtr pEngine, int width, int height, int format, IntPtr imgData, IntPtr detectedFaces, int detectModel);

        /// <summary>
        /// 人脸检测
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="imgData">图像数据 <see cref="ASVL_OFFSCREEN"/></param>
        /// <param name="detectedFaces">人脸检测结果</param>
        /// <param name="detectModel">预留字段 暂时使用 <see cref="ASF_DetectModel.ASF_DETECT_MODEL_RGB"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFDetectFacesEx(IntPtr pEngine, IntPtr imgData, IntPtr detectedFaces, int detectModel);

        /// <summary>
        /// 针对单张人脸区域的图像进行质量检测，不是针对整张图像
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="format">图像颜色空间  <see cref="ASF_ImagePixelFormat"/></param>
        /// <param name="imgData">图像数据</param>
        /// <param name="faceInfo">人脸检测结果<see cref="ASF_SingleFaceInfo"/></param>
        /// <param name="isMask">戴口罩为1，其它值认为未戴口罩</param>
        /// <param name="confidenceLevel">人脸图像质量检测结果</param>
        /// <param name="detectModel">预留字段 暂时使用 <see cref="ASF_DetectModel.ASF_DETECT_MODEL_RGB"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFImageQualityDetect(IntPtr pEngine, int width, int height, int format, IntPtr imgData, IntPtr faceInfo,int isMask,out float confidenceLevel, int detectModel);

        /// <summary>
        /// 人脸图像质量检测
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="imgData">图像数据 <see cref="ASVL_OFFSCREEN"/></param>
        /// <param name="faceInfo">人脸检测结果<see cref="ASF_SingleFaceInfo"/></param>
        /// <param name="isMask">仅支持传入1、0、-1，戴口罩 1，否则认为未戴口罩</param>
        /// <param name="confidenceLevel">人脸图像质量检测结果</param>
        /// <param name="detectModel">预留字段 暂时使用 <see cref="ASF_DetectModel.ASF_DETECT_MODEL_RGB"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFImageQualityDetectEx(IntPtr pEngine, IntPtr imgData, IntPtr faceInfo, int isMask, out float confidenceLevel, int detectModel);

        /// <summary>
        /// 单人脸特征提取
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="format">图像颜色空间  <see cref="ASF_ImagePixelFormat"/></param>
        /// <param name="imgData">图像数据</param>
        /// <param name="faceInfo">人脸检测结果<see cref="ASF_SingleFaceInfo"/></param>
        /// <param name="registerOrNot">注册照/识别照<see cref="ASF_RegisterOrNot"/> </param>
        /// <param name="mask">带口罩 1，否则0</param>
        /// <param name="faceFeature">人脸特征</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFFaceFeatureExtract(IntPtr pEngine, int width, int height, int format, IntPtr imgData, IntPtr faceInfo, int registerOrNot, int mask, IntPtr faceFeature);

        /// <summary>
        /// 单人脸特征提取
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="imgData">图像数据 <see cref="ASVL_OFFSCREEN"/></param>
        /// <param name="faceInfo">人脸检测结果<see cref="ASF_SingleFaceInfo"/></param>
        /// <param name="registerOrNot">注册照/识别照<see cref="ASF_RegisterOrNot"/> </param>
        /// <param name="mask">带口罩 1，否则0</param>
        /// <param name="faceFeature">人脸特征</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFFaceFeatureExtractEx(IntPtr pEngine, IntPtr imgData, IntPtr faceInfo, int registerOrNot, int mask, IntPtr faceFeature);

        /// <summary>
        /// 人脸特征比对
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="faceFeature1">待比较人脸特征1</param>
        /// <param name="faceFeature2"> 待比较人脸特征2</param>
        /// <param name="similarity">相似度(0.0~1.0)</param>
        /// <param name="compareModel">选择人脸特征比对模型 <see cref="Pro._1_0.Models.ASF_CompareModel"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFFaceFeatureCompare(IntPtr pEngine, IntPtr faceFeature1, IntPtr faceFeature2, out float similarity, int compareModel);

        /// <summary>
        /// 获取相关活体阈值
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="threshold">活体阈值<see cref="ASF_LivenessThreshold"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetLivenessParam(IntPtr pEngine, IntPtr threshold);

        /// <summary>
        /// 设置RGB/IR活体阈值，若不设置内部默认RGB：0.5 IR：0.7
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="threshold">活体阈值<see cref="ASF_LivenessThreshold"/></param>
        /// <returns></returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFSetLivenessParam(IntPtr pEngine, IntPtr threshold);

        /// <summary>
        /// 人脸信息检测（年龄/性别/口罩） 最多支持4张人脸信息检测，超过部分返回未知（活体仅支持单张人脸检测，超出返回未知）。
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="format">图像颜色空间  <see cref="ASF_ImagePixelFormat"/></param>
        /// <param name="imgData">图像数据</param>
        /// <param name="detectedFaces">人脸信息，用户根据待检测的功能裁减选择需要使用的人脸</param>
        /// <param name="combinedMask">1.检测的属性（ASF_AGE、ASF_GENDER、ASF_LIVENESS、ASF_MASKDETECT）支持多选,2.检测的属性须在引擎初始化接口的combinedMask参数中启用</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFProcess(IntPtr pEngine, int width, int height, int format, IntPtr imgData, IntPtr detectedFaces, int combinedMask);

        /// <summary>
        /// 人脸信息检测（年龄/性别/人脸3D角度） 最多支持4张人脸信息检测，超过部分返回未知（活体仅支持单张人脸检测，超出返回未知）。
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="imgData">LPASF_ImageData 图像数据</param>
        /// <param name="detectedFaces">人脸信息，用户根据待检测的功能裁减选择需要使用的人脸<see cref="ASF_MultiFaceInfo"/></param>
        /// <param name="combinedMask">1.检测的属性（ASF_AGE、ASF_GENDER、ASF_LIVENESS、ASF_MASKDETECT）支持多选,2.检测的属性须在引擎初始化接口的combinedMask参数中启用</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFProcessEx(IntPtr pEngine, IntPtr imgData, IntPtr detectedFaces, int combinedMask);

        /// <summary>
        /// 获取年龄信息
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="ageInfo">检测到的年龄信息<see cref="ASF_AgeInfo"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetAge(IntPtr pEngine, IntPtr ageInfo);

        /// <summary>
        /// 获取性别信息
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="genderInfo">检测到的性别信息<see cref="ASF_GenderInfo"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetGender(IntPtr pEngine, IntPtr genderInfo);

        /// <summary>
        /// 获取RGB活体结果
        /// </summary>
        /// <param name="hEngine">引擎handle</param>
        /// <param name="livenessInfo">活体检测信息<see cref="ASF_LivenessInfo"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetLivenessScore(IntPtr hEngine, IntPtr livenessInfo);

        /// <summary>
        /// 获取人脸是否戴口罩
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="maskInfo">检测到的性别信息<see cref="ASF_MaskInfo"/></param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetMask(IntPtr pEngine, IntPtr maskInfo);


        /// <summary>
        /// 该接口目前仅支持单人脸IR活体检测（不支持年龄、性别、3D角度的检测），默认取第一张人脸
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="format">颜色空间格式</param>
        /// <param name="imgData">图片数据</param>
        /// <param name="detectedFaces">人脸信息，用户根据待检测的功能裁减选择需要使用的人脸<see cref="ASF_MultiFaceInfo"/></param>
        /// <param name="combinedMask">目前只支持传入ASF_IR_LIVENESS属性的传入，且初始化接口需要传入 </param>
        /// <returns></returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFProcess_IR(IntPtr pEngine, int width, int height, int format, IntPtr imgData, IntPtr detectedFaces, int combinedMask);

        /// <summary>
        /// 该接口目前仅支持单人脸IR活体检测（不支持年龄、性别、3D角度的检测），默认取第一张人脸
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="imgData">LPASF_ImageData 图片数据</param>
        /// <param name="detectedFaces">人脸信息，用户根据待检测的功能裁减选择需要使用的人脸<see cref="ASF_MultiFaceInfo"/></param>
        /// <param name="combinedMask">目前只支持传入ASF_IR_LIVENESS属性的传入，且初始化接口需要传入 </param>
        /// <returns></returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFProcessEx_IR(IntPtr pEngine, IntPtr imgData, IntPtr detectedFaces, int combinedMask);

        /// <summary>
        /// 获取IR活体结果
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <param name="irLivenessInfo">检测到IR活体结果<see cref="ASF_LivenessInfo"/></param>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFGetLivenessScore_IR(IntPtr pEngine, IntPtr irLivenessInfo);

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <returns>调用结果<see cref="ASF_VERSION"/></returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial IntPtr ASFGetVersion();

        /// <summary>
        /// 销毁引擎
        /// </summary>
        /// <param name="pEngine">引擎handle</param>
        /// <returns>调用结果</returns>
        [LibraryImport(Dll_PATH, SetLastError = true)]
        internal static partial int ASFUninitEngine(IntPtr pEngine);

        /// TODO
        /// need add 
        /// ASFFaceFeatureCompare_Search
        /// ASFRegisterFaceFeature
        /// ASFRemoveFaceFeature
        /// ASFUpdateFaceFeature
        /// ASFGetFaceFeature
        /// ASFGetFaceCount
        /// 
        /// 少了额头相关

    }
}