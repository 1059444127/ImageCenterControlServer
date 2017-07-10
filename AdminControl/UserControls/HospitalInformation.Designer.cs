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
            this.btn_ModeHZ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            // btn_ModeHZ
            // 
            this.btn_ModeHZ.BackColor = System.Drawing.Color.Transparent;
            this.btn_ModeHZ.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ModeHZ.FlatAppearance.BorderSize = 0;
            this.btn_ModeHZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeHZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeHZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModeHZ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeHZ.ForeColor = System.Drawing.Color.White;
            this.btn_ModeHZ.Location = new System.Drawing.Point(374, 384);
            this.btn_ModeHZ.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ModeHZ.Name = "btn_ModeHZ";
            this.btn_ModeHZ.Size = new System.Drawing.Size(110, 50);
            this.btn_ModeHZ.TabIndex = 2;
            this.btn_ModeHZ.Text = "问题反馈";
            this.btn_ModeHZ.UseVisualStyleBackColor = false;
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
            // HospitalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ModeHZ);
            this.Controls.Add(this.txt_ApplicationInformation);
            this.Name = "HospitalInformation";
            this.Size = new System.Drawing.Size(864, 520);
            this.Load += new System.EventHandler(this.HospitalInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_ApplicationInformation;
        private System.Windows.Forms.Button btn_ModeHZ;
        private System.Windows.Forms.Label label1;
    }
}
