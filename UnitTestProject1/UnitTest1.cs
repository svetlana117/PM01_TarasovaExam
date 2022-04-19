using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using dll;

namespace UnitTestProject1
{
    [TestClass]

    public class UnitTest1
    {
        Dll d;

        [TestMethod]
        public void TestMethod1()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(20, 0), 0.15);
        }

        [TestMethod]
        public void TestMethod2()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(15, 0), 0, 15);
        }

        [TestMethod]
        public void TestMethod3()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(6, 0), 0.1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(1, 0), 0.00);
        }

        [TestMethod]
        public void TestMethod5()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(5, 500), 0.11);
        }

        [TestMethod]
        public void TestMethod6()
        {
            d = new Dll();
            Assert.AreEqual(dll.Dll.SaleCost(6, 999), 0.11);
        }

        [TestMethod]
        public void TestMethod7()
        {
            d = new Dll();
            Assert.ThrowsException<AssertFailedException>(() => (Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => dll.Dll.SaleCost(-1, -1))));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.ThrowsException<AssertFailedException>(() => (Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => dll.Dll.SaleCost(0, 0))));
        }
        [TestMethod]
        public void TestMethod9()
        {
            Assert.ThrowsException<AssertFailedException>(() => (Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => dll.Dll.SaleCost(0, 500.5)))) ;
        }
        [TestMethod]
        public void TestMethod10()
        {
            Assert.AreEqual(dll.Dll.SaleCost(5, 500.5), 0.11);
        }
    }
}
