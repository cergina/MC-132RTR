using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Controller.Middleman
{
    public static class Middleman
    {
        public const int ARP = 100;
        public const int RIB = 200;
        public const int RIPv2 = 300;
        public const int RIPv2_FLUSH = 301;
        public const int RIPv2_INVALID = 302;
        public const int RIPv2_HOLDDOWN = 303;
        public const int RIPv2_INTERVAL = 304;



        // GENERAL
        public static void TryToStartRouter()
        {
            if (Device.RouterRunning || Device.CountActiveDevices() < 2)
                return;



            throw new NotImplementedException();
        }

        public static void StopRouter()
        {
            if ()
            throw new NotImplementedException();
        }

        // DEVICES
        public static void TryToInitialiazeDevice(String DevName, Network Net)
        {
            Device Dev = GetDeviceByShorterName(DevName);

            if (Dev == null)
                return;

            throw new NotImplementedException();
        }

        public static void TryToChangeDevice(String DevName, Network Net)
        {
            Device Dev = GetDeviceByShorterName(DevName);

            if (Dev == null)
                return;

            throw new NotImplementedException();
        }

        public static Device GetDeviceByICapture(SharpPcap.ICaptureDevice ICapDev)
        {

            throw new NotImplementedException();
        }

        public static Device GetDeviceByShorterName(String ShorterName)
        {

            throw new NotImplementedException();
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

        /*
         * 
         */
        public static void SetTimer(int WhichProto, int Name, int Value)
        {
            switch (WhichProto)
            {
                case ARP:
                    T_ARP.GetInstance().ChangeTimeout(Value);
                    return;
                case RIPv2:
                    switch (Name)
                    {
                        case RIPv2_FLUSH:
                        case RIPv2_INVALID:
                        case RIPv2_HOLDDOWN:
                            T_RIPv2.GetInstance().ChangeTimer(Name, Value);
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


    }
}
