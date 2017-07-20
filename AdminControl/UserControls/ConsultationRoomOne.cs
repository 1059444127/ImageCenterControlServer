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
using System.Xml;

using DataTransferService;
using CommandHandleService;

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
        /// 模式列表
        /// </summary>
        private List<ModeConfig> ModeList;

        /// <summary>
        /// 灯光列表
        /// </summary>
        private List<LightConfig> LightList;

        /// <summary>
        /// 数据传输服务实例
        /// </summary>
        private DataTransfer Data;

        /// <summary>
        /// 控件刷新服务实例
        /// </summary>
        private ControlRefreshHelper ControlRefresh;

        /// <summary>
        /// 指令解析实例
        /// </summary>
        private CommandHandleHelper CommandHandle;

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

        /// <summary>
        /// 切换会诊模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeHZ_Click(object sender, EventArgs e)
        {
            ModeChange(1);
        }

        /// <summary>
        /// 切换议会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ModeYH_Click(object sender, EventArgs e)
        {
            ModeChange(2);
        }

        /// <summary>
        /// 切换科会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_KH_Click(object sender, EventArgs e)
        {
            ModeChange(3);
        }

        /// <summary>
        /// 切换胶片直投
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JP_Click(object sender, EventArgs e)
        {
            ModeChange(4);
        }

        /// <summary>
        /// 投影机1开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ProjectorOne_On_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 投影机1关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ProjectorOne_Off_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 投影机2开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ProjectorTwo_On_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 投影机2关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ProjectorTwo_Off_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 镜头开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Camera_On_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 镜头关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Camera_Off_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗帘打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Windows_On_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 窗帘关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Windows_Off_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 幕布下降
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Film_Down_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 幕布上升
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Film_Up_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 顶灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TopLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, true);
        }

        /// <summary>
        /// 顶灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_TopLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, false);
        }

        /// <summary>
        /// 壁灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WallLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, true);
        }

        /// <summary>
        /// 壁灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WallLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, false);
        }

        /// <summary>
        /// 灯带开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RoundLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, true);
        }

        /// <summary>
        /// 灯带关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_RoundLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, false);
        }

        /// <summary>
        /// 灯光开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AllLights_On_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), true);
        }

        /// <summary>
        /// 灯光关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AllLights_Off_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), false);
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

            CommandHandle = new CommandHandleHelper();

            ControlRefresh.RefreshButtons(gBx_LightsControl, false);
            //ControlRefresh.RefreshButtons(gBx_ModeChange, false);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

            ReadUserConfig();
        }
        #endregion

        #region 读取用户配置
        /// <summary>
        /// 读取用户配置
        /// </summary>
        private void ReadUserConfig()
        {
            //读取模式配置
            ModeList = new List<ModeConfig>();
            XmlDocument ModeDoc = new XmlDocument();
            XmlReaderSettings ModeSetting = new XmlReaderSettings();
            ModeSetting.IgnoreComments = true;
            XmlReader ModeReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoomOne\\ModeConfig.xml", ModeSetting);
            ModeDoc.Load(ModeReader);
            XmlNode ModeRootNode = ModeDoc.SelectSingleNode("Modes");
            XmlNodeList ModeRootChilds = ModeRootNode.ChildNodes;
            foreach (XmlNode Node in ModeRootChilds)
            {
                ModeConfig Mode = new ModeConfig();
                XmlElement Element = (XmlElement)Node;
                XmlNodeList Childs = Element.ChildNodes;
                Mode.ModeName = Childs.Item(0).InnerText;
                Mode.Relays = Childs.Item(1).InnerText;
                Mode.Projector = Childs.Item(2).InnerText;
                Mode.Matrix = Childs.Item(3).InnerText;
                Mode.Camera = Childs.Item(4).InnerText;
                ModeList.Add(Mode);
            }
            ModeReader.Close();

            //读取灯光配置
            LightList = new List<LightConfig>();
            XmlDocument LightDoc = new XmlDocument();
            XmlReaderSettings LightSetting = new XmlReaderSettings();
            LightSetting.IgnoreComments = true;
            XmlReader LightReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoomOne\\LightConfig.xml", LightSetting);
            LightDoc.Load(LightReader);
            XmlNode LightRootNode = LightDoc.SelectSingleNode("Lights");
            XmlNodeList LightRootChilds = LightRootNode.ChildNodes;
            foreach (XmlNode Node in LightRootChilds)
            {
                LightConfig Light = new LightConfig();
                XmlElement Element = (XmlElement)Node;
                XmlNodeList Childs = Element.ChildNodes;
                Light.LightName = Childs.Item(0).InnerText;
                Light.RelayNumber = Childs.Item(1).InnerText;
                LightList.Add(Light);
            }
            LightReader.Close();
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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "会诊室1控制器");
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
                    frm_Main.Log.WriteLog(string.Format("会诊室1控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室1控制器");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ControlConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                    ControlRefresh.RefreshButtons(gBx_ModeChange, false);
                    ControlRefresh.RefreshButtons(gBx_LightsControl, false);
                    ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

                    break;
                }

                frm_Main.Log.WriteLog("会诊室1设备状态：" + Status);

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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "会诊室1客户端");
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
                    frm_Main.Log.WriteLog(string.Format("会诊室1客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室1客户端");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);
                    break;
                }

                frm_Main.Log.WriteLog("接收到会诊室1客户端指令：" + Command);

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
                frm_Main.Log.WriteLog("会诊室1控制指令发送失败，控制端不在线");
                MessageBox.Show(ex.Message, "控制端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室1控制器");
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
                frm_Main.Log.WriteLog("会诊室1设备状态发送失败");
                MessageBox.Show(ex.Message, "会诊室1客户端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室1客户端");
                frm_Main.DataBase.UpdateTable(SQLString);

                is_ClientConnect = false;
            }
        }
        #endregion

        #region 设备控制

        #region 模式切换
        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="Mode"></param>
        private void ModeChange(int Mode)
        {
            string Command = string.Empty;

            switch (Mode)
            {
                case 1:
                    //继电器状态修改
                    Command = CommandHandle.GetRelayCommand(ModeList[0].Relays.Split(' ')[0], ModeList[0].Relays.Split(' ')[1]);
                    SendControlCommand(Command);

                    //矩阵切换
                    Command = CommandHandle.GetMatrixCommand(ModeList[0].Matrix.Split(' ')[0], ModeList[0].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);

                    //打开投影机
                    Command = CommandHandle.GetProjectorCommand(ModeList[0].Projector);
                    SendControlCommand(Command);
                    break;
                case 2:
                    //继电器状态修改
                    Command = CommandHandle.GetRelayCommand(ModeList[1].Relays.Split(' ')[0], ModeList[1].Relays.Split(' ')[1]);
                    SendControlCommand(Command);

                    //矩阵切换
                    Command = CommandHandle.GetMatrixCommand(ModeList[1].Matrix.Split(' ')[0], ModeList[1].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    break;
                case 3:
                    Command = CommandHandle.GetRelayCommand(ModeList[2].Relays.Split(' ')[0], ModeList[2].Relays.Split(' ')[1]);
                    SendControlCommand(Command);

                    //矩阵切换
                    Command = CommandHandle.GetMatrixCommand(ModeList[2].Matrix.Split(' ')[0], ModeList[2].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    break;
                case 4:
                    //继电器状态修改
                    Command = CommandHandle.GetRelayCommand(ModeList[3].Relays.Split(' ')[0], ModeList[3].Relays.Split(' ')[1]);
                    SendControlCommand(Command);

                    //矩阵切换
                    Command = CommandHandle.GetMatrixCommand(ModeList[3].Matrix.Split(' ')[0], ModeList[3].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 独立灯光控制
        /// <summary>
        /// 灯光控制
        /// </summary>
        /// <param name="RelayNumber">继电器号码</param>
        /// <param name="Status">继电器状态：true:开；false:关</param>
        private void LightControl(string RelayNumber, bool Status)
        {
            string Command = string.Empty;

            if (Status)
            {
                Command = CommandHandle.GetRelayCommand(RelayNumber, "0");
            }
            else
            {
                Command = CommandHandle.GetRelayCommand("0", RelayNumber);
            }

            SendControlCommand(Command);
        }
        #endregion

        #region 矩阵切换

        #endregion

        #region 投影机控制

        #endregion

        #region 镜头控制

        #endregion

        #endregion
    }
}
