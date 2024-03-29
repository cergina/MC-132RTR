﻿using MC_132RTR.Model.Core;
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
        public uint Type { get; private set; } = C_DHCP.NOTHING;
        public bool SucceededWithManual { get;  set; } = false;

        public uint Timer = 0;

        public bool Holding = false;
        public Byte Temporary = 20;

        public TP_DHCP(IPAddress Ip, Mask MaskIp, IPAddress DefGateIp, PhysicalAddress MAC, uint Type, bool Temporary)
        {
            IpAssigned = Ip;
            SubnetMask = MaskIp;
            DefGateway = DefGateIp;

            MacBind = MAC;
            this.Type = Type;
            Timer = (Type == C_DHCP.MANUAL) ? 0 : T_DHCP.TIMER; // because he did not ask yet

            Holding = Temporary;
        }

        public ListViewItem ToListViewItem()
        {
            String DHCPIpColumn = IpAssigned.ToString();
            String DHCPMaskColumn = SubnetMask.SubnetMask.ToString();
            String DHCPDefGatColumn = DefGateway.ToString();
            String DHCPMacColumn = MacBind.ToString();
            String DHCPTimeColumn = Timer.ToString();
            String DHCPHoldColumn = (Holding) ? Temporary.ToString() : "NOT";
            TypeAsString(out String DHCPTypeColumn);

            return new ListViewItem(new string[] { DHCPIpColumn, DHCPMaskColumn, DHCPDefGatColumn, DHCPMacColumn, DHCPTimeColumn, DHCPTypeColumn, DHCPHoldColumn });
        }

        private void TypeAsString(out String Column)
        {
            switch (Type)
            {
                case C_DHCP.MANUAL:
                    Column = C_DHCP.MANUAL_S;
                    return;
                case C_DHCP.AUTOMAT:
                    Column = C_DHCP.AUTOMAT_S;
                    return;
                case C_DHCP.DYNAMIC:
                    Column = C_DHCP.DYNAMIC_S;
                    return;
                default:
                    Column = "??";
                    return;
            }
        }

        internal void Refresh()
            => Timer = T_DHCP.TIMER;

        internal void SucceedByManual(TP_DHCP TPD_IT_MANUAL)
        {
            if (TPD_IT_MANUAL == null)
                return;

            if (TPD_IT_MANUAL.MacBind.Equals(this.MacBind))
            {
                T_DHCP.GetInstance().MakeReservedAvailable(this.IpAssigned);
                SucceededWithManual = true;
            }
        }
    }
}
