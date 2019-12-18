using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.TablePrimitive;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

namespace MC_132RTR.Model.Table
{
    class T_DHCP
    {
        public static uint TIMER { private set; get; } = 70;
        public static uint TIMER_RENEWAL { private set; get; } = 30;
        public static uint TIMER_REBIND { private set; get; } = 50;

        private static T_DHCP Instance = null;

        // assigned ip's
        public List<TP_DHCP> Table = new List<TP_DHCP>();
        // available ip's
        // public List<IPAddress> IpPool = null;
        public Dictionary<IPAddress, bool> DictPool { get; private set; } = null;

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
                    // REMOVE OLD RESERVATIONS
                    foreach (TP_DHCP TPD in Table)
                    {
                        if (TPD.Holding && TPD.Temporary == 0)
                            MakeReservedAvailable(TPD.IpAssigned);
                    }

                    Table.RemoveAll(Item => Item.Holding && Item.Temporary == 0);

                    // REMOVE DYNAMIC ENTRIES
                    Table.RemoveAll(Item => !Item.Holding && Item.Type == C_DHCP.DYNAMIC && Item.Timer == 0);

                    // OTHER
                    foreach (TP_DHCP TPD in Table)
                    {
                        if (TPD.Holding)
                            --TPD.Temporary;
                        else
                            --TPD.Timer;
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public void InitDHCP()
        {
            Table = new List<TP_DHCP>();  // empty

            IPAddress AlreadyAssigned = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S).Network.Address;

            DictPool = Network.GetListOfIntermezzoIp(C_DHCP.IpStart, C_DHCP.IpLast, AlreadyAssigned, true);
        }

        public void ChangeTimer(int Adept)
        {
            TIMER = (Adept >= 30) ? (uint)Adept : TIMER;
            TIMER_RENEWAL = TIMER / 2;
            TIMER_REBIND = TIMER / 4 * 3;
        }

        // generic stuff
        public static T_DHCP GetInstance()
            => Instance ?? (Instance = new T_DHCP());

        public List<TP_DHCP> GetListForView()
            => Table.ToList();

        internal TP_DHCP Find(PhysicalAddress MAC)
        {
            // search in table
            TP_DHCP TPD_IT = Table.Find(Item => Item.MacBind.Equals(MAC));
            if (TPD_IT != null)
                return TPD_IT;

            // if not in table
            return TemporarilyAssign(MAC);
        }

        internal TP_DHCP TemporarilyAssign(PhysicalAddress MAC)
        {
            return new TP_DHCP(RandomFromPool(), C_DHCP.DefaultMask, C_DHCP.IpDefGate, MAC, C_DHCP.Mode, true);
        }

        internal void MakeReservedAvailable(IPAddress Ip)
        {
            //Table.RemoveAll(Item => Item.IpAssigned.Equals(Ip) && Item.Holding);
            DictPool[Ip] = true;
        }

        internal void MakeReservedRegular(IPAddress Ip)
        {
            Table.Find(Item => Item.IpAssigned.Equals(Ip)).Holding = false;
        }

        // TEMPORARY
        internal IPAddress RandomFromPool()
        {
            List<IPAddress> keys = new List<IPAddress>(DictPool.Keys);

            foreach (IPAddress Ip in keys)
            {
                if (DictPool[Ip])
                {
                    DictPool[Ip] = false;
                    return Ip;
                }
            }

            return null;
        }

        // REGULAR
        internal bool AddDynamic(IPAddress IPToAssign, Mask SubnetMask, IPAddress IpDefGate, PhysicalAddress MacForThis)
            => Add(IPToAssign, SubnetMask, IpDefGate, MacForThis, C_DHCP.DYNAMIC);

        internal bool AddManual(IPAddress IPToAssign, Mask SubnetMask, IPAddress IpDefGate, PhysicalAddress MacForThis)
            => Add(IPToAssign, SubnetMask, IpDefGate, MacForThis, C_DHCP.MANUAL);

        internal bool AddAutomatic(IPAddress IPToAssign, Mask SubnetMask, IPAddress IpDefGate, PhysicalAddress MacForThis)
            => Add(IPToAssign, SubnetMask, IpDefGate, MacForThis, C_DHCP.AUTOMAT);

        internal bool Add(IPAddress IPToAssign, Mask SubnetMask, IPAddress IpDefGate, PhysicalAddress MacForThis, uint Type)
        {
            if (C_DHCP.DefaultMask == null || !C_DHCP.DefaultMask.IsCorrect() || !C_DHCP.RUNNING)
                return false;

            if (!C_DHCP.GetInstance().OkToAssignIp(IPToAssign))
                return false;

            if (Table.Find(Item => Item.IpAssigned.Equals(IPToAssign)) != null)
                return false;

            TP_DHCP TPDH = new TP_DHCP(IPToAssign, SubnetMask, IpDefGate, MacForThis, Type, false);

            DictPool[IPToAssign] = false;
            Table.Add(TPDH);

            return true;
        }

        internal void DeleteManual(IPAddress IPAddress)
            => Table.RemoveAll(Item => Item.Type == C_DHCP.MANUAL && Item.IpAssigned.Equals(IPAddress));
    }
}
