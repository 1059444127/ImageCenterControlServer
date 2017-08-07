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
        /// 发送数据接口
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="Data">待发送的数据</param>
        void SendData(Socket Connection, string Data);

        /// <summary>
        /// 接收数据接口
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <returns>接收到的数据</returns>
        string RecvData(Socket Connection);
    }
}
