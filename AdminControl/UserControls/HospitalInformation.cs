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
using EmailService;
using FileZipService;

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
        private string ZipLogFilePath;

        /// <summary>
        /// 邮件发送实例
        /// </summary>
        private EmailHelper Email;

        /// <summary>
        /// 文件压缩实例
        /// </summary>
        private FileZipHelper Zip;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        public HospitalInformation()
        {
            InitializeComponent();
            InitItems();
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
            panel_BUGReport.Visible = true;
            ZipLogFilePath = ZipLogFiles();
            txt_EmailFilePath.Text = ZipLogFilePath;
        }

        /// <summary>
        /// 发送反馈邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BUGReportSend_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消BUG反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BUGReportBack_Click(object sender, EventArgs e)
        {
            DeleteLogFile();
            panel_BUGReport.Visible = false;
            txt_EmailTitle.Text = string.Empty;
            richtxt_EmailContent.Text = string.Empty;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems()
        {
            panel_BUGReport.Visible = false;
            Email = new EmailHelper();
            Zip = new FileZipHelper();
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
        /// 创建日志压缩包
        /// </summary>
        /// <returns></returns>
        private string ZipLogFiles()
        {
            string LogFile = string.Format("{0}\\Log_{1}.zip", Application.StartupPath, DateTime.Now.ToString("yyMMdd"));

            try
            {
                Zip.CreateZip(Application.StartupPath + "\\Log", LogFile);
                return LogFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region 删除日志
        /// <summary>
        /// 删除日志文件
        /// </summary>
        private void DeleteLogFile()
        {
            if (File.Exists(ZipLogFilePath))
            {
                try
                {
                    File.Delete(ZipLogFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除文件失败：" + ex.Message, "错误");
                }
            }
        }
        #endregion
    }
}
