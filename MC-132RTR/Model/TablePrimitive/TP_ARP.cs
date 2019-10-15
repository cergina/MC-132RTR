using MC_132RTR.Model.Core;
using MC_132RTR.Model.Table;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_ARP
    {
        public PhysicalAddress Mac { get; private set; } = null;
        public Device LearnedViaDev { get; private set; } = null;
        public IPAddress Ip { get; private set; } = null;
        private int Validity;

        public TP_ARP(IPAddress Ip, PhysicalAddress Mac, Device LearnedViaDev)
        {
            this.Mac = Mac;
            this.Ip = Ip;
            this.Validity = T_ARP.TIMEOUT;
            this.LearnedViaDev = LearnedViaDev;
        }

        public void RegularOperation()
        {
            Decrement();
        }

        public void Renew(PhysicalAddress value, Device ReceivalDev)
        {
            this.Validity = T_ARP.TIMEOUT;
            this.LearnedViaDev = ReceivalDev;
            this.Mac = value;
        }

        private void Decrement()
        {
            if (this.Validity > 0)
                --this.Validity;
        }

        public void Deactivate()
        {
            this.Validity = 0;
        }

        public bool IsPassable()
        {
            if (Validity > 0)
                return true;
            else
                return false;
        }

        public ListViewItem ToListViewItem()
        {
            String ArpIpColumn = Ip.ToString();
            String ArpMacColumn = Mac.ToString();
            String ArpDevColumn = LearnedViaDev.Id;
            String ArpTTLColumn = Validity.ToString();

            return new ListViewItem(new string[] {ArpIpColumn, ArpMacColumn, ArpDevColumn, ArpTTLColumn });
        }
    }
}
