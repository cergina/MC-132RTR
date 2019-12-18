using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public static class Extractor
    {
        public static byte[] Extract(byte[] Data, int StartByte, int HowManyBytes)
        {
            if (Data == null || StartByte < 0 || HowManyBytes < 0)
                return null;

            byte[] TempBytes = new byte[HowManyBytes];

            for (int i = 0; i < HowManyBytes; i++)
                TempBytes[i] = Data[StartByte + i];

            return TempBytes;
        }

        public static object Extract(byte[] Data, int StartByte, Type Type)
        {
            if (Type == typeof(byte))
            {
                return (byte)Data[StartByte];
            }
            else if (Type == typeof(ushort))
            {
                return (ushort)BitConverter.ToUInt16(new Byte[2] { Data[StartByte + 1], Data[StartByte] }, 0);
            }
            else if (Type == typeof(uint))
            {
                return (uint)BitConverter.ToUInt32(new Byte[4] { Data[StartByte + 3], Data[StartByte + 2], Data[StartByte + 1], Data[StartByte] }, 0);

            }
            else if (Type == typeof(IPAddress))
            {
                byte[] NewIp = new byte[4];
                Array.Copy(Data, StartByte, NewIp, 0, 4);
                return (IPAddress)new IPAddress(NewIp);
            } else if (Type == typeof(PhysicalAddress))
            {
                byte[] NewMAC = new byte[6];
                Array.Copy(Data, StartByte, NewMAC, 0, 6);
                return (PhysicalAddress)new PhysicalAddress(NewMAC);
            }

            // such Type is not specified
            return null;
        }


        public static PacketDotNet.Packet GetPacket(RawCapture RawCap)
        {
            try
            {
                return PacketDotNet.Packet.ParsePacket(RawCap.LinkLayerType, RawCap.Data);
            }
            catch (Exception exc) { return null; }
        }

        public static EthernetPacket GetEthPacket(PacketDotNet.Packet Pckt) 
            => (EthernetPacket)Pckt.Extract(typeof(EthernetPacket));
        

        public static IPv4Packet GetIPv4Packet(EthernetPacket EthPacket)
            => (IPv4Packet)EthPacket.Extract(typeof(IPv4Packet));
        

        public static UdpPacket GetUdpPacket(IPv4Packet Ipv4Pckt)
            => (UdpPacket)Ipv4Pckt.Extract(typeof(UdpPacket));
        

        public static ARPPacket GetArpPacket(EthernetPacket EthPacket) 
            => (ARPPacket)EthPacket.Extract(typeof(ARPPacket));
        
    }
}
