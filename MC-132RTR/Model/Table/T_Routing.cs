using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.TablePrimitive;
using System;
using System.Collections.Generic;
using System.Net;

namespace MC_132RTR.Model.Table
{
    public class T_Routing
    {
        private static T_Routing Instance = null;

        private static List<TP_Routing> Routes = new List<TP_Routing>();

        public void AttemtToAdd_Static(Network SubNet, IPAddress Nh, int ExitDevNumber)
        {
            Device ExitDev = Device.PairDeviceWithNumber(ExitDevNumber);

            TP_Routing TPR = new TP_Routing(TP_Routing.STATIC, ExitDev, SubNet, Nh);
            Routes.Add(TPR);
        }

        public void AttemtToAdd_Connected()
        {

        }

        public void AttemtToAdd_Dynamic()
        {

        }

        public static T_Routing GetInstance()
        {
            if (Instance == null)
                Instance = new T_Routing();

            return Instance;
        }
    }
}
