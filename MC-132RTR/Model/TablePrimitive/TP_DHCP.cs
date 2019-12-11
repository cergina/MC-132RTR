using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using MC_132RTR.Model.Table;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace MC_132RTR.Model.TablePrimitive
{
    class TP_DHCP
    {
        public IPAddress IpAssigned { get; private set; } = null;
        public Mask SubnetMask { get; private set; } = null;
        public IPAddress DefGateway { get; private set; } = null;
        public PhysicalAddress MacBind { get; private set; } = null;
        public short Type { get; private set; } = -1;

        public int Timer = 0;

        public TP_DHCP(IPAddress Ip, Mask MaskIp, IPAddress DefGateIp, PhysicalAddress MAC, short Type)
        {
            IpAssigned = Ip;
            SubnetMask = MaskIp;
            DefGateway = DefGateIp;
            MacBind = MAC;
            this.Type = Type;
            Timer = (Type == C_DHCP.MANUAL) ? -1 : T_DHCP.TIMER;
        }

        public ListViewItem ToListViewItem()
        {
            String DHCPIpColumn = IpAssigned.ToString();
            String DHCPMaskColumn = SubnetMask.ToString();
            String DHCPDefGatColumn = DefGateway.ToString();
            String DHCPMacColumn = MacBind.ToString();
            String DHCPTimeColumn = Timer.ToString();
            TypeAsString(out String DHCPTypeColumn);

            return new ListViewItem(new string[] { DHCPIpColumn, DHCPMaskColumn, DHCPDefGatColumn, DHCPMacColumn, DHCPTimeColumn, DHCPTypeColumn });
        }

        private void TypeAsString(out String Column)
        {
            switch (Type)
            {
                case C_DHCP.MANUAL:
                    Column = "MANUAL";
                    return;
                case C_DHCP.AUTOMAT:
                    Column = "AUTO";
                    return;
                case C_DHCP.DYNAMIC:
                    Column = "DYN";
                    return;
                default:
                    Column = "??";
                    return;

            }
        }
    }
}
