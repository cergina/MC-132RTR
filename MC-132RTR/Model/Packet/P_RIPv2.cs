﻿using MC_132RTR.Model.Core;
using MC_132RTR.Model.Packet.Items;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
        EthernetPacket Pckt_Eth = null;
        IPv4Packet Pckt_IPv4 = null;
        UdpPacket Pckt_Udp = null;

        public P_RIPv2(byte[] BytesFromOutside)
        {
            if (BytesFromOutside == null)
                Bytes = new byte[HEADER_BYTES];
            else
                FromBytesFillObject(BytesFromOutside);

            UpdateCountsOfEntries();
        }

        // basic header validation
        public static bool ValidateHeader(P_RIPv2 PR)
        {
            if (PR.CT == 0 || PR.Ver != 2 || PR.MBZ != 0)
                return false;

            return true;
        }

        public static bool Validate(P_RIPv2 PR)
        {
            if (!ValidateHeader(PR))
                return false;

            return true;
        }

        public static void UponArrival(P_RIPv2 PR, out bool Okay)
        {
            Okay = false;
            
            if (!Validate(PR))
                return;

            if (IPv4_Checking.CheckUponArrival(PR.Pckt_IPv4))
                Okay = true;
        }

        // GENERAL
        private void UpdateCountsOfEntries()
        {
            EntriesCount = (Bytes.Length - HEADER_BYTES) / ENTRY_BYTES;
        }

        // PARSING 
        public void FromBytesFillObject(byte[] BytesFromOutside)
        {
            Bytes = BytesFromOutside;
            // TODO
        }


        // CRAFTING

        public static void BeforeSend(P_RIPv2 PR, out bool Ok)
        {
            if (!Validate(PR))
            {
                Ok = false;
                return;
            }

            Ok = true;
        }

        public int GetNumberOfRoutesInside()
        {
            if (Bytes == null)
                return -1;

            return (Bytes.Length - HEADER_BYTES) / ENTRY_BYTES;
        }


        public void InitializeRIPv2(bool Request_or_Reply)
        {
            CT = (Request_or_Reply == true) ? (byte)1 : (byte)2;
            Ver = 2;
            MBZ = 0;

            // Insert into packet
            Packet.Insertor.Insert(Bytes, 0, CT);
            Packet.Insertor.Insert(Bytes, 1, Ver);
            Packet.Insertor.Insert(Bytes, 2, MBZ);
        }

        public static P_RIPv2 CraftRequest()
        {
            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(true);

            throw new NotSupportedException();
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

                uint MetricToUse = (TPR.Metric >= 16) ? (uint)16 : TPR.Metric + 1;

                // insert
                I_RIPv2 IR = new I_RIPv2(TPR.Net.GetNetworkAddress(), TPR.Net.MaskAddress.SubnetMask, IPAddress.Parse("0.0.0.0"), MetricToUse);
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
                I_RIPv2 IR_Old = new I_RIPv2(NetOld.GetNetworkAddress(), NetOld.GetMaskIpAddress(), IPAddress.Parse("0.0.0.0"), 16);
                P_RIPv2.InsertEntry(Pckt, order++, IR_Old);
            }

            I_RIPv2 IR_New = new I_RIPv2(NetNew.GetNetworkAddress(), NetNew.GetMaskIpAddress(), IPAddress.Parse("0.0.0.0"), 0);
            P_RIPv2.InsertEntry(Pckt, order, IR_New);

            return Pckt;
        }

        public static P_RIPv2 CraftImmediateResponse(Network Net, uint Metrics)
        {
            P_RIPv2 Pckt = new P_RIPv2(null);
            Pckt.InitializeRIPv2(false);

            throw new NotSupportedException();
        }

        public static P_RIPv2 InsertEntry(P_RIPv2 PR, int order, I_RIPv2 IR)
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

        public static int CalculateStartByte(int order)
        {
            return P_RIPv2.HEADER_BYTES + (order * P_RIPv2.ENTRY_BYTES);
        }

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
