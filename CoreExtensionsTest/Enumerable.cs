using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Numerics;

namespace MarvinEde.CoreExtensionsTest
{
    [TestClass]
    public class Enumerable
    {
        protected IEnumerable<string> test = new List<string> { "Present", "AlsoPresent" };

        [TestMethod]
        public void TestIsIn()
        {
            Assert.IsTrue("Present".IsIn(test));
            Assert.IsFalse("NotPresent".IsIn(test));
        }

        [TestMethod]
        public void TestSum()
        {
            Assert.AreEqual(6, new int[] { 1, 2, 3 }.Sum());
            Assert.AreEqual(6, new long[] { 1, 2, 3 }.Sum());
            Assert.AreEqual(6, new short[] { 1, 2, 3 }.Sum());
            Assert.AreEqual(6, new BigInteger[] { 1, 2, 3 }.Sum());
            Assert.AreEqual(6, new double[] { 1, 2, 3 }.Sum());
            Assert.AreEqual(6, new float[] { 1, 2, 3 }.Sum());
        }
    }
}
