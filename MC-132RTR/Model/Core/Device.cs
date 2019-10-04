using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Core
{
    public class Device
    {
        public static bool RouterRunning = false;
        public static bool FinalShutdown = false;
        public static List<Device> ListOfDevices = new List<Device>();
        public static string Dev1 = null;
        public static string Dev2 = null;

        public ICaptureDevice ICapDev { get; private set; }
        public Network Network { get; private set; } = null;
        public string Id { get; private set; } = null;

        public bool DEV_Disabled { get; private set; } = true;
        public bool DEV_DisabledRIPv2 { get; private set; } = true;

        private Device(ICaptureDevice TmpICapDev, string Id)
        {
            ICapDev = TmpICapDev;
            Network = null;
            DEV_Disabled = true;
            DEV_DisabledRIPv2 = true;
            this.Id = Id;
        }

        private void SetWhenRouterOff(Network TmpNet, string DevName)
        {
            Network = TmpNet;

            if (Dev1 == null || Dev1.Equals(DevName)) {
                Dev1 = DevName;
                return;
            }

            if (Dev2 == null || Dev2.Equals(DevName)) {
                Dev2 = DevName;
                return;
            }
        }

        private void SetWhenRouterOn(Network NewProposedNet)
        {
            if (T_Routing.GetInstance().IsSubnetInRoutes(NewProposedNet.GetNetworkGeneral()) == null)
            {
                Network CurrentNetwork = Network;
                Network = NewProposedNet;

                T_Routing.GetInstance().UpdateConnected(CurrentNetwork, NewProposedNet.GetNetworkGeneral());
                SendInfoAboutChange(CurrentNetwork.GetNetworkGeneral(), NewProposedNet.GetNetworkGeneral());
            }
        }

        public void Set(IPAddress TmpIp, IPAddress TmpMask)
        {
            Network NewProposedNet = new Network(TmpIp, new Mask(TmpMask));
            
            if (!NewProposedNet.IsCorrect())
                return;

            if (RouterRunning)
                SetWhenRouterOn(NewProposedNet);
            else
                SetWhenRouterOff(NewProposedNet, ToString());
        }

        public static void SendInfoAboutChange(Network CurrentNetwork, Network NewProposedNet)
        {
            if (!RouterRunning)
                return;

            Logging.OutALWAYS("Send info about change not implemented yet");
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

        private bool TurnOn()
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

        private void TurnOff()
        {
            if (DEV_Disabled)
                return;

            DisableRIPv2();
            Network = null;
            DEV_Disabled = true;
        }

        private string GetDescription(bool UseShorterDescription)
        {
            if (UseShorterDescription)
            {
                //return ICapDev.Description.Split('\'')[0].Substring(14);
                return ICapDev.Description.Split('\'')[1];
            }
                
            return ICapDev.Description;
        }

        // GENERAL router stuff

        public static void InitializeAllDevices()
        {
            StopRouter();
            CaptureDeviceList.Instance.Refresh();
            ListOfDevices.Clear();

            int X = 0;
            foreach(var Dev in CaptureDeviceList.Instance)
            {
                ListOfDevices.Add(new Device(Dev, "DV" + X++));
            }
        }

        public static void StopRouter()
        {
            if (!RouterRunning)
                return;

            ShutDownAllDevices();

            RouterRunning = false;
            C_Routing.TurnOffListeningOnDevices();
        }

        public static void ShutDownAllDevices()
        {
            foreach (var TmpDev in ListOfDevices)
            {
                if (!TmpDev.DEV_Disabled)
                {
                    TmpDev.TurnOff();
                }
            }
        }

        public static void StartRouter()
        {
            if (RouterRunning)
                return;

            int StartedYet = 0;
            ShutDownAllDevices();
            foreach (var TmpDev in ListOfDevices)
            {
                if (TmpDev.TurnOn())
                {
                    if (T_Routing.GetInstance().AttemtToAdd_Connected(TmpDev))
                        ++StartedYet;
                }
            }

            if (StartedYet >= 2)
            {
                RouterRunning = true;
                C_Routing.TurnOnListeningOnDevices();
                Logging.OutALWAYS("Router started");
            } else
            {
                ShutDownAllDevices();
                T_Routing.GetInstance().ClearAllRoutes();
            }
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

        public static Device PairDeviceWithIpAddress(IPAddress Ip)
        {
            if (Ip == null)
                return null;

            foreach(Device Dev in ListOfDevices)
            {
                if (!Dev.IsUsable())
                    continue;

                if (Ip.Equals(Dev.Network.Address))
                    return Dev;
            }

            return null;
        }

        public static Device PairDeviceWithNumber(int number)
        {
            if (number == 0)
                return PairDeviceWithToString(Dev1);

            if (number == 1)
                return PairDeviceWithToString(Dev2);

            return null;
        }

        public static Device PairDeviceWithMacAdress(PhysicalAddress MacAddress)
        {
            if (MacAddress == null)
                return null;

            foreach(Device Dev in ListOfDevices)
            {
                if (!Dev.ICapDev.Started)
                    continue;

                Logging.Out("MacAddress: " + MacAddress + " , ICAP: " + Dev.ICapDev.MacAddress);

                if (MacAddress.Equals(Dev.ICapDev.MacAddress))
                    return Dev;
            }

            return null;
        }

        public static Device PairDeviceWithICaptureDevice(ICaptureDevice ICapDev)
        {
            if (ICapDev == null || ICapDev.MacAddress == null)
                return null;

            foreach(Device Dev in ListOfDevices)
            {
                if (!Dev.ICapDev.Started)
                    continue;

                if (ICapDev.MacAddress.Equals(Dev.ICapDev.MacAddress))
                    return Dev;
            }

            return null;
        }

        public static Device PairDeviceWithToString(String Name)
        {
            if (String.IsNullOrEmpty(Name))
                return null;

            foreach(Device Dev in ListOfDevices)
            {
                if (Name.Equals(Dev.ToString()))
                    return Dev;
            }

            return null;
        }

        override
        public string ToString()
        {
            return "[" + Id + "] " + GetDescription(true);
        }

        public bool Equals(Device Dev)
        {
            if (ToString().Equals(Dev.ToString()))
                return true;

            return false;
        }

        public bool Equals(string desc)
        {
            if (ToString().Equals(desc))
                return true;

            return false;
        }
    }
}
