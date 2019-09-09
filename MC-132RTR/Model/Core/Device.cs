using MC_132RTR.Model.Support;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    public class Device
    {
        public static bool RouterRunning = false;
        public static List<Device> ListOfDevices = new List<Device>();

        public ICaptureDevice ICapDev { get; private set; }
        public Network Network { get; private set; } = null;

        public bool DEV_Disabled { get; private set; } = true;
        public bool DEV_DisabledRIPv2 { get; private set; } = true;

        private Device(ICaptureDevice TmpICapDev)
        {
            ICapDev = TmpICapDev;
            Network = null;
            DEV_Disabled = true;
            DEV_DisabledRIPv2 = true;
        }

        private void SetWhenRouterOff(Network TmpNet)
        {
            Network = TmpNet;
        }

        private void SetWhenRouterOn(Network TmpNet)
        {
            // guarantee that correct network is about to change
            SendInfoAboutChange(TmpNet);
            Network = TmpNet;
        }

        public void Set(IPAddress TmpIp, IPAddress TmpMask)
        {
            Network TmpNet = new Network(TmpIp, new Mask(TmpMask));
            if (!TmpNet.IsCorrect())
                return;

            if (RouterRunning)
                SetWhenRouterOn(TmpNet);
            else
                SetWhenRouterOff(TmpNet);
        }

        public static void SendInfoAboutChange(Network NewNetwork)
        {
            if (!RouterRunning)
                return;

            throw new NotImplementedException();
        }

        // This function's used to send directly ethernet, from upper layers or ARP
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, EthernetPacketType Type,
            byte[] Payload)
        {
            if (DEV_Disabled)
                return;

            var EthPckt = new EthernetPacket(this.ICapDev.MacAddress, MAC_Dst, Type);
            EthPckt.PayloadData = Payload;

            this.ICapDev.SendPacket(EthPckt.Bytes);
        }

        // use this to send Ip layers (like UDP, ...)
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, IPv4Packet IpPckt)
        {
            if (DEV_Disabled)
                return;

            IpPckt.UpdateIPChecksum();

            SendViaThisDevice(MAC_Dst, EthernetPacketType.IpV4, IpPckt.Bytes);
        }

        public void EnableRIPv2()
        {
            if (DEV_Disabled || (!DEV_DisabledRIPv2))
                return;

            DEV_DisabledRIPv2 = false;
        }

        public void DisableRIPv2()
        {
            if (DEV_Disabled || DEV_DisabledRIPv2)
                return;

            DEV_DisabledRIPv2 = true;
        }

        public bool TurnOn()
        {
            if (DEV_Disabled)
            {
                bool ToReturn = IsUsable();
                DEV_Disabled = !ToReturn;
                return ToReturn;
            }

            return true;
        }

        public bool IsUsable()
        {
            if (Network != null && Network.IsCorrect())
            {
                return true;
            }
            return false;
        }

        public void TurnOff()
        {
            if (DEV_Disabled)
                return;

            DisableRIPv2();
            Network = null;
            DEV_Disabled = true;
        }

        public string GetDescription(bool UseShorterDescription)
        {
            if (UseShorterDescription)
            {
                Logging.OutALWAYS("1");
                Logging.OutALWAYS(ICapDev.Description);
                Logging.OutALWAYS();
                Logging.OutALWAYS(ICapDev.Description.Split('\n')[1]);
                String  Tmp = ICapDev.Description.Split('\n')[0]

                return ICapDev.Description.Split('\n')[1].Substring(14);
            }
                

            return ICapDev.Description;
        }

        // GENERAL router stuff

        public static void InitializeAllDevices()
        {
            StopRouter();
            CaptureDeviceList.Instance.Refresh();
            ListOfDevices.Clear();

            foreach(var Dev in CaptureDeviceList.Instance)
            {
                ListOfDevices.Add(new Device(Dev));
            }
        }

        public static void StopRouter()
        {
            if (!RouterRunning)
                return;

            foreach(var TmpDev in ListOfDevices)
            {
                if (!TmpDev.DEV_Disabled)
                {
                    TmpDev.TurnOff();
                }
            }

            RouterRunning = false;
        }

        public static void StartRouter()
        {
            if (RouterRunning)
                return;

            int StartedYet = 0;
            foreach(var TmpDev in ListOfDevices)
            {
                if (TmpDev.TurnOn())
                    ++StartedYet;
            }

            if (StartedYet >= 2)
                RouterRunning = true;
        }

        public static int CountActiveDevices()
        {
            int TmpActive = 0;

            foreach(var TmpDev in ListOfDevices)
            {
                if (!TmpDev.DEV_Disabled)
                    ++TmpActive;
            }

            return TmpActive;
        }

        public static int CountUsableDevices()
        {
            int TmpUsable = 0;
            foreach(var TmpDev in ListOfDevices)
            {
                if (TmpDev.IsUsable())
                    ++TmpUsable;
            }

            return TmpUsable;
        }
    }
}
