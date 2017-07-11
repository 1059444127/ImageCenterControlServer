using System;
using System.Text;
using System.Net.Sockets;

namespace DataTransferService
{
    /// <summary>
    /// 数据传输服务
    /// </summary>
    public class DataTransfer
    {
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <returns></returns>
        public string RecvData(Socket Connection)
        {
            //接收数据长度
            int Length;

            //接收数据
            string Data = null;

            //定义2M缓冲区
            byte[] MsgRecv = new byte[1024 * 1024 * 2];

            //阻塞接收数据
            Length = Connection.Receive(MsgRecv, MsgRecv.Length, 0);

            if (Length == 0)
            {
                throw new Exception("连接已断开");
            }

            Data = Encoding.UTF8.GetString(MsgRecv, 0, Length);

            return Data;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="RawData"></param>
        /// <returns>发送的字节数</returns>
        public void SendData(Socket Connection, string RawData)
        {
            byte[] Data = Encoding.UTF8.GetBytes(RawData);

            try
            {
                Connection.Send(Data, Data.Length, 0);
            }
            catch (Exception)
            {
                throw new Exception("连接已断开");
            }
        }
    }
}
