using MC_132RTR.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet.Items
{
    /***
     * Class representing an Entry item in RIPv2 Udp part of packet
     */
    public class I_RIPv2
    {
        public ushort Id { get; private set; } = 2;
        public ushort RouteTag { get; private set; } = 0;
        public IPAddress Ip { get; private set; } = null;
        public IPAddress Mask { get; private set; } = null;
        public IPAddress NextHop { get; private set; } = null;
        public uint Metric { get; private set; } = uint.MaxValue;
        //Not inside of packet
        public bool Usable { get; private set; } = false;

        public I_RIPv2(int order, P_RIPv2 PR)
        {
            try
            {
                int StartByte = P_RIPv2.CalculateStartByte(order);
                int TypesYet = 0;

                Id = (ushort)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(ushort));
                TypesYet += sizeof(ushort);
                RouteTag = (ushort)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(ushort));
                TypesYet += sizeof(ushort);
                Ip = (IPAddress)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(IPAddress));
                TypesYet += 4;
                Mask = (IPAddress)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(IPAddress));
                TypesYet += 4;
                NextHop = (IPAddress)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(IPAddress));
                TypesYet += 4;
                Metric = (uint)Extractor.Extract(PR.Bytes, StartByte + TypesYet, typeof(uint));

                DetermineUsability();
            }
            catch (Exception e)
            {
                Usable = false;
            }
        }

        public I_RIPv2(IPAddress Ip, IPAddress Mask, IPAddress NextHop, uint Metric)
        {
            this.Ip = Ip;
            this.Mask = Mask;
            this.NextHop = NextHop;
            this.Metric = Metric;

            DetermineUsability();
        }

        private void DetermineUsability()
        {
            if (Ip == null || Mask == null || NextHop == null || 
                Metric == uint.MaxValue || Id != 2 || RouteTag != 0)
                Usable = false;
            else
                Usable = true;
        }


    }
}
