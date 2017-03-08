using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarvinEde.CoreExtensionsTest
{
    [TestClass]
    public class DictionaryTest
    {

        protected readonly IDictionary<string, int> test = new Dictionary<string, int>(){{"Present", 1}};

        [TestMethod]
        public void TestFetchWithoutDefault()
        {
            var actualDefault = test.Fetch("NotPresent");
            Assert.AreEqual(0, actualDefault);

            var actualSuccess = test.Fetch("Present");
            Assert.AreEqual(1, actualSuccess);
        }

        [TestMethod]
        public void TestFetchWithFixedDefault()
        {
            var actualDefault = test.Fetch("NotPresent", 42);
            Assert.AreEqual(42, actualDefault);

            var actualSuccess = test.Fetch("Present", 42);
            Assert.AreEqual(1, actualSuccess);
        }

        [TestMethod]
        public void TestFetchWithLazyDefault()
        {
            var actualDefault = test.Fetch("NotPresent", () => 42);
            Assert.AreEqual(42, actualDefault);

            var actualSuccess = test.Fetch("Present", () => 42);
            Assert.AreEqual(1, actualSuccess);
        }


        [TestMethod]
        public void TestFetchLazyness()
        {
            Assert.AreEqual(1, test.Fetch("Present", () => throw new InternalTestFailureException("Error should not have been thrown")));

            Assert.ThrowsException<InternalTestFailureException>(
                () => test.Fetch("NotPresent", () => throw new InternalTestFailureException("Error should not have been thrown")), 
                "Error should have been thrown");
        }
    }
}
