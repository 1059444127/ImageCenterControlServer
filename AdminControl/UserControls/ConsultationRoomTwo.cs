using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminControl
{
    /// <summary>
    /// 会诊室2
    /// </summary>
    public partial class ConsultationRoomTwo : UserControl
    {
        #region 全局变量
        /// <summary>
        /// 主窗体实例
        /// </summary>
        private frm_Main frm_Main;

        /// <summary>
        /// 控制端状态刷新委托
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="ForeColor"></param>
        private delegate void ControlStatusChangeDelegate(string Status, Color ForeColor);

        /// <summary>
        /// 客户端状态刷新委托
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="ForeColor"></param>
        private delegate void ClientStatusChangeDelegate(string Status, Color ForeColor);
        #endregion

        #region 构造器
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="frm_Main"></param>
        public ConsultationRoomTwo(frm_Main frm_Main)
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
        private void ConsultationRoomTwo_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItems(frm_Main frm_Main)
        {
            this.frm_Main = frm_Main;
        }
        #endregion

        #region 刷新控件
        /// <summary>
        /// 控制器连接状态修改
        /// </summary>
        /// <param name="Status"></param>
        public void ControlStatusChange(string Status, Color ForeColor)
        {
            if (label_ControlStatus.InvokeRequired)
            {
                ControlStatusChangeDelegate Change = new ControlStatusChangeDelegate(ControlStatusChange);
                label_ControlStatus.Invoke(Change, Status, ForeColor);
            }
            else
            {
                label_ControlStatus.Text = Status;
                label_ControlStatus.ForeColor = ForeColor;
            }
        }

        /// <summary>
        /// 客户端连接状态修改
        /// </summary>
        /// <param name="Status"></param>
        public void ClientStatusChange(string Status, Color ForeColor)
        {
            if (label_ClientStatus.InvokeRequired)
            {
                ClientStatusChangeDelegate Change = new ClientStatusChangeDelegate(ClientStatusChange);
                label_ClientStatus.Invoke(Change, Status, ForeColor);
            }
            else
            {
                label_ClientStatus.Text = Status;
                label_ClientStatus.ForeColor = ForeColor;
            }
        }
        #endregion
    }
}
