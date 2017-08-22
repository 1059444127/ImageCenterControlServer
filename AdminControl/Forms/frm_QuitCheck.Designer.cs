namespace AdminControl
{
    partial class Frm_QuitCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_AdminPasswd = new System.Windows.Forms.TextBox();
            this.btn_QuitConfirm = new System.Windows.Forms.Button();
            this.btn_QuitReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入管理员密码";
            // 
            // txt_AdminPasswd
            // 
            this.txt_AdminPasswd.BackColor = System.Drawing.Color.White;
            this.txt_AdminPasswd.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_AdminPasswd.Location = new System.Drawing.Point(150, 109);
            this.txt_AdminPasswd.MaxLength = 16;
            this.txt_AdminPasswd.Name = "txt_AdminPasswd";
            this.txt_AdminPasswd.PasswordChar = '*';
            this.txt_AdminPasswd.ShortcutsEnabled = false;
            this.txt_AdminPasswd.Size = new System.Drawing.Size(157, 26);
            this.txt_AdminPasswd.TabIndex = 1;
            // 
            // btn_QuitConfirm
            // 
            this.btn_QuitConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btn_QuitConfirm.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_QuitConfirm.FlatAppearance.BorderSize = 0;
            this.btn_QuitConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_QuitConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_QuitConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuitConfirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QuitConfirm.ForeColor = System.Drawing.Color.White;
            this.btn_QuitConfirm.Location = new System.Drawing.Point(119, 201);
            this.btn_QuitConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btn_QuitConfirm.Name = "btn_QuitConfirm";
            this.btn_QuitConfirm.Size = new System.Drawing.Size(110, 50);
            this.btn_QuitConfirm.TabIndex = 2;
            this.btn_QuitConfirm.Text = "确认";
            this.btn_QuitConfirm.UseVisualStyleBackColor = false;
            this.btn_QuitConfirm.Click += new System.EventHandler(this.Btn_QuitConfirm_Click);
            // 
            // btn_QuitReturn
            // 
            this.btn_QuitReturn.BackColor = System.Drawing.Color.Transparent;
            this.btn_QuitReturn.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_QuitReturn.FlatAppearance.BorderSize = 0;
            this.btn_QuitReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_QuitReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_QuitReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuitReturn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_QuitReturn.ForeColor = System.Drawing.Color.White;
            this.btn_QuitReturn.Location = new System.Drawing.Point(229, 201);
            this.btn_QuitReturn.Margin = new System.Windows.Forms.Padding(0);
            this.btn_QuitReturn.Name = "btn_QuitReturn";
            this.btn_QuitReturn.Size = new System.Drawing.Size(110, 50);
            this.btn_QuitReturn.TabIndex = 3;
            this.btn_QuitReturn.Text = "取消";
            this.btn_QuitReturn.UseVisualStyleBackColor = false;
            this.btn_QuitReturn.Click += new System.EventHandler(this.Btn_QuitReturn_Click);
            // 
            // frm_QuitCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(460, 315);
            this.Controls.Add(this.btn_QuitReturn);
            this.Controls.Add(this.btn_QuitConfirm);
            this.Controls.Add(this.txt_AdminPasswd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_QuitCheck";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份校验";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_QuitCheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_AdminPasswd;
        private System.Windows.Forms.Button btn_QuitConfirm;
        private System.Windows.Forms.Button btn_QuitReturn;
    }
}