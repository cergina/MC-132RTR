using MC_132RTR.Model.Core;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public class P_Routing
    {
        public IPv4Packet Ipv4 { private set; get; } = null;
        public PhysicalAddress Mac { private set; get; } = null;

        public P_Routing(IPv4Packet Ipv4)
        {
            this.Ipv4 = Ipv4;
        }

        public static bool Validate(P_Routing PR)
        {
            if (PR == null || PR.Ipv4 == null || PR.Ipv4.TimeToLive == 0)
                return false;

            return true;
        }

        private static bool ValidateBeforeSend(P_Routing PR)
        {
            if (!Validate(PR))
                return false;

            if (PR.Mac == null)
                return false;

            return true;
        }

        public static bool UponArrivalTTL(P_Routing PR)
        {
            if (!Validate(PR))
                return false;

            --PR.Ipv4.TimeToLive;
            return true;
        }

        public static void BeforeSend(P_Routing PR)
        {
            if (!Validate(PR))
                return;

            PR.Ipv4.UpdateCalculatedValues();
            PR.Ipv4.UpdateIPChecksum();
        }

        public static void Send(P_Routing PR, TP_Routing TPR)
        {
            if (!ValidateBeforeSend(PR) || TPR == null || TPR.ExitDevice == null)
                return;
            
            TP_ARP TPA = T_ARP.GetInstance().IpToMac(TPR.NextHopIp, false);
            if (TPA == null)
                return;

            TPR.ExitDevice.SendViaThisDevice(TPA.Mac ,PR.Ipv4);
        }
    }
}
