﻿using MC_132RTR.Model.Packet;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    class C_DHCP
    {
        public const short MANUAL = 1;
        public const short DYNAMIC = 2;
        public const short AUTOMAT = 3;

        public const short Port_UDP_DHCP_ClientToServer = 67;
        public const short Port_UDP_DHCP_ServerToClient = 68;

        public static C_DHCP Instance = null;
        public static bool RUNNING { get; private set; } = false;

        private C_DHCP()
        {
        }

        public static C_DHCP GetInstance()
            => Instance ?? (Instance = new C_DHCP());

        public void DeviceAvailable(Device Dev)
        {
            Device.GetListOfUsableDevicesExceptOf(Dev).ForEach(OD => OD.DisableDHCP());

            // TODO Maybe some activation stuff sending?
        }

        // Get list that is via Dev, Make unavailable, Send info
        public void DeviceUnavailable(Device Dev)
        {
            // TODO Maybe some deactivation stuff sending?
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
    }
}
