using MC_132RTR.Model.Support;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    public class Device
    {
        public static bool Started = false;
        public static List<Device> ListOfDevices = new List<Device>();

        public ICaptureDevice ICapDev { get; private set; }
        private Network Network = null;

        private bool Disabled = true;
        private bool DisabledRIPv2 = true;

        private Device(ICaptureDevice TmpICapDev)
        {
            ICapDev = TmpICapDev;
            Network = null;
            Disabled = true;
            DisabledRIPv2 = true;
        }

        public void SetWhenRouterOff(IPAddress TmpIp, IPAddress TmpMask)
        {
            Network TmpNet = new Network(TmpIp, new Mask(TmpMask));

            if (TmpNet.IsCorrect())
                Network = TmpNet;
        }

        public void SetWhenRouterOn(IPAddress TmpIp, IPAddress TmpMask)
        {
            Network TmpNet = new Network(TmpIp, new Mask(TmpMask));

            if (TmpNet.IsCorrect())
            {
                // guarantee that correct network is about to change
                SendInfoAboutChange();
                Network = TmpNet;
            }
        }

        public static void SendInfoAboutChange()
        {
            
        }

        public void SendViaThisDevice()
        {
            if (Disabled)
                return;
        }

        public void EnableRIPv2()
        {
            if (Disabled)
                return;

            DisabledRIPv2 = false;
        }

        public void DisableRIPv2()
        {
            DisabledRIPv2 = true;
        }

        public bool TurnOn()
        {
            if (Network != null && Network.IsCorrect())
            {
                Disabled = false;
                return true;
            }
            return false;
        }

        public void TurnOff()
        {
            DisableRIPv2();
            Network = null;
            Disabled = true;
        }

        public string GetDescription(bool Shorter)
        {
            if (Shorter)
                return ICapDev.Description.Split('\n')[1].Substring(14);

            return ICapDev.Description;
        }

        // GENERAL router stuff

        public static void InitializeAllDevices()
        {
            CaptureDeviceList.Instance.Refresh();

            ListOfDevices.Clear();

            foreach(var Dev in CaptureDeviceList.Instance)
            {
                ListOfDevices.Add(new Device(Dev));
            }
        }

        public static void StopRouter()
        {
            if (!Started)
                return;

            foreach(var TmpDev in ListOfDevices)
            {
                if (!TmpDev.Disabled)
                {
                    TmpDev.TurnOff();
                }
            }

            Started = false;
        }

        public static void StartRouter()
        {
            if (Started)
                return;

            int StartedYet = 0;
            foreach(var TmpDev in ListOfDevices)
            {
                if (TmpDev.TurnOn())
                    ++StartedYet;
            }

            if (StartedYet >= 2)
                Started = true;
        }

        public static int CountActiveDevices()
        {
            int TmpActive = 0;

            foreach(var TmpDev in ListOfDevices)
            {
                if (!TmpDev.Disabled)
                    ++TmpActive;
            }

            return TmpActive;
        }
    }
}
