using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

            Data = MakeBiggerIfNecessary(Data, StartByte, HowManyBytes);
            Array.Copy(Value, 0, Data, StartByte, HowManyBytes);

            return Data;
        }

        public static byte[] Insert(byte[]Data, int StartByte, ushort Value)
        {
            if (Data == null || StartByte < 0)
                return null;

            byte[] ValueBytes = BitConverter.GetBytes((ushort)Value);
            Array.Reverse(ValueBytes);

            Data = MakeBiggerIfNecessary(Data, StartByte, ValueBytes.Length);
            Array.Copy(ValueBytes, 0, Data, StartByte, ValueBytes.Length);

            return Data;
        }

        public static byte[] Insert(byte[] Data, int StartByte, uint Value)
        {
            if (Data == null || StartByte < 0)
                return null;

            byte[] ValueBytes = BitConverter.GetBytes((uint)Value);
            Array.Reverse(ValueBytes);

            Data = MakeBiggerIfNecessary(Data, StartByte, ValueBytes.Length);
            Array.Copy(ValueBytes, 0, Data, StartByte, ValueBytes.Length);

            return Data;
        }

        public static byte[] Insert(byte[] Data, int StartByte, byte Value)
        {
            if (Data == null || StartByte < 0)
                return null;

            Data = MakeBiggerIfNecessary(Data, StartByte, 1);
            Data[StartByte] = Value;

            return Data;
        }

        public static byte[] Insert(byte[] Data, int StartByte, IPAddress Value)
        {
            if (Data == null || StartByte < 0)
                return null;

            byte[] ValueBytes = ((IPAddress)Value).GetAddressBytes();

            Data = MakeBiggerIfNecessary(Data, StartByte, ValueBytes.Length);
            Array.Copy(ValueBytes, 0, Data, StartByte, ValueBytes.Length);

            return Data;
        }

        public static byte[] Insert(byte[] Data, int StartByte, PhysicalAddress Value)
        {
            if (Data == null || StartByte < 0)
                return null;

            byte[] ValueBytes = ((PhysicalAddress)Value).GetAddressBytes();

            Data = MakeBiggerIfNecessary(Data, StartByte, ValueBytes.Length);
            Array.Copy(ValueBytes, 0, Data, StartByte, ValueBytes.Length);

            return Data;
        }

        public static byte[] MakeBiggerIfNecessary(byte[] Data, int StartByte, int HowManyBytes)
        {
            // expand packet if necessary
            if ((StartByte + HowManyBytes) > (Data.Length))
                Array.Resize(ref Data, StartByte + HowManyBytes);

            return Data;
        }
    }
}
