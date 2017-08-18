using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminControl
{
    /// <summary>
    /// 控件操作帮助类
    /// </summary>
    class ControlRefreshHelper
    {
        /// <summary>
        /// 标签状态刷新委托
        /// </summary>
        /// <param name="Label_Item">标签名</param>
        /// <param name="Status">状态</param>
        /// <param name="ForeColor">颜色</param>
        private delegate void RefreshLabelStatusDelegate(Label Label_Item, string Status, Color ForeColor);

        /// <summary>
        /// 按钮状态刷新委托
        /// </summary>
        /// <param name="Button_Item">按钮名</param>
        /// <param name="Status">可用状态</param>
        private delegate void RefreshButtonStatusDelegate(Button Button_Item, bool Status);

        /// <summary>
        /// 刷新标签状态
        /// </summary>
        /// <param name="Label_Item"></param>
        /// <param name="Status"></param>
        /// <param name="ForeColor"></param>
        public void RefreshLabelStatus(Label Label_Item, string Status, Color ForeColor)
        {
            if (Label_Item.InvokeRequired)
            {
                RefreshLabelStatusDelegate Refresh = new RefreshLabelStatusDelegate(RefreshLabelStatus);
                Label_Item.Invoke(Refresh, Label_Item, Status, ForeColor);
            }
            else
            {
                Label_Item.Text = Status;
                Label_Item.ForeColor = ForeColor;
            }
        }

        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        /// <param name="Button_Item"></param>
        /// <param name="Status"></param>
        public void RefreshButtonStatus(Button Button_Item, bool Status)
        {
            if (Button_Item.InvokeRequired)
            {
                RefreshButtonStatusDelegate Refresh = new RefreshButtonStatusDelegate(RefreshButtonStatus);
                Button_Item.Invoke(Refresh, Button_Item, Status);
            }
            else
            {
                Button_Item.Enabled = Status;
            }
        }

        /// <summary>
        /// 刷新指定区域按钮
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="Status"></param>
        public void RefreshButtons(GroupBox Group, bool Status)
        {
            foreach (Control item in Group.Controls)
            {
                if (item.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    RefreshButtonStatus(item as Button, Status);
                }
            }
        }
    }
}
