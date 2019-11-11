using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
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
            => (PR != null && IPv4_Checking.Check(PR.Ipv4));

        private static bool ValidateBeforeSend(P_Routing PR)
        {
            Logging.OutALWAYS("Validujem pred poslanim");
            if (!Validate(PR))
                return false;

            /*Logging.OutALWAYS("Validacia 2");
            if (PR.Mac == null)
                return false;*/

            Logging.OutALWAYS("validacia pred poslanim ok");
            return true;
        }

        public static void UponArrival(P_Routing PR, out bool okay)
        {
            okay = false;

            if (!Validate(PR))
                return;

            if (IPv4_Checking.CheckUponArrival(PR.Ipv4))
                okay = true;
        }

        public static void BeforeSend(Device CameFromDev, TP_Routing TPR, P_Routing PR, out bool Ok)
        {
            if (TPR == null || TPR.ExitDevice == null || CameFromDev.MacToString().Equals(TPR.ExitDevice.MacToString()) || (!Validate(PR)))
            {
                Ok = false;
                return;
            }

            PR.Ipv4.UpdateCalculatedValues();
            PR.Ipv4.UpdateIPChecksum();
            Ok = true;
        }

        public static void Send(P_Routing PR, TP_Routing TPR)
        {
            Logging.OutALWAYS("RIB Sending");

            if (!ValidateBeforeSend(PR) || TPR == null || TPR.ExitDevice == null)
            {
                if (TPR == null)
                    Logging.OutALWAYS("TPR je null");

                if (TPR.ExitDevice == null)
                    Logging.OutALWAYS("TPR exit dev je null");

                return;
            }

            Logging.OutALWAYS("Sending 1");

            TP_ARP TPA = T_ARP.GetInstance().IpToMac(TPR.NextHopIp, TPR.ExitDevice);
            if (TPA == null)
                return;

            Logging.OutALWAYS("Sending 2");

            TPR.ExitDevice.SendViaThisDevice(TPA.Mac ,PR.Ipv4);
        }
    }
}
