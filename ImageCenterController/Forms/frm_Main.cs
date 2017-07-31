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
using LogService;

namespace ImageCenterController
{
    /// <summary>
    /// 控制器模拟
    /// </summary>
    public partial class frm_Main : Form
    {
        #region 全局变量
        /// <summary>
        /// 连接套接字
        /// </summary>
        private Socket ControlSocket;

        /// <summary>
        /// 数据传输实例
        /// </summary>
        private DataTransfer Data;

        /// <summary>
        /// 日志服务实例
        /// </summary>
        private LogHelper Log;

        /// <summary>
        /// 连接标志位
        /// </summary>
        private volatile bool is_Connected = false;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public frm_Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 用户事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_Load(object sender, EventArgs e)
        {
            Data = new DataTransfer();
            Log = new LogHelper(Application.StartupPath + "\\Log");
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
        #endregion

        #region 功能函数
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
                    Log.WriteLog("关闭连接成功");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                    Log.WriteLog("关闭连接失败");
                    return;
                }
            }

            string ServerIP = txt_ServerIP.Text;
            string ServerPort = txt_ServerPort.Text;

            if (string.IsNullOrEmpty(ServerIP.Trim(' ')) || string.IsNullOrEmpty(ServerPort.Trim(' ')))
            {
                MessageBox.Show("IP和端口号不能为空！", "错误");
                Log.WriteLog("连接服务器失败.IP和端口号不能为空");
                return;
            }

            IPAddress IP = IPAddress.Parse(ServerIP);
            IPEndPoint Point = new IPEndPoint(IP, int.Parse(ServerPort));

            ControlSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                ControlSocket.Connect(Point);
                btn_Connect.Text = "断开";
                Log.WriteLog("连接服务器成功");
                is_Connected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                Log.WriteLog("连接服务器失败" + ex.Message);
            }
        }
        #endregion
    }
}
