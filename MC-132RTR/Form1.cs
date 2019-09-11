using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_132RTR
{
    public partial class Form1 : Form
    {
        private String StartState;
        public const String START_UP = "START UP";
        public const String STOP = "STOP";

        private String PowerState;
        public const String POWER_OFF = "POWER OFF";
        public const String POWER_UP = "POWER UP";

        public Form1()
        {
            InitializeComponent();
            InitializeGui();
        }

        public void InitializeGui()
        {
            StartState = START_UP;
            PowerState = POWER_OFF;

            PowerButton.Text = Middleman.GetPowerState();
            StartButton.Text = Middleman.GetStartState();

            DeviceRouterComboBOx.Items.Clear();

            foreach (Device Dev in Middleman.InitializeRouter())
            {
                DeviceRouterComboBOx.Items.Add(Dev);
            }

            DefaultValues();
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            switch (PowerState)
            {
                case POWER_OFF:

                    break;
                case POWER_UP:
                    break;
            }

            UpdateDeviceInfo();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            switch (StartState)
            {
                case START_UP:
                    Middleman.TryToStartRouter();
                    break;
                case STOP:
                    Middleman.StopRouter();
                    break;
            }

            StartState = Middleman.GetStartState();
            StartButton.Text = StartState;
            UpdateDeviceInfo();
        }

        private void ActivateDevButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DeviceRouterComboBOx.Text))
                return;

            Device ChosenDev = (Device)DeviceRouterComboBOx.SelectedItem;
            DeviceRouterComboBOx.SelectedItem = null;

            Middleman.TryToInitialiazeDevice(ChosenDev, IPTextBox.Text, MaskTextBox.Text);
            DefaultValues();
            UpdateDeviceInfo();
        }

        private void DeactivateDevButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DeviceRouterComboBOx.Text))
                return;

            Device ChosenDev = (Device)DeviceRouterComboBOx.SelectedItem;
            DeviceRouterComboBOx.SelectedItem = null;

            Middleman.TryToChangeDevice(ChosenDev, IPTextBox.Text, MaskTextBox.Text);
            DefaultValues();
            UpdateDeviceInfo();
        }

        private void Dev1RipButton_Click(object sender, EventArgs e)
        {

        }

        private void Dev2RipButton_Click(object sender, EventArgs e)
        {

        }

        private void Dev2RIPv2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // wont use
        }

        private void Dev2StatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // wont use
        }

        public void UpdateDeviceInfo()
        {
            ActiveCheckBox.Checked = Device.RouterRunning;
            PowerCheckBox.Checked = true;

            if (!String.IsNullOrEmpty(Device.Dev1))
            {
                Dev1Label.Text = Device.Dev1;
                Device Tmp = Device.PairDeviceWithToString(Device.Dev1);
                Dev1UsableCHeckBox.Checked = Tmp.IsUsable();
                Dev1NetworkLabel.Text = (Tmp.Network != null) ? Tmp.Network.ToString() : "null";
            }

            if (!String.IsNullOrEmpty(Device.Dev2))
            {
                Dev2Label.Text = Device.Dev2;
                Device Tmp = Device.PairDeviceWithToString(Device.Dev2);
                Dev2UsableCHeckBox.Checked = Tmp.IsUsable();
                Dev2NetworkLabel.Text = (Tmp.Network != null) ? Tmp.Network.ToString() : "null";
            }

            if (Device.RouterRunning)
            {
                DeviceRouterComboBOx.Items.Clear();
                
                foreach(Device Dev in Device.ListOfDevices)
                {
                    if (Dev.IsUsable())
                        DeviceRouterComboBOx.Items.Add(Dev);
                }
            }
        }

        private void DefaultValues()
        {
            IPTextBox.Text = "192.168.1.1";
            MaskTextBox.Text = "255.255.255.0";
        }
    }
}
