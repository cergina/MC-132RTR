namespace MC_132RTR
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
            this.dev1Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dev2Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RipDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.RipActivateButton = new System.Windows.Forms.Button();
            this.RipDeactivateButton = new System.Windows.Forms.Button();
            this.ActivateDevButton = new System.Windows.Forms.Button();
            this.DeactivateDevButton = new System.Windows.Forms.Button();
            this.Dev2StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.Dev2RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1RIPv2CheckBox = new System.Windows.Forms.CheckBox();
            this.Dev1StatusCheckBox = new System.Windows.Forms.CheckBox();
            this.PowerCheckBox = new System.Windows.Forms.CheckBox();
            this.ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PowerButton
            // 
            this.PowerButton.BackColor = System.Drawing.SystemColors.Window;
            this.PowerButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerButton.Location = new System.Drawing.Point(6, 55);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(142, 36);
            this.PowerButton.TabIndex = 0;
            this.PowerButton.Text = "POWER";
            this.PowerButton.UseVisualStyleBackColor = false;
            this.PowerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Window;
            this.StartButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(154, 55);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(148, 36);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DeviceRouterComboBOx
            // 
            this.DeviceRouterComboBOx.FormattingEnabled = true;
            this.DeviceRouterComboBOx.Location = new System.Drawing.Point(6, 21);
            this.DeviceRouterComboBOx.Name = "DeviceRouterComboBOx";
            this.DeviceRouterComboBOx.Size = new System.Drawing.Size(393, 24);
            this.DeviceRouterComboBOx.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dev1RIPv2CheckBox);
            this.groupBox1.Controls.Add(this.Dev1StatusCheckBox);
            this.groupBox1.Controls.Add(this.dev1Label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 61);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device 1";
            // 
            // dev1Label
            // 
            this.dev1Label.AutoSize = true;
            this.dev1Label.Location = new System.Drawing.Point(22, 18);
            this.dev1Label.Name = "dev1Label";
            this.dev1Label.Size = new System.Drawing.Size(92, 17);
            this.dev1Label.TabIndex = 7;
            this.dev1Label.Text = "Device Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Dev2RIPv2CheckBox);
            this.groupBox2.Controls.Add(this.Dev2StatusCheckBox);
            this.groupBox2.Controls.Add(this.dev2Label);
            this.groupBox2.Location = new System.Drawing.Point(365, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 61);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device 2";
            // 
            // dev2Label
            // 
            this.dev2Label.AutoSize = true;
            this.dev2Label.Location = new System.Drawing.Point(22, 18);
            this.dev2Label.Name = "dev2Label";
            this.dev2Label.Size = new System.Drawing.Size(92, 17);
            this.dev2Label.TabIndex = 7;
            this.dev2Label.Text = "Device Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ActiveCheckBox);
            this.groupBox3.Controls.Add(this.PowerCheckBox);
            this.groupBox3.Controls.Add(this.DeactivateDevButton);
            this.groupBox3.Controls.Add(this.DeviceRouterComboBOx);
            this.groupBox3.Controls.Add(this.ActivateDevButton);
            this.groupBox3.Controls.Add(this.StartButton);
            this.groupBox3.Controls.Add(this.PowerButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 485);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 99);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Router";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RipDeactivateButton);
            this.groupBox4.Controls.Add(this.RipActivateButton);
            this.groupBox4.Controls.Add(this.RipDeviceComboBox);
            this.groupBox4.Location = new System.Drawing.Point(756, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(363, 99);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RIPv2";
            // 
            // RipDeviceComboBox
            // 
            this.RipDeviceComboBox.FormattingEnabled = true;
            this.RipDeviceComboBox.Location = new System.Drawing.Point(6, 21);
            this.RipDeviceComboBox.Name = "RipDeviceComboBox";
            this.RipDeviceComboBox.Size = new System.Drawing.Size(351, 24);
            this.RipDeviceComboBox.TabIndex = 0;
            // 
            // RipActivateButton
            // 
            this.RipActivateButton.BackColor = System.Drawing.SystemColors.Window;
            this.RipActivateButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RipActivateButton.Location = new System.Drawing.Point(6, 51);
            this.RipActivateButton.Name = "RipActivateButton";
            this.RipActivateButton.Size = new System.Drawing.Size(155, 39);
            this.RipActivateButton.TabIndex = 13;
            this.RipActivateButton.Text = "ACTIVATE";
            this.RipActivateButton.UseVisualStyleBackColor = false;
            this.RipActivateButton.Click += new System.EventHandler(this.RipActivateButton_Click);
            // 
            // RipDeactivateButton
            // 
            this.RipDeactivateButton.BackColor = System.Drawing.SystemColors.Window;
            this.RipDeactivateButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RipDeactivateButton.Location = new System.Drawing.Point(194, 51);
            this.RipDeactivateButton.Name = "RipDeactivateButton";
            this.RipDeactivateButton.Size = new System.Drawing.Size(163, 39);
            this.RipDeactivateButton.TabIndex = 14;
            this.RipDeactivateButton.Text = "DEACTIVATE";
            this.RipDeactivateButton.UseVisualStyleBackColor = false;
            this.RipDeactivateButton.Click += new System.EventHandler(this.RipDeactivateButton_Click);
            // 
            // ActivateDevButton
            // 
            this.ActivateDevButton.BackColor = System.Drawing.SystemColors.Window;
            this.ActivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateDevButton.Location = new System.Drawing.Point(405, 11);
            this.ActivateDevButton.Name = "ActivateDevButton";
            this.ActivateDevButton.Size = new System.Drawing.Size(163, 39);
            this.ActivateDevButton.TabIndex = 15;
            this.ActivateDevButton.Text = "ACTIVATE";
            this.ActivateDevButton.UseVisualStyleBackColor = false;
            this.ActivateDevButton.Click += new System.EventHandler(this.ActivateDevButton_Click);
            // 
            // DeactivateDevButton
            // 
            this.DeactivateDevButton.BackColor = System.Drawing.SystemColors.Window;
            this.DeactivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeactivateDevButton.Location = new System.Drawing.Point(574, 11);
            this.DeactivateDevButton.Name = "DeactivateDevButton";
            this.DeactivateDevButton.Size = new System.Drawing.Size(163, 39);
            this.DeactivateDevButton.TabIndex = 15;
            this.DeactivateDevButton.Text = "DEACTIVATE";
            this.DeactivateDevButton.UseVisualStyleBackColor = false;
            this.DeactivateDevButton.Click += new System.EventHandler(this.DeactivateDevButton_Click);
            // 
            // Dev2StatusCheckBox
            // 
            this.Dev2StatusCheckBox.AutoSize = true;
            this.Dev2StatusCheckBox.Enabled = false;
            this.Dev2StatusCheckBox.Location = new System.Drawing.Point(35, 34);
            this.Dev2StatusCheckBox.Name = "Dev2StatusCheckBox";
            this.Dev2StatusCheckBox.Size = new System.Drawing.Size(70, 21);
            this.Dev2StatusCheckBox.TabIndex = 8;
            this.Dev2StatusCheckBox.Text = "Status";
            this.Dev2StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev2RIPv2CheckBox
            // 
            this.Dev2RIPv2CheckBox.AutoSize = true;
            this.Dev2RIPv2CheckBox.Enabled = false;
            this.Dev2RIPv2CheckBox.Location = new System.Drawing.Point(175, 34);
            this.Dev2RIPv2CheckBox.Name = "Dev2RIPv2CheckBox";
            this.Dev2RIPv2CheckBox.Size = new System.Drawing.Size(67, 21);
            this.Dev2RIPv2CheckBox.TabIndex = 9;
            this.Dev2RIPv2CheckBox.Text = "RIPv2";
            this.Dev2RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1RIPv2CheckBox
            // 
            this.Dev1RIPv2CheckBox.AutoSize = true;
            this.Dev1RIPv2CheckBox.Enabled = false;
            this.Dev1RIPv2CheckBox.Location = new System.Drawing.Point(176, 34);
            this.Dev1RIPv2CheckBox.Name = "Dev1RIPv2CheckBox";
            this.Dev1RIPv2CheckBox.Size = new System.Drawing.Size(67, 21);
            this.Dev1RIPv2CheckBox.TabIndex = 11;
            this.Dev1RIPv2CheckBox.Text = "RIPv2";
            this.Dev1RIPv2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1StatusCheckBox
            // 
            this.Dev1StatusCheckBox.AutoSize = true;
            this.Dev1StatusCheckBox.Enabled = false;
            this.Dev1StatusCheckBox.Location = new System.Drawing.Point(36, 34);
            this.Dev1StatusCheckBox.Name = "Dev1StatusCheckBox";
            this.Dev1StatusCheckBox.Size = new System.Drawing.Size(70, 21);
            this.Dev1StatusCheckBox.TabIndex = 10;
            this.Dev1StatusCheckBox.Text = "Status";
            this.Dev1StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // PowerCheckBox
            // 
            this.PowerCheckBox.AutoSize = true;
            this.PowerCheckBox.Enabled = false;
            this.PowerCheckBox.Location = new System.Drawing.Point(328, 51);
            this.PowerCheckBox.Name = "PowerCheckBox";
            this.PowerCheckBox.Size = new System.Drawing.Size(82, 21);
            this.PowerCheckBox.TabIndex = 16;
            this.PowerCheckBox.Text = "POWER";
            this.PowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Enabled = false;
            this.ActiveCheckBox.Location = new System.Drawing.Point(328, 70);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(78, 21);
            this.ActiveCheckBox.TabIndex = 17;
            this.ActiveCheckBox.Text = "ACTIVE";
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 596);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PowerButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ComboBox DeviceRouterComboBOx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label dev1Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label dev2Label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button DeactivateDevButton;
        private System.Windows.Forms.Button ActivateDevButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button RipDeactivateButton;
        private System.Windows.Forms.Button RipActivateButton;
        private System.Windows.Forms.ComboBox RipDeviceComboBox;
        private System.Windows.Forms.CheckBox Dev1RIPv2CheckBox;
        private System.Windows.Forms.CheckBox Dev1StatusCheckBox;
        private System.Windows.Forms.CheckBox Dev2RIPv2CheckBox;
        private System.Windows.Forms.CheckBox Dev2StatusCheckBox;
        private System.Windows.Forms.CheckBox ActiveCheckBox;
        private System.Windows.Forms.CheckBox PowerCheckBox;
    }
}

