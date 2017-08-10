﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandleInterface
{
    /// <summary>
    /// 文件操作接口
    /// </summary>
    public interface IFileHandleInterface
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="Log"></param>
        void WriteLog(string Log);

        /// <summary>
        /// 打包日志
        /// </summary>
        /// <param name="InputPath"></param>
        /// <param name="OutPutPath"></param>
        void PacketLog(string InputPath, string OutPutPath);

        /// <summary>
        /// 清理日志
        /// </summary>
        /// <param name="Path"></param>
        void DeleteLog(string Path);
    }
}
