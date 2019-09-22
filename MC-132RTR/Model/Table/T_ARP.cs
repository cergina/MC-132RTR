using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.TablePrimitive;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public TP_ARP MacToIp(IPAddress key, bool Always)
        {
            TP_ARP value;
            if (Dict.TryGetValue(key, out value))
            {
                if (Always || (value != null && value.IsPassable()))
                {
                    return value;
                }
            }
            return null;
        }

        public bool AttemptAddElement(IPAddress key, PhysicalAddress value)
        {
            if (!Dict.ContainsKey(key))
            {
                Dict.Add(key, new TP_ARP(key, value));
                return true;
            }

            // not necessary to detect when to insert in other cases
            return false;
        }

        public bool RemoveElemenet(IPAddress Addr)
        {
            return Dict.Remove(Addr);
        }

        public void DisableElement(IPAddress Addr)
        {
            TP_ARP Tmp = MacToIp(Addr, true);
            if (Tmp != null)
            {
                Tmp.Deactivate();
            }
        }

        public void RemoveAllElements()
        {
            Dict.Clear();
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

        // THREAD
        public void ARP_Thread()
        {
            Thread t = new Thread(Thread_Operation);

            t.Start();

            t.Join();
        }

        private void Thread_Operation()
        {
            while (true)
            {
                if (Device.FinalShutdown)
                    break;

                if (Device.RouterRunning)
                {

                } else
                {
                    //test
                    int c = Dict.Count();
                    if (c == 0)
                    {
                        Dict.Add(IPAddress.Parse("192.168.1.1"), new TP_ARP(IPAddress.Parse("192.168.1.1"), PhysicalAddress.Parse("BB:BB:BB:CC:CC:CC")));
                    } else
                    {
                        List<IPAddress> keys = new List<IPAddress>(Dict.Keys);
                        foreach (IPAddress ip in keys)
                        {
                            Dict[ip].RegularDecrement();
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
