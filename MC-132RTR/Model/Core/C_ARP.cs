

using MC_132RTR.Model.Support;
using SharpPcap;

namespace MC_132RTR.Model.Core
{
    public class C_ARP
    {
        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_ARP Instance = null;

        private C_ARP()
        {
        }

        public static C_ARP GetInstance()
        {
            if (Instance == null)
                Instance = new C_ARP();

            return Instance;
        }

        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            Logging.Out("ARP dosol");
        }
    }
}
