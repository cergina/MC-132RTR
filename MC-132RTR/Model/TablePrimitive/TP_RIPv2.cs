using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_RIPv2
    {
        public static uint INFINITY { private set; get; } = 16;

        public Network Net { get; private set; } = null;
        public uint Metric;
        public Device OriginDevice = null;


        public TP_RIPv2()
        {
        }

        private void RegularStuff()
        {

        }
    }
}
