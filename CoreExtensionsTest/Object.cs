using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarvinEde.CoreExtensionsTest
{
    [TestClass]
    public class Object
    { 
        [TestMethod]
        public void TestSwap()
        {
            string a = "a";
            string b = "b";

            this.Swap(ref a, ref b);

            Assert.AreEqual("a", b);
            Assert.AreEqual("b", a);
        }
    }
}
