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

namespace AdminControl
{
    /// <summary>
    /// 信息提示控件
    /// </summary>
    public partial class HospitalInformation : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 主窗体实例
        /// </summary>
        private frm_Main frm_Main;
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
            string LogFile = string.Format("{0}\\Log_{1}.zip", Application.StartupPath, DateTime.Now.ToString("yyMMdd"));

            panel_BUGReport.Visible = true;

            try
            {
                frm_Main.Log.PacketLog(Application.StartupPath + "\\Log", LogFile);
                txt_EmailFilePath.Text = LogFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "打包日志失败");
                txt_EmailFilePath.Text = string.Empty;
            }
        }
        #endregion

        #region 删除日志
        /// <summary>
        /// 删除日志文件
        /// </summary>
        private void DeleteLogFile()
        {

        }
        #endregion

        #region 邮件发送
        /// <summary>
        /// 邮件发送
        /// </summary>
        private void SendEmail()
        {
            /*
            Email.mailFrom = "jie.jie.1102@qq.com";
            Email.host = "smtp.qq.com";
            Email.mailPwd = "yhtuutdwaqyubeea";
            Email.mailBody = richtxt_EmailContent.Text;
            Email.mailSubject = txt_EmailTitle.Text;
            Email.mailToArray = new string[] { "jiejie941102@163.com" };
            Email.isbodyHtml = true;

            Email.attachmentsPath = new string[] { ZipLogFilePath };
            */
        }
        #endregion

        #region 清理反馈记录
        /// <summary>
        /// 清理记录
        /// </summary>
        private void CleanBUGReportLog()
        {
            DeleteLogFile();
            panel_BUGReport.Visible = false;
            txt_EmailTitle.Text = string.Empty;
            richtxt_EmailContent.Text = string.Empty;
        }
        #endregion
    }
}
