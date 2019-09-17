using MC_132RTR.Model.Support;
using SharpPcap;

namespace MC_132RTR.Model.Core
{
    public static class C_Routing
    {
        public static void TurnOnListeningOnDevices()
        {
            foreach (Device Dev in Device.ListOfDevices)
            {
                if (!Dev.IsUsable())
                    continue;

                Dev.ICapDev.Open(DeviceMode.Promiscuous);
                Dev.ICapDev.OnPacketArrival += new PacketArrivalEventHandler(OnPacketArrival);
                Dev.ICapDev.StartCapture();
            }
        }

        public static void TurnOffListeningOnDevices()
        {
            foreach(Device Dev in Device.ListOfDevices)
            {
                if (Dev.DEV_Disabled)
                    continue;

                Dev.ICapDev.StopCapture();
                Dev.ICapDev.Close();
            }
        }

        internal static void OnPacketArrival(object sender, CaptureEventArgs e)
        {
            if (!Device.RouterRunning)
                return;

            Logging.Out("Daco doslo");
        }
    }
}
