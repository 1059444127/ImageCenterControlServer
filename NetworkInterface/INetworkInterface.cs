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

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="SendAddress">发件人地址</param>
        /// <param name="Password">发件人密码</param>
        /// <param name="Host">SMTP服务器</param>
        /// <param name="RecvAddress">收件人地址</param>
        /// <param name="CopyRecvAddress">抄送地址</param>
        /// <param name="Subject">主题</param>
        /// <param name="Content">内容</param>
        /// <param name="FilePath">附件</param>
        /// <returns></returns>
        bool SendEmail(string SendAddress, string Password, string Host, string[] RecvAddress, string[] CopyRecvAddress, string Subject, string Content, string[] FilePath);
    }
}
