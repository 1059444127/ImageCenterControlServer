using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DataTransferService;

namespace ImageCenterController
{
    public partial class frm_Main : Form
    {
        private Socket ControlSocket;

        private DataTransfer Data;

        private volatile bool is_Connected = false;

        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            Data = new DataTransfer();
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            ConnectServer();
        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void ConnectServer()
        {
            if (is_Connected)
            {
                try
                {
                    ControlSocket.Close();
                    btn_Connect.Text = "连接";
                    is_Connected = false;
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    return;
                }
            }

            string ServerIP = txt_ServerIP.Text;
            string ServerPort = txt_ServerPort.Text;

            if (string.IsNullOrEmpty(ServerIP.Trim(' ')) || string.IsNullOrEmpty(ServerPort.Trim(' ')))
            {
                MessageBox.Show("IP和端口号不能为空！", "错误");
                return;
            }

            IPAddress IP = IPAddress.Parse(ServerIP);
            IPEndPoint Point = new IPEndPoint(IP, int.Parse(ServerPort));

            ControlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                ControlSocket.Connect(Point);
                btn_Connect.Text = "断开";
                is_Connected = true;
                Thread SendThread = new Thread(SendMessage);
                SendThread.IsBackground = true;
                SendThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        private void SendMessage()
        {
            while (true)
            {
                if (is_Connected)
                {
                    try
                    {
                        Data.SendData(ControlSocket, txt_Send.Text.Replace(" ","\t") + ":CRC=4d83\r\n");
                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
