using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Packet.Items;
using PacketDotNet;
using SharpPcap;

namespace MC_132RTR.Model.Core
{
    class C_RIPv2
    {
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

        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);

            P_RIPv2 PR = new P_RIPv2(Udp.PayloadData);

            P_RIPv2.UponArrival(PR, out bool Ok);

            if (!Ok)
                return;

            switch(PR.CT)
            {
                case 1:
                    ProcessRequest(PR, ReceivalDev);
                    break;
                case 2:
                    ProcessResponse(PR, ReceivalDev);
                    break;
                default:
                    break;
            }
        }

        private void ProcessRequest(P_RIPv2 PR, Device RecDev)
        {
            for (int i=0; i < PR.EntriesCount; i++)
            {
                I_RIPv2 IR = new I_RIPv2(i, PR);

                if (!IR.Usable)
                    continue;
                
                // TODO

            }
        }

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
