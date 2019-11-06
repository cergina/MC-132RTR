using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MC_132RTR.Controller.Middleman;
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
        public uint MetricsForRoute(IPAddress SubnetIp, IPAddress MaskIp)
        {
            Network Subnet = new Network(SubnetIp, new Mask(MaskIp));
            
            if (Subnet.IsCorrect())
                foreach (TP_RIPv2 TPR in Table.ToList())
                    if (TPR.Net.Equals(Subnet))
                        return TPR.Metric;

            return TP_RIPv2.INFINITY;
        }

        // generic stuff
        public static T_RIPv2 GetInstance()
        {
            if (Instance == null)
                Instance = new T_RIPv2();

            return Instance;
        }

        public void ChangeTimer(int Which, int Adept)
        {
            if (Adept <= 0)
                return;

            Logging.OutALWAYS("je to" + Adept);
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
    }
}
