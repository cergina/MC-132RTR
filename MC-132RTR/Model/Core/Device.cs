using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
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
        public static int MinAmountOfRunningDevices = 2;

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

        public static List<Device> GetListOfUsableDevicesExceptOf(Device DevT)
            => ListOfDevices.FindAll(T_Dev => T_Dev.IsUsable() && !DevT.Equals(T_Dev));

        public static List<Device> GetListOfUsableDevices()
            => ListOfDevices.FindAll(T_Dev => T_Dev.IsUsable());

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
            TP_Routing TPR = T_Routing.GetInstance().IsSubnetInRoutes(NewProposedNet.GetNetworkGeneral());
            if (TPR == null)
            {
                // Network like this is not in table
                Network CurrentNetwork = Network;
                Network = NewProposedNet;

                if (T_Routing.GetInstance().UpdateConnected(CurrentNetwork, NewProposedNet.GetNetworkGeneral()))
                    SendInfoAboutChange(CurrentNetwork.GetNetworkGeneral(), NewProposedNet.GetNetworkGeneral());
            } else if (Network.IsInSameSubnet(NewProposedNet))
            {
                // if just IP address changed 
                Network = NewProposedNet;
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

            P_RIPv2 PR = P_RIPv2.CraftResponse_ConnectedChange(CurrentNetwork, NewProposedNet);
            if (PR != null)
                foreach (Device D in GetListOfUsableDevices())
                    if (!D.DEV_Disabled && !D.DEV_DisabledRIPv2)
                    {
                        T_RIPv2.GetInstance().ChangeConnected(CurrentNetwork, NewProposedNet);
                        P_RIPv2.Send(D, PR, C_RIPv2.IP_RIPv2, C_RIPv2.MAC_RIPv2);
                    }
        }

        // This function's used to send directly ethernet, from upper layers or ARP
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, EthernetPacketType Type,
            byte[] Payload)
        {
            if (DEV_Disabled)
                return;

            var EthPckt = new EthernetPacket(this.ICapDev.MacAddress, MAC_Dst, Type);
            EthPckt.PayloadData = Payload;

            if (Endorsment.SENDING_POSSIBLE)
                this.ICapDev.SendPacket(EthPckt.Bytes);
        }

        // use this to send Ip layers (like UDP, ...)
        public void SendViaThisDevice(PhysicalAddress MAC_Dst, IPv4Packet IpPckt)
        {
            if (DEV_Disabled)
                return;

            IpPckt.UpdateIPChecksum();
            Logging.OutALWAYS("Checksum updatetnuty ");
            SendViaThisDevice(MAC_Dst, EthernetPacketType.IpV4, IpPckt.Bytes);
        }

        public void EnableRIPv2()
        {
            if (DEV_Disabled || !DEV_DisabledRIPv2)
                return;

            DEV_DisabledRIPv2 = false;

            C_RIPv2.GetInstance().DeviceAvailable(this);
        }

        public void DisableRIPv2()
        {
            if (DEV_Disabled || DEV_DisabledRIPv2)
                return;

            C_RIPv2.GetInstance().DeviceUnavailable(this);

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
            => (Network != null && Network.IsCorrect());

        private void TurnOff()
        {
            if (DEV_Disabled)
                return;

            DisableRIPv2();
            Network = null;
            DEV_Disabled = true;
        }

        private string GetDescription(bool UseShorterDescription)
            => (UseShorterDescription) ? ICapDev.Description.Split('\'')[1] : ICapDev.Description;

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

            if (StartedYet >= MinAmountOfRunningDevices)
            {
                RouterRunning = true;
                C_Routing.TurnOnListeningOnDevices();
                Logging.OutALWAYS("Router started");
            } else
            {
                ShutDownAllDevices();
                T_Routing.GetInstance().ClearAllRoutes();
                T_RIPv2.GetInstance().ClearAllRoutes();
            }
        }

        public static int CountActiveDevices()
            => ListOfDevices.FindAll(TmpDev => !TmpDev.DEV_Disabled).Count;

        public static int CountUsableDevices()
            => ListOfDevices.FindAll(TmpDev => TmpDev.IsUsable()).Count;

        public static Device PairDeviceWithIpAddress(IPAddress Ip) 
            => ListOfDevices.Find(Dev => Dev.IsUsable() && Dev.Network.Address.Equals(Ip));

        public static Device PairDeviceWithNumber(int number)
            => (number == 0 || number == 1) ? PairDeviceWithToString(number == 0 ? Dev1 : Dev2) : null;

        public static Device PairDeviceWithMacAdress(PhysicalAddress MacAddress)
            => ListOfDevices.Find(Dev => Dev.ICapDev.Started && Dev.ICapDev.MacAddress != null && Dev.ICapDev.MacAddress.Equals(MacAddress));

        public static Device PairDeviceWithICaptureDevice(ICaptureDevice ICapDev)
            => ListOfDevices.Find(Dev => ICapDev != null && ICapDev.MacAddress != null && Dev.ICapDev.Started && ICapDev.MacAddress.Equals(Dev.ICapDev.MacAddress));

        public static Device PairDeviceWithToString(String Name)
            => ListOfDevices.Find(Dev => Dev.ToString().Equals(Name));

        public string IpToString()
            => (Network != null) ? "IP: " + Network.ToString() : "IP is null";

        public string MacToString() 
            => (ICapDev != null && ICapDev.Started) ? "MAC: " + BitConverter.ToString(ICapDev.MacAddress.GetAddressBytes()) : "MAC is null";
        
        override
        public string ToString() 
            => "[" + Id + "] " + GetDescription(true);

        public bool Equals(Device Dev)
            => (ToString().Equals(Dev.ToString()));

        public bool Equals(string desc)
            => ToString().Equals(desc);
    }
}
