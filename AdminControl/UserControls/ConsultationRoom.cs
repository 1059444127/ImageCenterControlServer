﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Xml;

using DataTransferService;
using DataHandleService;

namespace AdminControl
{
    /// <summary>
    /// 会诊室1
    /// </summary>
    public partial class ConsultationRoom : UserControl
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
        /// 幕布列表
        /// </summary>
        private List<FilmConfig> FilmList;

        /// <summary>
        /// 数据传输服务实例
        /// </summary>
        private DataTransfer Data;

        /// <summary>
        /// 数据解析实例
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
        public ConsultationRoom(Frm_Main frm_Main)
        {
            InitializeComponent();
            InitServices(frm_Main);
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
            InitControls();
        }

        /// <summary>
        /// 切换会诊模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeHZ_Click(object sender, EventArgs e)
        {
            ModeChange(1);
        }

        /// <summary>
        /// 切换议会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeYH_Click(object sender, EventArgs e)
        {
            ModeChange(2);
        }

        /// <summary>
        /// 切换科会模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeKH_Click(object sender, EventArgs e)
        {
            ModeChange(3);
        }

        /// <summary>
        /// 切换胶片直投
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ModeJP_Click(object sender, EventArgs e)
        {
            ModeChange(4);
        }

        /// <summary>
        /// 投影机1开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ProjectorOne_On_Click(object sender, EventArgs e)
        {
            ProjectorControl("1", "1");
        }

        /// <summary>
        /// 投影机1关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ProjectorOne_Off_Click(object sender, EventArgs e)
        {
            ProjectorControl("1", "0");
        }

        /// <summary>
        /// 投影机2开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ProjectorTwo_On_Click(object sender, EventArgs e)
        {
            ProjectorControl("2", "1");
        }

        /// <summary>
        /// 投影机2关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ProjectorTwo_Off_Click(object sender, EventArgs e)
        {
            ProjectorControl("2", "0");
        }

        /// <summary>
        /// 镜头开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Camera_On_Click(object sender, EventArgs e)
        {
            CameraControl("1", "0");
        }

        /// <summary>
        /// 镜头关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Camera_Off_Click(object sender, EventArgs e)
        {
            CameraControl("0", "0");
        }

        /// <summary>
        /// 窗帘打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Windows_On_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[0].RelayNumber.Split(',')[0], WindowsList[0].RelayNumber.Split(',')[1]);
        }

        /// <summary>
        /// 窗帘关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Windows_Off_Click(object sender, EventArgs e)
        {
            WindowsControl(WindowsList[0].RelayNumber.Split(',')[1], WindowsList[0].RelayNumber.Split(',')[0]);
        }

        /// <summary>
        /// 幕布下降
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Film_Down_Click(object sender, EventArgs e)
        {
            FilmControl(FilmList[0].RelayNumber.Split(',')[0], FilmList[0].RelayNumber.Split(',')[1]);
        }

        /// <summary>
        /// 幕布上升
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Film_Up_Click(object sender, EventArgs e)
        {
            FilmControl(FilmList[0].RelayNumber.Split(',')[1], FilmList[0].RelayNumber.Split(',')[0]);
        }

        /// <summary>
        /// 顶灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TopLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, false);
        }

        /// <summary>
        /// 顶灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_TopLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[0].RelayNumber, true);
        }

        /// <summary>
        /// 壁灯开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WallLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, false);
        }

        /// <summary>
        /// 壁灯关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WallLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[1].RelayNumber, true);
        }

        /// <summary>
        /// 灯带开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RoundLight_On_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, false);
        }

        /// <summary>
        /// 灯带关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RoundLight_Off_Click(object sender, EventArgs e)
        {
            LightControl(LightList[2].RelayNumber, true);
        }

        /// <summary>
        /// 灯光开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AllLights_On_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), false);
        }

        /// <summary>
        /// 灯光关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AllLights_Off_Click(object sender, EventArgs e)
        {
            LightControl(string.Format("{0},{1},{2}", LightList[0].RelayNumber, LightList[1].RelayNumber, LightList[2].RelayNumber), true);
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化各类服务
        /// </summary>
        /// <param name="frm_Main"></param>
        private void InitServices(Frm_Main frm_Main)
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
            btn_ModeHZ.Text = ModeList[0].ModeName;
            btn_ModeYH.Text = ModeList[1].ModeName;
            btn_ModeKH.Text = ModeList[2].ModeName;
            btn_ModeJP.Text = ModeList[3].ModeName;
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
            XmlReader ModeReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoom\\ModeConfig.xml", ModeSetting);
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
                Mode.ProjectorOne = Childs.Item(2).InnerText;
                Mode.ProjectorTwo = Childs.Item(3).InnerText;
                Mode.Matrix = Childs.Item(4).InnerText;
                Mode.Camera = Childs.Item(5).InnerText;
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
            XmlReader LightReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoom\\LightConfig.xml", LightSetting);
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
            XmlReader WindowsReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoom\\WindowsConfig.xml", WindowsSetting);
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

            //读取幕布配置
            FilmList = new List<FilmConfig>();
            XmlDocument FilmDoc = new XmlDocument();
            XmlReaderSettings FilmSetting = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlReader FilmReader = XmlReader.Create(Application.StartupPath + "\\Config\\ConsultationRoom\\FilmConfig.xml", FilmSetting);
            FilmDoc.Load(FilmReader);
            XmlNode FilmRootNode = FilmDoc.SelectSingleNode("Films");
            XmlNodeList FilmRootChilds = FilmRootNode.ChildNodes;
            foreach (XmlNode Node in FilmRootChilds)
            {
                FilmConfig Film = new FilmConfig();
                XmlElement Element = (XmlElement)Node;
                XmlNodeList Childs = Element.ChildNodes;
                Film.FilmName = Childs.Item(0).InnerText;
                Film.RelayNumber = Childs.Item(1).InnerText;
                FilmList.Add(Film);
            }
            FilmReader.Close();
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

            Thread RecvDeviceStatusThread = new Thread(RecvDeviceStatus)
            {
                Name = "会诊室1设备状态接收线程",
                IsBackground = true
            };
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

            DataHandleHelper.HeartStruct Heart;

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

                    ControlRefresh.RefreshLabelStatus(label_ProjectorStatus, "初始化", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_CameraStatus, "初始化", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_MatrixIn, "初始化", Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_MatrixOut, "初始化", Color.Black);

                    /*
                    提示客户端控制器离线 
                    */
                    if (is_ClientConnect)
                    {
                        Heart.Status = "0";

                        Status = DataHandle.PacketDeviceStatusData(Heart);

                        SendDeviceStatus(Status);
                    }

                    break;
                }

                /*
                frm_Main.Log.WriteLog("会诊室1设备状态：" + Status.Replace("\r\n",""));
                */

                /*
                状态刷新
                */
                try
                {
                    Heart = DataHandle.GetHeartbeat(Status);

                    ControlRefresh.RefreshLabelStatus(label_ProjectorStatus, Heart.Projector, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_CameraStatus, Heart.CameraPower, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_MatrixIn, Heart.VideoIn, Color.Black);
                    ControlRefresh.RefreshLabelStatus(label_MatrixOut, Heart.VideoOut, Color.Black);
                }
                catch (Exception ex)
                {
                    frm_Main.Log.WriteLog("会诊室1设备状态错误：" + ex.Message);
                    continue;
                }

                /*
                发送设备状态到客户端
                */
                if (is_ClientConnect)
                {
                    Status = DataHandle.PacketDeviceStatusData(Heart);

                    SendDeviceStatus(Status);
                }
            }
        }
        #endregion

        #region 接收客户端指令
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

            Thread RecvClientCommandThread = new Thread(RecvClientCommand)
            {
                Name = "会诊室1用户指令接收线程",
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
                    frm_Main.Log.WriteLog(string.Format("会诊室1客户端{0}已下线", Socket.RemoteEndPoint.ToString().Split(':')[0]));

                    string SQLString = string.Format("update tb_clientinformation set client_ip = \"{0}\", client_status = \"{1}\"  where client_name = \"{2}\";", ClientSocket.RemoteEndPoint.ToString().Split(':')[0], "Offline", "会诊室1客户端");
                    frm_Main.DataBase.UpdateTable(SQLString);

                    is_ClientConnect = false;

                    ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);
                    break;
                }

                frm_Main.Log.WriteLog("接收到会诊室1客户端指令：" + Command.Replace("\r\n",""));

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
                        frm_Main.Log.WriteLog("会诊室1客户端指令解析失败：" + ex.Message);
                        continue;
                    }
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

                ControlRefresh.RefreshLabelStatus(label_ControlStatus, "未连接", Color.Red);

                ControlRefresh.RefreshButtons(gBx_ModeChange, false);
                ControlRefresh.RefreshButtons(gBx_LightsControl, false);
                ControlRefresh.RefreshButtons(gBx_DeviceControl, false);

                ControlRefresh.RefreshLabelStatus(label_ProjectorStatus, "初始化", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_CameraStatus, "初始化", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_MatrixIn, "初始化", Color.Black);
                ControlRefresh.RefreshLabelStatus(label_MatrixOut, "初始化", Color.Black);

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

                ControlRefresh.RefreshLabelStatus(label_ClientStatus, "未连接", Color.Red);

                is_ClientConnect = false;
            }
        }
        #endregion

        #region 设备控制

        #region 模式切换
        /// <summary>
        /// 模式切换
        /// </summary>
        /// <param name="Mode">模式编号</param>
        private void ModeChange(int Mode)
        {
            string Command = string.Empty;

            switch (Mode)
            {
                //会诊模式
                case 1:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[0].Relays.Split(' ')[0], ModeList[0].Relays.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //矩阵切换
                    Command = DataHandle.GetMatrixCommand(ModeList[0].Matrix.Split(' ')[0], ModeList[0].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机1
                    Command = DataHandle.GetProjectorCommand(ModeList[0].ProjectorOne.Split(',')[0], ModeList[0].ProjectorOne.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机2
                    Command = DataHandle.GetProjectorCommand(ModeList[0].ProjectorTwo.Split(',')[0], ModeList[0].ProjectorTwo.Split(',')[1]);
                    SendControlCommand(Command);
                    break;
                //议会模式
                case 2:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[1].Relays.Split(' ')[0], ModeList[1].Relays.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //矩阵切换
                    Command = DataHandle.GetMatrixCommand(ModeList[1].Matrix.Split(' ')[0], ModeList[1].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机1
                    Command = DataHandle.GetProjectorCommand(ModeList[1].ProjectorOne.Split(',')[0], ModeList[1].ProjectorOne.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机2
                    Command = DataHandle.GetProjectorCommand(ModeList[1].ProjectorTwo.Split(',')[0], ModeList[1].ProjectorTwo.Split(',')[1]);
                    SendControlCommand(Command);
                    break;
                //科会模式
                case 3:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[2].Relays.Split(' ')[0], ModeList[2].Relays.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //矩阵切换
                    Command = DataHandle.GetMatrixCommand(ModeList[2].Matrix.Split(' ')[0], ModeList[2].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机1
                    Command = DataHandle.GetProjectorCommand(ModeList[2].ProjectorOne.Split(',')[0], ModeList[2].ProjectorOne.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机2
                    Command = DataHandle.GetProjectorCommand(ModeList[2].ProjectorTwo.Split(',')[0], ModeList[2].ProjectorTwo.Split(',')[1]);
                    SendControlCommand(Command);
                    break;
                //胶片直投
                case 4:
                    //继电器状态修改
                    Command = DataHandle.GetRelayCommand(ModeList[3].Relays.Split(' ')[0], ModeList[3].Relays.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //矩阵切换
                    Command = DataHandle.GetMatrixCommand(ModeList[3].Matrix.Split(' ')[0], ModeList[3].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开镜头
                    Command = DataHandle.GetCameraCommand(ModeList[3].Camera, "0");
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机1
                    Command = DataHandle.GetProjectorCommand(ModeList[3].ProjectorOne.Split(',')[0], ModeList[3].ProjectorOne.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //打开投影机2
                    Command = DataHandle.GetProjectorCommand(ModeList[3].ProjectorTwo.Split(',')[0], ModeList[3].ProjectorTwo.Split(',')[1]);
                    SendControlCommand(Command);
                    break;
                //初始模式
                case 5:
                    //继电器状态初始化
                    Command = DataHandle.GetRelayCommand(ModeList[4].Relays.Split(' ')[0], ModeList[4].Relays.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //矩阵切换
                    Command = DataHandle.GetMatrixCommand(ModeList[4].Matrix.Split(' ')[0], ModeList[4].Matrix.Split(' ')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //关闭投影机1
                    Command = DataHandle.GetProjectorCommand(ModeList[4].ProjectorOne.Split(',')[0], ModeList[4].ProjectorOne.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //关闭投影机2
                    Command = DataHandle.GetProjectorCommand(ModeList[4].ProjectorTwo.Split(',')[0], ModeList[4].ProjectorTwo.Split(',')[1]);
                    SendControlCommand(Command);
                    Thread.Sleep(200);

                    //关闭镜头
                    Command = DataHandle.GetCameraCommand(ModeList[4].Camera, "0");
                    SendControlCommand(Command);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 独立矩阵切换
        /// <summary>
        /// 矩阵切换
        /// </summary>
        /// <param name="MatrixIn">输入序列</param>
        /// <param name="MatrixOut">输出序列</param>
        private void MatrixControl(string MatrixIn, string MatrixOut)
        {
            string Command = string.Empty;
            Command = DataHandle.GetMatrixCommand(MatrixIn, MatrixOut);
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

        #region 独立投影机控制
        /// <summary>
        /// 投影机控制
        /// </summary>
        /// <param name="ProjectorID">投影机ID</param>
        /// <param name="PowerStatus">投影机电源状态</param>
        private void ProjectorControl(string ProjectorID, string PowerStatus)
        {
            string Command = string.Empty;
            string SQLString = string.Empty;

            Command = DataHandle.GetProjectorCommand(ProjectorID, PowerStatus);
            SendControlCommand(Command);

            SQLString = string.Format("update tb_devicestatus set device_power = {0}, where device_name = \"投影机{1}\";", int.Parse(PowerStatus), ProjectorID);
            frm_Main.DataBase.UpdateTable(SQLString);
        }
        #endregion

        #region 独立镜头控制
        /// <summary>
        /// 镜头控制
        /// </summary>
        /// <param name="PowerStatus">电源状态</param>
        /// <param name="EnlargeLevel">放大等级</param>
        private void CameraControl(string PowerStatus, string EnlargeLevel)
        {
            string Command = string.Empty;
            string SQLString = string.Empty;

            Command = DataHandle.GetCameraCommand(PowerStatus, EnlargeLevel);
            SendControlCommand(Command);

            SQLString = string.Format("update tb_devicestatus set device_power = {0}, where device_name = \"胶片镜头\";", int.Parse(PowerStatus));
            frm_Main.DataBase.UpdateTable(SQLString);
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

        #region 独立幕布控制
        /// <summary>
        /// 独立幕布控制
        /// </summary>
        /// <param name="PortOpen">开启继电器序号</param>
        /// <param name="PortClose">关闭继电器序号</param>
        private void FilmControl(string PortOpen, string PortClose)
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
            ModeChange(5);
        }
        #endregion

        #endregion
    }
}
