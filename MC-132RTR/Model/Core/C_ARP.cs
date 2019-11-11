

using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using SharpPcap;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Core
{
    public class C_ARP
    {
        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_ARP Instance = null;
        private static List<IPAddress> AwaitingList = new List<IPAddress>();

        private C_ARP()
        {
        }

        public static C_ARP GetInstance()
            => Instance ?? (Instance = new C_ARP());

        public void ExplorationVia(IPAddress IpToExplore, int DevNum, bool All)
        {
            if (DevNum == 0 || All)
                P_ARP.SendRequest(Device.PairDeviceWithToString(Device.Dev1), IpToExplore);

            if (DevNum == 1 || All)
                P_ARP.SendRequest(Device.PairDeviceWithToString(Device.Dev2), IpToExplore);
        }


        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
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

            // is it me, send ARP response
            if (RequestForMyself(ReceivalDev, Ip_Target))
            {
                P_ARP.SendResponse(ReceivalDev, Mac_Source, Ip_Source, null, false);
                return;
            }

            // is it sth i have in my table? send proxy response
            if (RequestThatIKnow(ReceivalDev, Ip_Target))
            {
                P_ARP.SendResponse(ReceivalDev, Mac_Source, Ip_Source, Ip_Target, true);
                return;
            }
        }

        private bool RequestForMyself(Device ForThisDevice, IPAddress Ip_Target)
            => (Ip_Target != null && Ip_Target.Equals(ForThisDevice.Network.Address));

        private bool RequestThatIKnow(Device AvoidThisDevice, IPAddress Ip_Target)
        {
            TP_Routing TPR = T_Routing.GetInstance().RegularSearch(Ip_Target);

            if (TPR == null || TPR.ExitDevice == null)
                return false;

            // avoid sending sth in the same direction, request came from
            if (AvoidThisDevice.Equals(TPR.ExitDevice))
                return false;

            return true;
        }

        // RESPONSE STUFF
        private void Handle_Response(ARPPacket Pckt, Device ReceivalDev)
        {
            PhysicalAddress Mac_Source = Pckt.SenderHardwareAddress;
            IPAddress Ip_Source = Pckt.SenderProtocolAddress;

            IPAddress Ip_Desired = Ip_Source;
            PhysicalAddress Mac_Desired = Mac_Source;

            if (AwaitingList.Contains(Ip_Desired))
            { 
                AttemptToRemoveFromList(Ip_Desired);
                Table.T_ARP.GetInstance().AttemptAddElement(Ip_Desired, Mac_Desired, ReceivalDev);
            }
        }

        // List of expectancies
        public void AttemptToAddIntoList(IPAddress IpToExpect)
        {
            if (AwaitingList.Contains(IpToExpect))
                return;

            AwaitingList.Add(IpToExpect);
            Logging.Out("AwaitingList was enriched by: " + IpToExpect);
        }

        public void AttemptToRemoveFromList(IPAddress IpToRemove)
            => AwaitingList.Remove(IpToRemove);
    }
}
