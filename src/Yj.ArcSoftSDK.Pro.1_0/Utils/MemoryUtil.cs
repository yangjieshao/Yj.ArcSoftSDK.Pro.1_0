﻿using System;
using System.Runtime.InteropServices;

namespace Yj.ArcSoftSDK.Pro._1_0.Utils
{
    /// <summary>
    /// </summary>
    internal static class MemoryUtil
    {
        /// <summary>
        /// 申请内存
        /// </summary>
        /// <param name="len">内存长度(单位:字节)</param>
        /// <returns>内存首地址</returns>
        public static nint Malloc(int len)
        {
            return Marshal.AllocHGlobal(len);
        }

        public static string PtrToString(nint intPtr)
        {
            if (intPtr == nint.Zero)
            {
                return string.Empty;
            }
            return Marshal.PtrToStringAnsi(intPtr);
        }

        /// <summary>
        /// 释放ptr托管的内存
        /// </summary>
        /// <param name="ptr">托管指针</param>
        public static void Free(nint ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        /// <summary>
        /// 释放ptr托管的内存
        /// </summary>
        /// <param name="ptr">托管指针</param>
        public static void Free(ref nint ptr)
        {
            if (ptr != nint.Zero)
            {
                Free(ptr);
                ptr = nint.Zero;
            }
        }

        /// <summary>
        /// 将字节数组的内容拷贝到托管内存中
        /// </summary>
        /// <param name="source">元数据</param>
        /// <param name="startIndex">元数据拷贝起始位置</param>
        /// <param name="destination">托管内存</param>
        /// <param name="length">拷贝长度</param>
        public static void Copy(byte[] source, int startIndex, nint destination, int length)
        {
            Marshal.Copy(source, startIndex, destination, length);
        }

        /// <summary>
        /// 将托管内存的内容拷贝到字节数组中
        /// </summary>
        /// <param name="source">托管内存</param>
        /// <param name="destination">目标字节数组</param>
        /// <param name="startIndex">拷贝起始位置</param>
        /// <param name="length">拷贝长度</param>
        public static void Copy(nint source, byte[] destination, int startIndex, int length)
        {
            Marshal.Copy(source, destination, startIndex, length);
        }

        /// <summary>
        /// 将托管内存的内容拷贝到字节数组中
        /// </summary>
        /// <param name="source">托管内存</param>
        /// <param name="destination">目标字节数组</param>
        /// <param name="startIndex">拷贝起始位置</param>
        /// <param name="length">拷贝长度</param>
        public static void Copy(nint source, int[] destination, int startIndex, int length)
        {
            Marshal.Copy(source, destination, startIndex, length);
        }

        /// <summary>
        /// 将托管内存的内容拷贝到字节数组中
        /// </summary>
        /// <param name="source">托管内存</param>
        /// <param name="destination">目标字节数组</param>
        /// <param name="startIndex">拷贝起始位置</param>
        /// <param name="length">拷贝长度</param>
        public static void Copy(nint source, nint[] destination, int startIndex, int length)
        {
            Marshal.Copy(source, destination, startIndex, length);
        }

        /// <summary>
        /// 将结构体对象复制到ptr托管的内存
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ptr"></param>
        public static void StructureToPtr(object t, nint ptr)
        {
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
            Marshal.StructureToPtr(t, ptr, false);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        }

        /// <summary>
        /// 将ptr托管的内存转化为结构体对象
        /// </summary>
        public static object PtrToStructure(nint ptr, Type type)
        {
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
            return Marshal.PtrToStructure(ptr, type);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        }

        /// <summary>
        /// </summary>
        public static int PtrToInt(nint ptr)
        {
            var intBuffer = new byte[4];
            Marshal.Copy(ptr, intBuffer, 0, intBuffer.Length);
            return BitConverter.ToInt32(intBuffer, 0);
        }

        /// <summary>
        /// </summary>
        public static float PtrToFloat(nint ptr)
        {
            var intBuffer = new byte[4];
            Marshal.Copy(ptr, intBuffer, 0, intBuffer.Length);
            return BitConverter.ToSingle(intBuffer, 0);
        }

        /// <summary>
        /// 获取类型的大小
        /// </summary>
        /// <returns>类型的大小</returns>
        public static int SizeOf(Type type)
        {
#pragma warning disable IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
            return Marshal.SizeOf(type);
#pragma warning restore IL3050 // Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.
        }
    }
}