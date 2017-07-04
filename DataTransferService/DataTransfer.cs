using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="Connection"></param>
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
            Length = Connection.Receive(MsgRecv);

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
        /// <param name="Data"></param>
        public void SendData(Socket Connection, byte[] Data)
        {

        }
    }
}
