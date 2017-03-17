using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
    }
}
