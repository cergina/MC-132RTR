using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Packet;
using PacketDotNet;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;

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
                    break;
            }
        }

        public static int IdentifyAsProtocol(CaptureEventArgs e, Device DeviceReceived)
        {
            //
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            if (Layer0 == null)
                return Middleman.NOTHING;

            //
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            if (EthPckt == null) 
                return Middleman.NOTHING;

            // this will avoid working with self generated stuff
            if (Device.PairDeviceWithMacAdress(EthPckt.SourceHwAddress) != null)
                return Middleman.NOTHING;

            //
            ARPPacket ArpPckt = Extractor.GetArpPacket(EthPckt);
            if (ArpPckt != null)
                return Middleman.ARP;

            //
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            if (Ipv4 == null || !Ipv4.ValidChecksum)
                return Middleman.NOTHING;

            // Check if it is RIP, hence it has to be UDP first
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);
            if (Udp != null)
            {
                if (Udp.SourcePort == 520 || Udp.DestinationPort == 520)
                {
                    // Unicast RIP for router
                    // TODO not supported yet, will be tested?

                    // Multicast RIP case
                    if ((IPAddress.Parse("224.0.0.9").Equals(Ipv4.DestinationAddress))
                        &&
                        (PhysicalAddress.Parse("01-00-5E-00-00-09").Equals(EthPckt.DestinationHwAddress))                        
                        )
                        return (DeviceReceived.DEV_DisabledRIPv2) ? Middleman.NOTHING : Middleman.RIPv2;
                }
            }

            // The dest IP cant be any used on the router
            if (Device.PairDeviceWithIpAddress(Ipv4.DestinationAddress) != null)
                return Middleman.NOTHING;
            
            // Throw away stuff not intended for MAC
            if (Device.PairDeviceWithMacAdress(EthPckt.DestinationHwAddress) == null)
                return Middleman.NOTHING;

            return Middleman.RIB;
        }

        public static void GeneralHandle(CaptureEventArgs e, Device ReceivalDev)
        {
            bool Okay = true;

            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);

            P_Routing PR = new P_Routing(Ipv4);

            P_Routing.UponArrival(PR, out Okay);
            if (!Okay)
                return;

            TP_Routing TPR = T_Routing.GetInstance().RegularSearch(PR.Ipv4.DestinationAddress);

            P_Routing.BeforeSend(ReceivalDev, TPR, PR, out Okay);

            if (Okay)
                P_Routing.Send(PR, TPR);
        }
    }
}
