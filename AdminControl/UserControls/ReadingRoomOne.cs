using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AdminControl
{
    /// <summary>
    /// 阅片室1
    /// </summary>
    public partial class ReadingRoomOne : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 主窗体实例
        /// </summary>
        private frm_Main frm_Main;

        /// <summary>
        /// 控制端状态刷新委托
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="ForeColor"></param>
        private delegate void ControlStatusChangeDelegate(string Status, Color ForeColor);

        /// <summary>
        /// 客户端状态刷新委托
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="ForeColor"></param>
        private delegate void ClientStatusChangeDelegate(string Status, Color ForeColor);
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="frm_Main"></param>
        public ReadingRoomOne(frm_Main frm_Main)
        {
            InitializeComponent();
            InitItems(frm_Main);
        }
        #endregion

        #region 用户事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadingRoomOne_Load(object sender, EventArgs e)
        {


        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="frm_Main"></param>
        private void InitItems(frm_Main frm_Main)
        {
            this.frm_Main = frm_Main;
        }
        #endregion

        #region 接收阅片室数据
        /// <summary>
        /// 接收数据线程启动
        /// </summary>
        /// <param name="UserConnection"></param>
        public void RecvDeviceDataThreadStart(Socket UserConnection)
        {
            Thread RecvDeviceDataThread = new Thread(RecvDeviceData);
            RecvDeviceDataThread.IsBackground = true;
            RecvDeviceDataThread.Start(UserConnection);
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvDeviceData(object Connection)
        {
            Socket ClientSocket = Connection as Socket;

            //接收数据长度
            int Length;

            //接收消息字符串
            string StrMsg = null;

            while (true)
            {
                //定义2M缓冲区
                byte[] MsgRecv = new byte[1024 * 1024 * 2];

                try
                {
                    //阻塞接收数据
                    Length = ClientSocket.Receive(MsgRecv);

                    if (Length == 0)
                    {
                        frm_Main.Log.WriteLog(string.Format("阅片室控制端{0}已下线", ClientSocket.RemoteEndPoint.ToString().Split(':')[0]));
                        ControlStatusChange("未连接", Color.Red);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("阅片室控制端异常：" + ex.Message);
                    ControlStatusChange("未连接", Color.Red);
                    break;
                }

                StrMsg = Encoding.UTF8.GetString(MsgRecv, 1, Length - 1);
                frm_Main.Log.WriteLog("接收到阅片室控制端数据：" + StrMsg);
            }
        }
        #endregion

        #region 接收客户端指令
        /// <summary>
        /// 启动客户端指令接收线程
        /// </summary>
        /// <param name="UserConnection"></param>
        public void RecvClientCommandThreadStart(Socket UserConnection)
        {
            Thread RecvClientCommandThread = new Thread(RecvClientCommand);
            RecvClientCommandThread.IsBackground = true;
            RecvClientCommandThread.Start(UserConnection);
        }

        /// <summary>
        /// 客户端指令接收线程
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvClientCommand(object Connection)
        {
            Socket ClientSocket = Connection as Socket;

            //接收数据长度
            int Length;

            //接收消息字符串
            string StrMsg = null;

            while (true)
            {
                //定义2M缓冲区
                byte[] MsgRecv = new byte[1024 * 1024 * 2];

                try
                {
                    //阻塞接收数据
                    Length = ClientSocket.Receive(MsgRecv);

                    if (Length == 0)
                    {
                        frm_Main.Log.WriteLog(string.Format("阅片室客户端{0}已下线", ClientSocket.RemoteEndPoint.ToString().Split(':')[0]));
                        ClientStatusChange("未连接", Color.Red);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("阅片室客户端异常：" + ex.Message);
                    ClientStatusChange("未连接", Color.Red);
                    break;
                }

                StrMsg = Encoding.UTF8.GetString(MsgRecv, 1, Length - 1);
                frm_Main.Log.WriteLog("接收到阅片室客户端指令：" + StrMsg);
            }
        }
        #endregion

        #region 刷新控件
        /// <summary>
        /// 控制器连接状态修改
        /// </summary>
        /// <param name="Status"></param>
        public void ControlStatusChange(string Status, Color ForeColor)
        {
            if (label_ControlStatus.InvokeRequired)
            {
                ControlStatusChangeDelegate Change = new ControlStatusChangeDelegate(ControlStatusChange);
                label_ControlStatus.Invoke(Change, Status, ForeColor);
            }
            else
            {
                label_ControlStatus.Text = Status;
                label_ControlStatus.ForeColor = ForeColor;
            }
        }

        /// <summary>
        /// 客户端连接状态修改
        /// </summary>
        /// <param name="Status"></param>
        public void ClientStatusChange(string Status, Color ForeColor)
        {
            if (label_ClientStatus.InvokeRequired)
            {
                ClientStatusChangeDelegate Change = new ClientStatusChangeDelegate(ClientStatusChange);
                label_ClientStatus.Invoke(Change, Status, ForeColor);
            }
            else
            {
                label_ClientStatus.Text = Status;
                label_ClientStatus.ForeColor = ForeColor;
            }
        }
        #endregion
    }
}
