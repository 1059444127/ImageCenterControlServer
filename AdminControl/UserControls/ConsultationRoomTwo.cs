using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTransferService;
using System.Net.Sockets;
using System.Threading;

namespace AdminControl
{
    /// <summary>
    /// 会诊室2
    /// </summary>
    public partial class ConsultationRoomTwo : UserControl
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
        /// <param name="frm_Main"></param>
        public ConsultationRoomTwo(frm_Main frm_Main)
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
        private void ConsultationRoomTwo_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 会诊模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeHZ_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 议会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeYH_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 科会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_KH_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 胶片直投
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JP_Click(object sender, EventArgs e)
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

            ControlRefresh.RefreshButtons(gBx_LightsControl, false);
            ControlRefresh.RefreshButtons(gBx_ModeChange, false);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, false);
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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "会诊室2控制器");
            frm_Main.DataBase.UpdateTable(SQLString);

            Thread RecvDeviceStatusThread = new Thread(RecvDeviceStatus);
            RecvDeviceStatusThread.IsBackground = true;
            RecvDeviceStatusThread.Start(ControlSocket);

            ControlRefresh.RefreshButtons(gBx_ModeChange, true);
            ControlRefresh.RefreshButtons(gBx_LightsControl, true);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, true);
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
                    Status = Data.RecvData(Socket, 3000);
                }
                catch (Exception)
                {
                    frm_Main.Log.WriteLog(string.Format("会诊室2控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室2控制器");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ControlConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                    ControlRefresh.RefreshButtons(gBx_ModeChange, false);
                    ControlRefresh.RefreshButtons(gBx_LightsControl, false);
                    ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

                    break;
                }

                frm_Main.Log.WriteLog("会诊室2设备状态：" + Status);

                /*
                状态解析
                */

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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "会诊室2客户端");
            frm_Main.DataBase.UpdateTable(SQLString);

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
                    frm_Main.Log.WriteLog(string.Format("会诊室2客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室2客户端");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);
                    break;
                }

                frm_Main.Log.WriteLog("接收到会诊室2客户端指令：" + Command);

                /*
                指令解析
                */

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
                Data.SendData(ControlSocket, 3000, CMD);
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("会诊室2控制指令发送失败，控制端不在线");
                MessageBox.Show(ex.Message, "控制端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室2控制器");
                frm_Main.DataBase.UpdateTable(SQLString);

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
                Data.SendData(ClientSocket, 3000, Status);
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("会诊室2设备状态发送失败");
                MessageBox.Show(ex.Message, "会诊室2客户端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室2客户端");
                frm_Main.DataBase.UpdateTable(SQLString);

                is_ClientConnect = false;
            }
        }
        #endregion

        #region 模式切换
        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="Mode"></param>
        private void ModeChange(int Mode)
        {
            switch (Mode)
            {
                case 1:
                    SendControlCommand("会诊模式");
                    break;
                case 2:
                    SendControlCommand("议会模式");
                    break;
                case 3:
                    SendControlCommand("科会模式");
                    break;
                case 4:
                    SendControlCommand("胶片直投模式");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
