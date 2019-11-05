using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Packet.Items;
using PacketDotNet;
using SharpPcap;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Core
{
    class C_RIPv2
    {
        public static IPAddress IP_RIPv2 { private set; get; } = IPAddress.Parse("224.0.0.9");
        public static PhysicalAddress MAC_RIPv2 { private set; get; } = PhysicalAddress.Parse("01-00-5E-00-00-09");
        public static IPAddress IP_NH_THIS { private set; get; } = IPAddress.Parse("0.0.0.0");


        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_RIPv2 Instance = null;
        
        private C_RIPv2()
        {
        }

        public static C_RIPv2 GetInstance()
        {
            if (Instance == null)
                Instance = new C_RIPv2();

            return Instance;
        }

        public void ChangeTimer(int Adept)
        {
            if (Adept > 0)
                UPDATE_INTERVAL = Adept;
        }

        /*                 HANDLER                      */
        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);

            
            P_RIPv2 PR = new P_RIPv2(Udp.PayloadData);

            Ipv4 = P_RIPv2.UponArrival(PR, Ipv4, out bool Ok);

            if (!Ok)
                return;

            switch(PR.CT)
            {
                case 1:
                    ProcessRequest(Ipv4, PR, ReceivalDev);
                    break;
                case 2:
                    ProcessResponse(PR, ReceivalDev);
                    break;
                default:
                    break;
            }
        }

        /*        REQUEST CORE PROCESSING            */
        private void ProcessRequest(IPv4Packet IPv4, P_RIPv2 PR, Device RecDev)
        {
            I_RIPv2 RFCR_IR = new I_RIPv2(0, PR);
            if (IsRequestForClassicResponse(PR.EntriesCount, RFCR_IR.Id, RFCR_IR.Metric))
            {
                List<P_RIPv2> LPR = P_RIPv2.CraftPeriodicResponses(RecDev);
                P_RIPv2.SendList(RecDev, LPR, IP_RIPv2, MAC_RIPv2);
                return;
            }

            for (int i=0; i < PR.EntriesCount; i++)
            {
                I_RIPv2 IR = new I_RIPv2(i, PR);

                if (!IR.Usable)
                    continue;
                
                // TODO

            }
        }

        private bool IsRequestForClassicResponse(int EntCnt, ushort Id, uint Metric)
        {
            if (EntCnt == 1 && Id == 0 && Metric == 16)
                return true;

            return false;
        }

        /*        RESPONSE CORE PROCESSING            */
        private void ProcessResponse(P_RIPv2 PR, Device RecDev)
        {
            for (int i = 0; i < PR.EntriesCount; i++)
            {
                I_RIPv2 IR = new I_RIPv2(i, PR);

                if (!IR.Usable)
                    continue;

                // TODO

            }
        }
    }
}
