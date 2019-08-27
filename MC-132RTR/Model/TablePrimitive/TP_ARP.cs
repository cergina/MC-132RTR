using MC_132RTR.Model.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_ARP
    {
        private PhysicalAddress Mac = null;
        private IPAddress Ip = null;
        private int Validity;

        public TP_ARP(IPAddress Ip, PhysicalAddress Mac)
        {
            this.Mac = Mac;
            this.Ip = Ip;
            this.Validity = T_ARP.TIMEOUT;
        }

        // will be called by some thread
        private void RegularDecrement()
        {
            if (this.Validity > 0)
                --this.Validity;
        }

        public void Renew()
        {
            this.Validity = T_ARP.TIMEOUT;
        }

        public void Deactivate()
        {
            this.Validity = 0;
        }

        public bool Matches(IPAddress Adept)
        {
            if (Adept.GetAddressBytes().Equals(
                this.Ip.GetAddressBytes()))
                return true;
            else
                return false;
        }

        public TP_ARP ReturnIfSuitable(IPAddress Adept) {
            if (Adept == null)
                return null;

            if (Matches(Adept))
                return this;
            
            return null;
        }

        public bool IsPassable()
        {
            if (Validity > 0)
                return true;
            else
                return false;
        }

        public PhysicalAddress GetMAC()
        {
            return this.Mac;
        }
    }
}
