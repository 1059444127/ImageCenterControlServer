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
using System.Net.Sockets;
using DataTransferService;

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
        /// 数据传输服务实例
        /// </summary>
        private DataTransfer Data;

        /// <summary>
        /// 控件刷新服务实例
        /// </summary>
        private ControlRefreshHelper ControlRefresh;

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

            Data = new DataTransfer();

            ControlRefresh = new ControlRefreshHelper();

            ControlRefresh.RefreshButtons(gBx_Mutrix, false);
            ControlRefresh.RefreshButtons(gBx_Lights, false);
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

            ControlRefresh.RefreshLabelStatus(label_ControlStatus, "已连接", Color.Black);

            Thread RecvDeviceStatusThread = new Thread(RecvDeviceStatus);
            RecvDeviceStatusThread.IsBackground = true;
            RecvDeviceStatusThread.Start(Connection);

            ControlRefresh.RefreshButtons(gBx_Mutrix, true);
            ControlRefresh.RefreshButtons(gBx_Lights, true);
        }

        /// <summary>
        /// 接收设备状态
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvDeviceStatus(object Connection)
        {
            Socket Socket = Connection as Socket;

            string Status = null;

            while (true)
            {
                try
                {
                    Status = Data.RecvData(Socket);
                }
                catch (Exception)
                {
                    frm_Main.Log.WriteLog(string.Format("会诊室控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));
                    is_ControlConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                    ControlRefresh.RefreshButtons(gBx_Mutrix, false);
                    ControlRefresh.RefreshButtons(gBx_Lights, false);

                    break;
                }

                frm_Main.Log.WriteLog("会诊室设备状态：" + Status);

                if (is_ClientConnect)
                {
                    SendDeviceStatus(Status);
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

            ControlRefresh.RefreshLabelStatus(label_ClientStatus, "已连接", Color.Black);

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

            string Command = null;

            while (true)
            {
                try
                {
                    Command = Data.RecvData(Socket);
                }
                catch (Exception)
                {
                    frm_Main.Log.WriteLog(string.Format("会诊室客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));
                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);

                    break;
                }

                frm_Main.Log.WriteLog("接收到会诊室客户端指令：" + Command);

                if (is_ControlConnect)
                {
                    SendControlCommand(Command);
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
            try
            {
                Data.SendData(ControlSocket, CMD);
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("会诊室控制指令发送失败，控制端不在线");
                MessageBox.Show(ex.Message, "控制端已离线");
                is_ControlConnect = false;
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
            try
            {
                Data.SendData(ClientSocket, Status);
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("设备状态发送失败");
                MessageBox.Show(ex.Message, "客户端已离线");
                is_ClientConnect = false;
            }
        }
        #endregion
    }
}
