using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class BinarySearchTest {
        static int[] a = { 2, 3, 5, 7, 11, 13, 17, 19, 23};

        [TestMethod]
        public void IndexOfTest() {
            int expected = -1;
            int actual = BinarySearch.IndexOf(a, -1);
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = BinarySearch.IndexOf(a, 2);
            Assert.AreEqual(expected, actual);

            expected = 4;
            actual = BinarySearch.IndexOf(a, 11);
            Assert.AreEqual(expected, actual);

            expected = 8;
            actual = BinarySearch.IndexOf(a, 23);
            Assert.AreEqual(expected, actual);

            expected = -1;
            actual = BinarySearch.IndexOf(a, 24);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexOfRecTest() {
            int expected = -1;
            int actual = BinarySearch.IndexOf(a, -1);
            Assert.AreEqual(expected, actual);

            expected = 0;
            actual = BinarySearch.IndexOf(a, 2);
            Assert.AreEqual(expected, actual);

            expected = 4;
            actual = BinarySearch.IndexOf(a, 11);
            Assert.AreEqual(expected, actual);

            expected = 8;
            actual = BinarySearch.IndexOf(a, 23);
            Assert.AreEqual(expected, actual);

            expected = -1;
            actual = BinarySearch.IndexOf(a, 24);
            Assert.AreEqual(expected, actual);
        }
    }
}