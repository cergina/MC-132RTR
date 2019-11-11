using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public static class IPv4_Checking
    {
        public static bool CheckUponArrival(IPv4Packet Ipv4)
            => (Check(Ipv4) && TTL_OperationWithCheck(Ipv4));

        public static bool Check(IPv4Packet Ipv4)
            => (NotNull(Ipv4) && TTL_Check(Ipv4));

        public static bool TTL_Check(IPv4Packet Ipv4)
            => (Ipv4.TimeToLive > 0);

        public static bool TTL_OperationWithCheck(IPv4Packet Ipv4)
        {
            if (Ipv4.TimeToLive > 0)
                --Ipv4.TimeToLive;

            return TTL_Check(Ipv4);
        }

        private static bool NotNull(IPv4Packet Ipv4)
            => (Ipv4 != null);
    }
}
