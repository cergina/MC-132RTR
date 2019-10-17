﻿namespace MC_132RTR
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
            this.Dev1MacLabel = new System.Windows.Forms.Label();
            this.Dev1NetworkLabel = new System.Windows.Forms.Label();
            this.Dev1UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev1RipButton = new System.Windows.Forms.Button();
            this.Dev1RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1Label = new System.Windows.Forms.Label();
            this.Dev2GB = new System.Windows.Forms.GroupBox();
            this.Dev2MacLabel = new System.Windows.Forms.Label();
            this.Dev2NetworkLabel = new System.Windows.Forms.Label();
            this.Dev2UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev2RipButton = new System.Windows.Forms.Button();
            this.Dev2RIPv2CheckBox = new System.Windows.Forms.CheckBox();
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
            this.ExtraGB = new System.Windows.Forms.GroupBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.changeButton = new System.Windows.Forms.Button();
            this.Dev1GB.SuspendLayout();
            this.Dev2GB.SuspendLayout();
            this.RouterGB.SuspendLayout();
            this.StaticRoutesGB.SuspendLayout();
            this.TimersGB.SuspendLayout();
            this.ArpGB.SuspendLayout();
            this.RoutTabGB.SuspendLayout();
            this.ExtraGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.BackColor = System.Drawing.Color.Red;
            this.PowerButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerButton.ForeColor = System.Drawing.SystemColors.Control;
            this.PowerButton.Location = new System.Drawing.Point(9, 418);
            this.PowerButton.Margin = new System.Windows.Forms.Padding(2);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(146, 84);
            this.PowerButton.TabIndex = 0;
            this.PowerButton.Text = "POWER";
            this.PowerButton.UseVisualStyleBackColor = false;
            this.PowerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Window;
            this.StartButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.DeviceRouterComboBOx.FormattingEnabled = true;
            this.DeviceRouterComboBOx.Location = new System.Drawing.Point(6, 20);
            this.DeviceRouterComboBOx.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceRouterComboBOx.Name = "DeviceRouterComboBOx";
            this.DeviceRouterComboBOx.Size = new System.Drawing.Size(189, 21);
            this.DeviceRouterComboBOx.TabIndex = 3;
            // 
            // Dev1GB
            // 
            this.Dev1GB.Controls.Add(this.Dev1MacLabel);
            this.Dev1GB.Controls.Add(this.Dev1NetworkLabel);
            this.Dev1GB.Controls.Add(this.Dev1UsableCHeckBox);
            this.Dev1GB.Controls.Add(this.Dev1RipButton);
            this.Dev1GB.Controls.Add(this.Dev1RIPv2CheckBox);
            this.Dev1GB.Controls.Add(this.Dev1Label);
            this.Dev1GB.Location = new System.Drawing.Point(9, 71);
            this.Dev1GB.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1GB.Name = "Dev1GB";
            this.Dev1GB.Padding = new System.Windows.Forms.Padding(2);
            this.Dev1GB.Size = new System.Drawing.Size(260, 94);
            this.Dev1GB.TabIndex = 6;
            this.Dev1GB.TabStop = false;
            this.Dev1GB.Text = "Device 1";
            // 
            // Dev1MacLabel
            // 
            this.Dev1MacLabel.AutoSize = true;
            this.Dev1MacLabel.Location = new System.Drawing.Point(16, 58);
            this.Dev1MacLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev1MacLabel.Name = "Dev1MacLabel";
            this.Dev1MacLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev1MacLabel.TabIndex = 20;
            this.Dev1MacLabel.Text = "label1";
            // 
            // Dev1NetworkLabel
            // 
            this.Dev1NetworkLabel.AutoSize = true;
            this.Dev1NetworkLabel.Location = new System.Drawing.Point(16, 34);
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
            this.Dev1UsableCHeckBox.Location = new System.Drawing.Point(17, 74);
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
            this.Dev1RipButton.Location = new System.Drawing.Point(170, 38);
            this.Dev1RipButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1RipButton.Name = "Dev1RipButton";
            this.Dev1RipButton.Size = new System.Drawing.Size(86, 28);
            this.Dev1RipButton.TabIndex = 16;
            this.Dev1RipButton.Text = "RIP";
            this.Dev1RipButton.UseVisualStyleBackColor = false;
            this.Dev1RipButton.Click += new System.EventHandler(this.Dev1RipButton_Click);
            // 
            // Dev1RIPv2CheckBox
            // 
            this.Dev1RIPv2CheckBox.AutoSize = true;
            this.Dev1RIPv2CheckBox.Enabled = false;
            this.Dev1RIPv2CheckBox.Location = new System.Drawing.Point(76, 74);
            this.Dev1RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev1RIPv2CheckBox.Name = "Dev1RIPv2CheckBox";
            this.Dev1RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev1RIPv2CheckBox.TabIndex = 11;
            this.Dev1RIPv2CheckBox.Text = "RIPv2";
            this.Dev1RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1Label
            // 
            this.Dev1Label.AutoSize = true;
            this.Dev1Label.Location = new System.Drawing.Point(16, 15);
            this.Dev1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev1Label.Name = "Dev1Label";
            this.Dev1Label.Size = new System.Drawing.Size(72, 13);
            this.Dev1Label.TabIndex = 7;
            this.Dev1Label.Text = "Device Name";
            // 
            // Dev2GB
            // 
            this.Dev2GB.Controls.Add(this.Dev2MacLabel);
            this.Dev2GB.Controls.Add(this.Dev2NetworkLabel);
            this.Dev2GB.Controls.Add(this.Dev2UsableCHeckBox);
            this.Dev2GB.Controls.Add(this.Dev2RipButton);
            this.Dev2GB.Controls.Add(this.Dev2RIPv2CheckBox);
            this.Dev2GB.Controls.Add(this.Dev2Label);
            this.Dev2GB.Location = new System.Drawing.Point(8, 182);
            this.Dev2GB.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2GB.Name = "Dev2GB";
            this.Dev2GB.Padding = new System.Windows.Forms.Padding(2);
            this.Dev2GB.Size = new System.Drawing.Size(260, 93);
            this.Dev2GB.TabIndex = 8;
            this.Dev2GB.TabStop = false;
            this.Dev2GB.Text = "Device 2";
            // 
            // Dev2MacLabel
            // 
            this.Dev2MacLabel.AutoSize = true;
            this.Dev2MacLabel.Location = new System.Drawing.Point(16, 54);
            this.Dev2MacLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dev2MacLabel.Name = "Dev2MacLabel";
            this.Dev2MacLabel.Size = new System.Drawing.Size(35, 13);
            this.Dev2MacLabel.TabIndex = 20;
            this.Dev2MacLabel.Text = "label1";
            // 
            // Dev2NetworkLabel
            // 
            this.Dev2NetworkLabel.AutoSize = true;
            this.Dev2NetworkLabel.Location = new System.Drawing.Point(16, 34);
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
            this.Dev2UsableCHeckBox.Location = new System.Drawing.Point(18, 73);
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
            this.Dev2RipButton.Location = new System.Drawing.Point(170, 39);
            this.Dev2RipButton.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2RipButton.Name = "Dev2RipButton";
            this.Dev2RipButton.Size = new System.Drawing.Size(86, 28);
            this.Dev2RipButton.TabIndex = 15;
            this.Dev2RipButton.Text = "RIP";
            this.Dev2RipButton.UseVisualStyleBackColor = false;
            this.Dev2RipButton.Click += new System.EventHandler(this.Dev2RipButton_Click);
            // 
            // Dev2RIPv2CheckBox
            // 
            this.Dev2RIPv2CheckBox.AutoSize = true;
            this.Dev2RIPv2CheckBox.Enabled = false;
            this.Dev2RIPv2CheckBox.Location = new System.Drawing.Point(77, 73);
            this.Dev2RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.Dev2RIPv2CheckBox.Name = "Dev2RIPv2CheckBox";
            this.Dev2RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev2RIPv2CheckBox.TabIndex = 9;
            this.Dev2RIPv2CheckBox.Text = "RIPv2";
            this.Dev2RIPv2CheckBox.UseVisualStyleBackColor = true;
            this.Dev2RIPv2CheckBox.CheckedChanged += new System.EventHandler(this.Dev2RIPv2CheckBox_CheckedChanged);
            // 
            // Dev2Label
            // 
            this.Dev2Label.AutoSize = true;
            this.Dev2Label.Location = new System.Drawing.Point(16, 15);
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
            this.RouterGB.Location = new System.Drawing.Point(159, 418);
            this.RouterGB.Margin = new System.Windows.Forms.Padding(2);
            this.RouterGB.Name = "RouterGB";
            this.RouterGB.Padding = new System.Windows.Forms.Padding(2);
            this.RouterGB.Size = new System.Drawing.Size(479, 83);
            this.RouterGB.TabIndex = 11;
            this.RouterGB.TabStop = false;
            this.RouterGB.Text = "Router";
            // 
            // MaskTextBox
            // 
            this.MaskTextBox.Location = new System.Drawing.Point(349, 21);
            this.MaskTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MaskTextBox.Name = "MaskTextBox";
            this.MaskTextBox.Size = new System.Drawing.Size(125, 20);
            this.MaskTextBox.TabIndex = 19;
            // 
            // IPTextBox
            // 
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
            this.ActivateDevButton.BackColor = System.Drawing.SystemColors.Window;
            this.ActivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateDevButton.Location = new System.Drawing.Point(343, 42);
            this.ActivateDevButton.Margin = new System.Windows.Forms.Padding(2);
            this.ActivateDevButton.Name = "ActivateDevButton";
            this.ActivateDevButton.Size = new System.Drawing.Size(130, 32);
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
            this.StaticRoutesGB.Location = new System.Drawing.Point(9, 279);
            this.StaticRoutesGB.Margin = new System.Windows.Forms.Padding(2);
            this.StaticRoutesGB.Name = "StaticRoutesGB";
            this.StaticRoutesGB.Padding = new System.Windows.Forms.Padding(2);
            this.StaticRoutesGB.Size = new System.Drawing.Size(260, 135);
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
            this.TimersGB.Size = new System.Drawing.Size(256, 64);
            this.TimersGB.TabIndex = 13;
            this.TimersGB.TabStop = false;
            this.TimersGB.Text = "Timers";
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
            this.ArpGB.Size = new System.Drawing.Size(323, 249);
            this.ArpGB.TabIndex = 14;
            this.ArpGB.TabStop = false;
            this.ArpGB.Text = "ARP";
            // 
            // ARPClearButton
            // 
            this.ARPClearButton.BackColor = System.Drawing.SystemColors.Window;
            this.ARPClearButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ARPClearButton.Location = new System.Drawing.Point(259, 225);
            this.ARPClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ARPClearButton.Name = "ARPClearButton";
            this.ARPClearButton.Size = new System.Drawing.Size(60, 20);
            this.ARPClearButton.TabIndex = 34;
            this.ARPClearButton.Text = "Clear";
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
            this.ARPListView.Size = new System.Drawing.Size(314, 200);
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
            this.RoutTabGB.Location = new System.Drawing.Point(602, 10);
            this.RoutTabGB.Name = "RoutTabGB";
            this.RoutTabGB.Size = new System.Drawing.Size(489, 249);
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
            this.RoutingListView.Size = new System.Drawing.Size(475, 200);
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
            this.RipGB.Location = new System.Drawing.Point(643, 265);
            this.RipGB.Name = "RipGB";
            this.RipGB.Size = new System.Drawing.Size(448, 236);
            this.RipGB.TabIndex = 16;
            this.RipGB.TabStop = false;
            this.RipGB.Text = "RIPv2";
            // 
            // ExtraGB
            // 
            this.ExtraGB.Controls.Add(this.TimeLabel);
            this.ExtraGB.Controls.Add(this.changeButton);
            this.ExtraGB.Location = new System.Drawing.Point(274, 268);
            this.ExtraGB.Name = "ExtraGB";
            this.ExtraGB.Size = new System.Drawing.Size(363, 151);
            this.ExtraGB.TabIndex = 17;
            this.ExtraGB.TabStop = false;
            this.ExtraGB.Text = "Extra";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(5, 20);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(35, 13);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "label4";
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(45, 18);
            this.changeButton.Margin = new System.Windows.Forms.Padding(2);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(80, 19);
            this.changeButton.TabIndex = 0;
            this.changeButton.Text = "JUST TEST";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // RouterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 510);
            this.Controls.Add(this.PowerButton);
            this.Controls.Add(this.ExtraGB);
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
            this.Text = "Form1";
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
            this.ExtraGB.ResumeLayout(false);
            this.ExtraGB.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox ExtraGB;
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
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label Dev1MacLabel;
        private System.Windows.Forms.Label Dev2MacLabel;
    }
}

