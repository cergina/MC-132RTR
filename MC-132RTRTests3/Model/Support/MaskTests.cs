using Microsoft.VisualStudio.TestTools.UnitTesting;
using MC_132RTR.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MC_132RTR.Model.Support.Tests
{
    [TestClass()]
    public class MaskTests
    {
        Mask DupMask24 = new Mask(IPAddress.Parse("255.255.255.0"));
        Mask TestMask24 = new Mask(IPAddress.Parse("255.255.255.0"));
        Mask TestMask32 = new Mask(IPAddress.Parse("255.255.255.255"));
        Mask TestMask0 = new Mask(IPAddress.Parse("0.0.0.0"));
        Mask TestMask15 = new Mask(IPAddress.Parse("255.254.0.0"));

        [TestMethod()]
        public void ToCIDRTest()
        {
            Assert.IsTrue(TestMask0.ToCIDR() == 0);
            Assert.IsTrue(TestMask15.ToCIDR() == 15);
            Assert.IsTrue(TestMask24.ToCIDR() == 24);
            Assert.IsTrue(TestMask32.ToCIDR() == 32);
        }

        [TestMethod()]
        public void IsGreaterThanTest()
        {
            Assert.IsTrue(TestMask24.IsGreaterThan(TestMask15));
            Assert.IsTrue(TestMask24.IsGreaterThan(TestMask0));
            Assert.IsFalse(TestMask24.IsGreaterThan(TestMask32));
            Assert.IsTrue(TestMask32.IsGreaterThan(TestMask15));
        }

        [TestMethod()]
        public void WhichIsGreaterOrEqualTest()
        {
            Assert.IsTrue(Mask.WhichIsGreaterOrEqual(TestMask0, TestMask15) == 2);
            Assert.IsTrue(Mask.WhichIsGreaterOrEqual(TestMask24, TestMask0) == 1);
            Assert.IsTrue(Mask.WhichIsGreaterOrEqual(TestMask24, DupMask24) == 0);
            Assert.IsTrue(Mask.WhichIsGreaterOrEqual(TestMask15, TestMask32) == 2);

        }

        [TestMethod()]
        public void IsCorrectTest()
        {
            try
            {
                new Mask(IPAddress.Parse("255.255.255.512"));
                Assert.Fail();
            }
            catch (Exception en) { }

            try
            {
                new Mask(IPAddress.Parse("254.0.268.1"));
                Assert.Fail();
            }
            catch (Exception en) { }

            try
            {
                new Mask(IPAddress.Parse("0.0.0.254"));
                Assert.Fail();
            }
            catch (Exception en) { }

            Assert.IsTrue(TestMask15.IsCorrect());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(DupMask24.Equals(TestMask24));
            Assert.IsFalse(DupMask24.Equals(TestMask32));
            Assert.IsFalse(TestMask0.Equals(TestMask15));
            Assert.IsFalse(TestMask0.Equals(TestMask32));
        }
    }
}