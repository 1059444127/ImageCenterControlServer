namespace AdminControl
{
    partial class ReadingRoomTwo
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_ControlStatus = new System.Windows.Forms.Label();
            this.label_Control = new System.Windows.Forms.Label();
            this.label_ClientStatus = new System.Windows.Forms.Label();
            this.label_Client = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gadugi", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 56);
            this.label4.TabIndex = 3;
            this.label4.Text = "阅片室2";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(544, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 294);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "灯光系统";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(63, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 294);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "环境数据";
            // 
            // label_ControlStatus
            // 
            this.label_ControlStatus.AutoSize = true;
            this.label_ControlStatus.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ControlStatus.ForeColor = System.Drawing.Color.Red;
            this.label_ControlStatus.Location = new System.Drawing.Point(724, 19);
            this.label_ControlStatus.Name = "label_ControlStatus";
            this.label_ControlStatus.Size = new System.Drawing.Size(78, 25);
            this.label_ControlStatus.TabIndex = 9;
            this.label_ControlStatus.Text = "未连接";
            // 
            // label_Control
            // 
            this.label_Control.AutoSize = true;
            this.label_Control.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Control.Location = new System.Drawing.Point(640, 19);
            this.label_Control.Name = "label_Control";
            this.label_Control.Size = new System.Drawing.Size(83, 25);
            this.label_Control.TabIndex = 8;
            this.label_Control.Text = "控制端:";
            // 
            // label_ClientStatus
            // 
            this.label_ClientStatus.AutoSize = true;
            this.label_ClientStatus.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ClientStatus.ForeColor = System.Drawing.Color.Red;
            this.label_ClientStatus.Location = new System.Drawing.Point(724, 61);
            this.label_ClientStatus.Name = "label_ClientStatus";
            this.label_ClientStatus.Size = new System.Drawing.Size(78, 25);
            this.label_ClientStatus.TabIndex = 11;
            this.label_ClientStatus.Text = "未连接";
            // 
            // label_Client
            // 
            this.label_Client.AutoSize = true;
            this.label_Client.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Client.Location = new System.Drawing.Point(640, 61);
            this.label_Client.Name = "label_Client";
            this.label_Client.Size = new System.Drawing.Size(83, 25);
            this.label_Client.TabIndex = 10;
            this.label_Client.Text = "控制端:";
            // 
            // ReadingRoomTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label_ClientStatus);
            this.Controls.Add(this.label_Client);
            this.Controls.Add(this.label_ControlStatus);
            this.Controls.Add(this.label_Control);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Name = "ReadingRoomTwo";
            this.Size = new System.Drawing.Size(864, 520);
            this.Load += new System.EventHandler(this.ReadingRoomTwo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_ControlStatus;
        private System.Windows.Forms.Label label_Control;
        private System.Windows.Forms.Label label_ClientStatus;
        private System.Windows.Forms.Label label_Client;
    }
}
