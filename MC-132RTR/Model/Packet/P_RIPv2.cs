using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public class P_RIPv2
    {
        // command type: 0 bad, 1 req, 2 rep
        public byte CT { get; private set; }
        // must be 2
        public byte Ver { get; private set; }
        // must be zero
        public ushort MBZ { get; private set; }



        // basic header validation
        public bool Validate()
        {
            if (CT == 0 || Ver != 2 || MBZ != 0)
                return false;

            return true;
        }


        public void InitializeRIPv2(bool Request_or_Reply)
        {
            CT = (Request_or_Reply == true) ? (byte)1 : (byte)2;
            Ver = 2;
            MBZ = 0;

            // Insert into packet
        }

        public void 

    }
}
