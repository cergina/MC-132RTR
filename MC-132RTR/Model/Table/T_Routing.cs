using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.TablePrimitive;
using System;
using System.Collections.Generic;
using System.Linq;
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

            AddToRoutes(new TP_Routing(TP_Routing.STATIC, ExitDev, SubNet, Nh));
        }

        public void AttemtToAdd_Connected(Device ExitDev)
        {
            Network SubnetToUse = new Network(ExitDev.Network.GetNetworkAddress(), ExitDev.Network.MaskAddress);

            AddToRoutes(new TP_Routing(TP_Routing.DIRECT, ExitDev, SubnetToUse, null));
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

        public void AddToRoutes(TP_Routing TPR)
        {
            if (!TPR.Subnet.IsCorrect())
                return;

            if (IsSubnetInRoutes(TPR.Subnet) == null)
                Routes.Add(TPR);
        }

        /*
         * returns null if it's not in it
         */
        public TP_Routing IsSubnetInRoutes(Network Net)
        {
            foreach (TP_Routing TPR in Routes)
            {
                if (TPR.Subnet.IsInSameSubnet(Net))
                    return TPR;
            }

            return null;
        }

        public List<TP_Routing> GetListForView()
        {
            return Routes.ToList();
        }
    }
}
