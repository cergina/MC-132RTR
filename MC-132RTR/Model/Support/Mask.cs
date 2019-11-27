using System;
using System.Net;

/*
 * Trieda prevzatá z minuloročného riešenia
 * je plnou autorskou prácou Maroša Čergeťa
 */
namespace MC_132RTR.Model.Support
{
    public class Mask
    {
        public IPAddress SubnetMask { get; set; }

        /***
         *  Classic constructor that takes IP Form of Mask as parameter
         */
        public Mask(IPAddress MaskAddress)
        {
            SubnetMask = MaskAddress;

            if (MaskAddress == null || !IsCorrect())
            {
                throw new Exception("Mask is not valid.");
            }
        }

        /***
         * Converts IP Form of Mask to CIDR 
         * example 0.0.0.0 -> /0; 255.255.192.0 -> /18
         */
        public int ToCIDR()
        {
            // Form 4 Octets of IPv4 Mask
            byte[] tmp = SubnetMask.GetAddressBytes();

            String A = Convert.ToString(tmp[0], 2).PadLeft(8, '0');
            String B = Convert.ToString(tmp[1], 2).PadLeft(8, '0');
            String C = Convert.ToString(tmp[2], 2).PadLeft(8, '0');
            String D = Convert.ToString(tmp[3], 2).PadLeft(8, '0');

            // Join 4 Octets into one big binary string
            String F = A + B + C + D;

            int indexOfTheLastOne = F.LastIndexOf('1');

            /* It returns index -1 if there is none or 0 if there is 1 zero 
               So by ++ it we get mask /0 and /1 adequatly
            */
            return (++indexOfTheLastOne);
        }

        /***
         * Compares masks
         */
        public Boolean IsGreaterThan(Mask SecondMask)
        {
            if (ToCIDR() > SecondMask.ToCIDR())
                return true;   // FIRST IS GREATER
            else
                return false;   // SECOND IS GREATER
        }

        /***
         *  Compares masks
         */
        public static short WhichIsGreaterOrEqual(Mask Mask1, Mask Mask2)
        {
            int tmp1 = Mask1.ToCIDR();
            int tmp2 = Mask2.ToCIDR();

            if (tmp1 == tmp2)
                return 0;   // EQUAL MASKS
            else if (tmp1 > tmp2)
                return 1;   // FIRST IS GREATER
            else
                return 2;   // SECOND IS GREATER
        }

        /***
         * STATUS: FINAL
         * Neccesssary to test if MASK is correct
         */
        public bool IsCorrect()
        {
            /* Only succesive 1's or 0's are ACCEPTED as valid mask */
            byte[] tmp = SubnetMask.GetAddressBytes();

            String A = Convert.ToString(tmp[0], 2).PadLeft(8, '0');
            String B = Convert.ToString(tmp[1], 2).PadLeft(8, '0');
            String C = Convert.ToString(tmp[2], 2).PadLeft(8, '0');
            String D = Convert.ToString(tmp[3], 2).PadLeft(8, '0');

            String F = A + B + C + D;

            // 1 = start, 2 = accept 1's, 3 = Accept 0's, 4 = Error
            int State = 1;
            for (int i = 0; i < 32; i++)
            {
                switch (State)
                {
                    case 1: // Starting STATE
                        if (F[i].Equals('1'))
                            State = 2;
                        else
                            State = 3;
                        break;
                    case 2: // Accepting only 1
                        if (F[i].Equals('0'))
                            State = 3;  // First 0 occured, STATE = 3
                        break;
                    case 3: // Accepting only 0
                        if (F[i].Equals('1'))
                            return false; // STATE = 4, INCORRECT MASK
                        break;
                }
            }

            return true;
        }

        public bool Equals(Mask Mask)
        {
            if (Mask is null)
            {
                return false;
            }

            if (ReferenceEquals(this, Mask))
            {
                return true;
            }

            return Equals(Mask.ToCIDR(), ToCIDR());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType() && Equals(obj as Mask);
        }
    }
}
