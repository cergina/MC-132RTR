using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MC_132RTR.Controller.Middleman;

namespace MC_132RTR.Model.Table
{
    class T_RIPv2
    {
        private static T_RIPv2 Instance = null;

        // FLUSH (seconds) - time after the network is removed
        public int FLUSH { private set; get; } = 240;
        // INVALID (seconds) - time after the network goes to HOLD DOWN
        public int INVALID { private set; get; } = 180;
        // HOLD DOWN (seconds) - during this time is network advertised with 16 metrics and NOT UPDATES itself
        public int HOLDDOWN { private set; get; } = 180;


        // generic stuff
        public static T_RIPv2 GetInstance()
        {
            if (Instance == null)
                Instance = new T_RIPv2();

            return Instance;
        }

        public void ChangeTimer(int Adept, int Which)
        {
            if (!(Adept > 0))
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
    }
}
