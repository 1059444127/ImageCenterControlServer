namespace AdminControl
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.panel_Information = new System.Windows.Forms.Panel();
            this.label_Close = new System.Windows.Forms.Label();
            this.label_Minnor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_Week = new System.Windows.Forms.Label();
            this.label_Minute = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Hour = new System.Windows.Forms.Label();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.pBx_Index3 = new System.Windows.Forms.PictureBox();
            this.btn_About = new System.Windows.Forms.Button();
            this.pBx_Index2 = new System.Windows.Forms.PictureBox();
            this.pBx_Index1 = new System.Windows.Forms.PictureBox();
            this.btn_ReadingRoom = new System.Windows.Forms.Button();
            this.btn_ConsultationRoom = new System.Windows.Forms.Button();
            this.panel_UserControl = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Notice_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Information.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index1)).BeginInit();
            this.panel_UserControl.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Information
            // 
            this.panel_Information.BackColor = System.Drawing.Color.Gray;
            this.panel_Information.Controls.Add(this.label_Close);
            this.panel_Information.Controls.Add(this.label_Minnor);
            this.panel_Information.Controls.Add(this.label3);
            this.panel_Information.Controls.Add(this.label_Date);
            this.panel_Information.Controls.Add(this.label_Week);
            this.panel_Information.Controls.Add(this.label_Minute);
            this.panel_Information.Controls.Add(this.label2);
            this.panel_Information.Controls.Add(this.label_Hour);
            this.panel_Information.Location = new System.Drawing.Point(0, 0);
            this.panel_Information.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(1024, 80);
            this.panel_Information.TabIndex = 0;
            this.panel_Information.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Information_MouseDown);
            this.panel_Information.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Information_MouseMove);
            // 
            // label_Close
            // 
            this.label_Close.AutoSize = true;
            this.label_Close.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Close.ForeColor = System.Drawing.Color.White;
            this.label_Close.Location = new System.Drawing.Point(997, 9);
            this.label_Close.Name = "label_Close";
            this.label_Close.Size = new System.Drawing.Size(24, 16);
            this.label_Close.TabIndex = 8;
            this.label_Close.Text = "×";
            this.label_Close.Click += new System.EventHandler(this.Label_Close_Click);
            // 
            // label_Minnor
            // 
            this.label_Minnor.AutoSize = true;
            this.label_Minnor.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Minnor.ForeColor = System.Drawing.Color.White;
            this.label_Minnor.Location = new System.Drawing.Point(969, 6);
            this.label_Minnor.Name = "label_Minnor";
            this.label_Minnor.Size = new System.Drawing.Size(22, 24);
            this.label_Minnor.TabIndex = 7;
            this.label_Minnor.Text = "-";
            this.label_Minnor.Click += new System.EventHandler(this.Label_Minnor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(768, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "影像中心控制系统";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Date.ForeColor = System.Drawing.Color.White;
            this.label_Date.Location = new System.Drawing.Point(334, 28);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(177, 39);
            this.label_Date.TabIndex = 4;
            this.label_Date.Text = "2017/06/08";
            // 
            // label_Week
            // 
            this.label_Week.AutoSize = true;
            this.label_Week.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Week.ForeColor = System.Drawing.Color.White;
            this.label_Week.Location = new System.Drawing.Point(197, 28);
            this.label_Week.Name = "label_Week";
            this.label_Week.Size = new System.Drawing.Size(116, 39);
            this.label_Week.TabIndex = 3;
            this.label_Week.Text = "星期五";
            // 
            // label_Minute
            // 
            this.label_Minute.AutoSize = true;
            this.label_Minute.Font = new System.Drawing.Font("Gadugi", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Minute.ForeColor = System.Drawing.Color.White;
            this.label_Minute.Location = new System.Drawing.Point(125, 28);
            this.label_Minute.Name = "label_Minute";
            this.label_Minute.Size = new System.Drawing.Size(51, 39);
            this.label_Minute.TabIndex = 1;
            this.label_Minute.Text = "22";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(106, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // label_Hour
            // 
            this.label_Hour.AutoSize = true;
            this.label_Hour.BackColor = System.Drawing.Color.Transparent;
            this.label_Hour.Font = new System.Drawing.Font("Gadugi", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hour.ForeColor = System.Drawing.Color.White;
            this.label_Hour.Location = new System.Drawing.Point(27, 6);
            this.label_Hour.Name = "label_Hour";
            this.label_Hour.Size = new System.Drawing.Size(89, 68);
            this.label_Hour.TabIndex = 0;
            this.label_Hour.Text = "22";
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.LightGray;
            this.panel_Menu.Controls.Add(this.pBx_Index3);
            this.panel_Menu.Controls.Add(this.btn_About);
            this.panel_Menu.Controls.Add(this.pBx_Index2);
            this.panel_Menu.Controls.Add(this.pBx_Index1);
            this.panel_Menu.Controls.Add(this.btn_ReadingRoom);
            this.panel_Menu.Controls.Add(this.btn_ConsultationRoom);
            this.panel_Menu.Location = new System.Drawing.Point(0, 80);
            this.panel_Menu.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(160, 520);
            this.panel_Menu.TabIndex = 1;
            // 
            // pBx_Index3
            // 
            this.pBx_Index3.Image = global::AdminControl.Properties.Resources.zhankai;
            this.pBx_Index3.Location = new System.Drawing.Point(116, 414);
            this.pBx_Index3.Name = "pBx_Index3";
            this.pBx_Index3.Size = new System.Drawing.Size(44, 25);
            this.pBx_Index3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBx_Index3.TabIndex = 8;
            this.pBx_Index3.TabStop = false;
            this.pBx_Index3.Visible = false;
            // 
            // btn_About
            // 
            this.btn_About.BackColor = System.Drawing.Color.Transparent;
            this.btn_About.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_About.FlatAppearance.BorderSize = 0;
            this.btn_About.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_About.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_About.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_About.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_About.ForeColor = System.Drawing.Color.White;
            this.btn_About.Location = new System.Drawing.Point(9, 402);
            this.btn_About.Margin = new System.Windows.Forms.Padding(0);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(110, 50);
            this.btn_About.TabIndex = 7;
            this.btn_About.Text = "关于";
            this.btn_About.UseVisualStyleBackColor = false;
            this.btn_About.Click += new System.EventHandler(this.Btn_About_Click);
            // 
            // pBx_Index2
            // 
            this.pBx_Index2.Image = global::AdminControl.Properties.Resources.zhankai;
            this.pBx_Index2.Location = new System.Drawing.Point(116, 242);
            this.pBx_Index2.Name = "pBx_Index2";
            this.pBx_Index2.Size = new System.Drawing.Size(44, 25);
            this.pBx_Index2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBx_Index2.TabIndex = 6;
            this.pBx_Index2.TabStop = false;
            this.pBx_Index2.Visible = false;
            // 
            // pBx_Index1
            // 
            this.pBx_Index1.Image = global::AdminControl.Properties.Resources.zhankai;
            this.pBx_Index1.Location = new System.Drawing.Point(116, 72);
            this.pBx_Index1.Name = "pBx_Index1";
            this.pBx_Index1.Size = new System.Drawing.Size(44, 25);
            this.pBx_Index1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBx_Index1.TabIndex = 0;
            this.pBx_Index1.TabStop = false;
            this.pBx_Index1.Visible = false;
            // 
            // btn_ReadingRoom
            // 
            this.btn_ReadingRoom.BackColor = System.Drawing.Color.Transparent;
            this.btn_ReadingRoom.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ReadingRoom.FlatAppearance.BorderSize = 0;
            this.btn_ReadingRoom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ReadingRoom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ReadingRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadingRoom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReadingRoom.ForeColor = System.Drawing.Color.White;
            this.btn_ReadingRoom.Location = new System.Drawing.Point(9, 230);
            this.btn_ReadingRoom.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ReadingRoom.Name = "btn_ReadingRoom";
            this.btn_ReadingRoom.Size = new System.Drawing.Size(110, 50);
            this.btn_ReadingRoom.TabIndex = 3;
            this.btn_ReadingRoom.Text = "阅片室";
            this.btn_ReadingRoom.UseVisualStyleBackColor = false;
            this.btn_ReadingRoom.Click += new System.EventHandler(this.Btn_ReadingRoomTwo_Click);
            // 
            // btn_ConsultationRoom
            // 
            this.btn_ConsultationRoom.BackColor = System.Drawing.Color.Transparent;
            this.btn_ConsultationRoom.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ConsultationRoom.FlatAppearance.BorderSize = 0;
            this.btn_ConsultationRoom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ConsultationRoom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ConsultationRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ConsultationRoom.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ConsultationRoom.ForeColor = System.Drawing.Color.White;
            this.btn_ConsultationRoom.Location = new System.Drawing.Point(9, 58);
            this.btn_ConsultationRoom.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ConsultationRoom.Name = "btn_ConsultationRoom";
            this.btn_ConsultationRoom.Size = new System.Drawing.Size(110, 50);
            this.btn_ConsultationRoom.TabIndex = 0;
            this.btn_ConsultationRoom.Text = "会诊室";
            this.btn_ConsultationRoom.UseVisualStyleBackColor = false;
            this.btn_ConsultationRoom.Click += new System.EventHandler(this.Btn_ConsultationRoomOne_Click);
            // 
            // panel_UserControl
            // 
            this.panel_UserControl.BackColor = System.Drawing.Color.Silver;
            this.panel_UserControl.Controls.Add(this.label5);
            this.panel_UserControl.Controls.Add(this.label4);
            this.panel_UserControl.Location = new System.Drawing.Point(160, 80);
            this.panel_UserControl.Margin = new System.Windows.Forms.Padding(0);
            this.panel_UserControl.Name = "panel_UserControl";
            this.panel_UserControl.Size = new System.Drawing.Size(864, 520);
            this.panel_UserControl.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(308, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "点击左侧按钮使用详细功能";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gadugi", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(145, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(624, 56);
            this.label4.TabIndex = 0;
            this.label4.Text = "欢迎使用影像中心总控系统";
            // 
            // Notice_Icon
            // 
            this.Notice_Icon.ContextMenuStrip = this.MenuStrip;
            this.Notice_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("Notice_Icon.Icon")));
            this.Notice_Icon.Text = "影像中心服务器";
            this.Notice_Icon.Visible = true;
            this.Notice_Icon.Click += new System.EventHandler(this.Notice_Icon_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMainForm,
            this.CloseMainForm});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // ShowMainForm
            // 
            this.ShowMainForm.Name = "ShowMainForm";
            this.ShowMainForm.Size = new System.Drawing.Size(100, 22);
            this.ShowMainForm.Text = "显示";
            this.ShowMainForm.Click += new System.EventHandler(this.ShowMainForm_Click);
            // 
            // CloseMainForm
            // 
            this.CloseMainForm.Name = "CloseMainForm";
            this.CloseMainForm.Size = new System.Drawing.Size(100, 22);
            this.CloseMainForm.Text = "退出";
            this.CloseMainForm.Click += new System.EventHandler(this.CloseMainForm_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panel_UserControl);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Information);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影像中心总控端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBx_Index1)).EndInit();
            this.panel_UserControl.ResumeLayout(false);
            this.panel_UserControl.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button btn_ConsultationRoom;
        private System.Windows.Forms.Button btn_ReadingRoom;
        private System.Windows.Forms.Panel panel_UserControl;
        private System.Windows.Forms.Label label_Hour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_Minute;
        private System.Windows.Forms.Label label_Week;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pBx_Index2;
        private System.Windows.Forms.PictureBox pBx_Index1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pBx_Index3;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Minnor;
        private System.Windows.Forms.NotifyIcon Notice_Icon;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowMainForm;
        private System.Windows.Forms.ToolStripMenuItem CloseMainForm;
    }
}

