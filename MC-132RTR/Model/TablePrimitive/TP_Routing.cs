using MC_132RTR.Model.Core;
using MC_132RTR.Model.Support;
using System;
using System.Net;
using System.Windows.Forms;

namespace MC_132RTR.Model.TablePrimitive
{
    public class TP_Routing
    {
        public static readonly int DIRECT = 0;
        public static readonly int STATIC = 1;
        public static readonly int RIP = 120;

        private int testParam;
        public Device ExitDevice { private set; get; }
        public Network Subnet { private set; get; }
        public IPAddress NextHopIp { private set; get; }
        public int Type { private set; get; }

        public TP_Routing(int Type, Device ExitDev, Network SubNet, IPAddress NextHop)
        {
            this.testParam = 0;
            this.ExitDevice = ExitDev;
            this.NextHopIp = NextHop;
            this.Type = Type;
            this.Subnet = SubNet;
        }

        private void RegularStuff()
        {
            ++testParam;
        }

        public ListViewItem ToListViewItem()
        {
            String NetworkColumn = Subnet.ToString();
            String AdminDistanceColumn = Type.ToString();
            String DeviceColumn = (ExitDevice != null) ? ExitDevice.Id : "NO";
            String NextHopColumn = (NextHopIp != null) ? NextHopIp.ToString() : "NO";

            return new ListViewItem(new string[] { NetworkColumn, AdminDistanceColumn, DeviceColumn, NextHopColumn });
        }
    }
}
