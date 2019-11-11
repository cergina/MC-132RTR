using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using System;
using System.Net;
using System.Windows.Forms;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_Routing
    {
        public static readonly int DIRECT = 0;
        public static readonly int STATIC = 1;
        public static readonly int RIP = 120;

        public Device ExitDevice { private set; get; }
        public Network Subnet { private set; get; }
        public IPAddress NextHopIp { private set; get; }
        public int Type { private set; get; }


        public TP_Routing(int Type, Device ExitDev, Network SubNet, IPAddress NextHop)
        {
            this.ExitDevice = ExitDev;
            this.NextHopIp = NextHop;
            this.Type = Type;
            this.Subnet = SubNet;
        }

        private void RegularStuff()
        {
        }

        public ListViewItem ToListViewItem()
        {
            String NetworkColumn = Subnet.ToString();
            String AdminDistanceColumn = Type.ToString();
            String DeviceColumn = (ExitDevice != null) ? ExitDevice.Id : "NO";
            String NextHopColumn = (NextHopIp != null) ? NextHopIp.ToString() : "NO";

            return new ListViewItem(new string[] { NetworkColumn, AdminDistanceColumn, DeviceColumn, NextHopColumn });
        }

        // Updates
        public void UpdateNetwork(Network NetworkNew)
            => Subnet = NetworkNew;

        public Boolean Equals(TP_Routing TPR)
        {
            // MANDATORY
            if (this.Type != TPR.Type)
                return false;

            if (!this.Subnet.Equals(TPR.Subnet))
                return false;

            // OPTIONAL
            bool OkNH = false;
            if (NextHopIp == null && TPR.NextHopIp == null)
                OkNH = true;
            else if (NextHopIp != null && NextHopIp.Equals(TPR.NextHopIp))
                OkNH = true;
            else
                return false;

            bool OkDev = false;
            if (ExitDevice == null && TPR.ExitDevice == null)
                OkDev = true;
            else if (ExitDevice != null && ExitDevice.Equals(TPR.ExitDevice))
                OkDev = true;
            else return false;

            return true;
        }

        public bool CanBeRoutedDirectlyViaNextHop()
            => (CanBeRoutedDirectly() && NextHopIp != null);

        public bool CanBeRoutedDirectly()
            => (ExitDevice != null && ExitDevice.IsUsable());

        public bool HasAtLeastNetHop()
            => NextHopIp != null;

        /***
         * Two TP_Routing TPR's have to be passed, and at least one has 
         * to be matching before it.
         */
        public static void ChooseDeeperMatch(IPAddress IpToSearch, TP_Routing TPR1, TP_Routing TPR2, out TP_Routing Chosen)
        {
            // If one is null, the other one is deeper if exists
            Chosen = null;
            if (TPR1 == null || TPR2 == null)
            {
                if (TPR1 != null)
                    Chosen = TPR1;

                if (TPR2 != null)
                    Chosen = TPR2;

                return;
            }

            // Compare which mask is deeper
            if (TPR1.Subnet.MaskAddress.IsGreaterThan(TPR2.Subnet.MaskAddress))
                Chosen = TPR1;

            if (TPR2.Subnet.MaskAddress.IsGreaterThan(TPR1.Subnet.MaskAddress))
                Chosen = TPR2;

            if (Chosen != null)
                return;

            // Masks are equal (so DC is better than SR and SR is better than DYN)
            if (TPR1.Type < TPR2.Type)
                Chosen = TPR1;

            if (TPR2.Type < TPR1.Type)
                Chosen = TPR2;
        }
    }
}
