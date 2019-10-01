using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using PacketDotNet;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace MC_132RTR.Model.Packet
{
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

        //TODO this is fucking bullshit or what
        public static void SendResponse(Device Sender, PhysicalAddress MAC_WasSenderIsNowTarget, IPAddress IP_WasSenderIsNowTarget,
           bool IP_Proxy)
        {
            IPAddress AddressToUse = (IP_Proxy) ? IP_WasSenderIsNowTarget : Sender.Network.Address;
            
            ARPPacket Pckt = new ARPPacket(ARPOperation.Response,
                MAC_WasSenderIsNowTarget, 
                IP_WasSenderIsNowTarget,
                Sender.ICapDev.MacAddress,
                AddressToUse);



            Sender.SendViaThisDevice(MAC_WasSenderIsNowTarget, EthernetPacketType.Arp, Pckt.Bytes);
        }

    }
}
