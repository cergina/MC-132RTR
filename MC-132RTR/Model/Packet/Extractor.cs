using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public static class Extractor
    {
        public static byte[] Extract(byte[] Data, int StartByte, int HowManyBytes)
        {
            if (Data == null || StartByte < 0 || HowManyBytes < 0)
                return null;

            byte[] TempBytes = new byte[HowManyBytes];

            for (int i = 0; i < HowManyBytes; i++)
                TempBytes[i] = Data[StartByte + i];

            return TempBytes;
        }

        public static object Extract(byte[] Data, int StartByte, Type Type)
        {
            if (Type == typeof(byte))
            {
                return (byte)Data[StartByte];
            }
            else if (Type == typeof(ushort))
            {
                return (ushort)BitConverter.ToUInt16(new Byte[2] { Data[StartByte + 1], Data[StartByte] }, 0);
            }
            else if (Type == typeof(uint))
            {
                return (uint)BitConverter.ToUInt32(new Byte[4] { Data[StartByte + 3], Data[StartByte + 2], Data[StartByte + 1], Data[StartByte] }, 0);

            }
            else if (Type == typeof(IPAddress))
            {
                byte[] NewIp = new byte[4];
                Array.Copy(Data, StartByte, NewIp, 0, 4);
                return (IPAddress)new IPAddress(NewIp);
            }

            // such Type is not specified
            return null;
        }
    }
}
