using MC_132RTR.Model.Core;
using MC_132RTR.Model.Packet.Items;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Packet
{
    /*
    * |===========================================================|
    * |0(0)         7|8(1)        15|16(2)                      31|
    * | Command Type |   Version =2 |          MBZ = 0            | 
    * |===========================================================|
    * |32(4)                      47|48(6)                        |
    * |          ID   =       2     | ROUTE TAG   =     0         |
    * |___________________________________________________________|
    * |64(8)                                                      |
    * |                        SUBNET ADDRESS                     |
    * |___________________________________________________________|
    * |96(12)                                                     |
    * |                       SUBNET MASK                         |   <=  Route Table Entry
    * |___________________________________________________________|
    * |128(16)                                                    |
    * |                         NEXT HOP                          |
    * |___________________________________________________________|
    * |160(20)                                                    |
    * |                          METRIC                           |
    * |===========================================================|   <=  5x32 bites = 5x4 Bytes = 20 Bytes
    */
    public class P_RIPv2
    {
        public static int HEADER_BYTES = 4;
        public static int PACKET_MAX_ENTRIES = 25;
        public static int ENTRY_BYTES = 20;
        public static int MAX_ALLOWED_BYTES = HEADER_BYTES + (ENTRY_BYTES * PACKET_MAX_ENTRIES);

        // command type: 0 bad, 1 req, 2 rep
        public byte CT { get; private set; }
        // must be 2
        public byte Ver { get; private set; }
        // must be zero
        public ushort MBZ { get; private set; }

        public int EntriesCount { get; private set; }
        public byte[] Bytes = null;

        /*                   CONSTRUCTOR                        */
        public P_RIPv2(byte[] BytesFromOutside)
        {
            if (BytesFromOutside == null)
                Bytes = new byte[HEADER_BYTES];
            else
                FromBytesFillObject(BytesFromOutside);

            UpdateCountsOfEntries();
        }

        /*                      PUBLIC                          */
        public static void BeforeSend(P_RIPv2 PR, out bool Ok)
            => Ok = (Validate(PR));

        public static void SendList(Device ExitDev, List<P_RIPv2> LPR, IPAddress IP_Target, PhysicalAddress MAC)
            => LPR.ForEach(PR => { Send(ExitDev, PR, IP_Target, MAC); });

        public static void Send(Device ExitDev, P_RIPv2 PR, IPAddress IP_Target, PhysicalAddress MAC)
        {
            bool Ok;
            BeforeSend(PR, out Ok);

            if (!Ok || ExitDev.DEV_DisabledRIPv2)
                return;

            UdpPacket Udp = new UdpPacket(520, 520);
            Udp.PayloadData = PR.Bytes;

            IPv4Packet IP4 = new IPv4Packet(ExitDev.Network.Address, IP_Target)
            {
                PayloadData = Udp.Bytes,
                TimeToLive = 1,
                Protocol = IPProtocolType.UDP,
                PayloadLength = (ushort)Udp.Length
            };
            IP4.UpdateIPChecksum();

            ExitDev.SendViaThisDevice(MAC, EthernetPacketType.IpV4, IP4.Bytes);
        }

        public static int CalculateStartByte(int order)
            => P_RIPv2.HEADER_BYTES + (order * P_RIPv2.ENTRY_BYTES);

        public static bool Validate(P_RIPv2 PR)
            => ValidateHeader(PR); // && more stuff ? maybe?

        // PARSING
        public static IPv4Packet UponArrival(P_RIPv2 PR, IPv4Packet IPv4, out bool Okay)
        {
            Okay = false;
            
            if (Validate(PR) && IPv4_Checking.CheckUponArrival(IPv4))
                Okay = true;

            return IPv4;
        }


        // CRAFTING
        public static P_RIPv2 CraftRequest(IPAddress NetworkIp)
        {
            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(true);

            IPAddress AllZero = C_RIPv2.IP_NH_THIS;

            P_RIPv2.InsertEntry(Pckt, 0, new I_RIPv2(NetworkIp, AllZero, AllZero, 0));

            return Pckt;
        }

        public static P_RIPv2 CraftTriggeredResponse(Device CameFromDev, P_RIPv2 PR, IPv4Packet IPv4)
        {
            bool AlreadyTriggered = false;
            P_RIPv2 PR_Trig = new P_RIPv2(null);

            for (int i = 0, order = 0; i < PR.EntriesCount; i++)
            {
                I_RIPv2 IR = new I_RIPv2(i, PR);

                if ((!IR.Usable) || (IR.Metric == TP_RIPv2.INFINITY))
                    continue;

                IPAddress ViaIp = (IR.NextHop.Equals(C_RIPv2.IP_NH_THIS)) ? IPv4.SourceAddress : IR.NextHop;

                T_RIPv2.GetInstance().AttemptToIntegrateOutsider(out bool Trigger, IR, ViaIp);

                // Determine whether to insert into Triggered packet or to create it or nothing
                if (Trigger && AlreadyTriggered)
                    P_RIPv2.InsertEntry(PR_Trig, order++, IR.PrepareToResend());
                else if (Trigger && !AlreadyTriggered)
                {
                    PR_Trig.InitializeRIPv2(false);
                    AlreadyTriggered = true;
                }
            }
            
            return PR_Trig;
        }

        public static List<P_RIPv2> CraftPeriodicResponses(Device ForThisDevice)
        {
            if (ForThisDevice.DEV_DisabledRIPv2)
                return null;

            // init list to return for this specific device
            List<P_RIPv2> ListToReturn = new List<P_RIPv2>();

            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(false);

            int Curr_RouteIndex = 0;

            foreach (TP_RIPv2 TPR in T_RIPv2.GetInstance().Table.ToList())
            {
                // ignore TablePRimitive that was learned via this device
                if (TPR.OriginDevice.Equals(ForThisDevice))
                    continue;

                if (Curr_RouteIndex == PACKET_MAX_ENTRIES)
                {
                    ListToReturn.Add(Pckt);

                    Pckt = new P_RIPv2(null);
                    Pckt.InitializeRIPv2(false);
                    Curr_RouteIndex = 0;
                }

                uint MetricToUse = (TPR.Metrics >= TP_RIPv2.INFINITY) ? TP_RIPv2.INFINITY : TPR.Metrics + 1;

                // insert
                I_RIPv2 IR = new I_RIPv2(TPR.Net.GetNetworkAddress(), TPR.Net.MaskAddress.SubnetMask, C_RIPv2.IP_NH_THIS, MetricToUse);
                Pckt = P_RIPv2.InsertEntry(Pckt, Curr_RouteIndex++, IR);
            }

            if (Pckt.GetNumberOfRoutesInside() > 0)
                ListToReturn.Add(Pckt);

            return ListToReturn;
        }

        public static P_RIPv2 CraftResponse_ConnectedChange(Network NetOld, Network NetNew)
        {
            if (NetNew == null)
                return null;

            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(false);
            int order = 0;

            if (NetOld != null)
            {
                I_RIPv2 IR_Old = new I_RIPv2(NetOld.GetNetworkAddress(), NetOld.GetMaskIpAddress(), C_RIPv2.IP_NH_THIS, TP_RIPv2.INFINITY);
                P_RIPv2.InsertEntry(Pckt, order++, IR_Old);
            }

            I_RIPv2 IR_New = new I_RIPv2(NetNew.GetNetworkAddress(), NetNew.GetMaskIpAddress(), C_RIPv2.IP_NH_THIS, 0);
            P_RIPv2.InsertEntry(Pckt, order, IR_New);

            return Pckt;
        }

        public static P_RIPv2 CraftResponseUponRequest(P_RIPv2 PR_Req)
        {
            P_RIPv2 PR_New = new P_RIPv2(null);
            PR_New.InitializeRIPv2(false);
            
            for (int i_req = 0; i_req < PR_Req.EntriesCount; i_req++)
            {
                I_RIPv2 IR = new I_RIPv2(i_req, PR_Req);

                I_RIPv2 IR_New = new I_RIPv2(IR.Ip, IR.Mask, C_RIPv2.IP_NH_THIS,
                    T_RIPv2.GetInstance().MetricsForRoute(IR.Ip, IR.Mask));

                P_RIPv2.InsertEntry(PR_New, i_req, IR_New);
            }

            return PR_New;
        }

        public static P_RIPv2 CraftImmediateResponse(Network Net, uint Metrics)
        {
            if (Net == null)
                return null;

            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(false);

            I_RIPv2 IR = new I_RIPv2(Net.GetNetworkAddress(), Net.GetMaskIpAddress(), C_RIPv2.IP_NH_THIS, Metrics);
            P_RIPv2.InsertEntry(Pckt, 0, IR);

            return Pckt;
        }
        
        /*                   PRIVATE                          */
        private void FromBytesFillObject(byte[] BytesFromOutside)
            => Bytes = BytesFromOutside;

        private void InitializeRIPv2(bool Request_or_Reply)
        {
            CT = (Request_or_Reply == true) ? (byte)1 : (byte)2;
            Ver = 2;
            MBZ = 0;

            // Insert into packet
            Packet.Insertor.Insert(Bytes, 0, CT);
            Packet.Insertor.Insert(Bytes, 1, Ver);
            Packet.Insertor.Insert(Bytes, 2, MBZ);
        }

        private static bool ValidateHeader(P_RIPv2 PR)
        {
            if (PR.CT == 0 || PR.Ver != 2 || PR.MBZ != 0)
                return false;

            return true;
        }

        private void UpdateCountsOfEntries() 
            => EntriesCount = (Bytes.Length - HEADER_BYTES) / ENTRY_BYTES;
        

        private static P_RIPv2 InsertEntry(P_RIPv2 PR, int order, I_RIPv2 IR)
        {
            int StartB = CalculateStartByte(order);
            int TypesYet = 0;

            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.Id); // AFI
            TypesYet += sizeof(ushort);
            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.RouteTag); // RouteTag
            TypesYet += sizeof(ushort);
            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.Ip); // Ip
            TypesYet += 4;
            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.Mask); // Mask
            TypesYet += 4;
            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.NextHop); // NextHop
            TypesYet += 4;
            Insertor.Insert(PR.Bytes, StartB + TypesYet, IR.Metric); // Metric

            return PR;
        }

        private int GetNumberOfRoutesInside()
            => (Bytes == null) ? -1 : (Bytes.Length - HEADER_BYTES) / ENTRY_BYTES;










        /*public bool IsPartOfThisProtocol(Device Dev_Received, EthernetPacket Pckt_Eth, IPv4Packet Pckt)
        {
            this.Pckt_Eth = Pckt_Eth;
            this.Pckt_IPv4 = Pckt;

            if (Pckt_Eth == null || Pckt_IPv4 == null)
                return false;

            if (Pckt_IPv4.Checksum == Pckt_IPv4.CalculateIPChecksum())
                return false;

            this.Pckt_Udp = (UdpPacket)Pckt_IPv4.Extract(typeof(UdpPacket));

            if (Pckt_Udp == null || (Pckt_Udp.SourcePort != 520 && Pckt_Udp.DestinationPort != 520))
                return false;

            // it also has to match format of IP and MAC {unicast || multicast}
            Byte[] Pckt_DestIp = Pckt_IPv4.DestinationAddress.GetAddressBytes();
            Byte[] Pckt_DestMac = Pckt_Eth.DestinationHwAddress.GetAddressBytes();

            Byte[] DestIp_MUL = IPAddress.Parse("224.0.0.9").GetAddressBytes();
            Byte[] DestMac_MUL = PhysicalAddress.Parse("01-00-5E-00-00-09").GetAddressBytes();

            byte[] IP_Dev = Dev_Received.Network.GetNetworkAddress().GetAddressBytes();
            byte[] MAC_Dev = Dev_Received.ICapDev.MacAddress.GetAddressBytes();

            if (Pckt_DestIp.SequenceEqual(IP_Dev))
                return true;

            if (Pckt_DestIp.SequenceEqual(DestIp_MUL) && Pckt_DestMac.SequenceEqual(DestMac_MUL))
                return true;

            return false;
        }*/
    }
}
