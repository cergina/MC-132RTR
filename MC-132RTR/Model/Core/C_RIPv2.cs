using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Packet.Items;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using SharpPcap;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Core
{
    class C_RIPv2
    {
        public static IPAddress IP_RIPv2 { private set; get; } = IPAddress.Parse("224.0.0.9");
        public static PhysicalAddress MAC_RIPv2 { private set; get; } = PhysicalAddress.Parse("01-00-5E-00-00-09");
        public static IPAddress IP_NH_THIS { private set; get; } = IPAddress.Parse("0.0.0.0");


        // UPDATE (seconds) - time for periodic update
        public static int UPDATE_INTERVAL { private set; get; } = 30;
        public static C_RIPv2 Instance = null;

        private C_RIPv2()
        {
        }

        public static C_RIPv2 GetInstance()
            => Instance ?? (Instance = new C_RIPv2());

        public void ChangeTimer(int Adept)
        {
            if (Adept > 0)
                UPDATE_INTERVAL = Adept;
        }

        public int IfTimeForPeriodicDoSo(int UpdateTimer)
        {
            if (UpdateTimer == 0)
            {
                Device.GetListOfUsableDevices().ForEach(Dev => { if (!Dev.DEV_Disabled && !Dev.DEV_DisabledRIPv2)
                        ClassicResponse(Dev);
                });
                UpdateTimer = UPDATE_INTERVAL;
            }

            if (UpdateTimer > 0)
                --UpdateTimer;

            return UpdateTimer;
        }

        /*                                            */
        /*        CONNECTED DEVICES RIPv2             */
        /*                                            */

        // Send info about available network
        public void DeviceAvailable(Device Dev)
        {
            P_RIPv2 PR = P_RIPv2.CraftResponse_RIPv2DeviceAvailability(Dev, true);
            Device.GetListOfUsableDevicesExceptOf(Dev).ForEach(UD => P_RIPv2.Send(UD, PR, IP_RIPv2, MAC_RIPv2));

            T_RIPv2.GetInstance().IntegrateDevice(Dev);
        }

        // Get list that is via Dev, Make unavailable, Send info
        public void DeviceUnavailable(Device Dev)
        {
            P_RIPv2 PR = P_RIPv2.CraftResponse_RIPv2DeviceAvailability(Dev, false);
            Device.GetListOfUsableDevicesExceptOf(Dev).ForEach(UD => P_RIPv2.Send(UD, PR, IP_RIPv2, MAC_RIPv2));

            T_RIPv2.GetInstance().RemoveFromOriginDevice(Dev);
        }

        /*                 HANDLER                      */
        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);
            
            P_RIPv2 PR = new P_RIPv2(Udp.PayloadData);

            Ipv4 = P_RIPv2.UponArrival(PR, Ipv4, out bool Ok);
            if (!Ok)
                return;

            switch (PR.CT)
            {
                case 1:
                    ProcessRequest(PR, ReceivalDev);
                    break;
                case 2:
                    ProcessResponse(PR, Ipv4, ReceivalDev);
                    break;
                default:
                    break;
            }
        }

        /*                                            */
        /*         REQUEST CORE PROCESSING            */
        /*                                            */
        private void ProcessRequest(P_RIPv2 PR, Device RecDev)
        {
            if (IsRequestForClassicResponse(PR))
                ClassicResponse(RecDev);
            else
                ResponseUponRequest(PR, RecDev);
        }

        // Is functions Request
        private bool IsRequestForClassicResponse(P_RIPv2 PR)
        {
            I_RIPv2 RFCR_IR = new I_RIPv2(0, PR);

            if (PR.EntriesCount == 1 && RFCR_IR.Id == 0 && RFCR_IR.Metric == TP_RIPv2.INFINITY)
                return true;

            return false;
        }

        // Do sth functions Request
        private void ClassicResponse(Device RecDev)
        {
            List<P_RIPv2> LPR = P_RIPv2.CraftPeriodicResponses(RecDev);
            P_RIPv2.SendList(RecDev, LPR, IP_RIPv2, MAC_RIPv2);
        }

        private void ResponseUponRequest(P_RIPv2 PR, Device RecDev)
        {
            P_RIPv2 PR_Resp = P_RIPv2.CraftResponseUponRequest(PR);
            P_RIPv2.Send(RecDev, PR_Resp, IP_RIPv2, MAC_RIPv2);
        }

        /*                                            */
        /*        RESPONSE CORE PROCESSING            */
        /*                                            */
        private void ProcessResponse(P_RIPv2 PR, IPv4Packet IP4, Device RecDev)
        {
            //When better route is found, or no longer available is, triggered update need be sent
            P_RIPv2 PR_Trig = P_RIPv2.AttemptToIntegrateAndCraftTriggeredResponse(RecDev, PR, IP4);

            if (PR_Trig.EntriesCount == 0)
                return;

            List<Device> L_Dev = Device.GetListOfUsableDevicesExceptOf(RecDev);
            foreach (Device D in L_Dev)
                P_RIPv2.Send(D, PR_Trig, C_RIPv2.IP_RIPv2, C_RIPv2.MAC_RIPv2);
        }
    }
}
