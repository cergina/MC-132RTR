using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using System.Net;

namespace MC_132RTR.Model.TablePrimitive
{
    class TP_Routing
    {
        public static readonly int DIRECT = 0;
        public static readonly int STATIC = 1;
        public static readonly int RIP = 120;

        private int testParam;
        private Device ExitDevice;
        private Network Subnet;
        private IPAddress NextHopIp;
        private int Type;

        public TP_Routing(int Type, Device ExitDev, Network SubNet, IPAddress NextHop)
        {
            this.testParam = 0;
            this.ExitDevice = ExitDev;
            this.NextHopIp = NextHop;
            this.Type = Type;
            this.Subnet = SubNet;
        }

        private void RegularStuff()
        {
            ++testParam;
        }
    }
}
