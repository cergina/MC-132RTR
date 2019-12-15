using MC_132RTR.Model.Core;
using MC_132RTR.Model.TablePrimitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace MC_132RTR.Model.Table
{
    class T_DHCP
    {
        public static int TIMER { private set; get; } = 30;
        private static T_DHCP Instance = null;

        public List<TP_DHCP> Table = new List<TP_DHCP>();
        public List<IPAddress> IpPool = null;

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

        public void InitDHCP()
        {
            Table = new List<TP_DHCP>();  // empty
            IpPool = new List<IPAddress>();   // generate

            IPAddress AlreadyAssigned = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S).Network.Address;

            
        }

        public void ChangeTimer(int Adept)
            => TIMER = (Adept > 0) ? Adept : TIMER;

        // generic stuff
        public static T_DHCP GetInstance()
            => Instance ?? (Instance = new T_DHCP());

        public List<TP_DHCP> GetListForView()
            => Table.ToList();

        internal void AddManual(IPAddress IPToAssign, IPAddress IpDefGat, PhysicalAddress MacForThis)
        {
            if (C_DHCP.DefaultMask == null || !C_DHCP.DefaultMask.IsCorrect() || !C_DHCP.RUNNING)
                return;

            if (!C_DHCP.GetInstance().OkToAssignIp(IPToAssign))
                return;

            if (Table.Find(Item => Item.IpAssigned.Equals(IPToAssign)) != null)
                return;

            TP_DHCP TPDH = new TP_DHCP(IPToAssign, C_DHCP.DefaultMask, IpDefGat, MacForThis, C_DHCP.MANUAL);
            Table.Add(TPDH);
        }

        internal void DeleteManual(IPAddress IPAddress)
            => Table.RemoveAll(Item => Item.Type == C_DHCP.MANUAL && Item.IpAssigned.Equals(IPAddress));
    }
}
