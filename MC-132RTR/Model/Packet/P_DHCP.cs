using MC_132RTR.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    class P_DHCP
    {
        public const Byte DHCPDISCOVER = 1;
        public const Byte DHCPOFFER = 2;
        public const Byte DHCPREQUEST = 3;
        public const Byte DHCPACK = 5;




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

        // DHCP Message type
        static void GenerateOption53(ref Byte[] Bytes, Byte Value)
        {
            Bytes = Insertor.Insert(Bytes, Bytes.Length, DHCP_OPTION_MESSAGETYPE);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, (Byte)1);
            Bytes = Insertor.Insert(Bytes, Bytes.Length, Value);
        }

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
