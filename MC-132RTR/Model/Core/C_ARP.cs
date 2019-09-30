

using MC_132RTR.Model.Support;
using PacketDotNet;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Core
{
    public class C_ARP
    {
        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_ARP Instance = null;

        private C_ARP()
        {
        }

        public static C_ARP GetInstance()
        {
            if (Instance == null)
                Instance = new C_ARP();

            return Instance;
        }

        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            Logging.Out("ARP dosol");

            PacketDotNet.Packet Layer0 = Packet.Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Packet.Extractor.GetEthPacket(Layer0);
            ARPPacket ArpPckt = Packet.Extractor.GetArpPacket(EthPckt);

            switch(ArpPckt.Operation)
            {
                case ARPOperation.Request:
                    Handle_Request(ArpPckt, ReceivalDev);
                    break;
                case ARPOperation.Response:
                    Handle_Response(ArpPckt, ReceivalDev);
                    break;
                default:
                    break;
            }
        }

        // REQUEST STUFF
        private void Handle_Request(ARPPacket Pckt, Device ReceivalDev)
        {
            PhysicalAddress Mac_Source = Pckt.SenderHardwareAddress;
            PhysicalAddress Mac_Target = Pckt.TargetHardwareAddress;
            IPAddress Ip_Target = Pckt.TargetProtocolAddress;
            IPAddress Ip_Source = Pckt.SenderProtocolAddress;


        }


        // RESPONSE STUFF
        private void Handle_Response(ARPPacket Pckt, Device ReceivalDev)
        {
            PhysicalAddress Mac_Source = Pckt.SenderHardwareAddress;
            PhysicalAddress Mac_Target = Pckt.TargetHardwareAddress;
            IPAddress Ip_Target = Pckt.TargetProtocolAddress;
            IPAddress Ip_Source = Pckt.SenderProtocolAddress;

            IPAddress Ip_Desired = Ip_Source;
            PhysicalAddress Mac_Desired = Mac_Source;

            Table.T_ARP.GetInstance().AttemptAddElement(Ip_Desired, Mac_Desired);
        }
    }
}
