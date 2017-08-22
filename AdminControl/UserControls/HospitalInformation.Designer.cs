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
            this.txt_ApplicationInformation = new System.Windows.Forms.TextBox();
            this.btn_BUGReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_BUGReport = new System.Windows.Forms.Panel();
            this.btn_BUGReportSend = new System.Windows.Forms.Button();
            this.btn_BUGReportBack = new System.Windows.Forms.Button();
            this.txt_EmailFilePath = new System.Windows.Forms.TextBox();
            this.txt_EmailTitle = new System.Windows.Forms.TextBox();
            this.richtxt_EmailContent = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_BUGReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ApplicationInformation
            // 
            this.txt_ApplicationInformation.BackColor = System.Drawing.Color.Silver;
            this.txt_ApplicationInformation.Enabled = false;
            this.txt_ApplicationInformation.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ApplicationInformation.Location = new System.Drawing.Point(221, 110);
            this.txt_ApplicationInformation.Multiline = true;
            this.txt_ApplicationInformation.Name = "txt_ApplicationInformation";
            this.txt_ApplicationInformation.Size = new System.Drawing.Size(416, 261);
            this.txt_ApplicationInformation.TabIndex = 1;
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
            this.btn_BUGReport.Location = new System.Drawing.Point(374, 384);
            this.btn_BUGReport.Margin = new System.Windows.Forms.Padding(0);
            this.btn_BUGReport.Name = "btn_BUGReport";
            this.btn_BUGReport.Size = new System.Drawing.Size(110, 50);
            this.btn_BUGReport.TabIndex = 2;
            this.btn_BUGReport.Text = "问题反馈";
            this.btn_BUGReport.UseVisualStyleBackColor = false;
            this.btn_BUGReport.Click += new System.EventHandler(this.Btn_BUGReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(356, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "软件信息";
            // 
            // panel_BUGReport
            // 
            this.panel_BUGReport.Controls.Add(this.btn_BUGReportSend);
            this.panel_BUGReport.Controls.Add(this.btn_BUGReportBack);
            this.panel_BUGReport.Controls.Add(this.txt_EmailFilePath);
            this.panel_BUGReport.Controls.Add(this.txt_EmailTitle);
            this.panel_BUGReport.Controls.Add(this.richtxt_EmailContent);
            this.panel_BUGReport.Controls.Add(this.label5);
            this.panel_BUGReport.Controls.Add(this.label4);
            this.panel_BUGReport.Controls.Add(this.label3);
            this.panel_BUGReport.Controls.Add(this.label2);
            this.panel_BUGReport.Location = new System.Drawing.Point(32, 10);
            this.panel_BUGReport.Name = "panel_BUGReport";
            this.panel_BUGReport.Size = new System.Drawing.Size(800, 500);
            this.panel_BUGReport.TabIndex = 4;
            // 
            // btn_BUGReportSend
            // 
            this.btn_BUGReportSend.BackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportSend.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_BUGReportSend.FlatAppearance.BorderSize = 0;
            this.btn_BUGReportSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BUGReportSend.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BUGReportSend.ForeColor = System.Drawing.Color.White;
            this.btn_BUGReportSend.Location = new System.Drawing.Point(605, 410);
            this.btn_BUGReportSend.Margin = new System.Windows.Forms.Padding(0);
            this.btn_BUGReportSend.Name = "btn_BUGReportSend";
            this.btn_BUGReportSend.Size = new System.Drawing.Size(110, 50);
            this.btn_BUGReportSend.TabIndex = 8;
            this.btn_BUGReportSend.Text = "发送";
            this.btn_BUGReportSend.UseVisualStyleBackColor = false;
            this.btn_BUGReportSend.Click += new System.EventHandler(this.Btn_BUGReportSend_Click);
            // 
            // btn_BUGReportBack
            // 
            this.btn_BUGReportBack.BackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportBack.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_BUGReportBack.FlatAppearance.BorderSize = 0;
            this.btn_BUGReportBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_BUGReportBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BUGReportBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BUGReportBack.ForeColor = System.Drawing.Color.White;
            this.btn_BUGReportBack.Location = new System.Drawing.Point(143, 410);
            this.btn_BUGReportBack.Margin = new System.Windows.Forms.Padding(0);
            this.btn_BUGReportBack.Name = "btn_BUGReportBack";
            this.btn_BUGReportBack.Size = new System.Drawing.Size(110, 50);
            this.btn_BUGReportBack.TabIndex = 7;
            this.btn_BUGReportBack.Text = "返回";
            this.btn_BUGReportBack.UseVisualStyleBackColor = false;
            this.btn_BUGReportBack.Click += new System.EventHandler(this.Btn_BUGReportBack_Click);
            // 
            // txt_EmailFilePath
            // 
            this.txt_EmailFilePath.Location = new System.Drawing.Point(143, 110);
            this.txt_EmailFilePath.Name = "txt_EmailFilePath";
            this.txt_EmailFilePath.Size = new System.Drawing.Size(164, 21);
            this.txt_EmailFilePath.TabIndex = 6;
            // 
            // txt_EmailTitle
            // 
            this.txt_EmailTitle.Location = new System.Drawing.Point(143, 78);
            this.txt_EmailTitle.Name = "txt_EmailTitle";
            this.txt_EmailTitle.Size = new System.Drawing.Size(164, 21);
            this.txt_EmailTitle.TabIndex = 5;
            // 
            // richtxt_EmailContent
            // 
            this.richtxt_EmailContent.Location = new System.Drawing.Point(143, 142);
            this.richtxt_EmailContent.Name = "richtxt_EmailContent";
            this.richtxt_EmailContent.Size = new System.Drawing.Size(572, 236);
            this.richtxt_EmailContent.TabIndex = 4;
            this.richtxt_EmailContent.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "邮件正文：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "日志附件：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "邮件主题：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(336, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "BUG反馈";
            // 
            // HospitalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel_BUGReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BUGReport);
            this.Controls.Add(this.txt_ApplicationInformation);
            this.Name = "HospitalInformation";
            this.Size = new System.Drawing.Size(864, 520);
            this.Load += new System.EventHandler(this.HospitalInformation_Load);
            this.panel_BUGReport.ResumeLayout(false);
            this.panel_BUGReport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_ApplicationInformation;
        private System.Windows.Forms.Button btn_BUGReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_BUGReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richtxt_EmailContent;
        private System.Windows.Forms.TextBox txt_EmailFilePath;
        private System.Windows.Forms.TextBox txt_EmailTitle;
        private System.Windows.Forms.Button btn_BUGReportSend;
        private System.Windows.Forms.Button btn_BUGReportBack;
    }
}
