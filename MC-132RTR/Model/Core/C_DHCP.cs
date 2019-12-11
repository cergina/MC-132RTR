﻿using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Support;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    class C_DHCP
    {
        public const uint NOTHING = 0;
        public const string NOTHING_S = "";
        public const uint MANUAL = 1;
        public const string MANUAL_S = "MANUAL";
        public const uint DYNAMIC = 2;
        public const string DYNAMIC_S = "DYNAMIC";
        public const uint AUTOMAT = 3;
        public const string AUTOMAT_S = "AUTOMAT";

        public const short Port_UDP_DHCP_ClientToServer = 67;
        public const short Port_UDP_DHCP_ServerToClient = 68;

        public static C_DHCP Instance = null;
        public static bool RUNNING { get; private set; } = false;
        public static string ActiveDevice_S = null;

        // DHCP settings
        public static Mask DefaultMask { get; private set; } = null;
        public static IPAddress IpStart { get; private set; } = null;
        public static IPAddress IpLast { get; private set; } = null;
        public static IPAddress IpDefGate { get; private set; } = null;
        public static uint Mode { get; private set; } = C_DHCP.NOTHING;

        private C_DHCP()
        {
        }

        public static C_DHCP GetInstance()
            => Instance ?? (Instance = new C_DHCP());

        public void SettingsChange(IPAddress IpS, IPAddress IpL, Mask SubnetMask, uint ModeToSet)
        {
            RUNNING = false;

            IpStart = IpS;
            IpLast = IpL;
            DefaultMask = SubnetMask;
            Mode = ModeToSet;

            AttemptToStartDHCP();
        }

        public void DeviceAvailable(Device Dev)
        {
            Device.GetListOfUsableDevicesExceptOf(Dev).ForEach(OD => OD.DisableDHCP());

            // TODO Maybe some activation stuff sending?
            ActiveDevice_S = Dev.Id;
        }

        // Get list that is via Dev, Make unavailable, Send info
        public void DeviceUnavailable(Device Dev)
        {
            // TODO Maybe some deactivation stuff sending?
            ActiveDevice_S = null;
        }

        /*                 HANDLER                      */
        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);

            // TODO
        }

        public string ModeAsString()
        {
            switch (Mode)
            {
                case MANUAL:
                    return MANUAL_S;
                case DYNAMIC:
                    return DYNAMIC_S;
                case AUTOMAT:
                    return AUTOMAT_S;
                case NOTHING:
                default:
                    return NOTHING_S;
            }
        }

        private void AttemptToStartDHCP()
        {
            if (IpStart == null || IpLast == null || 
                DefaultMask == null || !DefaultMask.IsCorrect())
                return;
            
            // TODO check if in one network and so one...
            Device Dev = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S);

            if (Dev.Network.IsWithinNetworkRange(IpStart) && Dev.Network.IsWithinNetworkRange(IpLast))
            {
                if (!Dev.Network.Address.Equals(IpStart) &&
                        !Dev.Network.Address.Equals(IpLast))
                {
                    IpDefGate = Dev.Network.Address;

                    RUNNING = true;
                    return;
                }
            }
        }

        public bool OkToAssignIp(IPAddress IpToAssign)
        {
            Device Dev = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S);

            if (!Dev.Network.IsWithinNetworkRange(IpToAssign))
                return false;

            return true;
        }
    }
}
