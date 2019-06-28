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
    }
}
