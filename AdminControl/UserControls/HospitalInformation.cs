using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DataTransferService;

namespace AdminControl
{
    /// <summary>
    /// 信息提示控件
    /// </summary>
    public partial class HospitalInformation : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 日志压缩包路径
        /// </summary>
        string LogFilePath;

        /// <summary>
        /// 主窗体实例
        /// </summary>
        private frm_Main frm_Main;

        /// <summary>
        /// 数据传输实例
        /// </summary>
        private DataTransfer Data;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public HospitalInformation(frm_Main frm_Main)
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
        private void HospitalInformation_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 显示BUG反馈界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BUGReport_Click(object sender, EventArgs e)
        {
            GetLogFile();
        }

        /// <summary>
        /// 发送反馈邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BUGReportSend_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        /// <summary>
        /// 取消BUG反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BUGReportBack_Click(object sender, EventArgs e)
        {
            CleanBUGReportLog();
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems(frm_Main frm_Main)
        {
            panel_BUGReport.Visible = false;

            Data = new DataTransfer();

            this.frm_Main = frm_Main;

            ReadConfig();
        }
        #endregion

        #region 读取配置
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void ReadConfig()
        {
            StreamReader Reader = new StreamReader(Application.StartupPath + "\\Config\\HospitalInformationConfig.bin");
            string Config = string.Empty;

            while ((Config = Reader.ReadLine()) != null)
            {
                txt_ApplicationInformation.Text += Config + "\r\n";
            }

            Reader.Close();
        }
        #endregion

        #region 打包日志
        /// <summary>
        /// 打包压缩日志
        /// </summary>
        private void GetLogFile()
        {
            LogFilePath = string.Format("{0}\\Log_{1}.zip", Application.StartupPath, DateTime.Now.ToString("yyMMdd"));

            panel_BUGReport.Visible = true;

            try
            {
                frm_Main.Log.PacketLog(Application.StartupPath + "\\Log", LogFilePath);
                txt_EmailFilePath.Text = LogFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打包日志失败");
                txt_EmailFilePath.Text = string.Empty;
            }
        }
        #endregion

        #region 清理日志
        /// <summary>
        /// 清理记录
        /// </summary>
        private void CleanBUGReportLog()
        {
            try
            {
                frm_Main.Log.DeleteLog(LogFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "清理日志失败");
            }

            panel_BUGReport.Visible = false;
            txt_EmailTitle.Text = string.Empty;
            richtxt_EmailContent.Text = string.Empty;
        }
        #endregion

        #region 邮件发送
        /// <summary>
        /// 邮件发送
        /// </summary>
        private void SendEmail()
        {
            string SendAddress = "jie.jie.1102@qq.com";
            string Host = "smtp.qq.com";
            string Passwd = "yhtuutdwaqyubeea";
            string Content = richtxt_EmailContent.Text;
            string Subject = txt_EmailTitle.Text;
            string[] RecvAddress = new string[] { "jiejie941102@163.com" };
            string[] FilePath = new string[] { LogFilePath };

            try
            {
                Data.SendEmail(SendAddress, Passwd, Host, RecvAddress, null, Subject, Content, FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }
        #endregion
    }
}
