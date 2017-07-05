using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

using LogService;
using DataHandleService;
using CommandHandleService;
using DataEncryptService;

namespace AdminControl
{
    /// <summary>
    /// 服务器主窗体
    /// </summary>
    public partial class frm_Main : Form
    {
        #region 全局变量
        /// <summary>
        /// 服务器IP
        /// </summary>
        private string ServerIP;

        /// <summary>
        /// 服务器端口
        /// </summary>
        private int ServerPort;

        /// <summary>
        /// 客户端类型配置
        /// </summary>
        private string[] ClientTypeConfig = new string[4];

        /// <summary>
        /// 监听套接字
        /// </summary>
        private Socket WatchSocket;

        /// <summary>
        /// 刷新时间委托
        /// </summary>
        private delegate void RefreshTimeDelegate();

        /// <summary>
        /// 日志记录实例
        /// </summary>
        public LogHelper Log;

        /// <summary>
        /// 数据解析实例
        /// </summary>
        public DataHandleHelper DataHandle;

        /// <summary>
        /// 指令解析实例
        /// </summary>
        public CommandHandleHelper CommandHandle;

        /// <summary>
        /// 数据加密实例
        /// </summary>
        public DataEncryptHelper DataEncrypt;

        /// <summary>
        /// 会诊室1控件
        /// </summary>
        private ConsultationRoomOne HZOne;

        /// <summary>
        /// 会诊室2控件
        /// </summary>
        private ConsultationRoomTwo HZTwo;

        /// <summary>
        /// 阅片室1控件
        /// </summary>
        private ReadingRoomOne YPOne;

        /// <summary>
        /// 阅片室2控件 
        /// </summary>
        private ReadingRoomTwo YPTwo;

        /// <summary>
        /// 保存用户连接的集合
        /// </summary>
        public Dictionary<string, Socket> DictSockets = new Dictionary<string, Socket>();

        /// <summary>
        /// 保存用户线程的集合
        /// </summary>
        public Dictionary<string, Thread> DictThreads = new Dictionary<string, Thread>();
        #endregion

        #region 加载动画
        //窗体弹出或消失效果
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public frm_Main()
        {
            InitializeComponent();
            InitService();
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
            AnimateWindow(this.Handle, 500, AW_BLEND);
        }

        /// <summary>
        /// 会诊室1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConsultationRoomOne_Click(object sender, EventArgs e)
        {
            ShowSelectedIndex(1);
            ShowSelectUserControl(HZOne);
        }

        /// <summary>
        /// 会诊室2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConsultationRoomTwo_Click(object sender, EventArgs e)
        {
            ShowSelectedIndex(2);
            ShowSelectUserControl(HZTwo);
        }

        /// <summary>
        /// 阅片室1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadingRoomOne_Click(object sender, EventArgs e)
        {
            ShowSelectedIndex(3);
            ShowSelectUserControl(YPOne);
        }

        /// <summary>
        /// 阅片室2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReadingRoomTwo_Click(object sender, EventArgs e)
        {
            ShowSelectedIndex(4);
            ShowSelectUserControl(YPTwo);
        }

        /// <summary>
        /// 窗体关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND + AW_HIDE);
            ServerStop();
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.WriteLog("程序安全退出");
        }
        #endregion

        #region 功能函数

        #region 初始化各类服务
        /// <summary>
        /// 初始化服务
        /// </summary>
        private void InitService()
        {
            StartLog();
            StartDataHandle();
            StartCommandHandle();
            StartDataEncrypt();
            StartTime();
            ReadConfig();
            StartServer();
            StartUserControl();
        }

        #endregion

        #region 启动日志记录服务
        /// <summary>
        /// 启动日志记录服务
        /// </summary>
        private void StartLog()
        {
            string LogPath = Application.StartupPath + "\\Log";

            try
            {
                Log = new LogHelper(LogPath);
                Log.WriteLog("日志服务初始化成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "日志服务初始化失败");
                System.Environment.Exit(0);
            }
        }
        #endregion

        #region 启动数据解析服务
        /// <summary>
        /// 数据解析服务
        /// </summary>
        private void StartDataHandle()
        {
            DataHandle = new DataHandleHelper();
        }
        #endregion

        #region 启动指令解析服务
        /// <summary>
        /// 指令解析服务
        /// </summary>
        private void StartCommandHandle()
        {
            CommandHandle = new CommandHandleHelper();
        }
        #endregion

        #region 启动数据加密服务
        /// <summary>
        /// 数据加密服务
        /// </summary>
        private void StartDataEncrypt()
        {
            DataEncrypt = new DataEncryptHelper();
        }
        #endregion

        #region 时间动态刷新服务
        /// <summary>
        /// 启动时间刷新线程
        /// </summary>
        private void StartTime()
        {
            Thread TimeThread = new Thread(TimeRefreshThread);
            TimeThread.IsBackground = true;
            TimeThread.Start();
            Log.WriteLog("时间动态刷新服务启动成功");
        }

        /// <summary>
        /// 时间刷新线程
        /// </summary>
        private void TimeRefreshThread()
        {
            while (true)
            {
                try
                {
                    RefreshTimeLables();
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 刷新标签
        /// </summary>
        private void RefreshTimeLables()
        {
            if (label_Hour.InvokeRequired || label_Minute.InvokeRequired || label_Week.InvokeRequired || label_Date.InvokeRequired)
            {
                RefreshTimeDelegate Time = new RefreshTimeDelegate(RefreshTimeLables);
                label_Hour.BeginInvoke(Time);
                label_Minute.BeginInvoke(Time);
                label_Week.BeginInvoke(Time);
                label_Date.BeginInvoke(Time);
            }
            else
            {
                label_Hour.Text = HourChange(DateTime.Now.Hour);
                label_Minute.Text = MinuteChange(DateTime.Now.Minute);
                label_Week.Text = WeekChangetoChinese(DateTime.Now.DayOfWeek.ToString());
                label_Date.Text = DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        /// <summary>
        /// 小时补0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string HourChange(int num)
        {
            string Hour;
            if (num >= 0 && num <= 9)
            {
                Hour = "0" + num.ToString();
            }
            else
            {
                Hour = num.ToString();
            }
            return Hour;
        }

        /// <summary>
        /// 分钟补0
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string MinuteChange(int num)
        {
            string Minute;
            if (num >= 0 && num <= 9)
            {
                Minute = "0" + num.ToString();
            }
            else
            {
                Minute = num.ToString();
            }
            return Minute;
        }

        /// <summary>
        /// 转换汉语星期
        /// </summary>
        /// <param name="Week"></param>
        /// <returns></returns>
        private string WeekChangetoChinese(string Week)
        {
            switch (Week)
            {
                case "Monday":
                    Week = "星期一";
                    break;
                case "Tuesday":
                    Week = "星期二";
                    break;
                case "Wednesday":
                    Week = "星期三";
                    break;
                case "Thursday":
                    Week = "星期四";
                    break;
                case "Friday":
                    Week = "星期五";
                    break;
                case "Saturday":
                    Week = "星期六";
                    break;
                case "Sunday":
                    Week = "星期日";
                    break;
                default:
                    break;
            }

            return Week;
        }
        #endregion

        #region 读取用户配置
        /// <summary>
        /// 读取用户配置
        /// </summary>
        private void ReadConfig()
        {
            string[] ServerConfig = null;

            try
            {
                StreamReader Reader = new StreamReader(Application.StartupPath + "\\Config\\ServerConfig.bin");
                ServerConfig = Reader.ReadLine().Split(':');
                ServerIP = ServerConfig[0];
                ServerPort = int.Parse(ServerConfig[1]);
                Reader.Close();
                Log.WriteLog("服务器配置文件读取成功");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("服务器配置文件丢失！请重新安装程序！", "错误");
                Log.WriteLog("服务器配置文件丢失，程序无法启动");
                System.Environment.Exit(0);
            }
            catch (FormatException)
            {
                MessageBox.Show("服务器配置文件格式错误！", "错误");
                Log.WriteLog("服务器配置文件格式错误，程序无法启动");
                System.Environment.Exit(0);
            }

            try
            {
                StreamReader Reader = new StreamReader(Application.StartupPath + "\\Config\\ClientTypeConfig.bin");
                for (int i = 0; i < 4; i++)
                {
                    ClientTypeConfig[i] = Reader.ReadLine().Split(':')[1];
                }
                Reader.Close();
                Log.WriteLog("客户端类型配置文件读取成功");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("客户端类型配置文件丢失！请重新安装程序！", "错误");
                Log.WriteLog("客户端类型配置文件丢失，程序无法启动");
                System.Environment.Exit(0);
            }
            catch (FormatException)
            {
                MessageBox.Show("客户端类型配置文件格式错误！", "错误");
                Log.WriteLog("客户端类型配置文件格式错误，程序无法启动");
                System.Environment.Exit(0);
            }
        }
        #endregion

        #region 服务器线程启动
        /// <summary>
        /// 启动服务器线程
        /// </summary>
        private void StartServer()
        {
            Thread ListenThread = new Thread(ListenConnect);
            ListenThread.IsBackground = true;
            ListenThread.Start();
        }
        #endregion

        #region 监听用户连接
        /// <summary>
        /// 监听用户连接
        /// </summary>
        private void ListenConnect()
        {
            //创建监听套接字
            WatchSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ///设置服务器IP地址
            IPAddress ServerAddress = IPAddress.Parse(ServerIP);

            //获得网络终结点
            IPEndPoint ServerEndPoint = new IPEndPoint(ServerAddress, ServerPort);

            try
            {
                //绑定IP地址和端口
                WatchSocket.Bind(ServerEndPoint);
                Log.WriteLog("服务器绑定IP成功");
            }
            catch (Exception ex)
            {
                Log.WriteLog("服务器绑定IP失败：" + ex.Message);
                return;
            }

            //监听队列长度20
            WatchSocket.Listen(20);

            Log.WriteLog("服务器启动成功");

            while (true)
            {
                try
                {
                    //监听用户连接请求
                    Socket UserConnection = WatchSocket.Accept();

                    //判断客户端类型
                    SwitchClientType(UserConnection.RemoteEndPoint.ToString().Split(':')[0], UserConnection);
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        #endregion

        #region 判断客户类型
        /// <summary>
        /// 判断客户端类型
        /// </summary>
        /// <param name="ClientIP"></param>
        /// <param name="UserConnection"></param>
        private void SwitchClientType(string ClientIP, Socket UserConnection)
        {
            if (ClientIP.Equals(ClientTypeConfig[0]))
            {
                //阅片室控制端连接
                Log.WriteLog(string.Format("阅片室控制端{0}连接成功", ClientIP));

                //启动传感器数据和灯光状态接收线程
                YPOne.RecvDeviceDataThreadStart(UserConnection);
            }
            else if (ClientIP.Equals(ClientTypeConfig[1]))
            {
                //阅片室客户端连接
                Log.WriteLog(string.Format("阅片室客户端{0}连接成功", ClientIP));

                //启动客户端指令接收线程
                YPOne.RecvClientCommandThreadStart(UserConnection);
            }
            else if (ClientIP.Equals(ClientTypeConfig[2]))
            {
                //会诊室控制端连接
                Log.WriteLog(string.Format("会诊室控制端{0}连接成功", ClientIP));

                //启动设备状态接收线程
                HZOne.RecvDeviceStatusThreadStart(UserConnection);
            }
            else if (ClientIP.Equals(ClientTypeConfig[3]))
            {
                //会诊室客户端连接
                Log.WriteLog(string.Format("会诊室客户端{0}连接成功", ClientIP));

                //启动客户端指令接收线程
                HZOne.RecvClientCommandThreadStart(UserConnection);
            }
            else
            {
                MessageBox.Show("非法连接！" + ClientIP);
            }
        }
        #endregion

        #region 关闭服务器
        /// <summary>
        /// 关闭服务器
        /// </summary>
        private void ServerStop()
        {
            try
            {
                WatchSocket.Close();
                Log.WriteLog("服务器关闭成功");
            }
            catch (Exception ex)
            {
                Log.WriteLog("服务器关闭异常：" + ex.Message);
            }
        }
        #endregion

        #region 初始化用户控件
        /// <summary>
        /// 初始化用户控件
        /// </summary>
        private void StartUserControl()
        {
            HZOne = new ConsultationRoomOne(this);
            HZTwo = new ConsultationRoomTwo(this);
            YPOne = new ReadingRoomOne(this);
            YPTwo = new ReadingRoomTwo(this);
        }
        #endregion

        #region 显示小箭头
        /// <summary>
        /// 显示选择的菜单
        /// </summary>
        /// <param name="Index"></param>
        private void ShowSelectedIndex(int Index)
        {
            switch (Index)
            {
                case 1:
                    pBx_Index1.Visible = true;
                    pBx_Index2.Visible = false;
                    pBx_Index3.Visible = false;
                    pBx_Index4.Visible = false;
                    break;
                case 2:
                    pBx_Index1.Visible = false;
                    pBx_Index2.Visible = true;
                    pBx_Index3.Visible = false;
                    pBx_Index4.Visible = false;
                    break;
                case 3:
                    pBx_Index1.Visible = false;
                    pBx_Index2.Visible = false;
                    pBx_Index3.Visible = true;
                    pBx_Index4.Visible = false;
                    break;
                case 4:
                    pBx_Index1.Visible = false;
                    pBx_Index2.Visible = false;
                    pBx_Index3.Visible = false;
                    pBx_Index4.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 显示详细界面
        /// <summary>
        /// 显示选择的用户界面
        /// </summary>
        /// <param name="Control"></param>
        private void ShowSelectUserControl(UserControl Control)
        {
            Control.Show();
            panel_UserControl.Controls.Clear();
            panel_UserControl.Controls.Add(Control);
        }
        #endregion

        #endregion
    }
}
