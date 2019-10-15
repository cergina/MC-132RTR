using MC_132RTR.Model.Core;
using MC_132RTR.Model.Packet;
using MC_132RTR.Model.TablePrimitive;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace MC_132RTR.Model.Table
{
    public class T_ARP
    {
        // the only representation of ARP table in code
        private static T_ARP Instance = null;
        public static int TIMEOUT { private set; get; } = 30;

        private IDictionary<IPAddress, TP_ARP> Dict = new Dictionary<IPAddress, TP_ARP>();

        public List<TP_ARP> GetListForView()
        {
            List<IPAddress> keys = new List<IPAddress>(Dict.Keys);
            List<TP_ARP> tmp = new List<TP_ARP>();

            foreach (IPAddress ip in keys)
            {
                tmp.Add(Dict[ip]);
            }

            return tmp;
        }

        public TP_ARP IpToMac(IPAddress key, bool Always)
        {
            TP_ARP value;
            if (Dict.TryGetValue(key, out value))
            {
                if (Always || (value != null && value.IsPassable()))
                {
                    return value;
                }
            }

            C_ARP.GetInstance().ExplorationVia(key, -1, true);
            return null;
        }

        public bool AttemptAddElement(IPAddress key, PhysicalAddress value, Device ReceivalDev)
        {
            // If doesn't contain just add
            if (!Dict.ContainsKey(key))
            {
                Dict.Add(key, new TP_ARP(key, value, ReceivalDev));
                return true;
            } else
            {
                Dict[key].Renew(value, ReceivalDev);
            }

            // not necessary to detect when to insert in other cases
            return false;
        }

        public void RemoveAllElements()
        {
            Dict.Clear();
        }

        public void ChangeTimeout(int Adept)
        {
            if (Adept <= 0)
                return;

            TIMEOUT = Adept;
        }

        public static T_ARP GetInstance()
        {
            if (Instance == null)
                Instance = new T_ARP();

            return Instance;
        }

        public void Thread_Operation()
        {
            while (true)
            {
                if (Device.FinalShutdown)
                    break;

                if (Device.RouterRunning)
                {
                    int c = Dict.Count();
                    if (c > 0)
                    {
                        List<IPAddress> keys = new List<IPAddress>(Dict.Keys);
                        foreach (IPAddress ip in keys)
                        {
                            if (Dict[ip].IsPassable())
                                Dict[ip].RegularOperation();
                            else
                                Dict.Remove(ip);
                        }
                    }
                } 

                Thread.Sleep(1000);
            }
        }
    }
}
