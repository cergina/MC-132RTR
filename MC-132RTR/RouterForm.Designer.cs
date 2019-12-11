namespace MC_132RTR
{
    partial class RouterForm
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
            this.PowerButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.DeviceRouterComboBOx = new System.Windows.Forms.ComboBox();
            this.Dev1GB = new System.Windows.Forms.GroupBox();
            this.Dev1DHCPCheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1DHCPButton = new System.Windows.Forms.Button();
            this.Dev1RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1MacLabel = new System.Windows.Forms.Label();
            this.Dev1NetworkLabel = new System.Windows.Forms.Label();
            this.Dev1UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev1RipButton = new System.Windows.Forms.Button();
            this.Dev1Label = new System.Windows.Forms.Label();
            this.Dev2GB = new System.Windows.Forms.GroupBox();
            this.Dev2DHCPCheckBox = new System.Windows.Forms.CheckBox();
            this.Dev2DHCPButton = new System.Windows.Forms.Button();
            this.Dev2RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev2MacLabel = new System.Windows.Forms.Label();
            this.Dev2NetworkLabel = new System.Windows.Forms.Label();
            this.Dev2UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev2RipButton = new System.Windows.Forms.Button();
            this.Dev2Label = new System.Windows.Forms.Label();
            this.RouterGB = new System.Windows.Forms.GroupBox();
            this.MaskTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PowerCheckBox = new System.Windows.Forms.CheckBox();
            this.ActivateDevButton = new System.Windows.Forms.Button();
            this.StaticRoutesGB = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StaticDev2RadioButton = new System.Windows.Forms.RadioButton();
            this.StaticDev1RadioButton = new System.Windows.Forms.RadioButton();
            this.StaticNoDevRadioButton = new System.Windows.Forms.RadioButton();
            this.StaticRemoveButton = new System.Windows.Forms.Button();
            this.StaticAddButton = new System.Windows.Forms.Button();
            this.StaticNextHopTextBox = new System.Windows.Forms.TextBox();
            this.StaticMaskTextBox = new System.Windows.Forms.TextBox();
            this.StaticIpTextBox = new System.Windows.Forms.TextBox();
            this.TimersGB = new System.Windows.Forms.GroupBox();
            this.RIPIntervalButton = new System.Windows.Forms.Button();
            this.TimerPeriodicTextBox = new System.Windows.Forms.TextBox();
            this.RIPinTimeLabel = new System.Windows.Forms.Label();
            this.TimerHoldTextBox = new System.Windows.Forms.TextBox();
            this.TimerFlushTextBox = new System.Windows.Forms.TextBox();
            this.TimerHoldButton = new System.Windows.Forms.Button();
            this.TimerFlushButton = new System.Windows.Forms.Button();
            this.TimerInvalidButton = new System.Windows.Forms.Button();
            this.TimerArpButton = new System.Windows.Forms.Button();
            this.TimerInvalidTextBox = new System.Windows.Forms.TextBox();
            this.TimerArpTextBox = new System.Windows.Forms.TextBox();
            this.ArpGB = new System.Windows.Forms.GroupBox();
            this.ARPClearButton = new System.Windows.Forms.Button();
            this.ARPListView = new System.Windows.Forms.ListView();
            this.ArpIpColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpMacColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpDevColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpTTLColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpSendButton = new System.Windows.Forms.Button();
            this.ArpTestTextBox = new System.Windows.Forms.TextBox();
            this.ArpD2RadioButton = new System.Windows.Forms.RadioButton();
            this.ArpD1RadioButton = new System.Windows.Forms.RadioButton();
            this.RoutTabGB = new System.Windows.Forms.GroupBox();
            this.RoutingListView = new System.Windows.Forms.ListView();
            this.NetworkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdminDistanceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DeviceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextHopColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RipGB = new System.Windows.Forms.GroupBox();
            this.RIPListView = new System.Windows.Forms.ListView();
            this.RIPNetworkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPNextHopColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPMetricsColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPDeviceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPInvalidColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPHolddownColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIPFlushColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtraGB = new System.Windows.Forms.GroupBox();
            this.DHCPListView = new System.Windows.Forms.ListView();
            this.DHCPIpColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPMaskColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPDefGatColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPMacColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPTypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DHCPOptionsGB = new System.Windows.Forms.GroupBox();
            this.DHCPInfoLabel = new System.Windows.Forms.Label();
            this.DHCPSaveButton = new System.Windows.Forms.Button();
            this.DHCPIpEndTextBox = new System.Windows.Forms.TextBox();
            this.DHCPIpStartTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DHCPTimerButton = new System.Windows.Forms.Button();
            this.DHCPTimerTextBox = new System.Windows.Forms.TextBox();
            this.DHCPAutoRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.DHCPMaskTextBox = new System.Windows.Forms.TextBox();
            this.DHCPDynRadioButton = new System.Windows.Forms.RadioButton();
            this.DHCPManagementGB = new System.Windows.Forms.GroupBox();
            this.DHCPAddButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.DHCPMacTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DHCPDefGateTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DHCPIpTextBox = new System.Windows.Forms.TextBox();
            this.CommentTextBox = new System.Windows.Forms.Label();
            this.Dev1GB.SuspendLayout();
            this.Dev2GB.SuspendLayout();
            this.RouterGB.SuspendLayout();
            this.StaticRoutesGB.SuspendLayout();
            this.TimersGB.SuspendLayout();
            this.ArpGB.SuspendLayout();
            this.RoutTabGB.SuspendLayout();
            this.RipGB.SuspendLayout();
            this.ExtraGB.SuspendLayout();
            this.DHCPOptionsGB.SuspendLayout();
            this.DHCPManagementGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.BackColor = System.Drawing.Color.Red;
            this.PowerButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PowerButton.Location = new System.Drawing.Point(4, 636);
            this.PowerButton.Margin = new System.Windows.Forms.Padding(2);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(99, 83);
            this.PowerButton.TabIndex = 0;
            this.PowerButton.Text = "POWER";
            this.PowerButton.UseVisualStyleBackColor = false;
            this.PowerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Green;
            this.StartButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StartButton.Location = new System.Drawing.Point(6, 45);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(259, 29);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DeviceRouterComboBOx
            // 
            this.DeviceRouterComboBOx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DeviceRouterComboBOx.FormattingEnabled = true;
            this.DeviceRouterComboBOx.Location = new System.Drawing.Point(6, 20);
            this.DeviceRouterComboBOx.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRouterComboBOx.Name = "DeviceRouterComboBOx";
            this.DeviceRouterComboBOx.Size = new System.Drawing.Size(189, 21);
            this.DeviceRouterComboBOx.TabIndex = 3;
            // 
            // Dev1GB
            // 
            this.Dev1GB.Controls.Add(this.Dev1DHCPCheckBox);
            this.Dev1GB.Controls.Add(this.Dev1DHCPButton);
            this.Dev1GB.Controls.Add(this.Dev1RIPv2CheckBox);
            this.Dev1GB.Controls.Add(this.Dev1MacLabel);
            this.Dev1GB.Controls.Add(this.Dev1NetworkLabel);
            this.Dev1GB.Controls.Add(this.Dev1UsableCHeckBox);
            this.Dev1GB.Controls.Add(this.Dev1RipButton);
            this.Dev1GB.Controls.Add(this.Dev1Label);
            this.Dev1GB.Location = new System.Drawing.Point(5, 103);
            this.Dev1GB.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1GB.Name = "Dev1GB";
            this.Dev1GB.Padding = new System.Windows.Forms.Padding(2);
            this.Dev1GB.Size = new System.Drawing.Size(260, 125);
            this.Dev1GB.TabIndex = 6;
            this.Dev1GB.TabStop = false;
            this.Dev1GB.Text = "Device 1";
            // 
            // Dev1DHCPCheckBox
            // 
            this.Dev1DHCPCheckBox.AutoSize = true;
            this.Dev1DHCPCheckBox.Enabled = false;
            this.Dev1DHCPCheckBox.Location = new System.Drawing.Point(10, 83);
            this.Dev1DHCPCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1DHCPCheckBox.Name = "Dev1DHCPCheckBox";
            this.Dev1DHCPCheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev1DHCPCheckBox.TabIndex = 22;
            this.Dev1DHCPCheckBox.Text = "DHCP";
            this.Dev1DHCPCheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1DHCPButton
            // 
            this.Dev1DHCPButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev1DHCPButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev1DHCPButton.Location = new System.Drawing.Point(79, 93);
            this.Dev1DHCPButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1DHCPButton.Name = "Dev1DHCPButton";
            this.Dev1DHCPButton.Size = new System.Drawing.Size(86, 28);
            this.Dev1DHCPButton.TabIndex = 21;
            this.Dev1DHCPButton.Text = "DHCP";
            this.Dev1DHCPButton.UseVisualStyleBackColor = false;
            this.Dev1DHCPButton.Click += new System.EventHandler(this.Dev1DHCPButton_Click);
            // 
            // Dev1RIPv2CheckBox
            // 
            this.Dev1RIPv2CheckBox.AutoSize = true;
            this.Dev1RIPv2CheckBox.Enabled = false;
            this.Dev1RIPv2CheckBox.Location = new System.Drawing.Point(10, 104);
            this.Dev1RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1RIPv2CheckBox.Name = "Dev1RIPv2CheckBox";
            this.Dev1RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev1RIPv2CheckBox.TabIndex = 11;
            this.Dev1RIPv2CheckBox.Text = "RIPv2";
            this.Dev1RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1MacLabel
            // 
            this.Dev1MacLabel.AutoSize = true;
            this.Dev1MacLabel.Location = new System.Drawing.Point(12, 47);
            this.Dev1MacLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev1MacLabel.Name = "Dev1MacLabel";
            this.Dev1MacLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev1MacLabel.TabIndex = 20;
            this.Dev1MacLabel.Text = "label1";
            // 
            // Dev1NetworkLabel
            // 
            this.Dev1NetworkLabel.AutoSize = true;
            this.Dev1NetworkLabel.Location = new System.Drawing.Point(12, 34);
            this.Dev1NetworkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev1NetworkLabel.Name = "Dev1NetworkLabel";
            this.Dev1NetworkLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev1NetworkLabel.TabIndex = 19;
            this.Dev1NetworkLabel.Text = "label1";
            // 
            // Dev1UsableCHeckBox
            // 
            this.Dev1UsableCHeckBox.AutoSize = true;
            this.Dev1UsableCHeckBox.Enabled = false;
            this.Dev1UsableCHeckBox.Location = new System.Drawing.Point(10, 62);
            this.Dev1UsableCHeckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1UsableCHeckBox.Name = "Dev1UsableCHeckBox";
            this.Dev1UsableCHeckBox.Size = new System.Drawing.Size(59, 17);
            this.Dev1UsableCHeckBox.TabIndex = 17;
            this.Dev1UsableCHeckBox.Text = "Usable";
            this.Dev1UsableCHeckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1RipButton
            // 
            this.Dev1RipButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev1RipButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev1RipButton.Location = new System.Drawing.Point(169, 93);
            this.Dev1RipButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1RipButton.Name = "Dev1RipButton";
            this.Dev1RipButton.Size = new System.Drawing.Size(86, 28);
            this.Dev1RipButton.TabIndex = 16;
            this.Dev1RipButton.Text = "RIP";
            this.Dev1RipButton.UseVisualStyleBackColor = false;
            this.Dev1RipButton.Click += new System.EventHandler(this.Dev1RipButton_Click);
            // 
            // Dev1Label
            // 
            this.Dev1Label.AutoSize = true;
            this.Dev1Label.Location = new System.Drawing.Point(12, 15);
            this.Dev1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev1Label.Name = "Dev1Label";
            this.Dev1Label.Size = new System.Drawing.Size(72, 13);
            this.Dev1Label.TabIndex = 7;
            this.Dev1Label.Text = "Device Name";
            // 
            // Dev2GB
            // 
            this.Dev2GB.Controls.Add(this.Dev2DHCPCheckBox);
            this.Dev2GB.Controls.Add(this.Dev2DHCPButton);
            this.Dev2GB.Controls.Add(this.Dev2RIPv2CheckBox);
            this.Dev2GB.Controls.Add(this.Dev2MacLabel);
            this.Dev2GB.Controls.Add(this.Dev2NetworkLabel);
            this.Dev2GB.Controls.Add(this.Dev2UsableCHeckBox);
            this.Dev2GB.Controls.Add(this.Dev2RipButton);
            this.Dev2GB.Controls.Add(this.Dev2Label);
            this.Dev2GB.Location = new System.Drawing.Point(4, 232);
            this.Dev2GB.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2GB.Name = "Dev2GB";
            this.Dev2GB.Padding = new System.Windows.Forms.Padding(2);
            this.Dev2GB.Size = new System.Drawing.Size(260, 129);
            this.Dev2GB.TabIndex = 8;
            this.Dev2GB.TabStop = false;
            this.Dev2GB.Text = "Device 2";
            // 
            // Dev2DHCPCheckBox
            // 
            this.Dev2DHCPCheckBox.AutoSize = true;
            this.Dev2DHCPCheckBox.Enabled = false;
            this.Dev2DHCPCheckBox.Location = new System.Drawing.Point(11, 87);
            this.Dev2DHCPCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2DHCPCheckBox.Name = "Dev2DHCPCheckBox";
            this.Dev2DHCPCheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev2DHCPCheckBox.TabIndex = 22;
            this.Dev2DHCPCheckBox.Text = "DHCP";
            this.Dev2DHCPCheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev2DHCPButton
            // 
            this.Dev2DHCPButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev2DHCPButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev2DHCPButton.Location = new System.Drawing.Point(80, 97);
            this.Dev2DHCPButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2DHCPButton.Name = "Dev2DHCPButton";
            this.Dev2DHCPButton.Size = new System.Drawing.Size(86, 28);
            this.Dev2DHCPButton.TabIndex = 21;
            this.Dev2DHCPButton.Text = "DHCP";
            this.Dev2DHCPButton.UseVisualStyleBackColor = false;
            this.Dev2DHCPButton.Click += new System.EventHandler(this.Dev2DHCPButton_Click);
            // 
            // Dev2RIPv2CheckBox
            // 
            this.Dev2RIPv2CheckBox.AutoSize = true;
            this.Dev2RIPv2CheckBox.Enabled = false;
            this.Dev2RIPv2CheckBox.Location = new System.Drawing.Point(11, 108);
            this.Dev2RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2RIPv2CheckBox.Name = "Dev2RIPv2CheckBox";
            this.Dev2RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev2RIPv2CheckBox.TabIndex = 9;
            this.Dev2RIPv2CheckBox.Text = "RIPv2";
            this.Dev2RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev2MacLabel
            // 
            this.Dev2MacLabel.AutoSize = true;
            this.Dev2MacLabel.Location = new System.Drawing.Point(13, 51);
            this.Dev2MacLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev2MacLabel.Name = "Dev2MacLabel";
            this.Dev2MacLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev2MacLabel.TabIndex = 20;
            this.Dev2MacLabel.Text = "label1";
            // 
            // Dev2NetworkLabel
            // 
            this.Dev2NetworkLabel.AutoSize = true;
            this.Dev2NetworkLabel.Location = new System.Drawing.Point(13, 36);
            this.Dev2NetworkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev2NetworkLabel.Name = "Dev2NetworkLabel";
            this.Dev2NetworkLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev2NetworkLabel.TabIndex = 19;
            this.Dev2NetworkLabel.Text = "label1";
            // 
            // Dev2UsableCHeckBox
            // 
            this.Dev2UsableCHeckBox.AutoSize = true;
            this.Dev2UsableCHeckBox.Enabled = false;
            this.Dev2UsableCHeckBox.Location = new System.Drawing.Point(11, 66);
            this.Dev2UsableCHeckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2UsableCHeckBox.Name = "Dev2UsableCHeckBox";
            this.Dev2UsableCHeckBox.Size = new System.Drawing.Size(59, 17);
            this.Dev2UsableCHeckBox.TabIndex = 18;
            this.Dev2UsableCHeckBox.Text = "Usable";
            this.Dev2UsableCHeckBox.UseVisualStyleBackColor = true;
            // 
            // Dev2RipButton
            // 
            this.Dev2RipButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev2RipButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev2RipButton.Location = new System.Drawing.Point(170, 97);
            this.Dev2RipButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2RipButton.Name = "Dev2RipButton";
            this.Dev2RipButton.Size = new System.Drawing.Size(86, 28);
            this.Dev2RipButton.TabIndex = 15;
            this.Dev2RipButton.Text = "RIP";
            this.Dev2RipButton.UseVisualStyleBackColor = false;
            this.Dev2RipButton.Click += new System.EventHandler(this.Dev2RipButton_Click);
            // 
            // Dev2Label
            // 
            this.Dev2Label.AutoSize = true;
            this.Dev2Label.Location = new System.Drawing.Point(13, 15);
            this.Dev2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev2Label.Name = "Dev2Label";
            this.Dev2Label.Size = new System.Drawing.Size(72, 13);
            this.Dev2Label.TabIndex = 7;
            this.Dev2Label.Text = "Device Name";
            // 
            // RouterGB
            // 
            this.RouterGB.Controls.Add(this.MaskTextBox);
            this.RouterGB.Controls.Add(this.IPTextBox);
            this.RouterGB.Controls.Add(this.ActiveCheckBox);
            this.RouterGB.Controls.Add(this.PowerCheckBox);
            this.RouterGB.Controls.Add(this.DeviceRouterComboBOx);
            this.RouterGB.Controls.Add(this.ActivateDevButton);
            this.RouterGB.Controls.Add(this.StartButton);
            this.RouterGB.Location = new System.Drawing.Point(107, 636);
            this.RouterGB.Margin = new System.Windows.Forms.Padding(2);
            this.RouterGB.Name = "RouterGB";
            this.RouterGB.Padding = new System.Windows.Forms.Padding(2);
            this.RouterGB.Size = new System.Drawing.Size(484, 83);
            this.RouterGB.TabIndex = 11;
            this.RouterGB.TabStop = false;
            this.RouterGB.Text = "Router";
            // 
            // MaskTextBox
            // 
            this.MaskTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MaskTextBox.Location = new System.Drawing.Point(349, 21);
            this.MaskTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MaskTextBox.Name = "MaskTextBox";
            this.MaskTextBox.Size = new System.Drawing.Size(129, 20);
            this.MaskTextBox.TabIndex = 19;
            // 
            // IPTextBox
            // 
            this.IPTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.IPTextBox.Location = new System.Drawing.Point(199, 21);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(147, 20);
            this.IPTextBox.TabIndex = 18;
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Enabled = false;
            this.ActiveCheckBox.Location = new System.Drawing.Point(269, 61);
            this.ActiveCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(64, 17);
            this.ActiveCheckBox.TabIndex = 17;
            this.ActiveCheckBox.Text = "ACTIVE";
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // PowerCheckBox
            // 
            this.PowerCheckBox.AutoSize = true;
            this.PowerCheckBox.Enabled = false;
            this.PowerCheckBox.Location = new System.Drawing.Point(269, 45);
            this.PowerCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.PowerCheckBox.Name = "PowerCheckBox";
            this.PowerCheckBox.Size = new System.Drawing.Size(67, 17);
            this.PowerCheckBox.TabIndex = 16;
            this.PowerCheckBox.Text = "POWER";
            this.PowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // ActivateDevButton
            // 
            this.ActivateDevButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ActivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateDevButton.Location = new System.Drawing.Point(349, 42);
            this.ActivateDevButton.Margin = new System.Windows.Forms.Padding(2);
            this.ActivateDevButton.Name = "ActivateDevButton";
            this.ActivateDevButton.Size = new System.Drawing.Size(129, 32);
            this.ActivateDevButton.TabIndex = 15;
            this.ActivateDevButton.Text = "ACTIVATE";
            this.ActivateDevButton.UseVisualStyleBackColor = false;
            this.ActivateDevButton.Click += new System.EventHandler(this.ActivateDevButton_Click);
            // 
            // StaticRoutesGB
            // 
            this.StaticRoutesGB.Controls.Add(this.label3);
            this.StaticRoutesGB.Controls.Add(this.label2);
            this.StaticRoutesGB.Controls.Add(this.label1);
            this.StaticRoutesGB.Controls.Add(this.StaticDev2RadioButton);
            this.StaticRoutesGB.Controls.Add(this.StaticDev1RadioButton);
            this.StaticRoutesGB.Controls.Add(this.StaticNoDevRadioButton);
            this.StaticRoutesGB.Controls.Add(this.StaticRemoveButton);
            this.StaticRoutesGB.Controls.Add(this.StaticAddButton);
            this.StaticRoutesGB.Controls.Add(this.StaticNextHopTextBox);
            this.StaticRoutesGB.Controls.Add(this.StaticMaskTextBox);
            this.StaticRoutesGB.Controls.Add(this.StaticIpTextBox);
            this.StaticRoutesGB.Location = new System.Drawing.Point(4, 365);
            this.StaticRoutesGB.Margin = new System.Windows.Forms.Padding(2);
            this.StaticRoutesGB.Name = "StaticRoutesGB";
            this.StaticRoutesGB.Padding = new System.Windows.Forms.Padding(2);
            this.StaticRoutesGB.Size = new System.Drawing.Size(260, 140);
            this.StaticRoutesGB.TabIndex = 12;
            this.StaticRoutesGB.TabStop = false;
            this.StaticRoutesGB.Text = "Static Routes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Next Hop (+ ?)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mask (+, -)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP Address (+, -)";
            // 
            // StaticDev2RadioButton
            // 
            this.StaticDev2RadioButton.AutoSize = true;
            this.StaticDev2RadioButton.Location = new System.Drawing.Point(3, 51);
            this.StaticDev2RadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticDev2RadioButton.Name = "StaticDev2RadioButton";
            this.StaticDev2RadioButton.Size = new System.Drawing.Size(80, 17);
            this.StaticDev2RadioButton.TabIndex = 24;
            this.StaticDev2RadioButton.TabStop = true;
            this.StaticDev2RadioButton.Text = "DEV 2 (+ ?)";
            this.StaticDev2RadioButton.UseVisualStyleBackColor = true;
            // 
            // StaticDev1RadioButton
            // 
            this.StaticDev1RadioButton.AutoSize = true;
            this.StaticDev1RadioButton.Location = new System.Drawing.Point(3, 35);
            this.StaticDev1RadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticDev1RadioButton.Name = "StaticDev1RadioButton";
            this.StaticDev1RadioButton.Size = new System.Drawing.Size(80, 17);
            this.StaticDev1RadioButton.TabIndex = 23;
            this.StaticDev1RadioButton.TabStop = true;
            this.StaticDev1RadioButton.Text = "DEV 1 (+ ?)";
            this.StaticDev1RadioButton.UseVisualStyleBackColor = true;
            // 
            // StaticNoDevRadioButton
            // 
            this.StaticNoDevRadioButton.AutoSize = true;
            this.StaticNoDevRadioButton.Location = new System.Drawing.Point(3, 17);
            this.StaticNoDevRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticNoDevRadioButton.Name = "StaticNoDevRadioButton";
            this.StaticNoDevRadioButton.Size = new System.Drawing.Size(117, 17);
            this.StaticNoDevRadioButton.TabIndex = 22;
            this.StaticNoDevRadioButton.TabStop = true;
            this.StaticNoDevRadioButton.Text = "NO EXIT DEV (+ ?)";
            this.StaticNoDevRadioButton.UseVisualStyleBackColor = true;
            // 
            // StaticRemoveButton
            // 
            this.StaticRemoveButton.BackColor = System.Drawing.SystemColors.Window;
            this.StaticRemoveButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaticRemoveButton.Location = new System.Drawing.Point(129, 41);
            this.StaticRemoveButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticRemoveButton.Name = "StaticRemoveButton";
            this.StaticRemoveButton.Size = new System.Drawing.Size(126, 28);
            this.StaticRemoveButton.TabIndex = 21;
            this.StaticRemoveButton.Text = "-";
            this.StaticRemoveButton.UseVisualStyleBackColor = false;
            this.StaticRemoveButton.Click += new System.EventHandler(this.StaticRemoveButton_Click);
            // 
            // StaticAddButton
            // 
            this.StaticAddButton.BackColor = System.Drawing.SystemColors.Window;
            this.StaticAddButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaticAddButton.Location = new System.Drawing.Point(129, 10);
            this.StaticAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticAddButton.Name = "StaticAddButton";
            this.StaticAddButton.Size = new System.Drawing.Size(126, 28);
            this.StaticAddButton.TabIndex = 20;
            this.StaticAddButton.Text = "+";
            this.StaticAddButton.UseVisualStyleBackColor = false;
            this.StaticAddButton.Click += new System.EventHandler(this.StaticAddButton_Click);
            // 
            // StaticNextHopTextBox
            // 
            this.StaticNextHopTextBox.Location = new System.Drawing.Point(93, 114);
            this.StaticNextHopTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.StaticNextHopTextBox.Name = "StaticNextHopTextBox";
            this.StaticNextHopTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticNextHopTextBox.TabIndex = 2;
            // 
            // StaticMaskTextBox
            // 
            this.StaticMaskTextBox.Location = new System.Drawing.Point(93, 92);
            this.StaticMaskTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.StaticMaskTextBox.Name = "StaticMaskTextBox";
            this.StaticMaskTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticMaskTextBox.TabIndex = 1;
            // 
            // StaticIpTextBox
            // 
            this.StaticIpTextBox.Location = new System.Drawing.Point(93, 71);
            this.StaticIpTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.StaticIpTextBox.Name = "StaticIpTextBox";
            this.StaticIpTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticIpTextBox.TabIndex = 0;
            // 
            // TimersGB
            // 
            this.TimersGB.Controls.Add(this.RIPIntervalButton);
            this.TimersGB.Controls.Add(this.TimerPeriodicTextBox);
            this.TimersGB.Controls.Add(this.RIPinTimeLabel);
            this.TimersGB.Controls.Add(this.TimerHoldTextBox);
            this.TimersGB.Controls.Add(this.TimerFlushTextBox);
            this.TimersGB.Controls.Add(this.TimerHoldButton);
            this.TimersGB.Controls.Add(this.TimerFlushButton);
            this.TimersGB.Controls.Add(this.TimerInvalidButton);
            this.TimersGB.Controls.Add(this.TimerArpButton);
            this.TimersGB.Controls.Add(this.TimerInvalidTextBox);
            this.TimersGB.Controls.Add(this.TimerArpTextBox);
            this.TimersGB.Location = new System.Drawing.Point(9, 2);
            this.TimersGB.Margin = new System.Windows.Forms.Padding(2);
            this.TimersGB.Name = "TimersGB";
            this.TimersGB.Padding = new System.Windows.Forms.Padding(2);
            this.TimersGB.Size = new System.Drawing.Size(256, 97);
            this.TimersGB.TabIndex = 13;
            this.TimersGB.TabStop = false;
            this.TimersGB.Text = "Timers";
            // 
            // RIPIntervalButton
            // 
            this.RIPIntervalButton.BackColor = System.Drawing.SystemColors.Window;
            this.RIPIntervalButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RIPIntervalButton.Location = new System.Drawing.Point(199, 64);
            this.RIPIntervalButton.Margin = new System.Windows.Forms.Padding(2);
            this.RIPIntervalButton.Name = "RIPIntervalButton";
            this.RIPIntervalButton.Size = new System.Drawing.Size(52, 20);
            this.RIPIntervalButton.TabIndex = 36;
            this.RIPIntervalButton.Text = "PERIODIC";
            this.RIPIntervalButton.UseVisualStyleBackColor = false;
            this.RIPIntervalButton.Click += new System.EventHandler(this.RIPIntervalButton_Click);
            // 
            // TimerPeriodicTextBox
            // 
            this.TimerPeriodicTextBox.Location = new System.Drawing.Point(141, 64);
            this.TimerPeriodicTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerPeriodicTextBox.Name = "TimerPeriodicTextBox";
            this.TimerPeriodicTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerPeriodicTextBox.TabIndex = 35;
            // 
            // RIPinTimeLabel
            // 
            this.RIPinTimeLabel.AutoSize = true;
            this.RIPinTimeLabel.Location = new System.Drawing.Point(3, 71);
            this.RIPinTimeLabel.Name = "RIPinTimeLabel";
            this.RIPinTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.RIPinTimeLabel.TabIndex = 34;
            this.RIPinTimeLabel.Text = "label4";
            // 
            // TimerHoldTextBox
            // 
            this.TimerHoldTextBox.Location = new System.Drawing.Point(141, 40);
            this.TimerHoldTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerHoldTextBox.Name = "TimerHoldTextBox";
            this.TimerHoldTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerHoldTextBox.TabIndex = 33;
            // 
            // TimerFlushTextBox
            // 
            this.TimerFlushTextBox.Location = new System.Drawing.Point(141, 17);
            this.TimerFlushTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerFlushTextBox.Name = "TimerFlushTextBox";
            this.TimerFlushTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerFlushTextBox.TabIndex = 32;
            // 
            // TimerHoldButton
            // 
            this.TimerHoldButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerHoldButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerHoldButton.Location = new System.Drawing.Point(199, 40);
            this.TimerHoldButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimerHoldButton.Name = "TimerHoldButton";
            this.TimerHoldButton.Size = new System.Drawing.Size(52, 20);
            this.TimerHoldButton.TabIndex = 31;
            this.TimerHoldButton.Text = "Hold";
            this.TimerHoldButton.UseVisualStyleBackColor = false;
            this.TimerHoldButton.Click += new System.EventHandler(this.TimerHoldButton_Click);
            // 
            // TimerFlushButton
            // 
            this.TimerFlushButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerFlushButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerFlushButton.Location = new System.Drawing.Point(199, 13);
            this.TimerFlushButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimerFlushButton.Name = "TimerFlushButton";
            this.TimerFlushButton.Size = new System.Drawing.Size(52, 24);
            this.TimerFlushButton.TabIndex = 30;
            this.TimerFlushButton.Text = "Flush";
            this.TimerFlushButton.UseVisualStyleBackColor = false;
            this.TimerFlushButton.Click += new System.EventHandler(this.TimerFlushButton_Click);
            // 
            // TimerInvalidButton
            // 
            this.TimerInvalidButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerInvalidButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerInvalidButton.Location = new System.Drawing.Point(64, 40);
            this.TimerInvalidButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimerInvalidButton.Name = "TimerInvalidButton";
            this.TimerInvalidButton.Size = new System.Drawing.Size(63, 20);
            this.TimerInvalidButton.TabIndex = 29;
            this.TimerInvalidButton.Text = "Invalid";
            this.TimerInvalidButton.UseVisualStyleBackColor = false;
            this.TimerInvalidButton.Click += new System.EventHandler(this.TimerInvalidButton_Click);
            // 
            // TimerArpButton
            // 
            this.TimerArpButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerArpButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerArpButton.Location = new System.Drawing.Point(64, 15);
            this.TimerArpButton.Margin = new System.Windows.Forms.Padding(2);
            this.TimerArpButton.Name = "TimerArpButton";
            this.TimerArpButton.Size = new System.Drawing.Size(63, 22);
            this.TimerArpButton.TabIndex = 28;
            this.TimerArpButton.Text = "ARP";
            this.TimerArpButton.UseVisualStyleBackColor = false;
            this.TimerArpButton.Click += new System.EventHandler(this.TimerArpButton_Click);
            // 
            // TimerInvalidTextBox
            // 
            this.TimerInvalidTextBox.Location = new System.Drawing.Point(6, 41);
            this.TimerInvalidTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerInvalidTextBox.Name = "TimerInvalidTextBox";
            this.TimerInvalidTextBox.Size = new System.Drawing.Size(55, 20);
            this.TimerInvalidTextBox.TabIndex = 1;
            // 
            // TimerArpTextBox
            // 
            this.TimerArpTextBox.Location = new System.Drawing.Point(6, 17);
            this.TimerArpTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerArpTextBox.Name = "TimerArpTextBox";
            this.TimerArpTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerArpTextBox.TabIndex = 0;
            // 
            // ArpGB
            // 
            this.ArpGB.Controls.Add(this.ARPClearButton);
            this.ArpGB.Controls.Add(this.ARPListView);
            this.ArpGB.Controls.Add(this.ArpSendButton);
            this.ArpGB.Controls.Add(this.ArpTestTextBox);
            this.ArpGB.Controls.Add(this.ArpD2RadioButton);
            this.ArpGB.Controls.Add(this.ArpD1RadioButton);
            this.ArpGB.Location = new System.Drawing.Point(273, 10);
            this.ArpGB.Margin = new System.Windows.Forms.Padding(2);
            this.ArpGB.Name = "ArpGB";
            this.ArpGB.Padding = new System.Windows.Forms.Padding(2);
            this.ArpGB.Size = new System.Drawing.Size(365, 249);
            this.ArpGB.TabIndex = 14;
            this.ArpGB.TabStop = false;
            this.ArpGB.Text = "ARP Table";
            // 
            // ARPClearButton
            // 
            this.ARPClearButton.BackColor = System.Drawing.SystemColors.Window;
            this.ARPClearButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARPClearButton.Location = new System.Drawing.Point(259, 223);
            this.ARPClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ARPClearButton.Name = "ARPClearButton";
            this.ARPClearButton.Size = new System.Drawing.Size(100, 20);
            this.ARPClearButton.TabIndex = 34;
            this.ARPClearButton.Text = "Clear ALL";
            this.ARPClearButton.UseVisualStyleBackColor = false;
            this.ARPClearButton.Click += new System.EventHandler(this.ARPClearButton_Click);
            // 
            // ARPListView
            // 
            this.ARPListView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ARPListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArpIpColumn,
            this.ArpMacColumn,
            this.ArpDevColumn,
            this.ArpTTLColumn});
            this.ARPListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.ARPListView.HideSelection = false;
            this.ARPListView.Location = new System.Drawing.Point(5, 18);
            this.ARPListView.Name = "ARPListView";
            this.ARPListView.Size = new System.Drawing.Size(354, 200);
            this.ARPListView.TabIndex = 33;
            this.ARPListView.UseCompatibleStateImageBehavior = false;
            this.ARPListView.View = System.Windows.Forms.View.Details;
            // 
            // ArpIpColumn
            // 
            this.ArpIpColumn.Text = "Ip";
            this.ArpIpColumn.Width = 89;
            // 
            // ArpMacColumn
            // 
            this.ArpMacColumn.Text = "Mac";
            this.ArpMacColumn.Width = 125;
            // 
            // ArpDevColumn
            // 
            this.ArpDevColumn.Text = "Device";
            this.ArpDevColumn.Width = 54;
            // 
            // ArpTTLColumn
            // 
            this.ArpTTLColumn.Text = "Ttl";
            this.ArpTTLColumn.Width = 39;
            // 
            // ArpSendButton
            // 
            this.ArpSendButton.BackColor = System.Drawing.SystemColors.Window;
            this.ArpSendButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArpSendButton.Location = new System.Drawing.Point(203, 224);
            this.ArpSendButton.Margin = new System.Windows.Forms.Padding(2);
            this.ArpSendButton.Name = "ArpSendButton";
            this.ArpSendButton.Size = new System.Drawing.Size(52, 20);
            this.ArpSendButton.TabIndex = 32;
            this.ArpSendButton.Text = "Send";
            this.ArpSendButton.UseVisualStyleBackColor = false;
            this.ArpSendButton.Click += new System.EventHandler(this.ArpSendButton_Click);
            // 
            // ArpTestTextBox
            // 
            this.ArpTestTextBox.Location = new System.Drawing.Point(87, 224);
            this.ArpTestTextBox.Name = "ArpTestTextBox";
            this.ArpTestTextBox.Size = new System.Drawing.Size(111, 20);
            this.ArpTestTextBox.TabIndex = 2;
            // 
            // ArpD2RadioButton
            // 
            this.ArpD2RadioButton.AutoSize = true;
            this.ArpD2RadioButton.Location = new System.Drawing.Point(49, 224);
            this.ArpD2RadioButton.Name = "ArpD2RadioButton";
            this.ArpD2RadioButton.Size = new System.Drawing.Size(39, 17);
            this.ArpD2RadioButton.TabIndex = 1;
            this.ArpD2RadioButton.TabStop = true;
            this.ArpD2RadioButton.Text = "D2";
            this.ArpD2RadioButton.UseVisualStyleBackColor = true;
            // 
            // ArpD1RadioButton
            // 
            this.ArpD1RadioButton.AutoSize = true;
            this.ArpD1RadioButton.Location = new System.Drawing.Point(8, 224);
            this.ArpD1RadioButton.Name = "ArpD1RadioButton";
            this.ArpD1RadioButton.Size = new System.Drawing.Size(39, 17);
            this.ArpD1RadioButton.TabIndex = 0;
            this.ArpD1RadioButton.TabStop = true;
            this.ArpD1RadioButton.Text = "D1";
            this.ArpD1RadioButton.UseVisualStyleBackColor = true;
            // 
            // RoutTabGB
            // 
            this.RoutTabGB.Controls.Add(this.RoutingListView);
            this.RoutTabGB.Location = new System.Drawing.Point(643, 10);
            this.RoutTabGB.Name = "RoutTabGB";
            this.RoutTabGB.Size = new System.Drawing.Size(490, 249);
            this.RoutTabGB.TabIndex = 15;
            this.RoutTabGB.TabStop = false;
            this.RoutTabGB.Text = "Routing Table";
            // 
            // RoutingListView
            // 
            this.RoutingListView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RoutingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NetworkColumn,
            this.AdminDistanceColumn,
            this.DeviceColumn,
            this.NextHopColumn});
            this.RoutingListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.RoutingListView.HideSelection = false;
            this.RoutingListView.Location = new System.Drawing.Point(6, 18);
            this.RoutingListView.Name = "RoutingListView";
            this.RoutingListView.Size = new System.Drawing.Size(477, 222);
            this.RoutingListView.TabIndex = 35;
            this.RoutingListView.UseCompatibleStateImageBehavior = false;
            this.RoutingListView.View = System.Windows.Forms.View.Details;
            // 
            // NetworkColumn
            // 
            this.NetworkColumn.Text = "Network";
            this.NetworkColumn.Width = 165;
            // 
            // AdminDistanceColumn
            // 
            this.AdminDistanceColumn.Text = "AD";
            this.AdminDistanceColumn.Width = 54;
            // 
            // DeviceColumn
            // 
            this.DeviceColumn.Text = "Device";
            this.DeviceColumn.Width = 149;
            // 
            // NextHopColumn
            // 
            this.NextHopColumn.Text = "Next hop";
            this.NextHopColumn.Width = 102;
            // 
            // RipGB
            // 
            this.RipGB.Controls.Add(this.RIPListView);
            this.RipGB.Location = new System.Drawing.Point(643, 268);
            this.RipGB.Name = "RipGB";
            this.RipGB.Size = new System.Drawing.Size(490, 237);
            this.RipGB.TabIndex = 16;
            this.RipGB.TabStop = false;
            this.RipGB.Text = "RIPv2 Table";
            // 
            // RIPListView
            // 
            this.RIPListView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RIPListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RIPNetworkColumn,
            this.RIPNextHopColumn,
            this.RIPMetricsColumn,
            this.RIPDeviceColumn,
            this.RIPInvalidColumn,
            this.RIPHolddownColumn,
            this.RIPFlushColumn});
            this.RIPListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.RIPListView.HideSelection = false;
            this.RIPListView.Location = new System.Drawing.Point(6, 19);
            this.RIPListView.Name = "RIPListView";
            this.RIPListView.Size = new System.Drawing.Size(477, 212);
            this.RIPListView.TabIndex = 35;
            this.RIPListView.UseCompatibleStateImageBehavior = false;
            this.RIPListView.View = System.Windows.Forms.View.Details;
            // 
            // RIPNetworkColumn
            // 
            this.RIPNetworkColumn.Text = "Network";
            this.RIPNetworkColumn.Width = 93;
            // 
            // RIPNextHopColumn
            // 
            this.RIPNextHopColumn.Text = "Next hop";
            this.RIPNextHopColumn.Width = 73;
            // 
            // RIPMetricsColumn
            // 
            this.RIPMetricsColumn.Text = "Metrics";
            this.RIPMetricsColumn.Width = 46;
            // 
            // RIPDeviceColumn
            // 
            this.RIPDeviceColumn.Text = "Device";
            this.RIPDeviceColumn.Width = 82;
            // 
            // RIPInvalidColumn
            // 
            this.RIPInvalidColumn.Text = "Invalid";
            this.RIPInvalidColumn.Width = 43;
            // 
            // RIPHolddownColumn
            // 
            this.RIPHolddownColumn.Text = "Holddown";
            this.RIPHolddownColumn.Width = 64;
            // 
            // RIPFlushColumn
            // 
            this.RIPFlushColumn.Text = "Flush";
            this.RIPFlushColumn.Width = 40;
            // 
            // ExtraGB
            // 
            this.ExtraGB.Controls.Add(this.DHCPListView);
            this.ExtraGB.Location = new System.Drawing.Point(597, 511);
            this.ExtraGB.Name = "ExtraGB";
            this.ExtraGB.Size = new System.Drawing.Size(529, 221);
            this.ExtraGB.TabIndex = 17;
            this.ExtraGB.TabStop = false;
            this.ExtraGB.Text = "DHCP Table";
            // 
            // DHCPListView
            // 
            this.DHCPListView.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DHCPListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DHCPIpColumn,
            this.DHCPMaskColumn,
            this.DHCPDefGatColumn,
            this.DHCPMacColumn,
            this.DHCPTimeColumn,
            this.DHCPTypeColumn});
            this.DHCPListView.ForeColor = System.Drawing.SystemColors.InfoText;
            this.DHCPListView.HideSelection = false;
            this.DHCPListView.Location = new System.Drawing.Point(6, 19);
            this.DHCPListView.Name = "DHCPListView";
            this.DHCPListView.Size = new System.Drawing.Size(517, 196);
            this.DHCPListView.TabIndex = 36;
            this.DHCPListView.UseCompatibleStateImageBehavior = false;
            this.DHCPListView.View = System.Windows.Forms.View.Details;
            // 
            // DHCPIpColumn
            // 
            this.DHCPIpColumn.Text = "Ip";
            this.DHCPIpColumn.Width = 80;
            // 
            // DHCPMaskColumn
            // 
            this.DHCPMaskColumn.Text = "Mask";
            this.DHCPMaskColumn.Width = 97;
            // 
            // DHCPDefGatColumn
            // 
            this.DHCPDefGatColumn.Text = "Default Gateway";
            this.DHCPDefGatColumn.Width = 97;
            // 
            // DHCPMacColumn
            // 
            this.DHCPMacColumn.Text = "MAC";
            this.DHCPMacColumn.Width = 91;
            // 
            // DHCPTimeColumn
            // 
            this.DHCPTimeColumn.Text = "Time";
            // 
            // DHCPTypeColumn
            // 
            this.DHCPTypeColumn.Text = "Type";
            this.DHCPTypeColumn.Width = 83;
            // 
            // DHCPOptionsGB
            // 
            this.DHCPOptionsGB.Controls.Add(this.DHCPInfoLabel);
            this.DHCPOptionsGB.Controls.Add(this.DHCPSaveButton);
            this.DHCPOptionsGB.Controls.Add(this.DHCPIpEndTextBox);
            this.DHCPOptionsGB.Controls.Add(this.DHCPIpStartTextBox);
            this.DHCPOptionsGB.Controls.Add(this.label9);
            this.DHCPOptionsGB.Controls.Add(this.label8);
            this.DHCPOptionsGB.Controls.Add(this.DHCPTimerButton);
            this.DHCPOptionsGB.Controls.Add(this.DHCPTimerTextBox);
            this.DHCPOptionsGB.Controls.Add(this.DHCPAutoRadioButton);
            this.DHCPOptionsGB.Controls.Add(this.label5);
            this.DHCPOptionsGB.Controls.Add(this.DHCPMaskTextBox);
            this.DHCPOptionsGB.Controls.Add(this.DHCPDynRadioButton);
            this.DHCPOptionsGB.Location = new System.Drawing.Point(273, 365);
            this.DHCPOptionsGB.Name = "DHCPOptionsGB";
            this.DHCPOptionsGB.Size = new System.Drawing.Size(364, 140);
            this.DHCPOptionsGB.TabIndex = 18;
            this.DHCPOptionsGB.TabStop = false;
            this.DHCPOptionsGB.Text = "DHCP Options";
            // 
            // DHCPInfoLabel
            // 
            this.DHCPInfoLabel.AutoSize = true;
            this.DHCPInfoLabel.Location = new System.Drawing.Point(19, 117);
            this.DHCPInfoLabel.Name = "DHCPInfoLabel";
            this.DHCPInfoLabel.Size = new System.Drawing.Size(41, 13);
            this.DHCPInfoLabel.TabIndex = 42;
            this.DHCPInfoLabel.Text = "label10";
            // 
            // DHCPSaveButton
            // 
            this.DHCPSaveButton.BackColor = System.Drawing.SystemColors.Window;
            this.DHCPSaveButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DHCPSaveButton.Location = new System.Drawing.Point(182, 86);
            this.DHCPSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPSaveButton.Name = "DHCPSaveButton";
            this.DHCPSaveButton.Size = new System.Drawing.Size(154, 26);
            this.DHCPSaveButton.TabIndex = 41;
            this.DHCPSaveButton.Text = "Save settings";
            this.DHCPSaveButton.UseVisualStyleBackColor = false;
            this.DHCPSaveButton.Click += new System.EventHandler(this.DHCPSaveButton_Click);
            // 
            // DHCPIpEndTextBox
            // 
            this.DHCPIpEndTextBox.Location = new System.Drawing.Point(219, 54);
            this.DHCPIpEndTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPIpEndTextBox.Name = "DHCPIpEndTextBox";
            this.DHCPIpEndTextBox.Size = new System.Drawing.Size(117, 20);
            this.DHCPIpEndTextBox.TabIndex = 40;
            // 
            // DHCPIpStartTextBox
            // 
            this.DHCPIpStartTextBox.Location = new System.Drawing.Point(56, 54);
            this.DHCPIpStartTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPIpStartTextBox.Name = "DHCPIpStartTextBox";
            this.DHCPIpStartTextBox.Size = new System.Drawing.Size(117, 20);
            this.DHCPIpStartTextBox.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "End IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 57);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Start IP";
            // 
            // DHCPTimerButton
            // 
            this.DHCPTimerButton.BackColor = System.Drawing.SystemColors.Window;
            this.DHCPTimerButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DHCPTimerButton.Location = new System.Drawing.Point(242, 12);
            this.DHCPTimerButton.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPTimerButton.Name = "DHCPTimerButton";
            this.DHCPTimerButton.Size = new System.Drawing.Size(94, 26);
            this.DHCPTimerButton.TabIndex = 37;
            this.DHCPTimerButton.Text = "Lease Time";
            this.DHCPTimerButton.UseVisualStyleBackColor = false;
            this.DHCPTimerButton.Click += new System.EventHandler(this.DHCPTimerButton_Click);
            // 
            // DHCPTimerTextBox
            // 
            this.DHCPTimerTextBox.Location = new System.Drawing.Point(180, 15);
            this.DHCPTimerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPTimerTextBox.Name = "DHCPTimerTextBox";
            this.DHCPTimerTextBox.Size = new System.Drawing.Size(58, 20);
            this.DHCPTimerTextBox.TabIndex = 37;
            // 
            // DHCPAutoRadioButton
            // 
            this.DHCPAutoRadioButton.AutoSize = true;
            this.DHCPAutoRadioButton.Location = new System.Drawing.Point(87, 17);
            this.DHCPAutoRadioButton.Name = "DHCPAutoRadioButton";
            this.DHCPAutoRadioButton.Size = new System.Drawing.Size(88, 17);
            this.DHCPAutoRadioButton.TabIndex = 1;
            this.DHCPAutoRadioButton.Text = "AUTOMATIC";
            this.DHCPAutoRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Mask";
            // 
            // DHCPMaskTextBox
            // 
            this.DHCPMaskTextBox.Location = new System.Drawing.Point(56, 92);
            this.DHCPMaskTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPMaskTextBox.Name = "DHCPMaskTextBox";
            this.DHCPMaskTextBox.Size = new System.Drawing.Size(117, 20);
            this.DHCPMaskTextBox.TabIndex = 29;
            // 
            // DHCPDynRadioButton
            // 
            this.DHCPDynRadioButton.AutoSize = true;
            this.DHCPDynRadioButton.Checked = true;
            this.DHCPDynRadioButton.Location = new System.Drawing.Point(14, 17);
            this.DHCPDynRadioButton.Name = "DHCPDynRadioButton";
            this.DHCPDynRadioButton.Size = new System.Drawing.Size(74, 17);
            this.DHCPDynRadioButton.TabIndex = 0;
            this.DHCPDynRadioButton.TabStop = true;
            this.DHCPDynRadioButton.Text = "DYNAMIC";
            this.DHCPDynRadioButton.UseVisualStyleBackColor = true;
            // 
            // DHCPManagementGB
            // 
            this.DHCPManagementGB.Controls.Add(this.DHCPAddButton);
            this.DHCPManagementGB.Controls.Add(this.label7);
            this.DHCPManagementGB.Controls.Add(this.DHCPMacTextBox);
            this.DHCPManagementGB.Controls.Add(this.label6);
            this.DHCPManagementGB.Controls.Add(this.DHCPDefGateTextBox);
            this.DHCPManagementGB.Controls.Add(this.label4);
            this.DHCPManagementGB.Controls.Add(this.DHCPIpTextBox);
            this.DHCPManagementGB.Location = new System.Drawing.Point(4, 530);
            this.DHCPManagementGB.Name = "DHCPManagementGB";
            this.DHCPManagementGB.Size = new System.Drawing.Size(587, 82);
            this.DHCPManagementGB.TabIndex = 19;
            this.DHCPManagementGB.TabStop = false;
            this.DHCPManagementGB.Text = "DHCP Management";
            // 
            // DHCPAddButton
            // 
            this.DHCPAddButton.BackColor = System.Drawing.SystemColors.Window;
            this.DHCPAddButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DHCPAddButton.Location = new System.Drawing.Point(324, 42);
            this.DHCPAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPAddButton.Name = "DHCPAddButton";
            this.DHCPAddButton.Size = new System.Drawing.Size(257, 31);
            this.DHCPAddButton.TabIndex = 23;
            this.DHCPAddButton.Text = "ADD";
            this.DHCPAddButton.UseVisualStyleBackColor = false;
            this.DHCPAddButton.Click += new System.EventHandler(this.DHCPAddButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "For MAC";
            // 
            // DHCPMacTextBox
            // 
            this.DHCPMacTextBox.Location = new System.Drawing.Point(95, 49);
            this.DHCPMacTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPMacTextBox.Name = "DHCPMacTextBox";
            this.DHCPMacTextBox.Size = new System.Drawing.Size(164, 20);
            this.DHCPMacTextBox.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Default Gateway";
            // 
            // DHCPDefGateTextBox
            // 
            this.DHCPDefGateTextBox.Location = new System.Drawing.Point(417, 18);
            this.DHCPDefGateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPDefGateTextBox.Name = "DHCPDefGateTextBox";
            this.DHCPDefGateTextBox.Size = new System.Drawing.Size(164, 20);
            this.DHCPDefGateTextBox.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "IP Address";
            // 
            // DHCPIpTextBox
            // 
            this.DHCPIpTextBox.Location = new System.Drawing.Point(95, 18);
            this.DHCPIpTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPIpTextBox.Name = "DHCPIpTextBox";
            this.DHCPIpTextBox.Size = new System.Drawing.Size(164, 20);
            this.DHCPIpTextBox.TabIndex = 28;
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.AutoSize = true;
            this.CommentTextBox.Location = new System.Drawing.Point(331, 287);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(57, 13);
            this.CommentTextBox.TabIndex = 20;
            this.CommentTextBox.Text = "TextToPut";
            this.CommentTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RouterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 735);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.DHCPManagementGB);
            this.Controls.Add(this.ExtraGB);
            this.Controls.Add(this.DHCPOptionsGB);
            this.Controls.Add(this.PowerButton);
            this.Controls.Add(this.RipGB);
            this.Controls.Add(this.RoutTabGB);
            this.Controls.Add(this.ArpGB);
            this.Controls.Add(this.TimersGB);
            this.Controls.Add(this.StaticRoutesGB);
            this.Controls.Add(this.RouterGB);
            this.Controls.Add(this.Dev2GB);
            this.Controls.Add(this.Dev1GB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RouterForm";
            this.Text = "MC-132RTR";
            this.Dev1GB.ResumeLayout(false);
            this.Dev1GB.PerformLayout();
            this.Dev2GB.ResumeLayout(false);
            this.Dev2GB.PerformLayout();
            this.RouterGB.ResumeLayout(false);
            this.RouterGB.PerformLayout();
            this.StaticRoutesGB.ResumeLayout(false);
            this.StaticRoutesGB.PerformLayout();
            this.TimersGB.ResumeLayout(false);
            this.TimersGB.PerformLayout();
            this.ArpGB.ResumeLayout(false);
            this.ArpGB.PerformLayout();
            this.RoutTabGB.ResumeLayout(false);
            this.RipGB.ResumeLayout(false);
            this.ExtraGB.ResumeLayout(false);
            this.DHCPOptionsGB.ResumeLayout(false);
            this.DHCPOptionsGB.PerformLayout();
            this.DHCPManagementGB.ResumeLayout(false);
            this.DHCPManagementGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PowerButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox DeviceRouterComboBOx;
        private System.Windows.Forms.GroupBox Dev1GB;
        private System.Windows.Forms.Label Dev1Label;
        private System.Windows.Forms.GroupBox Dev2GB;
        private System.Windows.Forms.Label Dev2Label;
        private System.Windows.Forms.GroupBox RouterGB;
        private System.Windows.Forms.Button ActivateDevButton;
        private System.Windows.Forms.CheckBox Dev1RIPv2CheckBox;
        private System.Windows.Forms.CheckBox Dev2RIPv2CheckBox;
        private System.Windows.Forms.CheckBox ActiveCheckBox;
        private System.Windows.Forms.CheckBox PowerCheckBox;
        private System.Windows.Forms.Button Dev1RipButton;
        private System.Windows.Forms.Button Dev2RipButton;
        private System.Windows.Forms.TextBox MaskTextBox;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.CheckBox Dev1UsableCHeckBox;
        private System.Windows.Forms.CheckBox Dev2UsableCHeckBox;
        private System.Windows.Forms.Label Dev1NetworkLabel;
        private System.Windows.Forms.Label Dev2NetworkLabel;
        private System.Windows.Forms.GroupBox StaticRoutesGB;
        private System.Windows.Forms.Button StaticRemoveButton;
        private System.Windows.Forms.Button StaticAddButton;
        private System.Windows.Forms.TextBox StaticNextHopTextBox;
        private System.Windows.Forms.TextBox StaticMaskTextBox;
        private System.Windows.Forms.TextBox StaticIpTextBox;
        private System.Windows.Forms.RadioButton StaticDev2RadioButton;
        private System.Windows.Forms.RadioButton StaticDev1RadioButton;
        private System.Windows.Forms.RadioButton StaticNoDevRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox TimersGB;
        private System.Windows.Forms.TextBox TimerHoldTextBox;
        private System.Windows.Forms.TextBox TimerFlushTextBox;
        private System.Windows.Forms.Button TimerHoldButton;
        private System.Windows.Forms.Button TimerFlushButton;
        private System.Windows.Forms.Button TimerInvalidButton;
        private System.Windows.Forms.Button TimerArpButton;
        private System.Windows.Forms.TextBox TimerInvalidTextBox;
        private System.Windows.Forms.TextBox TimerArpTextBox;
        private System.Windows.Forms.GroupBox ArpGB;
        private System.Windows.Forms.GroupBox RoutTabGB;
        private System.Windows.Forms.GroupBox RipGB;
        private System.Windows.Forms.ListView ARPListView;
        private System.Windows.Forms.ColumnHeader ArpIpColumn;
        private System.Windows.Forms.ColumnHeader ArpMacColumn;
        private System.Windows.Forms.ColumnHeader ArpDevColumn;
        private System.Windows.Forms.ColumnHeader ArpTTLColumn;
        private System.Windows.Forms.Button ArpSendButton;
        private System.Windows.Forms.TextBox ArpTestTextBox;
        private System.Windows.Forms.RadioButton ArpD2RadioButton;
        private System.Windows.Forms.RadioButton ArpD1RadioButton;
        private System.Windows.Forms.Button ARPClearButton;
        private System.Windows.Forms.ListView RoutingListView;
        private System.Windows.Forms.ColumnHeader NetworkColumn;
        private System.Windows.Forms.ColumnHeader AdminDistanceColumn;
        private System.Windows.Forms.ColumnHeader DeviceColumn;
        private System.Windows.Forms.ColumnHeader NextHopColumn;
        private System.Windows.Forms.Label Dev1MacLabel;
        private System.Windows.Forms.Label Dev2MacLabel;
        private System.Windows.Forms.ListView RIPListView;
        private System.Windows.Forms.ColumnHeader RIPNetworkColumn;
        private System.Windows.Forms.ColumnHeader RIPNextHopColumn;
        private System.Windows.Forms.ColumnHeader RIPMetricsColumn;
        private System.Windows.Forms.ColumnHeader RIPDeviceColumn;
        private System.Windows.Forms.ColumnHeader RIPInvalidColumn;
        private System.Windows.Forms.ColumnHeader RIPHolddownColumn;
        private System.Windows.Forms.ColumnHeader RIPFlushColumn;
        private System.Windows.Forms.Label RIPinTimeLabel;
        private System.Windows.Forms.Button RIPIntervalButton;
        private System.Windows.Forms.TextBox TimerPeriodicTextBox;
        private System.Windows.Forms.GroupBox ExtraGB;
        private System.Windows.Forms.CheckBox Dev1DHCPCheckBox;
        private System.Windows.Forms.Button Dev1DHCPButton;
        private System.Windows.Forms.CheckBox Dev2DHCPCheckBox;
        private System.Windows.Forms.Button Dev2DHCPButton;
        private System.Windows.Forms.GroupBox DHCPOptionsGB;
        private System.Windows.Forms.GroupBox DHCPManagementGB;
        private System.Windows.Forms.ListView DHCPListView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DHCPMacTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DHCPDefGateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DHCPMaskTextBox;
        private System.Windows.Forms.TextBox DHCPIpTextBox;
        private System.Windows.Forms.Button DHCPAddButton;
        private System.Windows.Forms.RadioButton DHCPDynRadioButton;
        private System.Windows.Forms.RadioButton DHCPAutoRadioButton;
        private System.Windows.Forms.TextBox DHCPTimerTextBox;
        private System.Windows.Forms.Label CommentTextBox;
        private System.Windows.Forms.Button DHCPTimerButton;
        private System.Windows.Forms.ColumnHeader DHCPIpColumn;
        private System.Windows.Forms.ColumnHeader DHCPMaskColumn;
        private System.Windows.Forms.ColumnHeader DHCPDefGatColumn;
        private System.Windows.Forms.ColumnHeader DHCPTimeColumn;
        private System.Windows.Forms.ColumnHeader DHCPMacColumn;
        private System.Windows.Forms.ColumnHeader DHCPTypeColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DHCPIpEndTextBox;
        private System.Windows.Forms.TextBox DHCPIpStartTextBox;
        private System.Windows.Forms.Button DHCPSaveButton;
        private System.Windows.Forms.Label DHCPInfoLabel;
    }
}

