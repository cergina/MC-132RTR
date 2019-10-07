﻿

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
            }
        }

        private bool RequestForMyself(Device ForThisDevice, IPAddress Ip_Target)
        {
            if (Ip_Target != null && Ip_Target.Equals(ForThisDevice.Network.Address))
                return true;

            return false;
        }

        private bool RequestThatIKnow(Device AvoidThisDevice, IPAddress Ip_Target)
        {
            TP_Routing TPR = T_Routing.GetInstance().RegularSearch(Ip_Target);

            if (TPR == null || TPR.ExitDevice == null)
                return false;

            // avoid sending sth in the same direction, request came from
            if (AvoidThisDevice.ToString().Equals(TPR.ExitDevice.ToString()))
                return false;

            return false;
        }

        // RESPONSE STUFF
        private void Handle_Response(ARPPacket Pckt, Device ReceivalDev)
        {
            PhysicalAddress Mac_Source = Pckt.SenderHardwareAddress;
            //PhysicalAddress Mac_Target = Pckt.TargetHardwareAddress;
            //IPAddress Ip_Target = Pckt.TargetProtocolAddress;
            IPAddress Ip_Source = Pckt.SenderProtocolAddress;

            IPAddress Ip_Desired = Ip_Source;
            PhysicalAddress Mac_Desired = Mac_Source;

            if (AwaitingList.Contains(Ip_Desired))
            { 
                Table.T_ARP.GetInstance().AttemptAddElement(Ip_Desired, Mac_Desired);
                AttemptToRemoveFromList(Ip_Desired);
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
        {
            AwaitingList.Remove(IpToRemove);
        }
    }
}
