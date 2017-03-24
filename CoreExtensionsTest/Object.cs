using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void TestTab()
        {
            IList<int> list = new List<int>() { 1, 2, 3 };
            int intermediateCount = list.Tab(l => l.Add(1)).Count();
            Assert.AreEqual(4, intermediateCount);
        }
    }
}
