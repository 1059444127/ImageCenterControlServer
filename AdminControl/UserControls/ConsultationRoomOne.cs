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
    /// 会诊室1
    /// </summary>
    public partial class ConsultationRoomOne : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 客户端连接标志位
        /// </summary>
        private volatile bool is_ClientConnect = false;

        /// <summary>
        /// 控制器连接标志位
        /// </summary>
        private volatile bool is_ControlConnect = false;

        /// <summary>
        /// 主窗体
        /// </summary>
        private frm_Main frm_Main;

        /// <summary>
        /// 客户端套接字
        /// </summary>
        private Socket ClientSocket;

        /// <summary>
        /// 控制端套接字
        /// </summary>
        private Socket ControlSocket;

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

        /// <summary>
        /// 刷新按钮状态委托
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="Status"></param>
        private delegate void RefreshButtonsStatusDelegate(Control Control, bool Status);
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public ConsultationRoomOne(frm_Main frm_Main)
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
        private void ConsultationRoomOne_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems(frm_Main frm_Main)
        {
            this.frm_Main = frm_Main;
            RefreshButtons(false, gBx_Lights);
            RefreshButtons(false, gBx_Mutrix);
        }
        #endregion

        #region 接收设备状态
        /// <summary>
        /// 接收设备状态线程启动
        /// </summary>
        /// <param name="Connection"></param>
        public void RecvDeviceStatusThreadStart(Socket Connection)
        {
            ControlSocket = Connection;
            is_ControlConnect = true;

            Thread RecvDeviceStatusThread = new Thread(RecvDeviceStatus);
            RecvDeviceStatusThread.IsBackground = true;
            RecvDeviceStatusThread.Start(Connection);

            RefreshButtons(true, gBx_Lights);
            RefreshButtons(true, gBx_Mutrix);
        }

        /// <summary>
        /// 接收设备状态
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvDeviceStatus(object Connection)
        {
            Socket Socket = Connection as Socket;

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
                    Length = Socket.Receive(MsgRecv);

                    if (Length == 0)
                    {
                        frm_Main.Log.WriteLog(string.Format("会诊室控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));
                        is_ControlConnect = false;
                        ControlStatusChange("未连接", Color.Red);
                        RefreshButtons(false, gBx_Lights);
                        RefreshButtons(false, gBx_Mutrix);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("会诊室控制端异常：" + ex.Message);
                    is_ControlConnect = false;
                    ControlStatusChange("未连接", Color.Red);
                    RefreshButtons(false, gBx_Lights);
                    RefreshButtons(false, gBx_Mutrix);
                    break;
                }

                StrMsg = Encoding.UTF8.GetString(MsgRecv, 0, Length);
                frm_Main.Log.WriteLog("会诊室设备状态：" + StrMsg);

                if (is_ClientConnect)
                {
                    SendDeviceStatus(StrMsg);
                }
            }
        }
        #endregion

        #region 接受客户端指令
        /// <summary>
        /// 接收客户端指令线程启动
        /// </summary>
        /// <param name="Connection"></param>
        public void RecvClientCommandThreadStart(Socket Connection)
        {
            ClientSocket = Connection;
            is_ClientConnect = true;

            Thread RecvClientCommandThread = new Thread(RecvClientCommand);
            RecvClientCommandThread.IsBackground = true;
            RecvClientCommandThread.Start(Connection);
        }

        /// <summary>
        /// 客户端指令接收线程
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvClientCommand(object Connection)
        {
            Socket Socket = Connection as Socket;

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
                    Length = Socket.Receive(MsgRecv);

                    if (Length == 0)
                    {
                        frm_Main.Log.WriteLog(string.Format("会诊室客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));
                        is_ClientConnect = false;
                        ClientStatusChange("未连接", Color.Red);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("会诊室客户端异常：" + ex.Message);
                    is_ClientConnect = false;
                    ClientStatusChange("未连接", Color.Red);
                    break;
                }

                StrMsg = Encoding.UTF8.GetString(MsgRecv, 0, Length);
                frm_Main.Log.WriteLog("接收到会诊室客户端指令：" + StrMsg);

                /*
                指令解析
                */

                if (is_ControlConnect)
                {
                    SendControlCommand(StrMsg);
                }
            }
        }
        #endregion

        #region 发送控制指令
        /// <summary>
        /// 发送控制指令
        /// </summary>
        /// <param name="CMD"></param>
        private void SendControlCommand(string CMD)
        {
            byte[] Command = Encoding.UTF8.GetBytes(CMD);

            try
            {
                ControlSocket.Send(Command);
                frm_Main.Log.WriteLog("指令发送成功");
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("指令发送失败");
                MessageBox.Show(ex.Message, "控制端已离线");
            }
        }
        #endregion

        #region 发送设备状态
        /// <summary>
        /// 发送设备状态
        /// </summary>
        /// <param name="Status"></param>
        private void SendDeviceStatus(string Status)
        {
            byte[] STS = Encoding.UTF8.GetBytes(Status);

            try
            {
                ClientSocket.Send(STS);
                frm_Main.Log.WriteLog("设备状态发送成功");
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("设备状态发送失败");
                MessageBox.Show(ex.Message, "客户端已离线");
            }
        }
        #endregion

        #region 连接状态刷新
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

        #region 按钮状态刷新
        /// <summary>
        /// 刷新指定区域按钮
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="Group"></param>
        private void RefreshButtons(bool Status,GroupBox Group)
        {
            foreach (Control item in Group.Controls)
            {
                RefreshButtonsStatus(item, Status);
            }
        }

        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        /// <param name="Button"></param>
        /// <param name="Status"></param>
        private void RefreshButtonsStatus(Control Button, bool Status)
        {
            if (Button.InvokeRequired)
            {
                RefreshButtonsStatusDelegate Refresh = new RefreshButtonsStatusDelegate(RefreshButtonsStatus);
                Button.Invoke(Refresh, Button, Status);
            }
            else
            {
                Button.Enabled = Status;
            }
        }
        #endregion
    }
}
