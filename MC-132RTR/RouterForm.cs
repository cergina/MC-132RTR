using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_132RTR
{
    public partial class RouterForm : Form
    {
        // //////////////////
        // Atributes
        public static RouterForm Instance { private set; get; } = null;

        public String StartState { private set; get; }
        public const String START_UP = "START UP";
        public const String STOP = "STOP";

        public String PowerState { private set; get; }
        public const String POWER_OFF = "POWER OFF";
        public const String POWER_UP = "POWER UP";

        // //////////////////
        // Constructor
        public RouterForm()
        {
            InitializeComponent();
            InitializeGui();
            Instance = this;
        }

        // //////////////////
        // Init stuff
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
            EnableOrDisableElements();
            GuiTImersInit();
        }

        private void DefaultValues()
        {
            IPTextBox.Text = "10.10.10.2";
            MaskTextBox.Text = "255.255.255.0";
        }

        private void GuiTImersInit()
        {
            TimerArpTextBox.Text = "[" + Middleman.GetTimer(Middleman.ARP, 0).ToString() + "] sec";
            TimerInvalidTextBox.Text = "[" + Middleman.GetTimer(Middleman.RIPv2, Middleman.RIPv2_INVALID).ToString() + "] sec";
            TimerFlushTextBox.Text = "[" + Middleman.GetTimer(Middleman.RIPv2, Middleman.RIPv2_FLUSH).ToString() + "] sec";
            TimerHoldTextBox.Text = "[" + Middleman.GetTimer(Middleman.RIPv2, Middleman.RIPv2_HOLDDOWN).ToString() + "] sec";
            TimerPeriodicTextBox.Text = "[" + Middleman.GetTimer(Middleman.RIPv2, Middleman.RIPv2_INTERVAL).ToString() + "] sec";
        }

        private void GuiClearStatic()
        {
            StaticNoDevRadioButton.Checked = false;
            StaticDev1RadioButton.Checked = false;
            StaticDev2RadioButton.Checked = false;
            StaticIpTextBox.Clear();
            StaticNextHopTextBox.Clear();
            StaticMaskTextBox.Clear();
        }

        private void GuiClearArpTestSend()
        {
            ArpTestTextBox.Clear();
            ArpD1RadioButton.Checked = false;
            ArpD2RadioButton.Checked = false;
        }

        private void EnableOrDisableElements()
        {
            bool ValueToSet = POWER_UP.Equals(PowerState);

            TimersGB.Enabled = ValueToSet;
            Dev1GB.Enabled = ValueToSet;
            Dev2GB.Enabled = ValueToSet;
            StaticRoutesGB.Enabled = ValueToSet;
            RouterGB.Enabled = ValueToSet;
            ArpGB.Enabled = ValueToSet;
            RoutTabGB.Enabled = ValueToSet;
            ExtraGB.Enabled = ValueToSet;
            RipGB.Enabled = ValueToSet;
            DHCPManagementGB.Enabled = ValueToSet;
            DHCPOptionsGB.Enabled = ValueToSet;
        }

        // //////////////////
        // Functions often changed
        private void Method()
        {
            // ARP
            ARPListView.Items.Clear();
            Middleman.GetListViewItemsARP().ForEach(Item => ARPListView.Items.Add(Item));
            
            // Routing
            RoutingListView.Items.Clear();
            Middleman.GetListViewItemsROUTE().ForEach(Item => RoutingListView.Items.Add(Item));
            
            // RIP
            RIPListView.Items.Clear();
            Middleman.GetListViewItemsRIP().ForEach(Item => RIPListView.Items.Add(Item));

            // DHCP
            DHCPListView.Items.Clear();
            //TODO Middleman.GetListViewItemsDHCP().ForEach(Item => DHCPListView.Items.Add(Item));

            // RIP timer
            RIPinTimeLabel.Text = "RIP periodic attempt in [" + T_RIPv2.NextUpdate + "] seconds";
        }

        // //////////////////
        // Event handlers NOT DONE
        private void ArpSendButton_Click(object sender, EventArgs e)
        {
            Middleman.SendTestArp(ArpTestTextBox.Text, WhichDevArpIsSelected());
            GuiClearArpTestSend();
        }

        private void ARPClearButton_Click(object sender, EventArgs e)
        {
            Middleman.Clear(Middleman.ARP);
        }

        private void Dev1RipButton_Click(object sender, EventArgs e)
        {
            if (Dev1RIPv2CheckBox.Checked)
                Middleman.DisableRIPv2OnDevice(Device.Dev1);
            else
                Middleman.EnableRIPv2OnDevice(Device.Dev1);

            UpdateDeviceInfo();
        }

        private void Dev2RipButton_Click(object sender, EventArgs e)
        {
            if (Dev2RIPv2CheckBox.Checked)
                Middleman.DisableRIPv2OnDevice(Device.Dev2);
            else
                Middleman.EnableRIPv2OnDevice(Device.Dev2);

            UpdateDeviceInfo();
        }

        private void Dev1DHCPButton_Click(object sender, EventArgs e)
        {
            if (Dev1DHCPCheckBox.Checked)
                Middleman.DisableDHCPOnDevice(Device.Dev1);
            else
                Middleman.EnableDHCPOnDevice(Device.Dev1);

            UpdateDeviceInfo();
        }

        private void Dev2DHCPButton_Click(object sender, EventArgs e)
        {
            if (Dev2DHCPCheckBox.Checked)
                Middleman.DisableDHCPOnDevice(Device.Dev2);
            else
                Middleman.EnableDHCPOnDevice(Device.Dev2);

            UpdateDeviceInfo();
        }

        private void TimerArpButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.ARP, 0, int.Parse(TimerArpTextBox.Text));
                GuiTImersInit();
            }
            catch (Exception en) { }
        }
        private void TimerInvalidButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_INVALID, int.Parse(TimerInvalidTextBox.Text));
                GuiTImersInit();
            }
            catch (Exception en) { }
        }

        private void TimerFlushButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_FLUSH, int.Parse(TimerFlushTextBox.Text));
                GuiTImersInit();
            }
            catch (Exception en) { }
        }

        private void TimerHoldButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_HOLDDOWN, int.Parse(TimerHoldTextBox.Text));
                GuiTImersInit();
            }
            catch (Exception en) { }
        }

        private void RIPIntervalButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_INTERVAL, int.Parse(TimerPeriodicTextBox.Text));
                GuiTImersInit();
            } catch (Exception en) { }
        }

        // //////////////////
        // Event handlers FINISHED
        private void ActivateDevButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(DeviceRouterComboBOx.Text))
                return;

            Device ChosenDev = (Device)DeviceRouterComboBOx.SelectedItem;
            DeviceRouterComboBOx.SelectedItem = null;

            Middleman.TryToInitialiazeDevice(ChosenDev, IPTextBox.Text, MaskTextBox.Text);
            DefaultValues();
            // TODO temporary
            IPTextBox.Text = "11.11.11.2";
            UpdateDeviceInfo();
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            switch (PowerState)
            {
                case POWER_OFF:
                    PowerState = POWER_UP;
                    SafeInvoker(new Action(Middleman.ThreadStart));
                    break;
                case POWER_UP:
                    PowerState = POWER_OFF;
                    break;
            }

            UpdateDeviceInfo();
            PowerButton.Text = Middleman.GetPowerState();
            EnableOrDisableElements();
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

        // //////////////////
        // Small functions
        private void SafeInvoker(Delegate Meth, params object[] args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    Meth.DynamicInvoke(args);
                }));
            }
            else
            {
                Meth.DynamicInvoke(args);
            }
        }

        public void RefreshEverySecond()
        {
            while (PowerState.Equals(POWER_UP))
            {
                SafeInvoker(new Action(Method));
                Thread.Sleep(1000);
            }
        }

        public int WhichDevArpIsSelected()
        {
            if (ArpD1RadioButton.Checked)
                return 0;
            else if (ArpD2RadioButton.Checked)
                return 1;
            else
                return -1;
        }

        // ///////////////////////////////
        // Fixed usage not checked often
        public void UpdateDeviceInfo()
        {
            ActiveCheckBox.Checked = Device.RouterRunning;
            PowerCheckBox.Checked = true;

            ProcessDeviceFE(Device.Dev1, Dev1Label, Dev1NetworkLabel, Dev1MacLabel, Dev1UsableCHeckBox, Dev1RIPv2CheckBox, Dev1DHCPCheckBox);
            ProcessDeviceFE(Device.Dev2, Dev2Label, Dev2NetworkLabel, Dev2MacLabel, Dev2UsableCHeckBox, Dev2RIPv2CheckBox, Dev2DHCPCheckBox);

            if (Device.RouterRunning)
            {
                DeviceRouterComboBOx.Items.Clear();

                foreach (Device Dev in Device.ListOfDevices)
                {
                    if (Dev.IsUsable())
                        DeviceRouterComboBOx.Items.Add(Dev);
                }
            }
        }

        private void ProcessDeviceFE(String DevNO, Label DevLabel, Label NetworkLabel, Label MacLabel, CheckBox UsableCheckBox, CheckBox RIPv2CheckBox, CheckBox DHCPCheckBox)
        {
            if (String.IsNullOrEmpty(DevNO))
                return;

            DevLabel.Text = DevNO;
            Device Tmp = Device.PairDeviceWithToString(DevNO);
            NetworkLabel.Text = Tmp.IpToString();
            MacLabel.Text = Tmp.MacToString();
            UsableCheckBox.Checked = Tmp.IsUsable();
            RIPv2CheckBox.Checked = !Tmp.DEV_DisabledRIPv2;
            DHCPCheckBox.Checked = !Tmp.DEV_DisabledDHCP;
        }

        private void StaticAddButton_Click(object sender, EventArgs e)
        {
            Middleman.TryToAddStaticRoute(StaticIpTextBox.Text,
                StaticMaskTextBox.Text, StaticNextHopTextBox.Text,
                WhichNumberToUseStatic());

            GuiClearStatic();
        }

        private void StaticRemoveButton_Click(object sender, EventArgs e)
        {
            Middleman.RemoveStaticRoute(StaticIpTextBox.Text,
                StaticMaskTextBox.Text, StaticNextHopTextBox.Text,
                WhichNumberToUseStatic());

            GuiClearStatic();
        }

        // utils
        private int WhichNumberToUseStatic()
        {
            int whichNumberToUse = -1;
            if (StaticDev1RadioButton.Checked)
                whichNumberToUse = 0;

            if (StaticDev2RadioButton.Checked)
                whichNumberToUse = 1;

            return whichNumberToUse;
        }


    }
}
