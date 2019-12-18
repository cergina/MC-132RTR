using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Packet
{
    class P_DHCP
    {
        public const short BOOTP_BASE_SIZE = 236;
        public const short DHCP_BASE_SIZE = 240;
        public const uint MAGIC_COOKIE = 0x63825363;

        public const Byte DHCPDISCOVER = 1;
        public const Byte DHCPOFFER = 2;
        public const Byte DHCPREQUEST = 3;
        public const Byte DHCPACK = 5;

        /*  DHCP Stuff */

        /* PARSING */
        public Byte[] Bytes { get; private set; } = null;
        public Byte OP { get; private set; }
        public uint XID { get; private set; }
        public PhysicalAddress CHADDR { get; private set; }
        private Dictionary<Byte, byte[]> OptionDict = new Dictionary<Byte, byte[]>();

        public P_DHCP(Byte[] ExternalBytes)
        {
            this.Bytes = ExternalBytes;

            OP = (Byte)Extractor.Extract(this.Bytes, 0, typeof(Byte));
            XID = (uint)Extractor.Extract(this.Bytes, 4, typeof(uint));
            CHADDR = (PhysicalAddress)Extractor.Extract(this.Bytes, 28, typeof(PhysicalAddress));

            uint TmpMC = (uint)Extractor.Extract(this.Bytes, BOOTP_BASE_SIZE, typeof(uint));
            // parse options if its truly DHCP
            if (MAGIC_COOKIE.Equals(TmpMC))
            {
                int OptionsPos = DHCP_BASE_SIZE;
                int OptionsSize = this.Bytes.Length;
                Byte CurrentOption = 0;

                while (OptionsPos < OptionsSize)
                {
                    CurrentOption = (byte)Extractor.Extract(this.Bytes, OptionsPos, typeof(byte));

                    // DHCP break
                    if (CurrentOption == 255)
                        break;

                    // DHCP pad
                    if (CurrentOption == 0)
                    {
                        ++OptionsPos;
                        continue;
                    }

                    Byte OptionLen = (byte)Extractor.Extract(this.Bytes, OptionsPos, typeof(byte));
                    OptionDict.Add(CurrentOption, Extractor.Extract(this.Bytes, OptionsPos + 1, OptionLen));
                    
                    OptionsPos += OptionLen;
                }
            }
        }

        /* CRAFTING */

        private P_DHCP(Byte OpCode, uint XID, IPAddress Yiaddr, IPAddress Siaddr, PhysicalAddress Chaddr) {
            Bytes = new byte[1];

            // BOOTP base
            Bytes = Insertor.Insert(Bytes, 0, OpCode);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)1);  // HTYPE
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)6);  // HLEN
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)0);  // HOPS

            Bytes = Insertor.Insert(Bytes, Bytes.Length, XID);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (uint)0); // SECS, FLAG same time
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (uint)0); // CIADDR
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Yiaddr); // YIADDR
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Siaddr); // SIADDR
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (uint)0); // GIADDR

            Bytes = Insertor.Insert(Bytes, Bytes.Length, Chaddr); // MAC has 6B, CHADDR has 16B so fill 10B
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)0, 10);

            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)0, 192); // SNAME + FILE

            Bytes = Insertor.Insert(Bytes, Bytes.Length, MAGIC_COOKIE);
        }

        internal bool IsFor(IPAddress IpRouter)
        {
            OptionDict.TryGetValue(DHCP_OPTION_SERVERID, out byte[] ServerOption);

            // if not mentioned, its for us            
            if (ServerOption == null || ServerOption.Length < 4)
                return true;

            return (C_DHCP.IpDefGate.GetAddressBytes().Equals(ServerOption)) ? true : false;
        }

        internal PhysicalAddress IsBy()
        {
            if (OptionDict.TryGetValue(DHCP_OPTION_CLIENTID, out byte[] ClientOption))
                return new PhysicalAddress(ClientOption);
            else
                return null;
        }

        public static void Send(Device ExitDev, UdpPacket P_UDP, IPAddress Ip_Source, IPAddress Ip_Target, PhysicalAddress MAC_Target)
        {
            if (ExitDev.DEV_Disabled || ExitDev.DEV_DisabledDHCP)
                return;

            IPv4Packet IP4 = new IPv4Packet(Ip_Source, Ip_Target)
            {
                PayloadData = P_UDP.Bytes,
                TimeToLive = 1,
                Protocol = IPProtocolType.UDP,
                PayloadLength = (ushort)P_UDP.Length
            };
            IP4.Checksum = IP4.CalculateIPChecksum();

            ExitDev.SendViaThisDevice(MAC_Target, EthernetPacketType.IpV4, IP4.Bytes);
        }

        internal static byte IdentifyMessageType(byte[] PayloadData)
        {
            if (PayloadData == null || PayloadData.Length <= DHCP_BASE_SIZE)
                return 0;

            byte[] Extract = Extractor.Extract(PayloadData, DHCP_BASE_SIZE, 3);
            
            if (Extract != null && Extract.Length == 3 
                && Extract[0] == DHCP_OPTION_MESSAGETYPE && Extract[1] == 1)
                return Extract[2];

            return 0;
        }

        /*                 BOOTP                        */
        public static UdpPacket BOOTP_w_DHCP_OFFER(TP_DHCP TPD, uint XID_Previous)
        {
            byte[] OptionBytes = new byte[1];

            List<IPAddress> ListRoutersFor3 = new List<IPAddress>
            {
                TPD.DefGateway
            };

            List<IPAddress> ListRoutersFor6 = new List<IPAddress>
            {
                IPAddress.Parse("8.8.8.8")
            };

            // inserting options
            GenerateOption53(ref OptionBytes, DHCPOFFER);
            GenerateOption1(ref OptionBytes, TPD.SubnetMask);
            GenerateOption3(ref OptionBytes, ListRoutersFor3);
            GenerateOption51(ref OptionBytes, T_DHCP.TIMER);
            GenerateOption58(ref OptionBytes, T_DHCP.TIMER_RENEWAL);
            GenerateOption59(ref OptionBytes, T_DHCP.TIMER_REBIND);
            GenerateOption54(ref OptionBytes, TPD.DefGateway);
            GenerateOption6(ref OptionBytes, ListRoutersFor6);
            GenerateOption255(ref OptionBytes);

            // Attach options to P_DHCP
            P_DHCP PD = new P_DHCP(0x02, XID_Previous, IPAddress.Parse("0.0.0.0"), TPD.DefGateway, TPD.MacBind);
            PD.AttachOptions(OptionBytes);

            UdpPacket Udp = new UdpPacket(C_DHCP.Port_UDP_DHCP_ClientToServer, C_DHCP.Port_UDP_DHCP_ServerToClient);
            Udp.PayloadData = PD.Bytes;

            return Udp;
        }

        public static UdpPacket BOOTP_w_DHCP_ACK(TP_DHCP TPD, uint XID_Previous)
        {
            byte[] OptionBytes = new byte[1];

            List<IPAddress> ListRoutersFor3 = new List<IPAddress>
            {
                TPD.DefGateway
            };

            List<IPAddress> ListRoutersFor6 = new List<IPAddress>
            {
                IPAddress.Parse("8.8.8.8")
            };

            // inserting options
            GenerateOption53(ref OptionBytes, DHCPACK);
            GenerateOption1(ref OptionBytes, TPD.SubnetMask);
            GenerateOption3(ref OptionBytes, ListRoutersFor3);
            GenerateOption51(ref OptionBytes, T_DHCP.TIMER);
            GenerateOption58(ref OptionBytes, T_DHCP.TIMER_RENEWAL);
            GenerateOption59(ref OptionBytes, T_DHCP.TIMER_REBIND);
            GenerateOption54(ref OptionBytes, TPD.DefGateway);
            GenerateOption6(ref OptionBytes, ListRoutersFor6);
            GenerateOption255(ref OptionBytes);

            // Attach options to P_DHCP
            P_DHCP PD = new P_DHCP(0x02, XID_Previous, TPD.IpAssigned, TPD.DefGateway, TPD.MacBind);
            PD.AttachOptions(OptionBytes);

            UdpPacket Udp = new UdpPacket(C_DHCP.Port_UDP_DHCP_ClientToServer, C_DHCP.Port_UDP_DHCP_ServerToClient);
            Udp.PayloadData = PD.Bytes;

            return Udp;
        }

        static UdpPacket BOOTP_w_DHCP_DISCOVER()
        {
            throw new NotSupportedException();
        }

        static UdpPacket BOOTP_w_DHCP_REQUEST()
        {
            throw new NotSupportedException();
        }

        private void AttachOptions(byte[] optionBytes)
            => Bytes = Insertor.Insert(Bytes, DHCP_BASE_SIZE, optionBytes, optionBytes.Length);

        /*                     DHCP                            */


        /* DHCP Options Insertion */
        public const Byte DHCP_OPTION_MESSAGETYPE = 53;
        public const Byte DHCP_OPTION_CLIENTID = 61;
        public const Byte DHCP_OPTION_REQIP = 50;
        public const Byte DHCP_OPTION_REQPARAMLIST = 55;
        public const Byte DHCP_OPTION_SUBMASK = 1;
        public const Byte DHCP_OPTION_ROUTER = 3;
        public const Byte DHCP_OPTION_DNS = 6;
        public const Byte DHCP_OPTION_SERVERID = 54;
        public const Byte DHCP_OPTION_LEASETIME = 51;
        public const Byte DHCP_OPTION_RENEWAL = 58;
        public const Byte DHCP_OPTION_REBIND = 59;

        // DHCP Pad
        static void GenerateOption0(ref Byte[] Bytes)
            => Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)0);

        // DHCP Terminate
        static void GenerateOption255(ref Byte[] Bytes)
            => Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)255);

        // DHCP Message type
        static void GenerateOption53(ref Byte[] Bytes, Byte Value)
            => GenerateOptionByte(ref Bytes, DHCP_OPTION_MESSAGETYPE, Value);

        // DHCP Client identification
        static void GenerateOption61(ref Byte[] Bytes, PhysicalAddress MAC)
        {
            Bytes = Insertor.Insert(Bytes, Bytes.Length, DHCP_OPTION_CLIENTID);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)7);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)1);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, MAC);
        }

        // DHCP Requested IP address
        static void GenerateOption50(ref Byte[] Bytes, IPAddress Ip)
            => GenerateOptionIp(ref Bytes, DHCP_OPTION_REQIP, Ip);

        // List of requested params
        static void GenerateOption55(ref Byte[] Bytes, List<Byte> OptionCodes)
        {
            if (OptionCodes == null || OptionCodes.Count == 0)
                return;

            Bytes = Insertor.Insert(Bytes, Bytes.Length, DHCP_OPTION_REQPARAMLIST);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)OptionCodes.Count);
            foreach(Byte OC in OptionCodes)
                Bytes = Insertor.Insert(Bytes, Bytes.Length, OC);
        }

        // Subnet Mask
        static void GenerateOption1(ref Byte[] Bytes, Mask SubnetMask)
            => GenerateOptionIp(ref Bytes, DHCP_OPTION_SUBMASK, SubnetMask != null ? SubnetMask.SubnetMask : null);

        // Router options
        static void GenerateOption3(ref Byte[] Bytes, List<IPAddress> RoutersIp)
            => GenerateOptionListIp(ref Bytes, DHCP_OPTION_ROUTER, RoutersIp);

        // DNS Server list
        static void GenerateOption6(ref Byte[] Bytes, List<IPAddress> DNSsIp)
            => GenerateOptionListIp(ref Bytes, DHCP_OPTION_DNS, DNSsIp);

        // DHCP Server Identificator
        static void GenerateOption54(ref Byte[] Bytes, IPAddress ServerIdIp)
            => GenerateOptionIp(ref Bytes, DHCP_OPTION_SERVERID, ServerIdIp);

        // DHCP Ip Lease Time
        static void GenerateOption51(ref Byte[] Bytes, uint LeaseTime)
            => GenerateOptionUINT(ref Bytes, DHCP_OPTION_LEASETIME, LeaseTime);

        // DHCP Renewal Time
        static void GenerateOption58(ref Byte[] Bytes, uint RenewalTime)
            => GenerateOptionUINT(ref Bytes, DHCP_OPTION_RENEWAL, RenewalTime);

        // DHCP Ip Lease Time
        static void GenerateOption59(ref Byte[] Bytes, uint RebindingTime)
            => GenerateOptionUINT(ref Bytes, DHCP_OPTION_REBIND, RebindingTime);

        private static void GenerateOptionByte(ref Byte[] Bytes, Byte OptionCode, uint Value)
        {
            Bytes = Insertor.Insert(Bytes, Bytes.Length, OptionCode);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)1);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Value);
        }

        private static void GenerateOptionUINT(ref Byte[] Bytes, Byte OptionCode, uint Value)
        {
            Bytes = Insertor.Insert(Bytes, Bytes.Length, OptionCode);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)4);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Value);
        }

        private static void GenerateOptionIp(ref Byte[] Bytes, Byte OptionCode, IPAddress Ip)
        {
            if (Ip == null)
                return;

            Bytes = Insertor.Insert(Bytes, Bytes.Length, OptionCode);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)4);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Ip);
        }

        static void GenerateOptionListIp(ref Byte[] Bytes, Byte OptionCode, List<IPAddress> ListOfIp)
        {
            if (ListOfIp == null || ListOfIp.Count == 0)
                return;

            Bytes = Insertor.Insert(Bytes, Bytes.Length, OptionCode);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)(ListOfIp.Count * 4));
            foreach (IPAddress Ip in ListOfIp)
                Bytes = Insertor.Insert(Bytes, Bytes.Length, Ip);
        }
    }
}
