using System;
using System.Text;
using System.Net.Mail;
using System.Net.Sockets;

using NetworkInterface;

namespace DataTransferService
{
    /// <summary>
    /// 数据传输服务（继承网络通讯接口）
    /// </summary>
    public class DataTransfer : INetworkInterface
    {
        #region 接收数据
        /// <summary>
        /// 接收数据（不带接收超时）
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
        /// 接收数据（带接收超时）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="TimeOut">接收超时（单位：毫秒）</param>
        /// <returns></returns>
        public string RecvData(Socket Connection, int TimeOut)
        {
            //接收数据长度
            int Length;

            //接收数据
            string Data = null;

            //定义2M缓冲区
            byte[] MsgRecv = new byte[1024 * 1024 * 2];

            //接收超时
            Connection.ReceiveTimeout = TimeOut;

            //阻塞接收数据
            Length = Connection.Receive(MsgRecv, MsgRecv.Length, 0);

            if (Length == 0)
            {
                throw new Exception("连接已断开");
            }

            Data = Encoding.UTF8.GetString(MsgRecv, 0, Length);

            return Data;
        }
        #endregion

        #region 发送数据
        /// <summary>
        /// 发送数据（不带发送超时）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="RawData">发送的数据</param>
        /// <returns>发送的字节数</returns>
        public void SendData(Socket Connection, string RawData)
        {
            //缓冲区
            byte[] Data = Encoding.UTF8.GetBytes(RawData);

            try
            {
                //发送数据
                Connection.Send(Data, Data.Length, 0);
            }
            catch (Exception)
            {
                throw new Exception("连接已断开");
            }
        }

        /// <summary>
        /// 发送数据（带发送超时）
        /// </summary>
        /// <param name="Connection">连接套接字</param>
        /// <param name="TimeOut">超时时间（单位：毫秒）</param>
        /// <param name="Data">发送的数据</param>
        public void SendData(Socket Connection, int TimeOut, string RawData)
        {
            //缓冲区
            byte[] Data = Encoding.UTF8.GetBytes(RawData);

            //发送超时
            Connection.SendTimeout = TimeOut;

            try
            {
                //发送数据
                Connection.Send(Data, Data.Length, 0);
            }
            catch (Exception)
            {
                throw new Exception("连接已断开");
            }
        }
        #endregion

        #region 发送邮件
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
        public bool SendEmail(string SendAddress, string Password, string Host, string[] RecvAddress, string[] CopyRecvAddress, string Subject, string Content, string[] FilePath)
        {
            MailAddress Address = new MailAddress(SendAddress);

            MailMessage Email = new MailMessage();

            if (RecvAddress != null)
            {
                foreach (var item in RecvAddress)
                {
                    Email.To.Add(item);
                }
            }

            if (CopyRecvAddress != null)
            {
                foreach (var item in CopyRecvAddress)
                {
                    Email.CC.Add(item);
                }
            }

            Email.From = Address;

            Email.Subject = Subject;
            Email.SubjectEncoding = Encoding.UTF8;

            Email.Body = Content;
            Email.BodyEncoding = Encoding.UTF8;

            Email.IsBodyHtml = true;

            Email.Priority = MailPriority.Normal;

            try
            {
                if (FilePath != null && FilePath.Length > 0)
                {
                    Attachment File = null;
                    foreach (var item in FilePath)
                    {
                        File = new Attachment(item);
                        Email.Attachments.Add(File);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("在添加附件时有错误:" + ex.Message);
            }

            SmtpClient Client = new SmtpClient();

            Client.EnableSsl = true;

            Client.UseDefaultCredentials = false;

            Client.Credentials = new System.Net.NetworkCredential(SendAddress, Password);

            Client.Host = Host;

            try
            {
                Client.Send(Email);
                Email.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("邮件发送失败:" + ex.Message);
            }
        }
        #endregion
    }
}
