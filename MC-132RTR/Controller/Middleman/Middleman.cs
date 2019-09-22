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



        // GENERAL
        public static List<Device> InitializeRouter()
        {
            Device.InitializeAllDevices();
            return Device.ListOfDevices;
        }

        public static string GetStartState()
        {
            if (Device.RouterRunning)
                return RouterForm.STOP;
            else
                return RouterForm.START_UP;
        }

        public static string GetPowerState()
        {
            if (RouterForm.Instance == null)
                return "Initial";

            if (RouterForm.Instance.PowerState.Equals(RouterForm.POWER_UP))
                return RouterForm.POWER_OFF;
            else
                return RouterForm.POWER_UP;
        }

        public static void TryToStartRouter()
        {
            if (Device.RouterRunning || Device.CountUsableDevices() < 2)
                return;

            Device.StartRouter();
        }

        public static void StopRouter()
        {
            if (!Device.RouterRunning)
                return;

            Device.StopRouter();
        }

        // DEVICES
        public static void TryToInitialiazeDevice(Device Dev, String Ip, String Mask)
        {
            if (Dev == null || String.IsNullOrEmpty(Ip) || String.IsNullOrEmpty(Mask))
                return;

            try
            {
                Dev.Set(IPAddress.Parse(Ip), IPAddress.Parse(Mask));
            } catch (Exception exc)
            {
            }
        }

        public static void TryToChangeDevice(Device Dev, String Ip, String Mask)
        {
            if (Dev == null || String.IsNullOrEmpty(Ip) || String.IsNullOrEmpty(Mask))
                return;

            throw new NotImplementedException();
        }

        public static Device GetDeviceByICapture(SharpPcap.ICaptureDevice ICapDev)
        {
            throw new NotImplementedException();
        }

        public static Device GetDeviceByShorterName(String ShorterName)
        {
            return Device.PairDeviceWithToString(ShorterName);
        }

        // RIPv2
        public static void EnableRIPv2OnDevice(Device Dev)
        {
            Dev.EnableRIPv2();
        }

        public static void DisableRIPv2OnDevice(Device Dev)
        {
            Dev.DisableRIPv2();
        }

        public static void SendTestRIPv2(Device Dev)
        {
            throw new NotImplementedException();
        }

        // ARP
        public static PhysicalAddress ResolveMacForIp()
        {

            throw new NotImplementedException();
        }

        public static void SendTestArp(Network Net)
        {
            throw new NotImplementedException();
        }

        // ROUTING

        // STATIC ROUTES
        public static void TryToAddStaticRoute(Network NetTmp)
        {
            if (!NetTmp.IsCorrect())
                return;


            throw new NotImplementedException();
        }

        public static void RemoveStaticRoute(Network NetTmp)
        {
            
            throw new NotImplementedException();
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
                    throw new NotImplementedException();
                    break;
                default:
                    break;
            }
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
                            return T_RIPv2.GetInstance().FLUSH;
                        case RIPv2_INVALID:
                            return T_RIPv2.GetInstance().INVALID;
                        case RIPv2_HOLDDOWN:
                            return T_RIPv2.GetInstance().HOLDDOWN;
                        case RIPv2_INTERVAL:
                            return C_RIPv2.UPDATE_INTERVAL;
                        default:
                            return -1;
                    }
                default:
                    return -1;
            }
        }


        public static List<ListViewItem> GetListViewItemsARP()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();

            foreach (TP_ARP tparp in T_ARP.GetInstance().GetListForView())
            {
                ListTmp.Add(tparp.ToListViewItem());
            }

            return ListTmp;
        }

        public static List<ListViewItem> GetListViewItemsROUTE()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();

            

            return ListTmp;
        }

        public static List<ListViewItem> GetListViewItemsRIP()
        {
            List<ListViewItem> ListTmp = new List<ListViewItem>();

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
                default:
                    return;
            }
        }

        public static void ThreadStart()
        {
            new Thread(() => RouterForm.Instance.RefreshEverySecond()) { IsBackground = true }.Start();
        }

    }
}
