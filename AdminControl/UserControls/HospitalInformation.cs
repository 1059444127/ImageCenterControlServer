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
        /// <summary>
        /// 邮件发送实例
        /// </summary>
        private EmailHelper Email;

        /// <summary>
        /// 文件压缩实例
        /// </summary>
        private FileZipHelper Zip;

        /// <summary>
        /// 构造器
        /// </summary>
        public HospitalInformation()
        {
            InitializeComponent();
            InitItems();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HospitalInformation_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems()
        {
            Email = new EmailHelper();
            Zip = new FileZipHelper();
            ReadConfig();
        }

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
    }
}
