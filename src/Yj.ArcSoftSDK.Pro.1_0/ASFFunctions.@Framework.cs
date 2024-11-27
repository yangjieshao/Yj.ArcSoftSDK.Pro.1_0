using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Yj.ArcSoftSDK.Pro._1_0.Models;
using Yj.ArcSoftSDK.Pro._1_0.Utils;

namespace Yj.ArcSoftSDK.Pro._1_0
{
    /// <summary>
    /// </summary>
    public static partial class ASFFunctions
    {
        private const string NotSupportedMsg = "Only supported Linux x64";
        /// <summary>
        /// 采集当前设备信息
        /// </summary>
        public static string GetActiveDeviceInfo()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }
            var deviceInfo = IntPtr.Zero;
            _ = ASFFunctions_Pro_Linux.ASFGetActiveDeviceInfo(ref deviceInfo);
            return MemoryUtil.PtrToString(deviceInfo);
        }

        /// <summary>
        /// 离线激活
        /// </summary>
        /// <param name="activationFilePath">许可文件路径</param>
        public static int OfflineActivation(string activationFilePath)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }
            if (string.IsNullOrWhiteSpace(activationFilePath)
                || !System.IO.File.Exists(activationFilePath))
            {
                return -1;
            }


            var result = ASFFunctions_Pro_Linux.ASFOfflineActivation(activationFilePath);
            if (result == 0
                || result == 0x16002 /* SDK已激活 */
                || result == 0x19007 /* 离线授权文件不可用，本地原有激活文件可继续使用 */)
            {
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// 激活SDK
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="sox64Key"></param>
        /// <param name="sox64ProActiveKey">永久授权版 秘钥 </param>
        /// <param name="activationFilePath">许可文件路径 空表示离线激活</param>
        /// <returns></returns>
        public static int Activation(string appId,string sox64Key
            , string sox64ProActiveKey = null , string activationFilePath = null)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }

            var result = OfflineActivation(activationFilePath);
            if (result == 0)
            {
                return result;
            }


            var pASF_ActiveFileInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf(typeof(ASF_ActiveFileInfo)));

            if (!string.IsNullOrEmpty(sox64ProActiveKey))
            {
                result = ASFFunctions_Pro_Linux.ASFGetActiveFileInfo(pASF_ActiveFileInfo);
            }

            var aSF_ActiveFileInfo = default(ASF_ActiveFileInfo);
            if (result == 0)
            {
                aSF_ActiveFileInfo = (ASF_ActiveFileInfo)MemoryUtil.PtrToStructure(pASF_ActiveFileInfo, typeof(ASF_ActiveFileInfo));
            }
            MemoryUtil.Free(ref pASF_ActiveFileInfo);
            if (result == 0
                && long.TryParse(aSF_ActiveFileInfo.EndTime, out long endTime)
                && long.TryParse(aSF_ActiveFileInfo.StartTime, out long startTime)
                && (DateTime.Now.ToTimestamp() / 1000) < endTime
                && (DateTime.Now.ToTimestamp() / 1000) >= startTime
                && aSF_ActiveFileInfo.Platform.Contains("linux"))
            {
                return result;
            }
            if (!string.IsNullOrEmpty(sox64ProActiveKey))
            {
                result = ASFFunctions_Pro_Linux.ASFOnlineActivation(appId, sox64Key, sox64ProActiveKey);
                if (result != 0
                    && System.IO.File.Exists("ArcFacePro64.dat"))
                {
                    System.IO.File.Delete("ArcFacePro64.dat");
                    result = ASFFunctions_Pro_Linux.ASFOnlineActivation(appId, sox64Key, sox64ProActiveKey);
                }
            }
            return result;
        }

        /// <summary>
        /// 初始化引擎
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="isImgMode"></param>
        /// <param name="faceMaxNum">[1,10]</param>
        /// <param name="isAngleZeroOnly"></param>
        /// <param name="needFaceInfo">需要人脸信息(性别、年龄、角度)</param>
        /// <param name="needRgbLive">需要rgb活体</param>
        /// <param name="needIrLive">需要红外活体</param>
        /// <param name="needFaceFeature"> 需要提取人脸特征值</param>
        /// <param name="needImageQuality"> 是否需要图像质量检测</param>
        /// <param name="isBigRecMod"> 使用大模型 </param>
        public static int InitEngine(ref IntPtr pEngine, bool isImgMode = false, int faceMaxNum = 5, bool isAngleZeroOnly = true,
            bool needFaceInfo = false, bool needRgbLive = false, bool needIrLive = false, bool needFaceFeature = true,
            bool needImageQuality = false,bool isBigRecMod=true)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }
            if (faceMaxNum < 1)
            {
                faceMaxNum = 1;
            }
            if (faceMaxNum > 10)
            {
                faceMaxNum = 10;
            }
            //初始化引擎
            var detectMode = isImgMode ? ASF_DetectMode.ASF_DETECT_MODE_IMAGE : ASF_DetectMode.ASF_DETECT_MODE_VIDEO;
            //检测脸部的角度优先值
            var detectFaceOrientPriority = isAngleZeroOnly ? ASF_OrientPriority.ASF_OP_0_ONLY : ASF_OrientPriority.ASF_OP_ALL_OUT;
            //引擎初始化时需要初始化的检测功能组合
            var combinedMask = FaceEngineMask.ASF_FACE_DETECT;
            if (needFaceFeature)
            {
                combinedMask |= FaceEngineMask.ASF_FACERECOGNITION;
            }
            if (needFaceInfo)
            {
                // 年龄+性别 3M内存
                combinedMask = combinedMask | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER
                    | FaceEngineMask.ASF_MASKDETECT;//| FaceEngineMask.ASF_UPDATE_FACEDATA;
            }
            if (needRgbLive)
            {
                combinedMask |= FaceEngineMask.ASF_LIVENESS;
            }
            if (needIrLive)
            {
                combinedMask |= FaceEngineMask.ASF_IR_LIVENESS;
            }
            if (needImageQuality)
            {
                combinedMask |= FaceEngineMask.ASF_IMAGEQUALITY;
            }
            //初始化引擎，正常值为0，其他返回值请参考http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
            ASF_RecModel recModel = isBigRecMod ? ASF_RecModel.ASF_REC_LARGE : ASF_RecModel.ASF_REC_MIDDLE;

            int result = ASFFunctions_Pro_Linux.ASFInitEngine((uint)detectMode, (int)detectFaceOrientPriority, faceMaxNum, (int)combinedMask, (int)recModel,ref pEngine);
            return result;
        }

        /// <summary>
        /// </summary>
        public static int UninitEngine(ref IntPtr pEngine)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }
            int result = ASFFunctions_Pro_Linux.ASFUninitEngine(pEngine);
            pEngine = IntPtr.Zero;
            return result;
        }

        /// <summary>
        /// 人脸对比
        /// </summary>
        /// <param name="pEngine"></param>
        /// <param name="pFaceFeature1"></param>
        /// <param name="pFaceFeature2"></param>
        /// <param name="isIdcardCompare">是否证件照对比</param>
        public static float FaceFeatureCompare(IntPtr pEngine, IntPtr pFaceFeature1, IntPtr pFaceFeature2, bool isIdcardCompare)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }

            ASF_CompareModel compareModel = isIdcardCompare ? ASF_CompareModel.ASF_ID_PHOTO : ASF_CompareModel.ASF_LIFE_PHOTO;

            int retCode = ASFFunctions_Pro_Linux.ASFFaceFeatureCompare(pEngine, pFaceFeature1, pFaceFeature2, out float result, (int)compareModel);
            if (retCode != 0
                || result > 1)
            {
                // 相似度不可能大于1
                result = -1;
            }
            return result;
        }
    }
}