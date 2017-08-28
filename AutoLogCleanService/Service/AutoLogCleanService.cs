using System.ServiceProcess;
using LogService;

namespace AutoLogCleanService
{
    /// <summary>
    /// 日志清理服务
    /// </summary>
    public partial class AutoLogCleanService : ServiceBase
    {
        #region 全局变量
        /// <summary>
        /// 日志服务实例
        /// </summary>
        private LogHelper Log;

        /// <summary>
        /// 日志路径
        /// </summary>
        private string LogPath = "D:\\Log";

        /// <summary>
        /// 系统定时器
        /// </summary>
        private System.Timers.Timer Timer;
        #endregion

        #region 构造器
        /// <summary>
        /// 默认构造器
        /// </summary>
        public AutoLogCleanService()
        {
            InitializeComponent();
            InitItem();
        }
        #endregion

        #region 服务状态
        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="args">启动参数</param>
        protected override void OnStart(string[] args)
        {
            ServiceStart();
        }

        /// <summary>
        /// 停止
        /// </summary>
        protected override void OnStop()
        {
            ServiceStop();
        }
        #endregion

        #region 功能函数
        /// <summary>
        /// 初始化
        /// </summary>
        protected void InitItem()
        {
            Log = new LogHelper();

            Timer = new System.Timers.Timer();
        }

        /// <summary>
        /// 服务启动
        /// </summary>
        protected void ServiceStart()
        {
            //每隔五秒判断当前时间是不是0:00
            Timer.Interval = 5000;
            Timer.AutoReset = true;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
        }

        /// <summary>
        /// 定时器到达执行
        /// 每天零点清理日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if ((e.SignalTime.Hour == 0) && (e.SignalTime.Minute == 0))
            {
                //删除日志（正在使用中的文件不会被删除）
                Log.DeleteLogFiles(LogPath);
            }
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected void ServiceStop()
        {
            Timer.Enabled = false;
        }
        #endregion
    }
}
