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
using DataTransferService;
using DataHandleService;

namespace AdminControl
{
    /// <summary>
    /// 阅片室1
    /// </summary>
    public partial class ReadingRoomOne : UserControl
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
        /// 数据解析服务实例
        /// </summary>
        private DataHandleHelper DataHandle;

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

        /// <summary>
        /// 阅片模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeYP_Click(object sender, EventArgs e)
        {
            ModeChange(1);
        }

        /// <summary>
        /// 休息模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeXX_Click(object sender, EventArgs e)
        {
            ModeChange(2);
        }

        /// <summary>
        /// 离开模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeLK_Click(object sender, EventArgs e)
        {
            ModeChange(3);
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

            Data = new DataTransfer();

            DataHandle = new DataHandleHelper();

            ControlRefresh = new ControlRefreshHelper();

            ControlRefresh.RefreshButtons(gBx_LightsControl, false);
            ControlRefresh.RefreshButtons(gBx_ModeChange, false);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, false);
        }
        #endregion

        #region 接收环境数据
        /// <summary>
        /// 接收环境数据线程启动
        /// </summary>
        /// <param name="Connection"></param>
        public void RecvEnviroumentDataThreadStart(Socket Connection)
        {
            ControlSocket = Connection;
            is_ControlConnect = true;

            ControlRefresh.RefreshLabelStatus(label_ControlStatus, "已连接", Color.Black);

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "阅片室1控制器");
            frm_Main.DataBase.UpdateTable(SQLString);

            Thread RecvDeviceStatusThread = new Thread(RecvEnviroumentData);
            RecvDeviceStatusThread.IsBackground = true;
            RecvDeviceStatusThread.Start(ControlSocket);

            ControlRefresh.RefreshButtons(gBx_ModeChange, true);
            ControlRefresh.RefreshButtons(gBx_LightsControl, true);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, true);
        }

        /// <summary>
        /// 接收环境数据
        /// </summary>
        /// <param name="Connection"></param>
        private void RecvEnviroumentData(object Connection)
        {
            Socket Socket = Connection as Socket;

            string EnviroumentData = null;

            string Temp = string.Empty;
            string Hum = string.Empty;
            string Light = string.Empty;
            string Noise = string.Empty;

            string SQLString = string.Empty;

            while (true)
            {
                try
                {
                    EnviroumentData = Data.RecvData(Socket, 3000);
                }
                catch (Exception)
                {
                    frm_Main.Log.WriteLog(string.Format("阅片室1控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室1控制器");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ControlConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                    ControlRefresh.RefreshButtons(gBx_ModeChange, false);
                    ControlRefresh.RefreshButtons(gBx_LightsControl, false);
                    ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

                    ControlRefresh.RefreshLabelStatus(label_Temp, "初始化...", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Hum, "初始化...", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Light, "初始化...", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Noise, "初始化...", Color.Black);

                    break;
                }

                frm_Main.Log.WriteLog("阅片室1环境数据：" + EnviroumentData.Replace("\r\n", "\0"));

                /*
                数据解析
                */
                Temp = DataHandle.GetHouseTemp(EnviroumentData);
                Hum = DataHandle.GetHouseHum(EnviroumentData);
                Light = DataHandle.GetHouseLight(EnviroumentData);
                Noise = DataHandle.GetHouseNoise(EnviroumentData);

                //检查数据
                if (Temp.Contains("ERROR") || Hum.Contains("ERROR") || Light.Contains("ERROR") || Noise.Contains("ERROR"))
                {
                    frm_Main.Log.WriteLog("接受到错误环境数据，已舍弃");
                    continue;
                }

                //修改数据库
                SQLString = string.Format("update tb_roomenviroument set room_temp = \"{0}\", room_hum = \"{1}\", room_light = \"{2}\",room_noise = \"{3}\" where room_name = \"{4}\";", Temp, Hum, Light, Noise, "阅片室1");
                frm_Main.DataBase.UpdateTable(SQLString);

                /*
                刷新控件
                */
                ControlRefresh.RefreshLabelStatus(label_Temp, Temp, Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Hum, Hum, Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Light, Light, Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Noise, Noise, Color.Black);

                /*
                数据打包
                */

                /*
                数据发送 
                */
                if (is_ClientConnect)
                {
                    SendEnviroumentData(EnviroumentData);
                }
            }
        }
        #endregion

        #region 接收用户指令
        /// <summary>
        /// 接收客户端指令线程启动
        /// </summary>
        /// <param name="Connection"></param>
        public void RecvClientCommandThreadStart(Socket Connection)
        {
            ClientSocket = Connection;
            is_ClientConnect = true;

            ControlRefresh.RefreshLabelStatus(label_ClientStatus, "已连接", Color.Black);

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "阅片室1客户端");
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
                    frm_Main.Log.WriteLog(string.Format("阅片室1客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室1客户端");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);
                    break;
                }

                frm_Main.Log.WriteLog("接收到阅片室1客户端指令：" + Command);

                /*
                指令解析
                */

                /*
                指令打包
                */

                if (is_ControlConnect)
                {
                    SendControlCommand(Command);
                }
            }
        }
        #endregion

        #region 发送环境数据
        /// <summary>
        /// 发送环境数据
        /// </summary>
        /// <param name="Data"></param>
        private void SendEnviroumentData(string EnviroumentData)
        {
            try
            {
                Data.SendData(ClientSocket, 3000, EnviroumentData);
            }
            catch (Exception ex)
            {
                frm_Main.Log.WriteLog("阅片室1环境数据发送失败");
                MessageBox.Show(ex.Message, "阅片室1客户端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室1客户端");
                frm_Main.DataBase.UpdateTable(SQLString);

                is_ClientConnect = false;
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
                frm_Main.Log.WriteLog("阅片室1控制指令发送失败，控制端不在线");
                MessageBox.Show(ex.Message, "阅片室1控制端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室1控制器");
                frm_Main.DataBase.UpdateTable(SQLString);

                is_ControlConnect = false;
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
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
