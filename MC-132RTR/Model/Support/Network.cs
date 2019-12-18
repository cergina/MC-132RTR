using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

/*
 * Trieda prevzatá z minuloročného riešenia
 * je plnou autorskou prácou Maroša Čergeťa
 */
namespace MC_132RTR.Model.Support
{
    public class Network
    {
        public IPAddress Address { get; private set; }
        public Mask MaskAddress { get; private set; }

        /***
         * Constructor that allows to create an object of this class
         */
        public Network(IPAddress AddressCreate, Mask MaskCreate)
        {
            Address = AddressCreate;
            MaskAddress = MaskCreate;
        }

        public Network(String Ip, String MaskIp)
        {
            Address = IPAddress.Parse(Ip);
            MaskAddress = new Mask(IPAddress.Parse(MaskIp));
        }

        /***
         * STATUS: FINAL
         * Get broadcast address for the subnet in which this instance is
         */
        public IPAddress GetBroadcastAddress()
        {
            byte[] ipAdressBytes = Address.GetAddressBytes();
            byte[] SubnetMaskBytes = MaskAddress.SubnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != SubnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP Address and Subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (SubnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }

        /***
         * STATUS: FINAL
         * Get the network address in which this instance is
         */
        public IPAddress GetNetworkAddress()
        {
            byte[] ipAdressBytes = Address.GetAddressBytes();
            byte[] SubnetMaskBytes = MaskAddress.SubnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != SubnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP Address and Subnet mask do not match.");

            byte[] networkAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < networkAddress.Length; i++)
            {
                networkAddress[i] = (byte)(ipAdressBytes[i] & (SubnetMaskBytes[i]));
            }
            return new IPAddress(networkAddress);
        }

        public IPAddress GetMaskIpAddress()
        {
            return MaskAddress.SubnetMask;
        }

        /***
         * Created because too many references to general network were used
         */
        public Network GetNetworkGeneral()
        {
            return new Network(GetNetworkAddress(), MaskAddress);
        }

        /***
         * STATUS: FINAL
         * We want to know if 172.168.10.14/24 and 172.168.10.19/24 are in the same subnet
         * Call: (NetworkInstance).IsInSameSubnet(Network)
         */
        public bool IsInSameSubnet(Network NetworkTmp)
        {
            // get SubnetAddresses
            IPAddress NetworkSubnet = GetNetworkAddress();
            IPAddress NetworkTmpSubnet = NetworkTmp.GetNetworkAddress();

            Byte[] NetSub = NetworkSubnet.GetAddressBytes();
            Byte[] NetTmpSub = NetworkTmpSubnet.GetAddressBytes();

            // Compare if the Subnet is the same
            return NetSub.SequenceEqual(NetTmpSub) && NetworkTmp.MaskAddress.Equals(MaskAddress);
        }

        /***
         * STATUS: FINAL
         * We want to know if 172.168.10.15 is within network eg.: 172.168.10.14/24
         * => get network of 172.168.10.14 with the same mask as instance and compare to instance network broadcast.
         * Call: (NetworkInstance).IsWithinNetworkRange(IPAddress)
         */
        public bool IsWithinNetworkRange(IPAddress IPAddress) //0.0.0.0 /0 . 0.15.16.20
        {
            Network NetworkTmp = new Network(IPAddress, MaskAddress);  // 10.15.16.20/0 => 0.0.0.0

            IPAddress NetworkSubnet = GetNetworkAddress();  //0.0.0.0/0 = > 0.0.0.0 
            IPAddress NetworkTmpSubnet = NetworkTmp.GetNetworkAddress();

            Byte[] NetSub = NetworkSubnet.GetAddressBytes();
            Byte[] NetTmpSub = NetworkTmpSubnet.GetAddressBytes();

            return NetSub.SequenceEqual(NetTmpSub);
        }

        /***
         * STATUS: FINAL
         * Neccesssary to test if Network Object is correct
         * IPAddress has to exist && Mask has to be of correct format
         */
        public bool IsCorrect()
        {
            if (Address == null || (MaskAddress.IsCorrect() == false))
                return false;

            return true;
        }

        public bool Equals(Network NetSubArg)
        {
            Byte[] AddressBytes = Address.GetAddressBytes();
            Byte[] MaskBytes = MaskAddress.SubnetMask.GetAddressBytes();

            Byte[] ArgAddressBytes = NetSubArg.Address.GetAddressBytes();
            Byte[] ArgMaskBytes = NetSubArg.MaskAddress.SubnetMask.GetAddressBytes();

            if (AddressBytes.SequenceEqual(ArgAddressBytes) == false)
                return false;

            if (MaskBytes.SequenceEqual(ArgMaskBytes) == false)
                return false;

            return true;
        }

        public static Dictionary<IPAddress, bool> GetListOfIntermezzoIp(IPAddress FirstIp, IPAddress LastIp, IPAddress AvoidIp, bool IncorporateArguments)
        {
            Dictionary<IPAddress, bool> Tmp = new Dictionary<IPAddress, bool>();

            if (IncorporateArguments && !FirstIp.Equals(AvoidIp))
                Tmp.Add(FirstIp, true);

            // not changed
            uint L0 = LastIp.GetAddressBytes()[0];
            uint L1 = LastIp.GetAddressBytes()[1];
            uint L2 = LastIp.GetAddressBytes()[2];
            uint L3 = LastIp.GetAddressBytes()[3];

            // changed
            uint T0 = FirstIp.GetAddressBytes()[0];
            uint T1 = FirstIp.GetAddressBytes()[1];
            uint T2 = FirstIp.GetAddressBytes()[2];
            uint T3 = FirstIp.GetAddressBytes()[3];

            while (true)
            {
                // 193.x.x.x vs 192.x.x.x
                if (T0 > L0)
                    break;

                // 192.5.x.x vs 192.4.x.x
                if (T0 == L0 && T1 > L1)
                    break;

                // 192.5.80.x vs 192.5.78.x
                if (T0 == L0 && T1 == L1 && T2 > L2)
                    break;

                // 192.5.80.92 vs 192.5.80.91
                if (T0 == L0 && T1 == L1 && T2 == L2 && T3 > L3)
                    break;

                // after this part it is sure that we can increment IP
                uint NewIp = (T0 << 24) | (T1 << 16) | (T2 << 8) | T3;
                ++NewIp;

                T3 = NewIp & 255;
                T2 = (NewIp >> 8) & 255;
                T1 = (NewIp >> 16) & 255;
                T0 = (NewIp >> 24) & 255;

                IPAddress IpToAdd = IPAddress.Parse($"{T0}.{T1}.{T2}.{T3}");
                if (!IpToAdd.Equals(AvoidIp))
                    Tmp.Add(IpToAdd, true);
            }

            if (IncorporateArguments && !LastIp.Equals(AvoidIp))
                Tmp.Add(LastIp, true);

            return Tmp;
        }

        public override string ToString()
        {
            return Address.ToString() + "/" + MaskAddress.ToCIDR();
        }
    }
}
