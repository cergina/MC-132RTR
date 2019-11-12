using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using System.Net;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_RIPv2
    {
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

        public void Update(Network Net, uint Metrics, IPAddress NextHopIp, Device OriginDevice)
        {
            if (BlockedUpdate())
                return;

            this.Net = Net;
            this.NextHopIp = NextHopIp;
            this.Metrics = Metrics;
            this.OriginDevice = OriginDevice;

            ResetTimers();
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

            if (TemporaryDown())
            {
                if (Holddown > 0)
                    --Holddown;
            }
        }

        private bool BlockedUpdate()
            => (TemporaryDown() && Holddown > 0);

        private bool TemporaryDown()
            => Invalid == 0;
    }
}
