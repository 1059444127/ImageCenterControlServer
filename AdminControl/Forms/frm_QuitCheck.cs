using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataHandleService;

namespace AdminControl
{
    /// <summary>
    /// 退出确认界面
    /// </summary>
    public partial class Frm_QuitCheck : Form
    {
        #region 全局变量
        /// <summary>
        /// 主窗体实例
        /// </summary>
        private Frm_Main frm_Main;

        /// <summary>
        /// 数据处理实例
        /// </summary>
        private DataHandleHelper Data;
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="frm_Main"></param>
        public Frm_QuitCheck(Frm_Main frm_Main)
        {
            InitializeComponent();
            InitItem(frm_Main);
        }
        #endregion

        #region 用户事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_QuitCheck_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 退出确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_QuitConfirm_Click(object sender, EventArgs e)
        {
            ConfirmQuit();
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_QuitReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="frm_Main"></param>
        private void InitItem(Frm_Main frm_Main)
        {
            this.frm_Main = frm_Main;

            Data = new DataHandleHelper();
        }
        #endregion

        #region 退出校验
        /// <summary>
        /// 确认退出
        /// </summary>
        public void ConfirmQuit()
        {
            string Passwd = txt_AdminPasswd.Text;

            if (string.IsNullOrEmpty(Passwd.Trim(' ')))
            {
                MessageBox.Show("密码不能为空", "错误");
                return;
            }

            try
            {
                if (CheckPasswd(Passwd))
                {
                    this.Hide();
                    frm_Main.CloseForm();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误", "错误");
                    txt_AdminPasswd.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
        }

        /// <summary>
        /// 密码校验
        /// </summary>
        /// <param name="Passwd"></param>
        /// <returns></returns>
        protected bool CheckPasswd(string Passwd)
        {
            string SQLString = string.Format("select user_passwd from tb_userinformation where user_name = \"Admin\";");

            try
            {
                DataTable Table = frm_Main.DataBase.SelectTable(SQLString);

                if (Data.GetMD5String(Passwd).Equals(Table.Rows[0][0].ToString()))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
