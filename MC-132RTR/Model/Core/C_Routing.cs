using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Support;
using PacketDotNet;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;

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
            if (!Device.RouterRunning || !e.Device.Started)
                return;

            

            Device DeviceReceived = Device.PairDeviceWithICaptureDevice(e.Device);

            if (DeviceReceived == null)
                return;

            Logging.Out("Daco doslo");

            switch (IdentifyAsProtocol(e, DeviceReceived))
            {
                case Middleman.ARP:
                    // P_ARP handler
                    C_ARP.GetInstance().Handle(e, DeviceReceived);
                    break;
                case Middleman.RIPv2:
                    // P_RIPv2 handler
                    C_RIPv2.GetInstance().Handle(e, DeviceReceived);
                    break;
                case Middleman.RIB:
                    // Do some routing
                    C_Routing.GeneralHandle(e, DeviceReceived);
                    break;
                default:
                    Logging.Out("Blbost dosla");
                    break;
            }
        }

        public static int IdentifyAsProtocol(CaptureEventArgs e, Device DeviceReceived)
        {
            //
            PacketDotNet.Packet Layer0 = Packet.Extractor.GetPacket(e.Packet);
            if (Layer0 == null) {
                Logging.Out("Layer0 == null");
                return Middleman.NOTHING;
            }

            //
            EthernetPacket EthPckt = Packet.Extractor.GetEthPacket(Layer0);
            if (EthPckt == null) {
                Logging.Out("EthPckt == null");
                return Middleman.NOTHING;
            }

            // this will avoid working with self generated stuff
            if (Device.PairDeviceWithMacAdress(EthPckt.SourceHwAddress) != null)
            {
                Logging.Out("PairDev with Mac != null");
                return Middleman.NOTHING;
            }

            //
            ARPPacket ArpPckt = Packet.Extractor.GetArpPacket(EthPckt);
            if (ArpPckt != null) {
                Logging.Out("ArpPckt != null: ret ARP");
                return Middleman.ARP;
            }

            //
            IPv4Packet Ipv4 = Packet.Extractor.GetIPv4Packet(EthPckt);
            if (Ipv4 == null || !Ipv4.ValidChecksum) {
                Logging.Out("Ipv4 == null || !Ipv4.ValidChecksum");
                return Middleman.NOTHING;
            }

            // Check if it is RIP, hence it has to be UDP first
            UdpPacket Udp = Packet.Extractor.GetUdpPacket(Ipv4);
            if (Udp != null)
            {
                Logging.Out("Udp != null");
                if (Udp.SourcePort == 520 || Udp.DestinationPort == 520)
                {
                    Logging.Out("520");
                    // Unicast RIP for router
                    // TODO not supported yet, will be tested?

                    // Multicast RIP case
                    if ((IPAddress.Parse("224.0.0.9").Equals(Ipv4.DestinationAddress))
                        &&
                        (PhysicalAddress.Parse("01-00-5E-00-00-09").Equals(EthPckt.DestinationHwAddress))
                        )
                        return Middleman.RIPv2;
                }
            }

            // The dest IP cant be any used on the router
            if (Device.PairDeviceWithIpAddress(Ipv4.DestinationAddress) != null)
            {
                Logging.Out("Dev.ParWithIp(IPv4.DestHW) != null,ret NOTH");
                return Middleman.NOTHING;
            }
            
            // Throw away stuff not intended for MAC
            if (Device.PairDeviceWithMacAdress(EthPckt.DestinationHwAddress) == null)
            {
                Logging.Out("MAC is not inteded for this PC, ret NOTH");
                return Middleman.NOTHING;
            }


            Logging.Out("return RIB");
            return Middleman.RIB;
        }

        public static void GeneralHandle(CaptureEventArgs e, Device ReceivalDev)
        {
            Logging.Out("Dosol RIB ");

            PacketDotNet.Packet Layer0 = Packet.Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Packet.Extractor.GetEthPacket(Layer0);

        }
    }
}
