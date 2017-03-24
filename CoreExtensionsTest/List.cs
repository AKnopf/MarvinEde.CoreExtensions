using MarvinEde.CoreExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvinEde.CoreExtensionsTest
{
    [TestClass]
    public class List
    {

        protected readonly IList<int> empty = new List<int>();
        protected readonly IList<int> one = new List<int>() { 3 };
        protected readonly IList<int> odd = new List<int>() { 1, 2, 3 };
        protected readonly IList<int> even = new List<int>() { 1, 2, 3, 4 };

        [TestMethod]
        public void TestEachSliceEmpty()
        {
            empty.EachSlice((left, right) => throw new AssertFailedException("Lambda should not be evaluated"));
            Assert.IsFalse(empty.EachSlice((left, right) => left + right).Any());
        }

        [TestMethod]
        public void TestEachSliceOneAction()
        {
            int called = 0;
            one.EachSlice((left, right) =>
            {
                called += 1;
                Assert.AreEqual(3, left);
                Assert.AreEqual(default(int), right);
            });
            Assert.AreEqual(1, called);
        }

        [TestMethod]
        public void TestEachSliceOneFunction()
        {
            var actual = one.EachSlice((left, right) => left + right);
            Assert.AreEqual(1, actual.Count(), "Result should have one item");
            Assert.AreEqual(3, actual.First(), "Item should be 3");
        }

        [TestMethod]
        public void TestEachSliceOneIterator()
        {
            var actual = one.EachSlice();
            Assert.AreEqual(1, actual.Count(), "Result should have one item");
            Assert.AreEqual(3, actual.First().Item1, "Item should be 3");
        }

        [TestMethod]
        public void TestEachSliceOddAction()
        {
            IList<int> accumulatedList = new List<int>();
            odd.EachSlice((left, right) =>
            {
                accumulatedList.Add(left);
                accumulatedList.Add(right);
            });
            Assert.AreEqual(4, accumulatedList.Count());
            Assert.AreEqual(6, accumulatedList.Aggregate(0, (acc, number) => acc + number));
        }

        [TestMethod]
        public void TestEachSliceOddFunction()
        {
            var actual = odd.EachSlice((left, right) => left + right);
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(3, actual.First());
            Assert.AreEqual(3, actual.Last());
        }

        [TestMethod]
        public void TestEachSliceOddIterator()
        {
            var actual = odd.EachSlice();
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(1, actual.First().Item1);
            Assert.AreEqual(0, actual.Last().Item2);
        }

        [TestMethod]
        public void TestEachSliceEvenAction()
        {
            IList<int> accumulatedList = new List<int>();
            even.EachSlice((left, right) =>
            {
                accumulatedList.Add(left);
                accumulatedList.Add(right);
            });
            Assert.AreEqual(4, accumulatedList.Count());
            Assert.AreEqual(10, accumulatedList.Aggregate(0, (acc, number) => acc + number));
        }

        [TestMethod]
        public void TestEachSliceEvenFunction()
        {
            var actual = even.EachSlice((left, right) => left + right);
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(3, actual.First());
            Assert.AreEqual(7, actual.Last());
        }

        [TestMethod]
        public void TestEachSliceEvenIterator()
        {
            var actual = even.EachSlice();
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(1, actual.First().Item1);
            Assert.AreEqual(4, actual.Last().Item2);
        }

        [TestMethod]
        public void TestEachColumnEmptyIterator()
        {
            var actual = empty.EachColumn();
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void TestEachColumnOneIterator()
        {
            var actual = one.EachColumn();
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(3, actual.First().Item1);
            Assert.AreEqual(0, actual.First().Item2);
        }

        [TestMethod]
        public void TestEachColumnEvenIterator()
        {
            var actual = even.EachColumn();
            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual(1, actual.First().Item1);
            Assert.AreEqual(4, actual.Last().Item2);
        }

        [TestMethod]
        public void TestEachColumnOddIterator()
        {
            var actual = odd.EachColumn();
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(1, actual.First().Item1);
            Assert.AreEqual(3, actual.Last().Item2);
        }
    }
}
