using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using PacketDotNet;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Packet
{
    /*
     * _____________________________________________________________________________
     * | 0              7 | 8             15 | 16            23 | 24            31 |
     * |              HW TYPE                |             Protocol type           |
     * |___________________________________________________________________________|
     * | 32             7 | 8             15 | 16            23 | 24            31 |
     * |    HW.ADD.LENGTH |   PROT.ADD.LEN   |           OP    CODE                |
     * |___________________________________________________________________________|
     * | 64             7 | 8             15 | 16            23 | 24            31 |
     * |                  SENDER MAC                                               |
     * |___________________________________________________________________________|
     * | 96             7 | 8             15 | 16            23 | 24            31 |
     * |                                     |        SENDER IP                    |
     * |___________________________________________________________________________|
     * | 128            7 | 8             15 | 16            23 | 24            31 |
     * |                                     |              TARGET MAC             |
     * |___________________________________________________________________________|
     * | 160            7 | 8             15 | 16            23 | 24            31 |
     * |                                                                           |
     * |___________________________________________________________________________|
     * | 196            7 | 8             15 | 16            23 | 24            31 |
     * |                              TARGET IP                                    |
     * |___________________________________________________________________________|
     */
    class P_ARP
    {
        public static void SendRequest(Device Sender, IPAddress RequestedIp)
        {
            Logging.OutALWAYS("Paket Request, sent by: " + Sender.ToString() +", ip: " + Sender.Network.Address);

            ARPPacket Pckt = new ARPPacket(ARPOperation.Request,
                PhysicalAddress.Parse("00-00-00-00-00-00"),
                RequestedIp,
                Sender.ICapDev.MacAddress,
                Sender.Network.Address);

            Sender.SendViaThisDevice(PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"),
                EthernetPacketType.Arp, Pckt.Bytes);

            C_ARP.GetInstance().AttemptToAddIntoList(RequestedIp);
        }

        /*
         * example
         * Requ: MacSen AAA, IpSen: 111                | MacTar: 000, IpTar: 222
         * Resp: MacSen BBB, IpSen: 222 (AddressToUse) | MacTar: AAA, IpTar: 111
         */
        public static void SendResponse(Device Sender, PhysicalAddress MAC_WasSenderIsNowTarget, 
            IPAddress IP_WasSenderIsNowTarget, IPAddress IP_WasTargetIsNowSource, bool IP_Proxy)
        {
            // whether to use device's IP or proxy IP that was requested
            IPAddress AddressToUse = (IP_Proxy) ? IP_WasTargetIsNowSource : Sender.Network.Address;
            
            ARPPacket Pckt = new ARPPacket(ARPOperation.Response,
                MAC_WasSenderIsNowTarget, 
                IP_WasSenderIsNowTarget,
                Sender.ICapDev.MacAddress,
                AddressToUse);

            Sender.SendViaThisDevice(MAC_WasSenderIsNowTarget, EthernetPacketType.Arp, Pckt.Bytes);
        }

    }
}
