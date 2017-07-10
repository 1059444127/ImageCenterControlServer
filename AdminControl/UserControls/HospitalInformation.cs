using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailService;

namespace AdminControl
{
    public partial class HospitalInformation : UserControl
    {
        /// <summary>
        /// 邮件发送实例
        /// </summary>
        private EmailHelper Email;

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

        private void InitItems()
        {
            Email = new EmailHelper();
        }
    }
}
