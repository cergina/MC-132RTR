using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public class P_Routing
    {
        public IPv4Packet Ipv4 { private set; get; } = null;

        public P_Routing(IPv4Packet Ipv4)
        {
            this.Ipv4 = Ipv4;
        }

        public bool Validate()
        {
            if (Ipv4 == null || Ipv4.TimeToLive == 0)
                return false;

            return true;
        }

        public void UponArrivalTTL()
        {
            if (!Validate())
                return;

            --Ipv4.TimeToLive;
        }

        public void BeforeSend()
        {
            if (!Validate())
                return;

            Ipv4.UpdateCalculatedValues();
            Ipv4.UpdateIPChecksum();
        }
    }
}
