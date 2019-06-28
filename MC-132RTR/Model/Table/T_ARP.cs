using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Table
{
    public class T_ARP
    {
        private static T_ARP Instance = null;
        public static int TIMEOUT { private set; get; } = 30;

        public void RemoveAllElements()
        {

        }

        public void ChangeTimeout(int Adept)
        {
            if (!(Adept > 0))
                return;

            TIMEOUT = Adept;
        }

        public static T_ARP GetInstance()
        {
            if (Instance == null)
                Instance = new T_ARP();

            return Instance;
        }
    }
}
