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

            AddToRoutes(new TP_Routing(TP_Routing.STATIC, ExitDev, new Network(SubNet.GetNetworkAddress(), SubNet.MaskAddress), Nh));
        }

        public bool AttemtToAdd_Connected(Device ExitDev)
        {
            Network SubnetToUse = new Network(ExitDev.Network.GetNetworkAddress(), ExitDev.Network.MaskAddress);

            return AddToRoutes(new TP_Routing(TP_Routing.DIRECT, ExitDev, SubnetToUse, null));
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

        public bool AddToRoutes(TP_Routing TPR)
        {
            //TODO sprav check aby sa directly connected nedavali duplicitne nazaciatku
            if (!TPR.Subnet.IsCorrect())
                return false;

            if (IsSubnetInRoutes(TPR.Subnet) == null)
            {
                Routes.Add(TPR);
                return true;
            }

            return false;
        }

        /*
         * returns null if it's not in it
         */
        public TP_Routing IsSubnetInRoutes(Network Net)
        {
            foreach (TP_Routing TPR in Routes.ToList())
            {
                if (TPR.Subnet.Equals(Net))
                    return TPR;
            }

            return null;
        }

        public void ClearAllRoutes()
        {
            Routes.Clear();
        }

        public List<TP_Routing> GetListForView()
        {
            return Routes.ToList();
        }
    }
}
