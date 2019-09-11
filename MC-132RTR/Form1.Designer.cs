﻿namespace MC_132RTR
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Dev1NetworkLabel = new System.Windows.Forms.Label();
            this.Dev1UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev1RipButton = new System.Windows.Forms.Button();
            this.Dev1RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Dev2NetworkLabel = new System.Windows.Forms.Label();
            this.Dev2UsableCHeckBox = new System.Windows.Forms.CheckBox();
            this.Dev2RipButton = new System.Windows.Forms.Button();
            this.Dev2RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev2StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.Dev2Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MaskTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PowerCheckBox = new System.Windows.Forms.CheckBox();
            this.ActivateDevButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.Timers = new System.Windows.Forms.GroupBox();
            this.TimerHoldTextBox = new System.Windows.Forms.TextBox();
            this.TimerFlushTextBox = new System.Windows.Forms.TextBox();
            this.TimerHoldButton = new System.Windows.Forms.Button();
            this.TimerFlushButton = new System.Windows.Forms.Button();
            this.TimerInvalidButton = new System.Windows.Forms.Button();
            this.TimerArpButton = new System.Windows.Forms.Button();
            this.TimerInvalidTextBox = new System.Windows.Forms.TextBox();
            this.TimerArpTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ArpSendButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ArpIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpMac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpDev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArpTTL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Timers.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.BackColor = System.Drawing.SystemColors.Window;
            this.PowerButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerButton.Location = new System.Drawing.Point(4, 45);
            this.PowerButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(106, 29);
            this.PowerButton.TabIndex = 0;
            this.PowerButton.Text = "POWER";
            this.PowerButton.UseVisualStyleBackColor = false;
            this.PowerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Window;
            this.StartButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(116, 45);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(111, 29);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DeviceRouterComboBOx
            // 
            this.DeviceRouterComboBOx.FormattingEnabled = true;
            this.DeviceRouterComboBOx.Location = new System.Drawing.Point(4, 17);
            this.DeviceRouterComboBOx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeviceRouterComboBOx.Name = "DeviceRouterComboBOx";
            this.DeviceRouterComboBOx.Size = new System.Drawing.Size(223, 21);
            this.DeviceRouterComboBOx.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dev1NetworkLabel);
            this.groupBox1.Controls.Add(this.Dev1UsableCHeckBox);
            this.groupBox1.Controls.Add(this.Dev1RipButton);
            this.groupBox1.Controls.Add(this.Dev1RIPv2CheckBox);
            this.groupBox1.Controls.Add(this.Dev1StatusCheckBox);
            this.groupBox1.Controls.Add(this.Dev1Label);
            this.groupBox1.Location = new System.Drawing.Point(9, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(260, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device 1";
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
            this.Dev1UsableCHeckBox.Location = new System.Drawing.Point(4, 50);
            this.Dev1UsableCHeckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Dev1RipButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Dev1RIPv2CheckBox.Location = new System.Drawing.Point(116, 50);
            this.Dev1RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dev1RIPv2CheckBox.Name = "Dev1RIPv2CheckBox";
            this.Dev1RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev1RIPv2CheckBox.TabIndex = 11;
            this.Dev1RIPv2CheckBox.Text = "RIPv2";
            this.Dev1RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1StatusCheckBox
            // 
            this.Dev1StatusCheckBox.AutoSize = true;
            this.Dev1StatusCheckBox.Enabled = false;
            this.Dev1StatusCheckBox.Location = new System.Drawing.Point(64, 50);
            this.Dev1StatusCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dev1StatusCheckBox.Name = "Dev1StatusCheckBox";
            this.Dev1StatusCheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev1StatusCheckBox.TabIndex = 10;
            this.Dev1StatusCheckBox.Text = "Status";
            this.Dev1StatusCheckBox.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dev2NetworkLabel);
            this.groupBox2.Controls.Add(this.Dev2UsableCHeckBox);
            this.groupBox2.Controls.Add(this.Dev2RipButton);
            this.groupBox2.Controls.Add(this.Dev2RIPv2CheckBox);
            this.groupBox2.Controls.Add(this.Dev2StatusCheckBox);
            this.groupBox2.Controls.Add(this.Dev2Label);
            this.groupBox2.Location = new System.Drawing.Point(9, 147);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(260, 72);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device 2";
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
            this.Dev2UsableCHeckBox.Location = new System.Drawing.Point(4, 50);
            this.Dev2UsableCHeckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Dev2RipButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Dev2RIPv2CheckBox.Location = new System.Drawing.Point(121, 50);
            this.Dev2RIPv2CheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dev2RIPv2CheckBox.Name = "Dev2RIPv2CheckBox";
            this.Dev2RIPv2CheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev2RIPv2CheckBox.TabIndex = 9;
            this.Dev2RIPv2CheckBox.Text = "RIPv2";
            this.Dev2RIPv2CheckBox.UseVisualStyleBackColor = true;
            this.Dev2RIPv2CheckBox.CheckedChanged += new System.EventHandler(this.Dev2RIPv2CheckBox_CheckedChanged);
            // 
            // Dev2StatusCheckBox
            // 
            this.Dev2StatusCheckBox.AutoSize = true;
            this.Dev2StatusCheckBox.Enabled = false;
            this.Dev2StatusCheckBox.Location = new System.Drawing.Point(64, 50);
            this.Dev2StatusCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dev2StatusCheckBox.Name = "Dev2StatusCheckBox";
            this.Dev2StatusCheckBox.Size = new System.Drawing.Size(56, 17);
            this.Dev2StatusCheckBox.TabIndex = 8;
            this.Dev2StatusCheckBox.Text = "Status";
            this.Dev2StatusCheckBox.UseVisualStyleBackColor = true;
            this.Dev2StatusCheckBox.CheckedChanged += new System.EventHandler(this.Dev2StatusCheckBox_CheckedChanged);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MaskTextBox);
            this.groupBox3.Controls.Add(this.IPTextBox);
            this.groupBox3.Controls.Add(this.ActiveCheckBox);
            this.groupBox3.Controls.Add(this.PowerCheckBox);
            this.groupBox3.Controls.Add(this.DeviceRouterComboBOx);
            this.groupBox3.Controls.Add(this.ActivateDevButton);
            this.groupBox3.Controls.Add(this.StartButton);
            this.groupBox3.Controls.Add(this.PowerButton);
            this.groupBox3.Location = new System.Drawing.Point(47, 390);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(554, 83);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Router";
            // 
            // MaskTextBox
            // 
            this.MaskTextBox.Location = new System.Drawing.Point(388, 19);
            this.MaskTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaskTextBox.Name = "MaskTextBox";
            this.MaskTextBox.Size = new System.Drawing.Size(162, 20);
            this.MaskTextBox.TabIndex = 19;
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(231, 19);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(153, 20);
            this.IPTextBox.TabIndex = 18;
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Enabled = false;
            this.ActiveCheckBox.Location = new System.Drawing.Point(231, 57);
            this.ActiveCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.PowerCheckBox.Location = new System.Drawing.Point(231, 41);
            this.PowerCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.ActivateDevButton.Location = new System.Drawing.Point(304, 41);
            this.ActivateDevButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ActivateDevButton.Name = "ActivateDevButton";
            this.ActivateDevButton.Size = new System.Drawing.Size(245, 32);
            this.ActivateDevButton.TabIndex = 15;
            this.ActivateDevButton.Text = "ACTIVATE";
            this.ActivateDevButton.UseVisualStyleBackColor = false;
            this.ActivateDevButton.Click += new System.EventHandler(this.ActivateDevButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.StaticDev2RadioButton);
            this.groupBox4.Controls.Add(this.StaticDev1RadioButton);
            this.groupBox4.Controls.Add(this.StaticNoDevRadioButton);
            this.groupBox4.Controls.Add(this.StaticRemoveButton);
            this.groupBox4.Controls.Add(this.StaticAddButton);
            this.groupBox4.Controls.Add(this.StaticNextHopTextBox);
            this.groupBox4.Controls.Add(this.StaticMaskTextBox);
            this.groupBox4.Controls.Add(this.StaticIpTextBox);
            this.groupBox4.Location = new System.Drawing.Point(9, 223);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(260, 163);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Static Routes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Next Hop (+ ?)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mask (+, -)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP Address (+, -)";
            // 
            // StaticDev2RadioButton
            // 
            this.StaticDev2RadioButton.AutoSize = true;
            this.StaticDev2RadioButton.Location = new System.Drawing.Point(4, 54);
            this.StaticDev2RadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.StaticDev1RadioButton.Location = new System.Drawing.Point(4, 38);
            this.StaticDev1RadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.StaticNoDevRadioButton.Location = new System.Drawing.Point(4, 19);
            this.StaticNoDevRadioButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.StaticRemoveButton.Location = new System.Drawing.Point(130, 43);
            this.StaticRemoveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StaticRemoveButton.Name = "StaticRemoveButton";
            this.StaticRemoveButton.Size = new System.Drawing.Size(126, 28);
            this.StaticRemoveButton.TabIndex = 21;
            this.StaticRemoveButton.Text = "-";
            this.StaticRemoveButton.UseVisualStyleBackColor = false;
            // 
            // StaticAddButton
            // 
            this.StaticAddButton.BackColor = System.Drawing.SystemColors.Window;
            this.StaticAddButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaticAddButton.Location = new System.Drawing.Point(130, 11);
            this.StaticAddButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StaticAddButton.Name = "StaticAddButton";
            this.StaticAddButton.Size = new System.Drawing.Size(126, 28);
            this.StaticAddButton.TabIndex = 20;
            this.StaticAddButton.Text = "+";
            this.StaticAddButton.UseVisualStyleBackColor = false;
            // 
            // StaticNextHopTextBox
            // 
            this.StaticNextHopTextBox.Location = new System.Drawing.Point(93, 132);
            this.StaticNextHopTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StaticNextHopTextBox.Name = "StaticNextHopTextBox";
            this.StaticNextHopTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticNextHopTextBox.TabIndex = 2;
            // 
            // StaticMaskTextBox
            // 
            this.StaticMaskTextBox.Location = new System.Drawing.Point(93, 106);
            this.StaticMaskTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StaticMaskTextBox.Name = "StaticMaskTextBox";
            this.StaticMaskTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticMaskTextBox.TabIndex = 1;
            // 
            // StaticIpTextBox
            // 
            this.StaticIpTextBox.Location = new System.Drawing.Point(93, 78);
            this.StaticIpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StaticIpTextBox.Name = "StaticIpTextBox";
            this.StaticIpTextBox.Size = new System.Drawing.Size(164, 20);
            this.StaticIpTextBox.TabIndex = 0;
            // 
            // Timers
            // 
            this.Timers.Controls.Add(this.TimerHoldTextBox);
            this.Timers.Controls.Add(this.TimerFlushTextBox);
            this.Timers.Controls.Add(this.TimerHoldButton);
            this.Timers.Controls.Add(this.TimerFlushButton);
            this.Timers.Controls.Add(this.TimerInvalidButton);
            this.Timers.Controls.Add(this.TimerArpButton);
            this.Timers.Controls.Add(this.TimerInvalidTextBox);
            this.Timers.Controls.Add(this.TimerArpTextBox);
            this.Timers.Location = new System.Drawing.Point(9, 2);
            this.Timers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Timers.Name = "Timers";
            this.Timers.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Timers.Size = new System.Drawing.Size(256, 64);
            this.Timers.TabIndex = 13;
            this.Timers.TabStop = false;
            this.Timers.Text = "Timers";
            // 
            // TimerHoldTextBox
            // 
            this.TimerHoldTextBox.Location = new System.Drawing.Point(141, 40);
            this.TimerHoldTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerHoldTextBox.Name = "TimerHoldTextBox";
            this.TimerHoldTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerHoldTextBox.TabIndex = 33;
            // 
            // TimerFlushTextBox
            // 
            this.TimerFlushTextBox.Location = new System.Drawing.Point(141, 17);
            this.TimerFlushTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerFlushTextBox.Name = "TimerFlushTextBox";
            this.TimerFlushTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerFlushTextBox.TabIndex = 32;
            // 
            // TimerHoldButton
            // 
            this.TimerHoldButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerHoldButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerHoldButton.Location = new System.Drawing.Point(199, 40);
            this.TimerHoldButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerHoldButton.Name = "TimerHoldButton";
            this.TimerHoldButton.Size = new System.Drawing.Size(52, 20);
            this.TimerHoldButton.TabIndex = 31;
            this.TimerHoldButton.Text = "Hold";
            this.TimerHoldButton.UseVisualStyleBackColor = false;
            // 
            // TimerFlushButton
            // 
            this.TimerFlushButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerFlushButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerFlushButton.Location = new System.Drawing.Point(199, 13);
            this.TimerFlushButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerFlushButton.Name = "TimerFlushButton";
            this.TimerFlushButton.Size = new System.Drawing.Size(52, 24);
            this.TimerFlushButton.TabIndex = 30;
            this.TimerFlushButton.Text = "Flush";
            this.TimerFlushButton.UseVisualStyleBackColor = false;
            // 
            // TimerInvalidButton
            // 
            this.TimerInvalidButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerInvalidButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerInvalidButton.Location = new System.Drawing.Point(64, 40);
            this.TimerInvalidButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerInvalidButton.Name = "TimerInvalidButton";
            this.TimerInvalidButton.Size = new System.Drawing.Size(63, 20);
            this.TimerInvalidButton.TabIndex = 29;
            this.TimerInvalidButton.Text = "Invalid";
            this.TimerInvalidButton.UseVisualStyleBackColor = false;
            // 
            // TimerArpButton
            // 
            this.TimerArpButton.BackColor = System.Drawing.SystemColors.Window;
            this.TimerArpButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerArpButton.Location = new System.Drawing.Point(64, 15);
            this.TimerArpButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerArpButton.Name = "TimerArpButton";
            this.TimerArpButton.Size = new System.Drawing.Size(63, 22);
            this.TimerArpButton.TabIndex = 28;
            this.TimerArpButton.Text = "ARP";
            this.TimerArpButton.UseVisualStyleBackColor = false;
            // 
            // TimerInvalidTextBox
            // 
            this.TimerInvalidTextBox.Location = new System.Drawing.Point(6, 41);
            this.TimerInvalidTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerInvalidTextBox.Name = "TimerInvalidTextBox";
            this.TimerInvalidTextBox.Size = new System.Drawing.Size(55, 20);
            this.TimerInvalidTextBox.TabIndex = 1;
            // 
            // TimerArpTextBox
            // 
            this.TimerArpTextBox.Location = new System.Drawing.Point(6, 17);
            this.TimerArpTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TimerArpTextBox.Name = "TimerArpTextBox";
            this.TimerArpTextBox.Size = new System.Drawing.Size(54, 20);
            this.TimerArpTextBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Controls.Add(this.ArpSendButton);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Location = new System.Drawing.Point(273, 10);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(263, 249);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ARP";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(541, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(509, 249);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Routing Table";
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(643, 265);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(407, 210);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RIPv2";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(274, 268);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(363, 118);
            this.groupBox8.TabIndex = 17;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Console";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(1, 227);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dev 1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(50, 227);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Dev 2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 20);
            this.textBox1.TabIndex = 2;
            // 
            // ArpSendButton
            // 
            this.ArpSendButton.BackColor = System.Drawing.SystemColors.Window;
            this.ArpSendButton.Font = new System.Drawing.Font("Perpetua Titling MT", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArpSendButton.Location = new System.Drawing.Point(211, 224);
            this.ArpSendButton.Margin = new System.Windows.Forms.Padding(2);
            this.ArpSendButton.Name = "ArpSendButton";
            this.ArpSendButton.Size = new System.Drawing.Size(52, 20);
            this.ArpSendButton.TabIndex = 32;
            this.ArpSendButton.Text = "Send";
            this.ArpSendButton.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArpIp,
            this.ArpMac,
            this.ArpDev,
            this.ArpTTL});
            this.listView1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 18);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(253, 200);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ArpIp
            // 
            this.ArpIp.Text = "IP";
            // 
            // ArpMac
            // 
            this.ArpMac.Text = "MAC";
            // 
            // ArpDev
            // 
            this.ArpDev.Text = "Device";
            // 
            // ArpTTL
            // 
            this.ArpTTL.Text = "TTL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 482);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Timers);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Timers.ResumeLayout(false);
            this.Timers.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PowerButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox DeviceRouterComboBOx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Dev1Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Dev2Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ActivateDevButton;
        private System.Windows.Forms.CheckBox Dev1RIPv2CheckBox;
        private System.Windows.Forms.CheckBox Dev1StatusCheckBox;
        private System.Windows.Forms.CheckBox Dev2RIPv2CheckBox;
        private System.Windows.Forms.CheckBox Dev2StatusCheckBox;
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
        private System.Windows.Forms.GroupBox groupBox4;
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
        private System.Windows.Forms.GroupBox Timers;
        private System.Windows.Forms.TextBox TimerHoldTextBox;
        private System.Windows.Forms.TextBox TimerFlushTextBox;
        private System.Windows.Forms.Button TimerHoldButton;
        private System.Windows.Forms.Button TimerFlushButton;
        private System.Windows.Forms.Button TimerInvalidButton;
        private System.Windows.Forms.Button TimerArpButton;
        private System.Windows.Forms.TextBox TimerInvalidTextBox;
        private System.Windows.Forms.TextBox TimerArpTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ArpIp;
        private System.Windows.Forms.ColumnHeader ArpMac;
        private System.Windows.Forms.ColumnHeader ArpDev;
        private System.Windows.Forms.ColumnHeader ArpTTL;
        private System.Windows.Forms.Button ArpSendButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

