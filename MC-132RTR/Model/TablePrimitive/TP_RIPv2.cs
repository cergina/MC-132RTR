using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_RIPv2
    {
        public Network Net { get; private set; } = null;
        public uint Metric;
        public Device OriginDevice = null;
    }
}
