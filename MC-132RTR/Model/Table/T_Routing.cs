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
        private static short MAX_ITERATIONS = 20;
        private static T_Routing Instance = null;

        private static List<TP_Routing> Routes = new List<TP_Routing>();

        private T_Routing()
        {
        }

        public bool AttemtToAdd_Static(Network SubNet, IPAddress Nh, int ExitDevNumber)
            => AddToRoutes(new TP_Routing(TP_Routing.STATIC, Device.PairDeviceWithNumber(ExitDevNumber), SubNet.GetNetworkGeneral(), Nh));

        public bool AttemtToAdd_Connected(Device ExitDev)
            => AddToRoutes(new TP_Routing(TP_Routing.DIRECT, ExitDev, ExitDev.Network.GetNetworkGeneral(), null));
        
        public bool AttemtToAdd_Dynamic(TP_RIPv2 TPR)
            => AddToRoutes(new TP_Routing(TP_Routing.RIP, TPR.OriginDevice, TPR.Net, TPR.NextHopIp));

        public static T_Routing GetInstance()
            => Instance ?? (Instance = new T_Routing());

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

        public void RemoveFromRoutes(TP_Routing TPR)
            => Routes.Remove(TPR);

        public bool UpdateConnected(Network CurrentNetwork, Network NewProposedNet)
        {
            foreach (TP_Routing TPR in Routes)
            {
                if (TPR.Type == TP_Routing.DIRECT && TPR.Subnet.Equals(CurrentNetwork.GetNetworkGeneral()))
                {
                    TPR.UpdateNetwork(NewProposedNet);
                    return true;
                }
            }
            return false;
        }

        /*
         * returns null if it's not in it
         */
        public TP_Routing IsSubnetInRoutes(Network Net)
            => Routes.Find(TPR => TPR.Subnet.Equals(Net));
        

        public void DeepestMatchingSearch(IPAddress IpToSearch, out TP_Routing Chosen)
        {
            Chosen = null;

            foreach (TP_Routing TPR in Routes)
            {
                if (TPR.Subnet.IsWithinNetworkRange(IpToSearch))
                    TP_Routing.ChooseDeeperMatch(IpToSearch, TPR, Chosen, out Chosen);
            }
        }

        // used to obtain a route with specific stuff, ...
        public TP_Routing SpecificSearch(IPAddress Ip, Mask MaskIp, Device ExitDev, IPAddress NextHopIp, int Type)
        {
            TP_Routing CompareTPR = new TP_Routing(Type, ExitDev, new Network(Ip, MaskIp), NextHopIp);

            foreach (TP_Routing TPR in Routes)
            {
                if (TPR.Equals(CompareTPR))
                    return TPR;
            }

            return null;
        }

        public TP_Routing RegularSearch(IPAddress Ip_Target)
        {
            TP_Routing TPR = null;

            for (short iteration = 0; iteration < MAX_ITERATIONS && Ip_Target != null; ++iteration)
            {
                DeepestMatchingSearch(Ip_Target, out TPR);
                if (TPR == null)
                    return null;

                if (TPR.CanBeRoutedDirectlyViaNextHop())
                {
                    return TPR;
                } else if (TPR.CanBeRoutedDirectly())
                {
                    return new TP_Routing(TPR.Type, TPR.ExitDevice, TPR.Subnet, Ip_Target);
                } else
                {
                    Ip_Target = TPR.NextHopIp;
                }
            }

            return null;
        }

        public void ClearAllRoutes()
            => Routes.Clear();

        public List<TP_Routing> GetListForView()
            => Routes.ToList();
    }
}
