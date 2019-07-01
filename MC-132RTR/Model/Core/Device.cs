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
        public static bool Started = false;
        public static List<Device> ListOfDevices = new List<Device>();

        public ICaptureDevice ICapDev { get; private set; }
        public Network Network { get; private set; } = null;

        public bool Disabled { get; private set; } = true;
        public bool DisabledRIPv2 { get; private set; } = true;

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

        // This function's used to send directly ethernet, from upper layers or ARP
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, EthernetPacketType Type,
            byte[] Payload)
        {
            if (Disabled)
                return;

            var EthPckt = new EthernetPacket(this.ICapDev.MacAddress, MAC_Dst, Type);
            EthPckt.PayloadData = Payload;

            this.ICapDev.SendPacket(EthPckt.Bytes);
        }

        // use this to send Ip layers (like UDP, ...)
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, IPv4Packet IpPckt)
        {
            IpPckt.UpdateIPChecksum();

            SendViaThisDevice(MAC_Dst, EthernetPacketType.IpV4, IpPckt.Bytes);
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
