using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace NetworkInterface
{
    /// <summary>
    /// 网络通讯接口
    /// </summary>
    public interface INetworkInterface
    {
        /// <summary>
        /// 发送数据（不带超时检测）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="Data">待发送的数据</param>
        void SendData(Socket Connection, string Data);

        /// <summary>
        /// 发送数据（带超时检测）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="TimeOut">超时时间，单位：毫秒</param>
        /// <param name="Data">待发送的数据</param>
        void SendData(Socket Connection, int TimeOut, string Data);

        /// <summary>
        /// 接收数据（不带超时检测）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <returns>接收到的数据</returns>
        string RecvData(Socket Connection);

        /// <summary>
        /// 接收数据（带超时检测）
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="TimeOut"></param>
        /// <returns></returns>
        string RecvData(Socket Connection, int TimeOut); 
    }
}
