namespace AdminControl
{
    partial class HospitalInformation
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
            this.btn_BUGReport = new System.Windows.Forms.Button();
            this.label_HospitalName = new System.Windows.Forms.Label();
            this.txt_ApplicationInformation = new System.Windows.Forms.TextBox();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Information.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_BUGReport
            // 
            this.btn_BUGReport.BackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReport.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_BUGReport.FlatAppearance.BorderSize = 0;
            this.btn_BUGReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BUGReport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BUGReport.ForeColor = System.Drawing.Color.White;
            this.btn_BUGReport.Location = new System.Drawing.Point(152, 283);
            this.btn_BUGReport.Margin = new System.Windows.Forms.Padding(0);
            this.btn_BUGReport.Name = "btn_BUGReport";
            this.btn_BUGReport.Size = new System.Drawing.Size(110, 50);
            this.btn_BUGReport.TabIndex = 3;
            this.btn_BUGReport.Text = "问题反馈";
            this.btn_BUGReport.UseVisualStyleBackColor = false;
            // 
            // label_HospitalName
            // 
            this.label_HospitalName.AutoSize = true;
            this.label_HospitalName.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_HospitalName.Location = new System.Drawing.Point(96, 11);
            this.label_HospitalName.Name = "label_HospitalName";
            this.label_HospitalName.Size = new System.Drawing.Size(223, 29);
            this.label_HospitalName.TabIndex = 0;
            this.label_HospitalName.Text = "湖北妇幼保健院";
            // 
            // txt_ApplicationInformation
            // 
            this.txt_ApplicationInformation.BackColor = System.Drawing.Color.Silver;
            this.txt_ApplicationInformation.Enabled = false;
            this.txt_ApplicationInformation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ApplicationInformation.ForeColor = System.Drawing.Color.Black;
            this.txt_ApplicationInformation.Location = new System.Drawing.Point(16, 86);
            this.txt_ApplicationInformation.Multiline = true;
            this.txt_ApplicationInformation.Name = "txt_ApplicationInformation";
            this.txt_ApplicationInformation.ReadOnly = true;
            this.txt_ApplicationInformation.Size = new System.Drawing.Size(382, 172);
            this.txt_ApplicationInformation.TabIndex = 1;
            // 
            // panel_Information
            // 
            this.panel_Information.BackColor = System.Drawing.Color.Transparent;
            this.panel_Information.Controls.Add(this.label_HospitalName);
            this.panel_Information.Controls.Add(this.txt_ApplicationInformation);
            this.panel_Information.Controls.Add(this.btn_BUGReport);
            this.panel_Information.Location = new System.Drawing.Point(143, 18);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(416, 341);
            this.panel_Information.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_Information);
            this.panel1.Location = new System.Drawing.Point(85, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 462);
            this.panel1.TabIndex = 5;
            // 
            // HospitalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Name = "HospitalInformation";
            this.Size = new System.Drawing.Size(864, 520);
            this.Load += new System.EventHandler(this.HospitalInformation_Load);
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_BUGReport;
        private System.Windows.Forms.Label label_HospitalName;
        private System.Windows.Forms.TextBox txt_ApplicationInformation;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Panel panel1;
    }
}
