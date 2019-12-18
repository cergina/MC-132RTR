using MC_132RTR.Model.Packet;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    class C_DHCP
    {
        public const uint NOTHING = 0;
        public const string NOTHING_S = "";
        public const uint MANUAL = 1;
        public const string MANUAL_S = "MANUAL";
        public const uint DYNAMIC = 2;
        public const string DYNAMIC_S = "DYNAMIC";
        public const uint AUTOMAT = 3;
        public const string AUTOMAT_S = "AUTOMAT";

        public const ushort Port_UDP_DHCP_ClientToServer = 67;
        public const ushort Port_UDP_DHCP_ServerToClient = 68;

        public static C_DHCP Instance = null;
        public static bool RUNNING { get; private set; } = false;
        public static string ActiveDevice_S = null;

        // DHCP settings
        public static Mask DefaultMask { get; private set; } = null;
        public static IPAddress IpStart { get; private set; } = null;
        public static IPAddress IpLast { get; private set; } = null;
        public static IPAddress IpDefGate { get; private set; } = null;
        public static uint Mode { get; private set; } = C_DHCP.NOTHING;

        private C_DHCP()
        {
        }

        public static C_DHCP GetInstance()
            => Instance ?? (Instance = new C_DHCP());

        public void SettingsChange(IPAddress IpS, IPAddress IpL, Mask SubnetMask, uint ModeToSet)
        {
            RUNNING = false;

            IpStart = IpS;
            IpLast = IpL;
            DefaultMask = SubnetMask;
            Mode = ModeToSet;

            AttemptToStartDHCP();
        }

        public void DeviceAvailable(Device Dev)
        {
            Device.GetListOfUsableDevicesExceptOf(Dev).ForEach(OD => OD.DisableDHCP());

            // TODO Maybe some activation stuff sending?
            ActiveDevice_S = Dev.Id;
        }

        // Get list that is via Dev, Make unavailable, Send info
        public void DeviceUnavailable(Device Dev)
        {
            // TODO Maybe some deactivation stuff sending?
            ActiveDevice_S = null;
        }

        /*                 HANDLER                      */
        public void Handle(CaptureEventArgs e, Device ReceivalDev)
        {
            PacketDotNet.Packet Layer0 = Extractor.GetPacket(e.Packet);
            EthernetPacket EthPckt = Extractor.GetEthPacket(Layer0);
            IPv4Packet Ipv4 = Extractor.GetIPv4Packet(EthPckt);
            UdpPacket Udp = Extractor.GetUdpPacket(Ipv4);

            switch(P_DHCP.IdentifyMessageType(Udp.PayloadData))
            {
                case P_DHCP.DHCPDISCOVER:
                    ProcessDiscover(Udp.PayloadData, ReceivalDev);
                    return;
                case P_DHCP.DHCPREQUEST:
                    ProcesRequest(Udp.PayloadData, ReceivalDev);
                    return;
                case P_DHCP.DHCPOFFER:
                case P_DHCP.DHCPACK:
                default:
                    return;
            }
        }

        private void ProcesRequest(byte[] Data, Device ReceivalDev)
        {
            P_DHCP PD_R = new P_DHCP(Data);

            if (!PD_R.IsFor(IpDefGate))
                return;

            PhysicalAddress MAC = PD_R.IsBy();
            if (MAC == null)
                return;

            TP_DHCP TPD_Ack = T_DHCP.GetInstance().Find(MAC);

            if (TPD_Ack == null)
                return; // Or send DHCP NAK

            UdpPacket Ack = P_DHCP.BOOTP_w_DHCP_ACK(TPD_Ack, PD_R.XID);
            P_DHCP.Send(ReceivalDev, Ack, ReceivalDev.Network.Address, IPAddress.Parse("255.255.255.255"), MAC);
        }

        private void ProcessDiscover(byte[] Data, Device ReceivalDev)
        {
            P_DHCP PD_D = new P_DHCP(Data);

            PhysicalAddress MAC = PD_D.IsBy();
            if (MAC == null)
                return;

            // this does not have to be in DHCP table yet
            // but may be as a manual/automatic there is
            TP_DHCP TPD_Offer = T_DHCP.GetInstance().Find(MAC);

            if (TPD_Offer == null)
                return; // Or send DHCP NAK

            UdpPacket Offer = P_DHCP.BOOTP_w_DHCP_OFFER(TPD_Offer, PD_D.XID);
            P_DHCP.Send(ReceivalDev, Offer, ReceivalDev.Network.Address, IPAddress.Parse("255.255.255.255"), PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"));
        }

        public string ModeAsString()
        {
            switch (Mode)
            {
                case MANUAL:
                    return MANUAL_S;
                case DYNAMIC:
                    return DYNAMIC_S;
                case AUTOMAT:
                    return AUTOMAT_S;
                case NOTHING:
                default:
                    return NOTHING_S;
            }
        }

        private void AttemptToStartDHCP()
        {
            if (IpStart == null || IpLast == null || 
                DefaultMask == null || !DefaultMask.IsCorrect())
                return;
            
            // TODO check if in one network and so one...
            Device Dev = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S);

            if (Dev.Network.IsWithinNetworkRange(IpStart) && Dev.Network.IsWithinNetworkRange(IpLast))
            {
                if (!Dev.Network.Address.Equals(IpStart) &&
                        !Dev.Network.Address.Equals(IpLast))
                {
                    IpDefGate = Dev.Network.Address;

                    RUNNING = true;
                    T_DHCP.GetInstance().InitDHCP();
                    return;
                }
            }
        }

        public bool OkToAssignIp(IPAddress IpToAssign)
        {
            Device Dev = Device.PairDeviceWithId(C_DHCP.ActiveDevice_S);

            if (!Dev.Network.IsWithinNetworkRange(IpToAssign))
                return false;

            // todo: check if it works, else dat do uint
            if (T_DHCP.GetInstance().DictPool[IpToAssign])
                return true;

            return false;
        }
    }
}
