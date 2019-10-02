using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
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
        private DateTime previousTime = DateTime.Now;
        private readonly SynchronizationContext synchronizationContext;

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
            synchronizationContext = SynchronizationContext.Current;
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
        }
        private void DefaultValues()
        {
            IPTextBox.Text = "192.168.1.1";
            MaskTextBox.Text = "255.255.255.0";
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
        }

        // //////////////////
        // Functions often changed
        private void Method()
        {
            // ARP
            ARPListView.Items.Clear();
            //Logging.Out("Method");
            foreach (ListViewItem Item in Middleman.GetListViewItemsARP())
            {
                Logging.Out("Adding ARP");
                ARPListView.Items.Add(Item);
            }

            // Routing
            RoutingListView.Items.Clear();

            foreach (ListViewItem Item in Middleman.GetListViewItemsROUTE())
            {
               RoutingListView.Items.Add(Item);
            }

            // RIP
            //RIPList
            //ARPListView.Clear();

            //foreach (ListViewItem Item in Middleman.GetListViewItemsRIP())
            //{
            //   //Rip ListView.Items.Add(Item);
            //}
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

        }

        private void Dev2RipButton_Click(object sender, EventArgs e)
        {

        }
        private void TimerArpButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.ARP, 0, int.Parse(TimerArpTextBox.Text));
            }
            catch (Exception en) { }
        }
        private void TimerInvalidButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_INVALID, int.Parse(TimerInvalidTextBox.Text));
                // change in button
            }
            catch (Exception en) { }
        }
        private void TimerFlushButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_FLUSH, int.Parse(TimerFlushTextBox.Text));
                // change in button
            }
            catch (Exception en) { }
        }
        private void TimerHoldButton_Click(object sender, EventArgs e)
        {
            try
            {
                Middleman.SetTimer(Middleman.RIPv2, Middleman.RIPv2_HOLDDOWN, int.Parse(TimerHoldTextBox.Text));
                // change in button
            }
            catch (Exception en) { }
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
                //Logging.Out("RefreshEverySecond() while()");
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

            if (!String.IsNullOrEmpty(Device.Dev1))
            {
                Dev1Label.Text = Device.Dev1;
                Device Tmp = Device.PairDeviceWithToString(Device.Dev1);
                Dev1UsableCHeckBox.Checked = Tmp.IsUsable();
                Dev1NetworkLabel.Text = (Tmp.Network != null) ? Tmp.Network.ToString() : "null";
                Dev1MacLabel.Text = (Tmp.ICapDev != null && Tmp.ICapDev.Started) ? Tmp.ICapDev.MacAddress.ToString() : "null";
            }

            if (!String.IsNullOrEmpty(Device.Dev2))
            {
                Dev2Label.Text = Device.Dev2;
                Device Tmp = Device.PairDeviceWithToString(Device.Dev2);
                Dev2UsableCHeckBox.Checked = Tmp.IsUsable();
                Dev2NetworkLabel.Text = (Tmp.Network != null) ? Tmp.Network.ToString() : "null";
                Dev2MacLabel.Text = (Tmp.ICapDev != null && Tmp.ICapDev.Started) ? Tmp.ICapDev.MacAddress.ToString() : "null";
            }

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
        

        

        

        

        

        // ///////////////////////
        // Useless
        private void Dev2RIPv2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // wont use
        }
        private void Dev2StatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // wont use
        }
        private async void ChangeButton_Click(object sender, EventArgs e)
        {
            changeButton.Enabled = false;

            await Task.Run(() =>
            {
                int c = 0;
                while (true)
                {
                    UpdateUI(c++);
                }
            });

            changeButton.Enabled = true;
        }
        private void UpdateUI(int value)
        {
            var timeNow = DateTime.Now;

            if ((DateTime.Now - previousTime).Milliseconds <= 250) return;

            synchronizationContext.Post(new SendOrPostCallback(o =>
            {
                TimeLabel.Text = @"Ha " + (int)o;
            }), value);

            previousTime = timeNow;
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

        private void StaticAddButton_Click(object sender, EventArgs e)
        {
            int whichNumberToUse = -1;
            if (StaticDev1RadioButton.Checked)
                whichNumberToUse = 0;
            
            if (StaticDev2RadioButton.Checked)
                whichNumberToUse = 1;

            Middleman.TryToAddStaticRoute(StaticIpTextBox.Text,
                StaticMaskTextBox.Text, StaticNextHopTextBox.Text,
                whichNumberToUse);
        }

        private void StaticRemoveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
