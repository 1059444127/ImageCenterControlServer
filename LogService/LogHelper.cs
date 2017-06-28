using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogService
{
    /// <summary>
    /// 日志记录服务
    /// </summary>
    public class LogHelper
    {
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

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="LogPath"></param>
        public LogHelper(string LogPath)
        {
            this.LogPath = LogPath;
            InitFileStream();
        }

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

        /// <summary>
        /// 清理资源
        /// </summary>
        public void StopWriteLog()
        {
            try
            {
                LogSW.Close();
                LogFS.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
