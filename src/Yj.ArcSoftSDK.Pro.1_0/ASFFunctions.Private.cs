using System;
using System.Runtime.InteropServices;
using Yj.ArcSoftSDK.Pro._1_0.Models;
using Yj.ArcSoftSDK.Pro._1_0.Utils;

namespace Yj.ArcSoftSDK.Pro._1_0
{
    public partial class ASFFunctions
    {
        /// <summary>
        /// 年龄检测
        /// </summary>
        private static ASF_AgeInfo AgeEstimation(IntPtr pEngine)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }

            var pInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf(typeof(ASF_AgeInfo)));
            int retCode = ASFFunctions_Pro_Linux.ASFGetAge(pEngine, pInfo);

            var result = default(ASF_AgeInfo);
            if (retCode == 0)
            {
                result = (ASF_AgeInfo)MemoryUtil.PtrToStructure(pInfo, typeof(ASF_AgeInfo));
            }
            MemoryUtil.Free(ref pInfo);
            return result;
        }

        /// <summary>
        /// 性别检测
        /// </summary>
        private static ASF_GenderInfo GenderEstimation(IntPtr pEngine)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }

            var pInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf(typeof(ASF_GenderInfo)));
            int retCode = ASFFunctions_Pro_Linux.ASFGetGender(pEngine, pInfo);
            var result = default(ASF_GenderInfo);
            if (retCode == 0)
            {
                result = (ASF_GenderInfo)MemoryUtil.PtrToStructure(pInfo, typeof(ASF_GenderInfo));
            }
            MemoryUtil.Free(ref pInfo);
            return result;
        }

        /// <summary>
        /// RGB活体检测
        /// </summary>
        /// <param name="pEngine">引擎Handle</param>
        /// <returns>年龄检测结构体</returns>
        private static ASF_LivenessInfo LivenessInfo_RGB(IntPtr pEngine)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }

            var pInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf(typeof(ASF_LivenessInfo)));
            int retCode = ASFFunctions_Pro_Linux.ASFGetLivenessScore(pEngine, pInfo);
            var result = default(ASF_LivenessInfo);
            if (retCode == 0)
            {
                result = (ASF_LivenessInfo)MemoryUtil.PtrToStructure(pInfo, typeof(ASF_LivenessInfo));
            }
            MemoryUtil.Free(ref pInfo);
            return result;
        }

        /// <summary>
        /// 口罩检测
        /// </summary>
        /// <param name="pEngine">引擎Handle</param>
        /// <returns>年龄检测结构体</returns>
        private static ASF_MaskInfo MaskEstimation(IntPtr pEngine)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.ProcessArchitecture != Architecture.X64)
            {
                throw new NotSupportedException(NotSupportedMsg);
            }
            var pInfo = MemoryUtil.Malloc(MemoryUtil.SizeOf(typeof(ASF_MaskInfo)));
            int retCode = ASFFunctions_Pro_Linux.ASFGetMask(pEngine, pInfo);
            var result = default(ASF_MaskInfo);
            if (retCode == 0)
            {
                result = (ASF_MaskInfo)MemoryUtil.PtrToStructure(pInfo, typeof(ASF_MaskInfo));
            }
            MemoryUtil.Free(ref pInfo);
            return result;
        }
    }
}