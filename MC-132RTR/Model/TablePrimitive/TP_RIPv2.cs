using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using System;
using System.Net;
using System.Windows.Forms;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_RIPv2
    {
        public static uint CONNECTED { private set; get; } = 0;
        public static uint INFINITY { private set; get; } = 16;

        public Network Net { get; private set; } = null;
        public IPAddress NextHopIp { get; private set; } = null;
        public uint Metrics { get; private set; } = INFINITY;
        public Device OriginDevice { get; private set; } = null;

        public int Invalid { get; private set; } = T_RIPv2.INVALID;
        public int Holddown { get; private set; } = T_RIPv2.HOLDDOWN;
        public int Flush { get; private set; } = T_RIPv2.FLUSH;


        public TP_RIPv2(Network Net, uint Metrics, IPAddress NextHopIp, Device OriginDevice)
        {
            this.Net = Net;
            this.NextHopIp = NextHopIp;
            this.Metrics = Metrics;
            this.OriginDevice = OriginDevice;
        }

        public bool Update(Network Net, uint Metrics, IPAddress NextHopIp, Device OriginDevice)
        {
            if (BlockedUpdate())
                return false;

            this.Net = Net;
            this.NextHopIp = NextHopIp;
            this.Metrics = Metrics;
            this.OriginDevice = OriginDevice;

            ResetTimers();
            return true;
        }

        public void Renew()
        {
            if (!BlockedUpdate())
                ResetTimers();
        }

        private void ResetTimers()
        {
            Flush = T_RIPv2.FLUSH;
            Invalid = T_RIPv2.INVALID;
            Holddown = T_RIPv2.HOLDDOWN;
        }

        public bool Equals(Network TPRNet)
            => (TPRNet != null && TPRNet.Equals(Net));

        public void BlockUpdates()
            => Invalid = 0;

        public void RegularOperation()
        {
            if (Metrics == TP_Routing.DIRECT)
                return;

            if (Invalid > 0)
                --Invalid;
            
            if (Flush > 0)
                --Flush;

            if (BlockedUpdate())
                --Holddown;
        }

        public ListViewItem ToListViewItem()
        {
            String RIPNetworkColumn = Net.ToString();
            String RIPNextHopColumn = (NextHopIp != null) ? NextHopIp.ToString() : "NO";
            String RIPMetricsColumn = Metrics.ToString();
            String RIPDeviceColumn = (OriginDevice != null) ? OriginDevice.Id : "NO";
            String RIPInvalidColumn = Invalid.ToString();
            String RIPHolddownColumn = Holddown.ToString();
            String RIPFlushColumn = Flush.ToString();

            return new ListViewItem(new string[] { RIPNetworkColumn, RIPNextHopColumn, RIPMetricsColumn, RIPDeviceColumn, RIPInvalidColumn, RIPHolddownColumn, RIPFlushColumn });
        }

        public bool OperationsBeforeFlushDone()
        {
            TP_Routing TPR = T_Routing.GetInstance().SpecificSearch(
                Net.GetNetworkAddress(), Net.MaskAddress, OriginDevice, NextHopIp, TP_Routing.RIP);

            if (TPR != null)
                T_Routing.GetInstance().RemoveFromRoutes(TPR);

            return true;
        }

        public bool PassableToRoutingTable()
            => Metrics != TP_Routing.DIRECT && Metrics != INFINITY && Flush > 0;

        private bool BlockedUpdate()
            => (TemporaryDown() && Holddown > 0);

        private bool TemporaryDown()
            => Invalid == 0;
    }
}
