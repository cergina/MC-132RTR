using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Core
{
    class C_ARP
    {
        public static void SendRequest(Device Sender, IPAddress RequestedIp)
        {
            ARPPacket Pckt = new ARPPacket(ARPOperation.Request,
                PhysicalAddress.Parse("00-00-00-00-00-00"),
                RequestedIp,
                Sender.ICapDev.MacAddress,
                Sender.Network.Address);


        }

        public static void SendResponse(Device Sender, PhysicalAddress RequestedMac, 
            IPAddress RequestedIp, IPAddress ProxyIp)
        {
            IPAddress AddressToUse = (ProxyIp != null) ? ProxyIp : Sender.Network.Address;
            ARPPacket Pckt = new ARPPacket(ARPOperation.Response,
                RequestedMac,
                RequestedIp,
                Sender.ICapDev.MacAddress,
                AddressToUse);

            // send
        }
    }
}
