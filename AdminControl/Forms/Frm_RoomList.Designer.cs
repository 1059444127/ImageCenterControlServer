namespace AdminControl
{
    partial class Frm_RoomList
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
            this.Panel_Information = new System.Windows.Forms.Panel();
            this.panel_RoomList = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Panel_Information
            // 
            this.Panel_Information.BackColor = System.Drawing.Color.DimGray;
            this.Panel_Information.Location = new System.Drawing.Point(0, 0);
            this.Panel_Information.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Information.Name = "Panel_Information";
            this.Panel_Information.Size = new System.Drawing.Size(1024, 80);
            this.Panel_Information.TabIndex = 0;
            this.Panel_Information.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Information_MouseDown);
            this.Panel_Information.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Information_MouseMove);
            // 
            // panel_RoomList
            // 
            this.panel_RoomList.BackColor = System.Drawing.Color.LightGray;
            this.panel_RoomList.Location = new System.Drawing.Point(0, 80);
            this.panel_RoomList.Margin = new System.Windows.Forms.Padding(0);
            this.panel_RoomList.Name = "panel_RoomList";
            this.panel_RoomList.Size = new System.Drawing.Size(180, 520);
            this.panel_RoomList.TabIndex = 1;
            // 
            // Frm_RoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panel_RoomList);
            this.Controls.Add(this.Panel_Information);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_RoomList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器";
            this.Load += new System.EventHandler(this.Frm_RoomList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Information;
        private System.Windows.Forms.Panel panel_RoomList;
    }
}