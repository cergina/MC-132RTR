using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace MC_132RTR.Model.Support.Tests
{
    [TestClass()]
    public class NetworkTests
    {
        IPAddress DefIp = IPAddress.Parse("192.168.11.1");
        IPAddress DefMask = IPAddress.Parse("255.255.254.0");

        IPAddress DefGeneralIp = IPAddress.Parse("192.168.10.0");
        IPAddress DefBroadast = IPAddress.Parse("192.168.11.255");

        [TestMethod()]
        public void GetBroadcastAddressTest()
        {
            Network Net = new Network(DefIp, new Mask(DefMask));
            Assert.IsNotNull(Net);

            IPAddress BroadcastIpTest = Net.GetBroadcastAddress();
            Assert.IsNotNull(BroadcastIpTest);
            Assert.AreEqual<IPAddress>(DefBroadast, BroadcastIpTest);
        }

        [TestMethod()]
        public void GetNetworkAddressTest()
        {
            Network Net = new Network(DefIp, new Mask(DefMask));
            Assert.IsNotNull(Net);

            IPAddress NetworkGeneral = Net.GetNetworkAddress();
            Assert.IsNotNull(NetworkGeneral);
            Assert.AreEqual<IPAddress>(DefGeneralIp, NetworkGeneral);
        }

        [TestMethod()]
        public void IsInSameSubnetTest()
        {
            Network Net = new Network(DefIp, new Mask(DefMask));
            Assert.IsNotNull(Net);

            List<Network> ListNetOk = new List<Network>();
            ListNetOk.Add(new Network("192.168.10.0", "255.255.254.0"));
            ListNetOk.Add(new Network("192.168.11.255", "255.255.254.0"));
            ListNetOk.Add(new Network("192.168.10.185", "255.255.254.0"));
            ListNetOk.Add(new Network("192.168.11.129", "255.255.254.0"));

            List<Network> ListNetNotOk = new List<Network>();
            ListNetNotOk.Add(new Network("192.168.9.255", "255.255.254.0"));
            ListNetNotOk.Add(new Network("192.168.12.0", "255.255.254.0"));
            ListNetNotOk.Add(new Network("192.168.11.5", "255.255.255.0"));
            ListNetNotOk.Add(new Network("192.168.10.4", "255.255.255.0"));
            ListNetNotOk.Add(new Network("192.168.10.4", "255.255.255.0"));

            // should be ok
            foreach (Network LOK in ListNetOk)
                Assert.IsTrue(Net.IsInSameSubnet(LOK));

            // should not be ok
            foreach (Network LNOK in ListNetNotOk)
                Assert.IsFalse(Net.IsInSameSubnet(LNOK));
        }

        [TestMethod()]
        public void IsWithinNetworkRangeTest()
        {
            Network Net = new Network(DefIp, new Mask(DefMask));
            Assert.IsNotNull(Net);

            Assert.IsTrue(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.10.0")));
            Assert.IsTrue(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.11.255")));
            Assert.IsTrue(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.10.198")));

            Assert.IsFalse(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.9.255")));
            Assert.IsFalse(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.12.0")));
            Assert.IsFalse(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.12.49")));
            Assert.IsFalse(Net.IsWithinNetworkRange(IPAddress.Parse("192.168.4.5")));
        }

        [TestMethod()]
        public void IsCorrectTest()
        {
            List<Network> ListOk = new List<Network>();
            ListOk.Add(new Network(DefGeneralIp, new Mask(DefMask)));
            ListOk.Add(new Network("172.168.11.5", "255.0.0.0"));
            ListOk.Add(new Network("10.0.0.1", "255.128.0.0"));
            ListOk.Add(new Network("12.12.12.9", "254.0.0.0"));

            // True
            foreach (Network Ok in ListOk)
                Assert.IsTrue(Ok.IsCorrect());

            // False
            try
            {
                Assert.IsFalse((new Network("192.168.11.1", "128.0.255.0")).IsCorrect());
                Assert.Fail();
            } catch (Exception e) { };
            try
            {
                Assert.IsFalse((new Network(null, "255.255.0.0")).IsCorrect());
                Assert.Fail();
            }
            catch (Exception e) { };
        }
    }
}