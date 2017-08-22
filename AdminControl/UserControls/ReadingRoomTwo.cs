using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using DataTransferService;
using System.Threading;
using System.Xml;
using DataHandleService;

namespace AdminControl
{
    /// <summary>
    /// 阅片室2
    /// </summary>
    public partial class ReadingRoomTwo : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 客户端连接标志位
        /// </summary>
        private volatile bool is_ClientConnect = false;

        /// <summary>
        /// 控制器连接标志位
        /// </summary>
        public volatile bool is_ControlConnect = false;

        /// <summary>
        /// 模式列表
        /// </summary>
        private List<ModeConfig> ModeList;

        /// <summary>
        /// 灯光列表
        /// </summary>
        private List<LightConfig> LightList;

        /// <summary>
        /// 窗帘列表
        /// </summary>
        private List<WindowsConfig> WindowsList;

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
        private Frm_Main frm_Main;

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
        public ReadingRoomTwo(Frm_Main frm_Main)
        {
            InitializeComponent();
            InitService(frm_Main);
        }
        #endregion

        #region 用户事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadingRoomTwo_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        /// <summary>
        /// 阅片模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeYP_Click(object sender, EventArgs e)
        {
            ModeChange(1);
        }

        /// <summary>
        /// 休息模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeXX_Click(object sender, EventArgs e)
        {
            ModeChange(2);
        }

        /// <summary>
        /// 离开模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeLK_Click(object sender, EventArgs e)
        {
            ModeChange(3);
        }

        /// <summary>
        /// 顶灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TopLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, true);
        }

        /// <summary>
        /// 顶灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TopLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, false);
        }

        /// <summary>
        /// 壁灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WallLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, true);
        }

        /// <summary>
        /// 壁灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WallLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, false);
        }

        /// <summary>
        /// 灯带开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RoundLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, true);
        }

        /// <summary>
        /// 灯带关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RoundLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, false);
        }

        /// <summary>
        /// 总开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AllLights_On_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), true);
        }

        /// <summary>
        /// 总关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AllLights_Off_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), false);
        }

        /// <summary>
        /// 窗帘1开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WindowsOne_On_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[0].RelayNumber.Split(',')[0], WindowsList[0].RelayNumber.Split(',')[1]);
        }

        /// <summary>
        /// 窗帘1关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WindowsOne_Off_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[0].RelayNumber.Split(',')[1], WindowsList[0].RelayNumber.Split(',')[0]);
        }

        /// <summary>
        /// 窗帘2开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WindowsTwo_On_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[1].RelayNumber.Split(',')[0], WindowsList[1].RelayNumber.Split(',')[1]);
        }

        /// <summary>
        /// 窗帘2关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WindowsTwo_Off_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[1].RelayNumber.Split(',')[1], WindowsList[1].RelayNumber.Split(',')[0]);
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="frm_Main"></param>
        private void InitService(Frm_Main frm_Main)
        {
            this.frm_Main = frm_Main;

            Data = new DataTransfer();

            DataHandle = new DataHandleHelper();

            ControlRefresh = new ControlRefreshHelper();

            ControlRefresh.RefreshButtons(gBx_LightsControl, false);
            ControlRefresh.RefreshButtons(gBx_ModeChange, false);
            ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

            ReadUserConfig();
        }

        /// <summary>
        /// 初始化各类控件
        /// </summary>
        private void InitControls()
        {
            btn_ModeYP.Text = ModeList[0].ModeName + ":";
            btn_ModeXX.Text = ModeList[1].ModeName + ":";
            btn_ModeLK.Text = ModeList[2].ModeName + ":";

            label_LightOne.Text = LightList[0].LightName + ":";
            label_LightTwo.Text = LightList[1].LightName + ":";
            label_LightThree.Text = LightList[2].LightName + ":";

            label_WindowsOne.Text = WindowsList[0].WindowsName + ":";
            label_WindowsTwo.Text = WindowsList[1].WindowsName + ":";
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
            XmlReaderSettings ModeSetting = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlReader ModeReader = XmlReader.Create(Application.StartupPath + "\\Config\\ReadingRoomTwo\\ModeConfig.xml", ModeSetting);
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
                ModeList.Add(Mode);
            }
            ModeReader.Close();

            //读取灯光配置
            LightList = new List<LightConfig>();
            XmlDocument LightDoc = new XmlDocument();
            XmlReaderSettings LightSetting = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlReader LightReader = XmlReader.Create(Application.StartupPath + "\\Config\\ReadingRoomTwo\\LightConfig.xml", LightSetting);
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

            //读取窗帘配置
            WindowsList = new List<WindowsConfig>();
            XmlDocument WindowsDoc = new XmlDocument();
            XmlReaderSettings WindowsSetting = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlReader WindowsReader = XmlReader.Create(Application.StartupPath + "\\Config\\ReadingRoomTwo\\WindowsConfig.xml", WindowsSetting);
            WindowsDoc.Load(WindowsReader);
            XmlNode WindowsRootNode = WindowsDoc.SelectSingleNode("Windows");
            XmlNodeList WindowsRootChilds = WindowsRootNode.ChildNodes;
            foreach (XmlNode Node in WindowsRootChilds)
            {
                WindowsConfig Windows = new WindowsConfig();
                XmlElement Element = (XmlElement)Node;
                XmlNodeList Childs = Element.ChildNodes;
                Windows.WindowsName = Childs.Item(0).InnerText;
                Windows.RelayNumber = Childs.Item(1).InnerText;
                WindowsList.Add(Windows);
            }
            WindowsReader.Close();
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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "阅片室2控制器");
            frm_Main.DataBase.UpdateTable(SQLString);

            Thread RecvDeviceStatusThread = new Thread(RecvEnviroumentData)
            {
                Name = "阅片室2环境数据接收线程",
                IsBackground = true
            };
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

            DataHandleHelper.HeartStruct Heart;

            string SQLString = string.Empty;

            while (true)
            {
                try
                {
                    EnviroumentData = Data.RecvData(Socket, 3000);
                }
                catch (Exception)
                {
                    frm_Main.Log.WriteLog(string.Format("阅片室2控制端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室2控制器");
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

                    /*
                    提示客户端控制器离线 
                    */
                    if (is_ClientConnect)
                    {
                        Heart.Status = "0";

                        EnviroumentData = DataHandle.PacketEnviroumentData(Heart);

                        SendEnviroumentData(EnviroumentData);
                    }

                    break;
                }

                frm_Main.Log.WriteLog("阅片室2环境数据：" + EnviroumentData.Replace("\r\n", ""));

                try
                {
                    Heart = DataHandle.GetHeartbeat(EnviroumentData);

                    ControlRefresh.RefreshLabelStatus(label_Temp, Heart.Temp, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Hum, Heart.Hum, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Light, Heart.Light, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_Noise, Heart.Noise, Color.Black);

                    SQLString = string.Format("update tb_roomenviroument set room_temp = \"{0} + ℃\", room_hum = \"{1} + ％\", room_light = \"{2} + LUX\",room_noise = \"{3} + DB\" where room_name = \"{4}\";", Heart.Temp, Heart.Hum, Heart.Light, Heart.Noise, "阅片室2");
                    frm_Main.DataBase.UpdateTable(SQLString);
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("阅片室2环境数据错误：" + ex.Message);
                    continue;
                }

                /*
                环境数据发送
                */
                if (is_ClientConnect)
                {
                    EnviroumentData = DataHandle.PacketEnviroumentData(Heart);

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

            string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Online", "阅片室2客户端");
            frm_Main.DataBase.UpdateTable(SQLString);

            Thread RecvClientCommandThread = new Thread(RecvClientCommand)
            {
                Name = "阅片室2用户指令接收线程",
                IsBackground = true
            };
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
                    frm_Main.Log.WriteLog(string.Format("阅片室2客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室2客户端");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);
                    break;
                }

                frm_Main.Log.WriteLog("接收到阅片室2客户端指令：" + Command.Replace("\r\n", ""));
                
                /*
                指令解析与发送
                */
                if (is_ControlConnect)
                {
                    try
                    {
                        if (DataHandle.CheckData(Command))
                        {
                            SendControlCommand(Command);
                        }
                    }
                    catch (Exception ex)
                    {
                        frm_Main.Log.WriteLog("指令解析失败：" + ex.Message);
                        continue;
                    }
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
                frm_Main.Log.WriteLog("阅片室2环境数据发送失败");
                MessageBox.Show(ex.Message, "阅片室2客户端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室2客户端");
                frm_Main.DataBase.UpdateTable(SQLString);

                ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);

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
                frm_Main.Log.WriteLog("阅片室2控制指令发送失败，控制端不在线");
                MessageBox.Show(ex.Message, "阅片室2控制端已离线");

                string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\" where client_name = \"{2}\";", ControlSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "阅片室2控制器");
                frm_Main.DataBase.UpdateTable(SQLString);

                ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                ControlRefresh.RefreshButtons(gBx_ModeChange, false);
                ControlRefresh.RefreshButtons(gBx_LightsControl, false);
                ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

                ControlRefresh.RefreshLabelStatus(label_Temp, "初始化...", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Hum, "初始化...", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Light, "初始化...", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_Noise, "初始化...", Color.Black);

                is_ControlConnect = false;
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
                    Command = DataHandle.GetRelayCommand(ModeList[0].Relays.Split(' ')[0], ModeList[0].Relays.Split(' ')[1]);
                    break;
                case 2:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[1].Relays.Split(' ')[0], ModeList[1].Relays.Split(' ')[1]);
                    break;
                case 3:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[2].Relays.Split(' ')[0], ModeList[2].Relays.Split(' ')[1]);
                    break;
                case 4:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[3].Relays.Split(' ')[0], ModeList[3].Relays.Split(' ')[1]);
                    break;
                default:
                    break;
            }
            SendControlCommand(Command);
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
                Command = DataHandle.GetRelayCommand(RelayNumber, "0");
            }
            else
            {
                Command = DataHandle.GetRelayCommand("0", RelayNumber);
            }
            SendControlCommand(Command);
        }
        #endregion

        #region 独立窗帘控制
        /// <summary>
        /// 独立窗帘控制
        /// </summary>
        /// <param name="PortOpen">开启继电器序号</param>
        /// <param name="PortClose">关闭继电器序号</param>
        private void WindowsControl(string PortOpen, string PortClose)
        {
            string Command = string.Empty;

            Command = DataHandle.GetRelayCommand(PortOpen, PortClose);

            SendControlCommand(Command);
        }
        #endregion

        #region 设备状态重置
        /// <summary>
        /// 重置设备状态
        /// </summary>
        public void ResetMode()
        {
            ModeChange(4);
        }
        #endregion

        #endregion
    }
}
