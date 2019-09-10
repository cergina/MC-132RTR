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
            this.DeactivateDevButton = new System.Windows.Forms.Button();
            this.ActivateDevButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.DeviceRouterComboBOx.Size = new System.Drawing.Size(296, 24);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device 1";
            // 
            // Dev1NetworkLabel
            // 
            this.Dev1NetworkLabel.AutoSize = true;
            this.Dev1NetworkLabel.Location = new System.Drawing.Point(22, 42);
            this.Dev1NetworkLabel.Name = "Dev1NetworkLabel";
            this.Dev1NetworkLabel.Size = new System.Drawing.Size(46, 17);
            this.Dev1NetworkLabel.TabIndex = 19;
            this.Dev1NetworkLabel.Text = "label1";
            // 
            // Dev1UsableCHeckBox
            // 
            this.Dev1UsableCHeckBox.AutoSize = true;
            this.Dev1UsableCHeckBox.Enabled = false;
            this.Dev1UsableCHeckBox.Location = new System.Drawing.Point(6, 61);
            this.Dev1UsableCHeckBox.Name = "Dev1UsableCHeckBox";
            this.Dev1UsableCHeckBox.Size = new System.Drawing.Size(74, 21);
            this.Dev1UsableCHeckBox.TabIndex = 17;
            this.Dev1UsableCHeckBox.Text = "Usable";
            this.Dev1UsableCHeckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1RipButton
            // 
            this.Dev1RipButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev1RipButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev1RipButton.Location = new System.Drawing.Point(226, 47);
            this.Dev1RipButton.Name = "Dev1RipButton";
            this.Dev1RipButton.Size = new System.Drawing.Size(115, 35);
            this.Dev1RipButton.TabIndex = 16;
            this.Dev1RipButton.Text = "RIP";
            this.Dev1RipButton.UseVisualStyleBackColor = false;
            this.Dev1RipButton.Click += new System.EventHandler(this.Dev1RipButton_Click);
            // 
            // Dev1RIPv2CheckBox
            // 
            this.Dev1RIPv2CheckBox.AutoSize = true;
            this.Dev1RIPv2CheckBox.Enabled = false;
            this.Dev1RIPv2CheckBox.Location = new System.Drawing.Point(154, 61);
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
            this.Dev1StatusCheckBox.Location = new System.Drawing.Point(86, 61);
            this.Dev1StatusCheckBox.Name = "Dev1StatusCheckBox";
            this.Dev1StatusCheckBox.Size = new System.Drawing.Size(70, 21);
            this.Dev1StatusCheckBox.TabIndex = 10;
            this.Dev1StatusCheckBox.Text = "Status";
            this.Dev1StatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // Dev1Label
            // 
            this.Dev1Label.AutoSize = true;
            this.Dev1Label.Location = new System.Drawing.Point(22, 18);
            this.Dev1Label.Name = "Dev1Label";
            this.Dev1Label.Size = new System.Drawing.Size(92, 17);
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
            this.groupBox2.Location = new System.Drawing.Point(365, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device 2";
            // 
            // Dev2NetworkLabel
            // 
            this.Dev2NetworkLabel.AutoSize = true;
            this.Dev2NetworkLabel.Location = new System.Drawing.Point(22, 42);
            this.Dev2NetworkLabel.Name = "Dev2NetworkLabel";
            this.Dev2NetworkLabel.Size = new System.Drawing.Size(46, 17);
            this.Dev2NetworkLabel.TabIndex = 19;
            this.Dev2NetworkLabel.Text = "label1";
            // 
            // Dev2UsableCHeckBox
            // 
            this.Dev2UsableCHeckBox.AutoSize = true;
            this.Dev2UsableCHeckBox.Enabled = false;
            this.Dev2UsableCHeckBox.Location = new System.Drawing.Point(5, 62);
            this.Dev2UsableCHeckBox.Name = "Dev2UsableCHeckBox";
            this.Dev2UsableCHeckBox.Size = new System.Drawing.Size(74, 21);
            this.Dev2UsableCHeckBox.TabIndex = 18;
            this.Dev2UsableCHeckBox.Text = "Usable";
            this.Dev2UsableCHeckBox.UseVisualStyleBackColor = true;
            // 
            // Dev2RipButton
            // 
            this.Dev2RipButton.BackColor = System.Drawing.SystemColors.Window;
            this.Dev2RipButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dev2RipButton.Location = new System.Drawing.Point(226, 48);
            this.Dev2RipButton.Name = "Dev2RipButton";
            this.Dev2RipButton.Size = new System.Drawing.Size(115, 35);
            this.Dev2RipButton.TabIndex = 15;
            this.Dev2RipButton.Text = "RIP";
            this.Dev2RipButton.UseVisualStyleBackColor = false;
            this.Dev2RipButton.Click += new System.EventHandler(this.Dev2RipButton_Click);
            // 
            // Dev2RIPv2CheckBox
            // 
            this.Dev2RIPv2CheckBox.AutoSize = true;
            this.Dev2RIPv2CheckBox.Enabled = false;
            this.Dev2RIPv2CheckBox.Location = new System.Drawing.Point(161, 62);
            this.Dev2RIPv2CheckBox.Name = "Dev2RIPv2CheckBox";
            this.Dev2RIPv2CheckBox.Size = new System.Drawing.Size(67, 21);
            this.Dev2RIPv2CheckBox.TabIndex = 9;
            this.Dev2RIPv2CheckBox.Text = "RIPv2";
            this.Dev2RIPv2CheckBox.UseVisualStyleBackColor = true;
            this.Dev2RIPv2CheckBox.CheckedChanged += new System.EventHandler(this.Dev2RIPv2CheckBox_CheckedChanged);
            // 
            // Dev2StatusCheckBox
            // 
            this.Dev2StatusCheckBox.AutoSize = true;
            this.Dev2StatusCheckBox.Enabled = false;
            this.Dev2StatusCheckBox.Location = new System.Drawing.Point(85, 62);
            this.Dev2StatusCheckBox.Name = "Dev2StatusCheckBox";
            this.Dev2StatusCheckBox.Size = new System.Drawing.Size(70, 21);
            this.Dev2StatusCheckBox.TabIndex = 8;
            this.Dev2StatusCheckBox.Text = "Status";
            this.Dev2StatusCheckBox.UseVisualStyleBackColor = true;
            this.Dev2StatusCheckBox.CheckedChanged += new System.EventHandler(this.Dev2StatusCheckBox_CheckedChanged);
            // 
            // Dev2Label
            // 
            this.Dev2Label.AutoSize = true;
            this.Dev2Label.Location = new System.Drawing.Point(22, 18);
            this.Dev2Label.Name = "Dev2Label";
            this.Dev2Label.Size = new System.Drawing.Size(92, 17);
            this.Dev2Label.TabIndex = 7;
            this.Dev2Label.Text = "Device Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MaskTextBox);
            this.groupBox3.Controls.Add(this.IPTextBox);
            this.groupBox3.Controls.Add(this.ActiveCheckBox);
            this.groupBox3.Controls.Add(this.PowerCheckBox);
            this.groupBox3.Controls.Add(this.DeactivateDevButton);
            this.groupBox3.Controls.Add(this.DeviceRouterComboBOx);
            this.groupBox3.Controls.Add(this.ActivateDevButton);
            this.groupBox3.Controls.Add(this.StartButton);
            this.groupBox3.Controls.Add(this.PowerButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 482);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 102);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Router";
            // 
            // MaskTextBox
            // 
            this.MaskTextBox.Location = new System.Drawing.Point(517, 23);
            this.MaskTextBox.Name = "MaskTextBox";
            this.MaskTextBox.Size = new System.Drawing.Size(215, 22);
            this.MaskTextBox.TabIndex = 19;
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(308, 23);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(203, 22);
            this.IPTextBox.TabIndex = 18;
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Enabled = false;
            this.ActiveCheckBox.Location = new System.Drawing.Point(308, 70);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(78, 21);
            this.ActiveCheckBox.TabIndex = 17;
            this.ActiveCheckBox.Text = "ACTIVE";
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // PowerCheckBox
            // 
            this.PowerCheckBox.AutoSize = true;
            this.PowerCheckBox.Enabled = false;
            this.PowerCheckBox.Location = new System.Drawing.Point(308, 51);
            this.PowerCheckBox.Name = "PowerCheckBox";
            this.PowerCheckBox.Size = new System.Drawing.Size(82, 21);
            this.PowerCheckBox.TabIndex = 16;
            this.PowerCheckBox.Text = "POWER";
            this.PowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // DeactivateDevButton
            // 
            this.DeactivateDevButton.BackColor = System.Drawing.SystemColors.Window;
            this.DeactivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeactivateDevButton.Location = new System.Drawing.Point(569, 51);
            this.DeactivateDevButton.Name = "DeactivateDevButton";
            this.DeactivateDevButton.Size = new System.Drawing.Size(163, 39);
            this.DeactivateDevButton.TabIndex = 15;
            this.DeactivateDevButton.Text = "DEACTIVATE";
            this.DeactivateDevButton.UseVisualStyleBackColor = false;
            this.DeactivateDevButton.Click += new System.EventHandler(this.DeactivateDevButton_Click);
            // 
            // ActivateDevButton
            // 
            this.ActivateDevButton.BackColor = System.Drawing.SystemColors.Window;
            this.ActivateDevButton.Font = new System.Drawing.Font("Perpetua Titling MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivateDevButton.Location = new System.Drawing.Point(405, 51);
            this.ActivateDevButton.Name = "ActivateDevButton";
            this.ActivateDevButton.Size = new System.Drawing.Size(163, 39);
            this.ActivateDevButton.TabIndex = 15;
            this.ActivateDevButton.Text = "ACTIVATE";
            this.ActivateDevButton.UseVisualStyleBackColor = false;
            this.ActivateDevButton.Click += new System.EventHandler(this.ActivateDevButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 596);
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
        private System.Windows.Forms.Button DeactivateDevButton;
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
    }
}

