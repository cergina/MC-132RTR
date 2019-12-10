using MC_132RTR.Model.Core;
using MC_132RTR.Model.TablePrimitive;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MC_132RTR.Model.Table
{
    class T_DHCP
    {
        public static int TIMER { private set; get; } = 30;
        private static T_DHCP Instance = null;

        public List<TP_DHCP> Table = new List<TP_DHCP>();

        private T_DHCP()
        {

        }

        public void Thread_Operation()
        {
            while (true)
            {
                if (Device.FinalShutdown)
                    break;

                if (Device.RouterRunning && C_DHCP.RUNNING)
                {
                    // TODO
                }

                Thread.Sleep(1000);
            }
        }

        public void ChangeTimer(int Adept)
            => TIMER = (Adept > 0) ? Adept : TIMER;

        // generic stuff
        public static T_DHCP GetInstance()
            => Instance ?? (Instance = new T_DHCP());

        public List<TP_DHCP> GetListForView()
            => Table.ToList();
    }
}
