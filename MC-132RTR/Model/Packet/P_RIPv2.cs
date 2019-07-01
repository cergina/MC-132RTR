using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using MC_132RTR.Model.TablePrimitive;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
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

        public byte[] Bytes = null;
        EthernetPacket Pckt_Eth = null;
        IPv4Packet Pckt_IPv4 = null;
        UdpPacket Pckt_Udp = null;

        private P_RIPv2()
        {
            Bytes = new byte[HEADER_BYTES];
        }

        // basic header validation
        public bool ValidateHeader()
        {
            if (CT == 0 || Ver != 2 || MBZ != 0)
                return false;

            return true;
        }

        public bool IsPartOfThisProtocol(Device Dev_Received, EthernetPacket Pckt_Eth, IPv4Packet Pckt)
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
            P_RIPv2 Pckt = new P_RIPv2();
            Pckt.InitializeRIPv2(true);

            throw new NotSupportedException();
        }

        public static List<P_RIPv2> CraftPeriodicResponses(Device ForThisDevice)
        {
            if (ForThisDevice.DisabledRIPv2)
                return null;

            // init list to return for this specific device
            List<P_RIPv2> ListToReturn = new List<P_RIPv2>();

            P_RIPv2 Pckt = new P_RIPv2();
            Pckt.InitializeRIPv2(false);

            int Curr_RouteIndex = 0;

            foreach (TP_RIPv2 TPR in T_RIPv2.GetInstance().Table.ToList())
            {
                // ignore TablePRimitive that was learned via this device
                if (TPR.OriginDevice.GetDescription(true).Equals(ForThisDevice.GetDescription(true)))
                    continue;

                if (Curr_RouteIndex == PACKET_MAX_ENTRIES)
                {
                    ListToReturn.Add(Pckt);

                    Pckt = new P_RIPv2();
                    Pckt.InitializeRIPv2(false);
                    Curr_RouteIndex = 0;
                }

                int StartB = HEADER_BYTES + (Curr_RouteIndex++ * ENTRY_BYTES);
                uint MetricToUse = (TPR.Metric >= 16) ? (uint)16 : TPR.Metric + 1;

                // insert
                Pckt = P_RIPv2.InsertEntry(Pckt, StartB, TPR.Net, MetricToUse);
            }

            if (Pckt.GetNumberOfRoutesInside() > 0)
                ListToReturn.Add(Pckt);


            return ListToReturn;
        }

        public static P_RIPv2 CraftResponse_ConnectedChange(Network NetOld, Network NetNew)
        {
            if (NetNew == null)
                return null;

            P_RIPv2 Pckt = new P_RIPv2();
            Pckt.InitializeRIPv2(false);

            int StartB = HEADER_BYTES + (0 * ENTRY_BYTES);

            if (NetOld != null)
            {
                InsertEntry(Pckt, StartB, NetOld, (uint)16);
                StartB += ENTRY_BYTES;
            }

            InsertEntry(Pckt, StartB, NetNew, (uint)0);

            return Pckt;
        }

        public static P_RIPv2 CraftImmediateResponse(Network Net, uint Metrics)
        {
            P_RIPv2 Pckt = new P_RIPv2();
            Pckt.InitializeRIPv2(false);

            throw new NotSupportedException();
        }

        public static P_RIPv2 InsertEntry(P_RIPv2 Pckt, int StartB, Network Net, uint MetricToUse)
        {
            Insertor.Insert(Pckt.Bytes,
                    StartB + 0,
                    (ushort)2); // AFI
            Insertor.Insert(Pckt.Bytes,
                StartB + sizeof(ushort),
                (ushort)0); // RouteTag
            Insertor.Insert(Pckt.Bytes,
                StartB + 2 * sizeof(ushort),
                Net.GetNetworkAddress()); // IP
            Insertor.Insert(Pckt.Bytes,
                StartB + 2 * sizeof(ushort) + 4,
                Net.MaskAddress.SubnetMask); // Mask
            Insertor.Insert(Pckt.Bytes,
                StartB + 2 * sizeof(ushort) + 2 * 4,
                IPAddress.Parse("0.0.0.0")); // Mark this as next hop
            Insertor.Insert(Pckt.Bytes,
                StartB + 2 * sizeof(ushort) + 3 * 4,
                MetricToUse);

            return Pckt;
        }
    }
}
