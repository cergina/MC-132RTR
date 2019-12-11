using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace MC_132RTR.Controller.Middleman
{
    public static class Middleman
    {
        public const int NOTHING = 0;
        public const int ARP = 100;
        public const int RIB = 200;
        public const int RIPv2 = 300;
        public const int RIPv2_FLUSH = 301;
        public const int RIPv2_INVALID = 302;
        public const int RIPv2_HOLDDOWN = 303;
        public const int RIPv2_INTERVAL = 304;
        public const int DHCP = 400;

        // GENERAL
        public static List<Device> InitializeRouter()
        {
            Device.InitializeAllDevices();
            return Device.ListOfDevices;
        }

        public static string GetStartState()
            => Device.RouterRunning ? RouterForm.STOP : RouterForm.START_UP;

        public static string GetPowerState()
            => RouterForm.Instance == null ? 
                "Initial" : (RouterForm.Instance.PowerState.Equals(RouterForm.POWER_UP) ? 
                    RouterForm.POWER_OFF : RouterForm.POWER_UP);

        public static void TryToStartRouter()
        {
            if (!Device.RouterRunning && Device.CountUsableDevices() >= Device.MinAmountOfRunningDevices)
                Device.StartRouter();
        }

        public static void StopRouter()
        {
            if (Device.RouterRunning)
                Device.StopRouter();
        }

        // DEVICES
        public static void TryToInitialiazeDevice(Device Dev, String Ip, String Mask)
        {
            if (Dev == null || String.IsNullOrEmpty(Ip) || String.IsNullOrEmpty(Mask))
                return;

            try
            {
                Network Net = new Network(IPAddress.Parse(Ip), new Mask(IPAddress.Parse(Mask)));
                Dev.Set(Net.Address, Net.MaskAddress.SubnetMask);
            } catch (Exception exc)
            {
            }
        }

        // RIPv2
        public static void EnableRIPv2OnDevice(string DevS)
        {
            if (String.IsNullOrEmpty(DevS))
                return;

            Device Dev = Device.PairDeviceWithToString(DevS);
            if (Dev != null)
                Dev.EnableRIPv2();
        }

        public static void DisableRIPv2OnDevice(string DevS)
        {
            if (String.IsNullOrEmpty(DevS))
                return;

            Device Dev = Device.PairDeviceWithToString(DevS);
            if (Dev != null)
            {
                Dev.DisableRIPv2();
            }
        }

        // DHCP
        public static void SaveDHCPSettings(String IpStart, String IpEnd, String IpMask, uint Mode)
        {
            try
            {
                if (Mode == C_DHCP.NOTHING)
                    return;

                IPAddress IpFirst = IPAddress.Parse(IpStart);
                IPAddress IpLast = IPAddress.Parse(IpEnd);
                Mask SubnetMask = new Mask(IPAddress.Parse(IpMask));

                C_DHCP.GetInstance().SettingsChange(IpFirst, IpLast, SubnetMask, Mode);
            }
            catch (Exception en) { }
        }

        public static void EnableDHCPOnDevice(string DevS)
        {
            if (String.IsNullOrEmpty(DevS))
                return;

            Device Dev = Device.PairDeviceWithToString(DevS);
            if (Dev != null)
                Dev.EnableDHCP();
        }

        public static void DisableDHCPOnDevice(string DevS)
        {
            if (String.IsNullOrEmpty(DevS))
                return;

            Device Dev = Device.PairDeviceWithToString(DevS);
            if (Dev != null)
            {
                Dev.DisableDHCP();
            }
        }

        // ARP
        public static void SendTestArp(String Ip, int DevNum)
        {
            try
            {
                if (DevNum == -1 || String.IsNullOrEmpty(Ip))
                    return;

                IPAddress IpReq = IPAddress.Parse(Ip);

                switch(DevNum)
                {
                    case 0:
                    case 1:
                        C_ARP.GetInstance().ExplorationVia(IpReq, DevNum, false);
                        break;
                    default:
                        return;
                }
            }
            catch (Exception e) { };
        }

        // ROUTING

        // STATIC ROUTES
        public static void TryToAddStaticRoute(String Ip, String Mask,
            String NextHop, int ExitDev)
        {
            try
            {
                Network NetTmp = new Network(IPAddress.Parse(Ip), 
                    new Model.Support.Mask(IPAddress.Parse(Mask)));

                IPAddress NextHopIp;

                try
                {
                    NextHopIp = IPAddress.Parse(NextHop);
                } catch (Exception x) { NextHopIp = null; }

                if ((!NetTmp.IsCorrect()) || (NextHopIp == null && ExitDev == -1))
                {
                    Logging.Out("Nepridam");
                    return;
                }

                T_Routing.GetInstance().AttemtToAdd_Static(NetTmp, NextHopIp, ExitDev);
            } catch (Exception e) { }
        }

        public static void RemoveStaticRoute(String Ip, String Mask, String NextHop, int ExitDev)
        {
            try
            {
                Network NetTmp = new Network(IPAddress.Parse(Ip),
                    new Model.Support.Mask(IPAddress.Parse(Mask)));

                IPAddress NextHopIp;

                try
                {
                    NextHopIp = IPAddress.Parse(NextHop);
                }
                catch (Exception x) { NextHopIp = null; }

                if ((!NetTmp.IsCorrect()) || (NextHopIp == null && ExitDev == -1))
                {
                    Logging.Out("Nevykonam search for static route, incorrect");
                    return;
                }

                TP_Routing TPR = T_Routing.GetInstance().SpecificSearch(IPAddress.Parse(Ip), new Model.Support.Mask(IPAddress.Parse(Mask)),
                Device.PairDeviceWithNumber(ExitDev), NextHopIp, TP_Routing.STATIC);

                if (TPR != null)
                    T_Routing.GetInstance().RemoveFromRoutes(TPR);
            }
            catch (Exception e) { }
        }

        // Tables
        /*
         * Clears
         */
        public static void Clear(int WhichTable)
        {
            switch (WhichTable)
            {
                case ARP:
                    T_ARP.GetInstance().RemoveAllElements();
                    break;
                case RIPv2:
                    throw new NotSupportedException();
                case DHCP:
                    throw new NotSupportedException();
                default:
                    break;
            }
        }

        internal static void TryToAddDHCP(string IpText, string DefGatText, string ForMacText)
        {
            try
            {
                T_DHCP.GetInstance().AddManual(
                    IPAddress.Parse(IpText),
                    IPAddress.Parse(DefGatText),
                    PhysicalAddress.Parse(ForMacText)
                    );
            } catch (Exception en) { }
        }

        internal static void TryToDeleteDHCP(string IpText)
        {
            try
            {
                T_DHCP.GetInstance().DeleteManual(IPAddress.Parse(IpText));
            } catch (Exception en) { }
        }

        /*
         * 
         */
        public static int GetTimer(int WhichProto, int Name)
        {
            switch (WhichProto)
            {
                case ARP:
                    return T_ARP.TIMEOUT;
                case RIPv2:
                    switch (Name)
                    {
                        case RIPv2_FLUSH:
                            return T_RIPv2.FLUSH;
                        case RIPv2_INVALID:
                            return T_RIPv2.INVALID;
                        case RIPv2_HOLDDOWN:
                            return T_RIPv2.HOLDDOWN;
                        case RIPv2_INTERVAL:
                            return C_RIPv2.UPDATE_INTERVAL;
                        default:
                            return -1;
                    }
                case DHCP:
                    return T_DHCP.TIMER;
                default:
                    return -1;
            }
        }

        public static List<ListViewItem> GetListViewItemsARP()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();
            T_ARP.GetInstance().GetListForView().ForEach(Item => ListTmp.Add(Item.ToListViewItem()));
            return ListTmp;
        }

        public static List<ListViewItem> GetListViewItemsROUTE()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();
            T_Routing.GetInstance().GetListForView().ForEach(Item => ListTmp.Add(Item.ToListViewItem()));
            return ListTmp;
        }

        public static List<ListViewItem> GetListViewItemsRIP()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();
            T_RIPv2.GetInstance().GetListForView().ForEach(Item => ListTmp.Add(Item.ToListViewItem()));
            return ListTmp;
        }

        public static List<ListViewItem> GetListViewItemsDHCP()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();
            T_DHCP.GetInstance().GetListForView().ForEach(Item => ListTmp.Add(Item.ToListViewItem()));
            return ListTmp;
        }
        /*
         * 
         */
        public static void SetTimer(int WhichProto, int NameOnlyRip, int Value)
        {
            switch (WhichProto)
            {
                case ARP:
                    T_ARP.GetInstance().ChangeTimeout(Value);
                    return;
                case RIPv2:
                    switch (NameOnlyRip)
                    {
                        case RIPv2_FLUSH:
                        case RIPv2_INVALID:
                        case RIPv2_HOLDDOWN:
                            T_RIPv2.GetInstance().ChangeTimer(NameOnlyRip, Value);
                            return;
                        case RIPv2_INTERVAL:
                            C_RIPv2.GetInstance().ChangeTimer(Value);
                            return;
                        default:
                            return;
                    }
                case DHCP:
                    T_DHCP.GetInstance().ChangeTimer(Value);
                    return;
                default:
                    return;
            }
        }

        public static void ThreadStart()
        {
            /* Frontend */
            // GUI Thread
            new Thread(() => RouterForm.Instance.RefreshEverySecond()) { IsBackground = true }.Start();

            /* Backend */
            // ARP
            new Thread(() => T_ARP.GetInstance().Thread_Operation()) { IsBackground = true }.Start();

            // RIPv2
            new Thread(() => T_RIPv2.GetInstance().Thread_Operation()) { IsBackground = true }.Start();

            // DHCP
            new Thread(() => T_DHCP.GetInstance().Thread_Operation()) { IsBackground = true }.Start();
        }

        internal static string GetDHCPState()
        {
            // DEV [null/0/1] | IpS <-> IpL | M:Mask | DG:Gateway
            string ToReturn = $"DHCP[{C_DHCP.RUNNING.ToString()}], DEV[";
            // null / 1 / 2
            ToReturn += (C_DHCP.ActiveDevice_S == null) ? "null" : C_DHCP.ActiveDevice_S;
            ToReturn += "] | ";
            // first Ip
            ToReturn += C_DHCP.IpStart != null ? C_DHCP.IpStart.ToString() : "null";
            ToReturn += " <-> ";
            // last Ip
            ToReturn += C_DHCP.IpLast != null ? C_DHCP.IpLast.ToString() : "null";
            ToReturn += "\nM: ";
            //maska
            ToReturn += C_DHCP.DefaultMask != null ? C_DHCP.DefaultMask.SubnetMask.ToString() : "null";
            ToReturn += " | DG: ";
            // default gateway
            ToReturn += C_DHCP.IpDefGate != null ? C_DHCP.IpDefGate.ToString() : "null";
            ToReturn += $" | MOD: {C_DHCP.GetInstance().ModeAsString()}";
            return ToReturn;
        }
    }
}
