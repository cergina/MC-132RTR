using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC_132RTR.Model.Packet
{
    public static class Insertor
    {
        public static byte[] Insert(byte[] Data, int StartByte, byte[] Value, int HowManyBytes)
        {
            if (Data == null || Value == null || StartByte < 0 || HowManyBytes < 0)
                return null;

            // expand packet if necessary
            if ((StartByte + HowManyBytes) > (Data.Length))
                Array.Resize(ref Data, StartByte + HowManyBytes);

            // only insert as many Bytes as necessary
            for (int i = 0; i < HowManyBytes; i++)
                Data[StartByte + i] = Value[i];

            return Data;
        }

        public static byte[] Insert(byte[] Data, int StartByte, object Value)
        {
            if (Data == null || StartByte < 0 || Value == null)
                return null;

            if (Value is byte)
            {
                Data[StartByte] = (byte)Value;
            } else if (Value is ushort)
            {
                byte[] ValueBytes = BitConverter.GetBytes((ushort)Value);
                Data[StartByte + 1] = ValueBytes[0];
                Data[StartByte] = ValueBytes[1];
            } else if (Value is uint)
            {
                byte[] ValueBytes = BitConverter.GetBytes((ushort)Value);
                Data[StartByte + 3] = ValueBytes[0];
                Data[StartByte + 2] = ValueBytes[1];
                Data[StartByte + 1] = ValueBytes[2];
                Data[StartByte] = ValueBytes[3];
            } else if (Value is IPAddress)
            {
                byte[] ValueBytes = ((IPAddress)Value).GetAddressBytes();
                Array.Copy(ValueBytes, 0, Data, StartByte, ValueBytes.Length);
            }

            return Data;
        }

    }
}
