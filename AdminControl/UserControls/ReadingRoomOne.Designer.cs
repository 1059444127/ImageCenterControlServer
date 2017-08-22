namespace AdminControl
{
    partial class ReadingRoomOne
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
            this.label_ControlStatus = new System.Windows.Forms.Label();
            this.label_Control = new System.Windows.Forms.Label();
            this.label_ClientStatus = new System.Windows.Forms.Label();
            this.label_Client = new System.Windows.Forms.Label();
            this.gBx_ModeChange = new System.Windows.Forms.GroupBox();
            this.btn_ModeLK = new System.Windows.Forms.Button();
            this.btn_ModeXX = new System.Windows.Forms.Button();
            this.btn_ModeYP = new System.Windows.Forms.Button();
            this.gBx_DeviceControl = new System.Windows.Forms.GroupBox();
            this.btn_WindowsTwo_Off = new System.Windows.Forms.Button();
            this.btn_WindowsTwo_On = new System.Windows.Forms.Button();
            this.label_WindowsTwo = new System.Windows.Forms.Label();
            this.btn_WindowsOne_Off = new System.Windows.Forms.Button();
            this.btn_WindowsOne_On = new System.Windows.Forms.Button();
            this.label_WindowsOne = new System.Windows.Forms.Label();
            this.label_LightThree = new System.Windows.Forms.Label();
            this.label_LightTwo = new System.Windows.Forms.Label();
            this.label_LightOne = new System.Windows.Forms.Label();
            this.btn_TopLight_On = new System.Windows.Forms.Button();
            this.btn_WallLight_On = new System.Windows.Forms.Button();
            this.btn_RoundLight_On = new System.Windows.Forms.Button();
            this.btn_RoundLight_Off = new System.Windows.Forms.Button();
            this.btn_WallLight_Off = new System.Windows.Forms.Button();
            this.btn_TopLight_Off = new System.Windows.Forms.Button();
            this.btn_AllLights_On = new System.Windows.Forms.Button();
            this.btn_AllLights_Off = new System.Windows.Forms.Button();
            this.gBx_LightsControl = new System.Windows.Forms.GroupBox();
            this.gBx_Enviroument = new System.Windows.Forms.GroupBox();
            this.label_Noise = new System.Windows.Forms.Label();
            this.label_Light = new System.Windows.Forms.Label();
            this.label_Temp = new System.Windows.Forms.Label();
            this.label_Hum = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gBx_ModeChange.SuspendLayout();
            this.gBx_DeviceControl.SuspendLayout();
            this.gBx_LightsControl.SuspendLayout();
            this.gBx_Enviroument.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gadugi", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 56);
            this.label4.TabIndex = 2;
            this.label4.Text = "阅片室1";
            // 
            // label_ControlStatus
            // 
            this.label_ControlStatus.AutoSize = true;
            this.label_ControlStatus.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ControlStatus.ForeColor = System.Drawing.Color.Red;
            this.label_ControlStatus.Location = new System.Drawing.Point(724, 19);
            this.label_ControlStatus.Name = "label_ControlStatus";
            this.label_ControlStatus.Size = new System.Drawing.Size(78, 25);
            this.label_ControlStatus.TabIndex = 7;
            this.label_ControlStatus.Text = "未连接";
            // 
            // label_Control
            // 
            this.label_Control.AutoSize = true;
            this.label_Control.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Control.Location = new System.Drawing.Point(640, 19);
            this.label_Control.Name = "label_Control";
            this.label_Control.Size = new System.Drawing.Size(83, 25);
            this.label_Control.TabIndex = 6;
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
            this.label_ClientStatus.TabIndex = 9;
            this.label_ClientStatus.Text = "未连接";
            // 
            // label_Client
            // 
            this.label_Client.AutoSize = true;
            this.label_Client.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Client.Location = new System.Drawing.Point(640, 61);
            this.label_Client.Name = "label_Client";
            this.label_Client.Size = new System.Drawing.Size(83, 25);
            this.label_Client.TabIndex = 8;
            this.label_Client.Text = "客户端:";
            // 
            // gBx_ModeChange
            // 
            this.gBx_ModeChange.Controls.Add(this.btn_ModeLK);
            this.gBx_ModeChange.Controls.Add(this.btn_ModeXX);
            this.gBx_ModeChange.Controls.Add(this.btn_ModeYP);
            this.gBx_ModeChange.Location = new System.Drawing.Point(24, 150);
            this.gBx_ModeChange.Name = "gBx_ModeChange";
            this.gBx_ModeChange.Size = new System.Drawing.Size(146, 280);
            this.gBx_ModeChange.TabIndex = 25;
            this.gBx_ModeChange.TabStop = false;
            this.gBx_ModeChange.Text = "模式切换";
            // 
            // btn_ModeLK
            // 
            this.btn_ModeLK.BackColor = System.Drawing.Color.Transparent;
            this.btn_ModeLK.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ModeLK.FlatAppearance.BorderSize = 0;
            this.btn_ModeLK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeLK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeLK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModeLK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeLK.ForeColor = System.Drawing.Color.White;
            this.btn_ModeLK.Location = new System.Drawing.Point(19, 172);
            this.btn_ModeLK.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ModeLK.Name = "btn_ModeLK";
            this.btn_ModeLK.Size = new System.Drawing.Size(110, 50);
            this.btn_ModeLK.TabIndex = 3;
            this.btn_ModeLK.Text = "离开模式";
            this.btn_ModeLK.UseVisualStyleBackColor = false;
            this.btn_ModeLK.Click += new System.EventHandler(this.Btn_ModeLK_Click);
            // 
            // btn_ModeXX
            // 
            this.btn_ModeXX.BackColor = System.Drawing.Color.Transparent;
            this.btn_ModeXX.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ModeXX.FlatAppearance.BorderSize = 0;
            this.btn_ModeXX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeXX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeXX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModeXX.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeXX.ForeColor = System.Drawing.Color.White;
            this.btn_ModeXX.Location = new System.Drawing.Point(19, 119);
            this.btn_ModeXX.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ModeXX.Name = "btn_ModeXX";
            this.btn_ModeXX.Size = new System.Drawing.Size(110, 50);
            this.btn_ModeXX.TabIndex = 2;
            this.btn_ModeXX.Text = "休息模式";
            this.btn_ModeXX.UseVisualStyleBackColor = false;
            this.btn_ModeXX.Click += new System.EventHandler(this.Btn_ModeXX_Click);
            // 
            // btn_ModeYP
            // 
            this.btn_ModeYP.BackColor = System.Drawing.Color.Transparent;
            this.btn_ModeYP.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_ModeYP.FlatAppearance.BorderSize = 0;
            this.btn_ModeYP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeYP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ModeYP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ModeYP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ModeYP.ForeColor = System.Drawing.Color.White;
            this.btn_ModeYP.Location = new System.Drawing.Point(19, 66);
            this.btn_ModeYP.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ModeYP.Name = "btn_ModeYP";
            this.btn_ModeYP.Size = new System.Drawing.Size(110, 50);
            this.btn_ModeYP.TabIndex = 1;
            this.btn_ModeYP.Text = "阅片模式";
            this.btn_ModeYP.UseVisualStyleBackColor = false;
            this.btn_ModeYP.Click += new System.EventHandler(this.Btn_ModeYP_Click);
            // 
            // gBx_DeviceControl
            // 
            this.gBx_DeviceControl.Controls.Add(this.btn_WindowsTwo_Off);
            this.gBx_DeviceControl.Controls.Add(this.btn_WindowsTwo_On);
            this.gBx_DeviceControl.Controls.Add(this.label_WindowsTwo);
            this.gBx_DeviceControl.Controls.Add(this.btn_WindowsOne_Off);
            this.gBx_DeviceControl.Controls.Add(this.btn_WindowsOne_On);
            this.gBx_DeviceControl.Controls.Add(this.label_WindowsOne);
            this.gBx_DeviceControl.Location = new System.Drawing.Point(378, 149);
            this.gBx_DeviceControl.Name = "gBx_DeviceControl";
            this.gBx_DeviceControl.Size = new System.Drawing.Size(256, 280);
            this.gBx_DeviceControl.TabIndex = 27;
            this.gBx_DeviceControl.TabStop = false;
            this.gBx_DeviceControl.Text = "设备控制";
            // 
            // btn_WindowsTwo_Off
            // 
            this.btn_WindowsTwo_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WindowsTwo_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WindowsTwo_Off.FlatAppearance.BorderSize = 0;
            this.btn_WindowsTwo_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WindowsTwo_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WindowsTwo_Off.ForeColor = System.Drawing.Color.White;
            this.btn_WindowsTwo_Off.Location = new System.Drawing.Point(166, 163);
            this.btn_WindowsTwo_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WindowsTwo_Off.Name = "btn_WindowsTwo_Off";
            this.btn_WindowsTwo_Off.Size = new System.Drawing.Size(70, 50);
            this.btn_WindowsTwo_Off.TabIndex = 42;
            this.btn_WindowsTwo_Off.Text = "关";
            this.btn_WindowsTwo_Off.UseVisualStyleBackColor = false;
            this.btn_WindowsTwo_Off.Click += new System.EventHandler(this.Btn_WindowsTwo_Off_Click);
            // 
            // btn_WindowsTwo_On
            // 
            this.btn_WindowsTwo_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WindowsTwo_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WindowsTwo_On.FlatAppearance.BorderSize = 0;
            this.btn_WindowsTwo_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsTwo_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WindowsTwo_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WindowsTwo_On.ForeColor = System.Drawing.Color.White;
            this.btn_WindowsTwo_On.Location = new System.Drawing.Point(96, 163);
            this.btn_WindowsTwo_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WindowsTwo_On.Name = "btn_WindowsTwo_On";
            this.btn_WindowsTwo_On.Size = new System.Drawing.Size(70, 50);
            this.btn_WindowsTwo_On.TabIndex = 41;
            this.btn_WindowsTwo_On.Text = "开";
            this.btn_WindowsTwo_On.UseVisualStyleBackColor = false;
            this.btn_WindowsTwo_On.Click += new System.EventHandler(this.Btn_WindowsTwo_On_Click);
            // 
            // label_WindowsTwo
            // 
            this.label_WindowsTwo.AutoSize = true;
            this.label_WindowsTwo.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WindowsTwo.Location = new System.Drawing.Point(6, 174);
            this.label_WindowsTwo.Name = "label_WindowsTwo";
            this.label_WindowsTwo.Size = new System.Drawing.Size(72, 25);
            this.label_WindowsTwo.TabIndex = 40;
            this.label_WindowsTwo.Text = "窗帘2:";
            // 
            // btn_WindowsOne_Off
            // 
            this.btn_WindowsOne_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WindowsOne_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WindowsOne_Off.FlatAppearance.BorderSize = 0;
            this.btn_WindowsOne_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WindowsOne_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WindowsOne_Off.ForeColor = System.Drawing.Color.White;
            this.btn_WindowsOne_Off.Location = new System.Drawing.Point(166, 67);
            this.btn_WindowsOne_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WindowsOne_Off.Name = "btn_WindowsOne_Off";
            this.btn_WindowsOne_Off.Size = new System.Drawing.Size(70, 50);
            this.btn_WindowsOne_Off.TabIndex = 38;
            this.btn_WindowsOne_Off.Text = "关";
            this.btn_WindowsOne_Off.UseVisualStyleBackColor = false;
            this.btn_WindowsOne_Off.Click += new System.EventHandler(this.Btn_WindowsOne_Off_Click);
            // 
            // btn_WindowsOne_On
            // 
            this.btn_WindowsOne_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WindowsOne_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WindowsOne_On.FlatAppearance.BorderSize = 0;
            this.btn_WindowsOne_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WindowsOne_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WindowsOne_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WindowsOne_On.ForeColor = System.Drawing.Color.White;
            this.btn_WindowsOne_On.Location = new System.Drawing.Point(96, 67);
            this.btn_WindowsOne_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WindowsOne_On.Name = "btn_WindowsOne_On";
            this.btn_WindowsOne_On.Size = new System.Drawing.Size(70, 50);
            this.btn_WindowsOne_On.TabIndex = 34;
            this.btn_WindowsOne_On.Text = "开";
            this.btn_WindowsOne_On.UseVisualStyleBackColor = false;
            this.btn_WindowsOne_On.Click += new System.EventHandler(this.Btn_WindowsOne_On_Click);
            // 
            // label_WindowsOne
            // 
            this.label_WindowsOne.AutoSize = true;
            this.label_WindowsOne.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WindowsOne.Location = new System.Drawing.Point(6, 78);
            this.label_WindowsOne.Name = "label_WindowsOne";
            this.label_WindowsOne.Size = new System.Drawing.Size(72, 25);
            this.label_WindowsOne.TabIndex = 16;
            this.label_WindowsOne.Text = "窗帘1:";
            // 
            // label_LightThree
            // 
            this.label_LightThree.AutoSize = true;
            this.label_LightThree.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LightThree.Location = new System.Drawing.Point(6, 152);
            this.label_LightThree.Name = "label_LightThree";
            this.label_LightThree.Size = new System.Drawing.Size(78, 25);
            this.label_LightThree.TabIndex = 24;
            this.label_LightThree.Text = "灯带：";
            // 
            // label_LightTwo
            // 
            this.label_LightTwo.AutoSize = true;
            this.label_LightTwo.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LightTwo.Location = new System.Drawing.Point(6, 99);
            this.label_LightTwo.Name = "label_LightTwo";
            this.label_LightTwo.Size = new System.Drawing.Size(78, 25);
            this.label_LightTwo.TabIndex = 23;
            this.label_LightTwo.Text = "壁灯：";
            // 
            // label_LightOne
            // 
            this.label_LightOne.AutoSize = true;
            this.label_LightOne.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LightOne.Location = new System.Drawing.Point(6, 46);
            this.label_LightOne.Name = "label_LightOne";
            this.label_LightOne.Size = new System.Drawing.Size(78, 25);
            this.label_LightOne.TabIndex = 22;
            this.label_LightOne.Text = "顶灯：";
            // 
            // btn_TopLight_On
            // 
            this.btn_TopLight_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_TopLight_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TopLight_On.FlatAppearance.BorderSize = 0;
            this.btn_TopLight_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TopLight_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TopLight_On.ForeColor = System.Drawing.Color.White;
            this.btn_TopLight_On.Location = new System.Drawing.Point(76, 34);
            this.btn_TopLight_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_TopLight_On.Name = "btn_TopLight_On";
            this.btn_TopLight_On.Size = new System.Drawing.Size(55, 50);
            this.btn_TopLight_On.TabIndex = 14;
            this.btn_TopLight_On.Text = "开";
            this.btn_TopLight_On.UseVisualStyleBackColor = false;
            this.btn_TopLight_On.Click += new System.EventHandler(this.Btn_TopLight_On_Click);
            // 
            // btn_WallLight_On
            // 
            this.btn_WallLight_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WallLight_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WallLight_On.FlatAppearance.BorderSize = 0;
            this.btn_WallLight_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WallLight_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WallLight_On.ForeColor = System.Drawing.Color.White;
            this.btn_WallLight_On.Location = new System.Drawing.Point(76, 88);
            this.btn_WallLight_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WallLight_On.Name = "btn_WallLight_On";
            this.btn_WallLight_On.Size = new System.Drawing.Size(55, 50);
            this.btn_WallLight_On.TabIndex = 26;
            this.btn_WallLight_On.Text = "开";
            this.btn_WallLight_On.UseVisualStyleBackColor = false;
            this.btn_WallLight_On.Click += new System.EventHandler(this.Btn_WallLight_On_Click);
            // 
            // btn_RoundLight_On
            // 
            this.btn_RoundLight_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_RoundLight_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_RoundLight_On.FlatAppearance.BorderSize = 0;
            this.btn_RoundLight_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RoundLight_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RoundLight_On.ForeColor = System.Drawing.Color.White;
            this.btn_RoundLight_On.Location = new System.Drawing.Point(76, 141);
            this.btn_RoundLight_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_RoundLight_On.Name = "btn_RoundLight_On";
            this.btn_RoundLight_On.Size = new System.Drawing.Size(55, 50);
            this.btn_RoundLight_On.TabIndex = 27;
            this.btn_RoundLight_On.Text = "开";
            this.btn_RoundLight_On.UseVisualStyleBackColor = false;
            this.btn_RoundLight_On.Click += new System.EventHandler(this.Btn_RoundLight_On_Click);
            // 
            // btn_RoundLight_Off
            // 
            this.btn_RoundLight_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_RoundLight_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_RoundLight_Off.FlatAppearance.BorderSize = 0;
            this.btn_RoundLight_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_RoundLight_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RoundLight_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RoundLight_Off.ForeColor = System.Drawing.Color.White;
            this.btn_RoundLight_Off.Location = new System.Drawing.Point(131, 141);
            this.btn_RoundLight_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_RoundLight_Off.Name = "btn_RoundLight_Off";
            this.btn_RoundLight_Off.Size = new System.Drawing.Size(55, 50);
            this.btn_RoundLight_Off.TabIndex = 28;
            this.btn_RoundLight_Off.Text = "关";
            this.btn_RoundLight_Off.UseVisualStyleBackColor = false;
            this.btn_RoundLight_Off.Click += new System.EventHandler(this.Btn_RoundLight_Off_Click);
            // 
            // btn_WallLight_Off
            // 
            this.btn_WallLight_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_WallLight_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_WallLight_Off.FlatAppearance.BorderSize = 0;
            this.btn_WallLight_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_WallLight_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_WallLight_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_WallLight_Off.ForeColor = System.Drawing.Color.White;
            this.btn_WallLight_Off.Location = new System.Drawing.Point(131, 88);
            this.btn_WallLight_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_WallLight_Off.Name = "btn_WallLight_Off";
            this.btn_WallLight_Off.Size = new System.Drawing.Size(55, 50);
            this.btn_WallLight_Off.TabIndex = 29;
            this.btn_WallLight_Off.Text = "关";
            this.btn_WallLight_Off.UseVisualStyleBackColor = false;
            this.btn_WallLight_Off.Click += new System.EventHandler(this.Btn_WallLight_Off_Click);
            // 
            // btn_TopLight_Off
            // 
            this.btn_TopLight_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_TopLight_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TopLight_Off.FlatAppearance.BorderSize = 0;
            this.btn_TopLight_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TopLight_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TopLight_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TopLight_Off.ForeColor = System.Drawing.Color.White;
            this.btn_TopLight_Off.Location = new System.Drawing.Point(131, 35);
            this.btn_TopLight_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_TopLight_Off.Name = "btn_TopLight_Off";
            this.btn_TopLight_Off.Size = new System.Drawing.Size(55, 50);
            this.btn_TopLight_Off.TabIndex = 30;
            this.btn_TopLight_Off.Text = "关";
            this.btn_TopLight_Off.UseVisualStyleBackColor = false;
            this.btn_TopLight_Off.Click += new System.EventHandler(this.Btn_TopLight_Off_Click);
            // 
            // btn_AllLights_On
            // 
            this.btn_AllLights_On.BackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_On.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_AllLights_On.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AllLights_On.FlatAppearance.BorderSize = 0;
            this.btn_AllLights_On.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_On.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AllLights_On.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AllLights_On.ForeColor = System.Drawing.Color.White;
            this.btn_AllLights_On.Location = new System.Drawing.Point(11, 210);
            this.btn_AllLights_On.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AllLights_On.Name = "btn_AllLights_On";
            this.btn_AllLights_On.Size = new System.Drawing.Size(88, 50);
            this.btn_AllLights_On.TabIndex = 5;
            this.btn_AllLights_On.Text = "全开";
            this.btn_AllLights_On.UseVisualStyleBackColor = false;
            this.btn_AllLights_On.Click += new System.EventHandler(this.Btn_AllLights_On_Click);
            // 
            // btn_AllLights_Off
            // 
            this.btn_AllLights_Off.BackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_Off.BackgroundImage = global::AdminControl.Properties.Resources.button;
            this.btn_AllLights_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AllLights_Off.FlatAppearance.BorderSize = 0;
            this.btn_AllLights_Off.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_Off.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AllLights_Off.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AllLights_Off.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AllLights_Off.ForeColor = System.Drawing.Color.White;
            this.btn_AllLights_Off.Location = new System.Drawing.Point(98, 210);
            this.btn_AllLights_Off.Margin = new System.Windows.Forms.Padding(0);
            this.btn_AllLights_Off.Name = "btn_AllLights_Off";
            this.btn_AllLights_Off.Size = new System.Drawing.Size(88, 50);
            this.btn_AllLights_Off.TabIndex = 31;
            this.btn_AllLights_Off.Text = "全关";
            this.btn_AllLights_Off.UseVisualStyleBackColor = false;
            this.btn_AllLights_Off.Click += new System.EventHandler(this.Btn_AllLights_Off_Click);
            // 
            // gBx_LightsControl
            // 
            this.gBx_LightsControl.Controls.Add(this.btn_AllLights_Off);
            this.gBx_LightsControl.Controls.Add(this.btn_AllLights_On);
            this.gBx_LightsControl.Controls.Add(this.btn_TopLight_Off);
            this.gBx_LightsControl.Controls.Add(this.btn_WallLight_Off);
            this.gBx_LightsControl.Controls.Add(this.btn_RoundLight_Off);
            this.gBx_LightsControl.Controls.Add(this.btn_RoundLight_On);
            this.gBx_LightsControl.Controls.Add(this.btn_WallLight_On);
            this.gBx_LightsControl.Controls.Add(this.btn_TopLight_On);
            this.gBx_LightsControl.Controls.Add(this.label_LightOne);
            this.gBx_LightsControl.Controls.Add(this.label_LightTwo);
            this.gBx_LightsControl.Controls.Add(this.label_LightThree);
            this.gBx_LightsControl.Location = new System.Drawing.Point(176, 150);
            this.gBx_LightsControl.Name = "gBx_LightsControl";
            this.gBx_LightsControl.Size = new System.Drawing.Size(196, 280);
            this.gBx_LightsControl.TabIndex = 26;
            this.gBx_LightsControl.TabStop = false;
            this.gBx_LightsControl.Text = "灯光控制";
            // 
            // gBx_Enviroument
            // 
            this.gBx_Enviroument.Controls.Add(this.label_Noise);
            this.gBx_Enviroument.Controls.Add(this.label_Light);
            this.gBx_Enviroument.Controls.Add(this.label_Temp);
            this.gBx_Enviroument.Controls.Add(this.label_Hum);
            this.gBx_Enviroument.Controls.Add(this.label11);
            this.gBx_Enviroument.Controls.Add(this.label10);
            this.gBx_Enviroument.Controls.Add(this.label9);
            this.gBx_Enviroument.Controls.Add(this.label8);
            this.gBx_Enviroument.Location = new System.Drawing.Point(640, 154);
            this.gBx_Enviroument.Name = "gBx_Enviroument";
            this.gBx_Enviroument.Size = new System.Drawing.Size(207, 275);
            this.gBx_Enviroument.TabIndex = 28;
            this.gBx_Enviroument.TabStop = false;
            this.gBx_Enviroument.Text = "环境数据";
            // 
            // label_Noise
            // 
            this.label_Noise.AutoSize = true;
            this.label_Noise.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Noise.Location = new System.Drawing.Point(84, 195);
            this.label_Noise.Name = "label_Noise";
            this.label_Noise.Size = new System.Drawing.Size(93, 25);
            this.label_Noise.TabIndex = 53;
            this.label_Noise.Text = "初始化...";
            // 
            // label_Light
            // 
            this.label_Light.AutoSize = true;
            this.label_Light.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Light.Location = new System.Drawing.Point(84, 144);
            this.label_Light.Name = "label_Light";
            this.label_Light.Size = new System.Drawing.Size(93, 25);
            this.label_Light.TabIndex = 52;
            this.label_Light.Text = "初始化...";
            // 
            // label_Temp
            // 
            this.label_Temp.AutoSize = true;
            this.label_Temp.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Temp.Location = new System.Drawing.Point(84, 42);
            this.label_Temp.Name = "label_Temp";
            this.label_Temp.Size = new System.Drawing.Size(93, 25);
            this.label_Temp.TabIndex = 51;
            this.label_Temp.Text = "初始化...";
            // 
            // label_Hum
            // 
            this.label_Hum.AutoSize = true;
            this.label_Hum.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hum.Location = new System.Drawing.Point(84, 93);
            this.label_Hum.Name = "label_Hum";
            this.label_Hum.Size = new System.Drawing.Size(93, 25);
            this.label_Hum.TabIndex = 50;
            this.label_Hum.Text = "初始化...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 25);
            this.label11.TabIndex = 49;
            this.label11.Text = "噪音:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 25);
            this.label10.TabIndex = 48;
            this.label10.Text = "光照:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 25);
            this.label9.TabIndex = 47;
            this.label9.Text = "湿度:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 25);
            this.label8.TabIndex = 46;
            this.label8.Text = "温度:";
            // 
            // ReadingRoomOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.gBx_Enviroument);
            this.Controls.Add(this.gBx_DeviceControl);
            this.Controls.Add(this.gBx_LightsControl);
            this.Controls.Add(this.gBx_ModeChange);
            this.Controls.Add(this.label_ClientStatus);
            this.Controls.Add(this.label_Client);
            this.Controls.Add(this.label_ControlStatus);
            this.Controls.Add(this.label_Control);
            this.Controls.Add(this.label4);
            this.Name = "ReadingRoomOne";
            this.Size = new System.Drawing.Size(864, 520);
            this.Load += new System.EventHandler(this.ReadingRoomOne_Load);
            this.gBx_ModeChange.ResumeLayout(false);
            this.gBx_DeviceControl.ResumeLayout(false);
            this.gBx_DeviceControl.PerformLayout();
            this.gBx_LightsControl.ResumeLayout(false);
            this.gBx_LightsControl.PerformLayout();
            this.gBx_Enviroument.ResumeLayout(false);
            this.gBx_Enviroument.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ControlStatus;
        private System.Windows.Forms.Label label_Control;
        private System.Windows.Forms.Label label_ClientStatus;
        private System.Windows.Forms.Label label_Client;
        private System.Windows.Forms.GroupBox gBx_ModeChange;
        private System.Windows.Forms.Button btn_ModeLK;
        private System.Windows.Forms.Button btn_ModeXX;
        private System.Windows.Forms.Button btn_ModeYP;
        private System.Windows.Forms.GroupBox gBx_DeviceControl;
        private System.Windows.Forms.Button btn_WindowsOne_Off;
        private System.Windows.Forms.Button btn_WindowsOne_On;
        private System.Windows.Forms.Label label_WindowsOne;
        private System.Windows.Forms.Button btn_WindowsTwo_Off;
        private System.Windows.Forms.Button btn_WindowsTwo_On;
        private System.Windows.Forms.Label label_WindowsTwo;
        private System.Windows.Forms.Label label_LightThree;
        private System.Windows.Forms.Label label_LightTwo;
        private System.Windows.Forms.Label label_LightOne;
        private System.Windows.Forms.Button btn_TopLight_On;
        private System.Windows.Forms.Button btn_WallLight_On;
        private System.Windows.Forms.Button btn_RoundLight_On;
        private System.Windows.Forms.Button btn_RoundLight_Off;
        private System.Windows.Forms.Button btn_WallLight_Off;
        private System.Windows.Forms.Button btn_TopLight_Off;
        private System.Windows.Forms.Button btn_AllLights_On;
        private System.Windows.Forms.Button btn_AllLights_Off;
        private System.Windows.Forms.GroupBox gBx_LightsControl;
        private System.Windows.Forms.GroupBox gBx_Enviroument;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_Noise;
        private System.Windows.Forms.Label label_Light;
        private System.Windows.Forms.Label label_Temp;
        private System.Windows.Forms.Label label_Hum;
    }
}
