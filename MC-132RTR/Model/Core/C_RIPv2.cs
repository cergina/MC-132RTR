using MC_132RTR.Model.Support;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    class C_RIPv2
    {
        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_RIPv2 Instance = null;

        private C_RIPv2()
        {
        }

        public static C_RIPv2 GetInstance()
        {
            if (Instance == null)
                Instance = new C_RIPv2();

            return Instance;
        }

        public void ChangeTimer(int Adept)
        {
            if (Adept > 0)
                UPDATE_INTERVAL = Adept;
        }

        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            Logging.Out("RIPv2 doslo");
        }
    }
}
