using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
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


        public TP_RIPv2(Network Net, uint Metrics, IPAddress NextHopIp, Device OriginDevice)
        {
            this.Net = Net;
            this.NextHopIp = NextHopIp;
            this.Metrics = Metrics;
            this.OriginDevice = OriginDevice;
        }

        public void Update(Network Net, uint Metrics, IPAddress NextHopIp, Device OriginDevice)
        {
            this.Net = Net;
            this.NextHopIp = NextHopIp;
            this.Metrics = Metrics;
            this.OriginDevice = OriginDevice;
        }

        public bool Equals(Network TPRNet)
            => (TPRNet != null && TPRNet.Equals(Net));

        private void RegularStuff()
        {
        }
    }
}
