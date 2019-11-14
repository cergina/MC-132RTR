using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Core;
using MC_132RTR.Model.Packet.Items;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.TablePrimitive;

namespace MC_132RTR.Model.Table
{
    class T_RIPv2
    {
        private static T_RIPv2 Instance = null;

        // FLUSH (seconds) - time after the network is removed
        public static int FLUSH { private set; get; } = 240;
        // INVALID (seconds) - time after the network goes to HOLD DOWN
        public static int INVALID { private set; get; } = 180;
        // HOLD DOWN (seconds) - during this time is network advertised with 16 metrics and NOT UPDATES itself
        public static int HOLDDOWN { private set; get; } = 180;

        // entries of 
        public List<TP_RIPv2> Table = new List<TP_RIPv2>();

        /*                Table stuff                   */
        public void IntegrateDevice(Device Dev)
        {
            Network Net = Dev.Network.GetNetworkGeneral();
            TP_RIPv2 TPR = new TP_RIPv2(Net, TP_RIPv2.CONNECTED, C_RIPv2.IP_NH_THIS, Dev);
            Table.Add(TPR);
        }

        public void AttemptToIntegrateOutsider(out bool Trigger, I_RIPv2 IR, IPAddress RealNextHop, Device LearnedViaDev)
        {
            Trigger = false;
            if (Device.PairDeviceWithIpAddress(RealNextHop) != null)
                return;

            TP_RIPv2 TPR = GetRouteWithNetwork(IR.Ip, IR.Mask);
            Network ProposedNetwork = new Network(IR.Ip, new Mask(IR.Mask));

            // Case: unknown Route, usable metrics => learn, send triggered update
            if (TPR == null && IR.Metric < TP_RIPv2.INFINITY)
            {
                Table.Add(new TP_RIPv2(ProposedNetwork, IR.Metric, RealNextHop, LearnedViaDev));
                Trigger = true;
                return;
            }

            // Case: known Route
            if (TPR != null)
               switch(KnownRoute_JobDetermination(TPR, RealNextHop, IR.Metric))
               {
                   case "SAME_SOURCE_DIFF_METRICS_UPDATE":
                       Trigger = true;
                       TPR.Update(ProposedNetwork, IR.Metric, RealNextHop, TPR.OriginDevice);
                       break;
                   case "SAME_SOURCE_SAME_METRICS_UPDATE":
                        TPR.Renew();
                       break;
                   case "SAME_SOURCE_UNAVAILABLE_UPDATE":
                        Trigger = true;
                        TPR.BlockUpdates();
                       break;
                   case "DIFFERENT_SOURCE_BETTER_METRICS_UPDATE":
                        Trigger = true;
                        TPR.Update(ProposedNetwork, IR.Metric, RealNextHop, LearnedViaDev);
                        break;
                    default:
                        break;
               }
        }

        private string KnownRoute_JobDetermination(TP_RIPv2 TPR, IPAddress NextHop, uint NewMetrics)
        {
            if (NextHop.Equals(TPR.NextHopIp))
                if (NewMetrics == TP_RIPv2.INFINITY)
                    return "SAME_SOURCE_UNAVAILABLE_UPDATE";
                else if (NewMetrics == TPR.Metrics)
                    return "SAME_SOURCE_SAME_METRICS_UPDATE";
                else
                    return "SAME_SOURCE_DIFF_METRICS_UPDATE";
            else if (NewMetrics < TPR.Metrics)
                return "DIFFERENT_SOURCE_BETTER_METRICS_UPDATE";
            else
                return "";
        }
        
        public uint MetricsForRoute(IPAddress SubnetIp, IPAddress MaskIp)
        {
            Network Subnet = new Network(SubnetIp, new Mask(MaskIp));
            
            if (Subnet.IsCorrect())
                foreach (TP_RIPv2 TPR in Table.ToList())
                    if (TPR.Net.Equals(Subnet))
                        return TPR.Metrics;

            return TP_RIPv2.INFINITY;
        }

        public TP_RIPv2 GetRouteWithNetwork(IPAddress NetIp, IPAddress NetMaskIp)
        {
            Network Net = new Network(NetIp, new Mask(NetMaskIp));
            return Table.Find(TPR => TPR.Equals(Net));
        }

        public List<I_RIPv2>ListOfRoutesLearnedVia(Device Dev, bool INFINITY_METRICS)
        {
            List<I_RIPv2> L_IR = new List<I_RIPv2>();
            
            foreach(TP_RIPv2 TPR in GetListForView())
            {
                if (TPR.OriginDevice.Equals(Dev) && TPR.Metrics > TP_RIPv2.CONNECTED)
                    L_IR.Add(new I_RIPv2(TPR.Net.GetNetworkAddress(), TPR.Net.GetMaskIpAddress(),
                        TPR.NextHopIp, INFINITY_METRICS ? TP_RIPv2.INFINITY : TPR.Metrics));
            }

            return L_IR;
        }

        // generic stuff
        public static T_RIPv2 GetInstance()
            => Instance ?? (Instance = new T_RIPv2());

        public void ClearAllRoutes()
            => Table.Clear();

        public void ChangeTimer(int Which, int Adept)
        {
            if (Adept <= 0)
                return;

            switch (Which)
            {
                case Middleman.RIPv2_FLUSH:
                    FLUSH = Adept;
                    break;
                case Middleman.RIPv2_INVALID:
                    INVALID = Adept;
                    break;
                case Middleman.RIPv2_HOLDDOWN:
                    HOLDDOWN = Adept;
                    break;
            }
        }

        public void Thread_Operation()
        {
            while (true)
            {
                if (Device.FinalShutdown)
                    break;

                if (Device.RouterRunning)
                {
                    //  Regular decrements
                    Table.ForEach(TPR => TPR.RegularOperation());

                    // Cleanup
                    Table.RemoveAll(TPR => (TPR.Flush == 0 && TPR.OperationsBeforeFlushDone()));

                    // Export to routing table
                    ExportToRoutingTable();
                }

                Thread.Sleep(1000);
            }
        }

        private void ExportToRoutingTable()
        {
            foreach(TP_RIPv2 TPR in GetListForView())
                if (TPR.PassableToRoutingTable())
                    T_Routing.GetInstance().AttemtToAdd_Dynamic(TPR);
        }

        public List<TP_RIPv2> GetListForView()
            => Table.ToList();
    }
}
