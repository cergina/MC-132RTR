using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_RIPv2
    {
        public Network Net { get; private set; } = null;
        public uint Metric;
        public Device OriginDevice = null;

        private int testParam;

        public TP_RIPv2()
        {
            this.testParam = 0;
        }

        private void RegularStuff()
        {
            ++testParam;
        }
    }
}
