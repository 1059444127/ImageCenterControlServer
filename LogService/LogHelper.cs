using System;
using System.IO;

using FileHandleInterface;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace LogService
{
    /// <summary>
    /// 日志记录服务
    /// </summary>
    public class LogHelper : IFileHandleInterface
    {
        #region 全局变离
        /// <summary>
        /// 文件操作流
        /// </summary>
        private FileStream LogFS;

        /// <summary>
        /// 写文件流
        /// </summary>
        private StreamWriter LogSW;

        /// <summary>
        /// 日志路径
        /// </summary>
        private string LogPath;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="LogPath"></param>
        public LogHelper(string LogPath)
        {
            this.LogPath = LogPath;
            InitFileStream();
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化文件操作流
        /// </summary>
        private void InitFileStream()
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }

            LogPath = string.Format(LogPath + "\\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd hhmmss"));

            try
            {
                LogFS = new FileStream(LogPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                LogSW = new StreamWriter(LogFS);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 日志记录
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="Log"></param>
        public void WriteLog(string Log)
        {
            LogSW.Write("日志：" + "\t" + Log + "\r\n");
            LogSW.Write(DateTime.Now.ToString() + "\r\n");
            LogSW.Write("\r\n");
            LogSW.Flush();
            LogFS.Flush();
        }
        #endregion

        #region 打包日志
        /// <summary>
        /// 打包日志
        /// </summary>
        /// <param name="InputPath">压缩文件夹</param>
        /// <param name="OutPutPath">压缩后的文件名</param>
        public void PacketLog(string InputPath, string OutPutPath)
        {
            if (InputPath[InputPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            {
                InputPath += Path.DirectorySeparatorChar;
            }

            ZipOutputStream Stream = new ZipOutputStream(File.Create(OutPutPath));
            Stream.SetLevel(6);  //压缩级别 0-9

            CreateZipFiles(InputPath, Stream, InputPath);

            Stream.Finish();
            Stream.Close();
        }
        /// <summary>
        /// 递归压缩文件
        /// </summary>
        /// <param name="InputPath">待压缩的文件或文件夹路径</param>
        /// <param name="Stream">打包结果的zip文件路径（类似 D:\WorkSpace\a.zip）,全路径包括文件名和.zip扩展名</param>
        /// <param name="File"></param>
        private void CreateZipFiles(string InputPath, ZipOutputStream Stream, string File)
        {
            Crc32 CRC = new Crc32();

            string[] filesArray = Directory.GetFileSystemEntries(InputPath);

            foreach (var item in filesArray)
            {
                if (Directory.Exists(item))                     //如果当前是文件夹，递归
                {
                    CreateZipFiles(item, Stream, File);
                }
                else                                            //如果是文件，开始压缩
                {
                    try
                    {
                        FileStream fileStream = System.IO.File.OpenRead(item);

                        byte[] buffer = new byte[fileStream.Length];
                        fileStream.Read(buffer, 0, buffer.Length);
                        string tempFile = item.Substring(File.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(tempFile);
                        entry.DateTime = DateTime.Now;
                        entry.Size = fileStream.Length;
                        fileStream.Close();
                        CRC.Reset();
                        CRC.Update(buffer);
                        entry.Crc = CRC.Value;
                        Stream.PutNextEntry(entry);

                        Stream.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
        #endregion

        #region 删除日志
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="Path"></param>
        public void DeleteLog(string Path)
        {
            if (File.Exists(Path))
            {
                try
                {
                    File.Delete(Path);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion
    }
}
