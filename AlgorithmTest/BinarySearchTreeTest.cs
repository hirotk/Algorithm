using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class BinarySearchTreeTest {
        static BinaryTree<String> target;

        [TestInitialize]
        public void BeginTestMethod() {
            target = new BinaryTree<String>();
            target.Add(3, "three");
            target.Add(2, "two");
            target.Add(7, "seven");
        }

        [TestMethod]
        public void AddTest() {
            target.Add(5, "five");
            string expected = "[ 2 3 5 7 ]";
            string actual = target.KeysToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SearchTest() {
            Assert.AreEqual(target.Search(5), null);
            Assert.AreEqual(target.Search(7).Key, 7);
        }

        [TestMethod]
        public void RemoveTest() {
            target.Remove(2);
            string expected = "[ 3 7 ]";
            string actual = target.KeysToString();
            Assert.AreEqual(expected, actual);
            target.Remove(7);
            target.Remove(3);
            Assert.AreEqual(target.KeysToString(), "[ ]");
        }

        [TestMethod]
        public void ToStringTest() {
            string expected = "[ two three seven ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllTest() {
            target.Clear();
            string expectedIn = "[ 5 17 18 20 27 28 30 53 60 88 ]";
            string expectedPre = "[ 30 17 5 20 18 28 27 88 53 60 ]";

            int[] keys = { 30, 17, 88, 53, 5, 20, 18, 28, 27, 60 };
            foreach (int key in keys) target.Add(key);

            string actual = target.KeysToString();
            Assert.AreEqual(expectedIn, actual);
            actual = target.KeysToString(Order.Pre);
            Assert.AreEqual(expectedPre, actual);
        }

        [TestMethod]
        public void AllTest2() {
            target.Clear();
            string expectedIn = "[ -1 5 8 17 18 20 27 28 30 53 55 60 63 88 200 ]";
            string expectedPre = "[ 30 17 5 -1 8 20 18 28 27 88 53 60 55 63 200 ]";

            int[] keys = { 30, 17, 88, 53, 5, 20, 18, 28, 27, 60, 200, 55, 63, -1, 8 };
            foreach (int key in keys) target.Add(key);

            string actual = target.KeysToString();
            Assert.AreEqual(expectedIn, actual);
            actual = target.KeysToString(Order.Pre);
            Assert.AreEqual(expectedPre, actual);
        }

        [TestMethod]
        public void AllTest3() {
            target.Clear();
            string expectedIn = "[ -1 17 18 27 28 30 55 60 63 88 ]";
            string expectedPre = "[ 30 17 -1 27 18 28 88 60 55 63 ]";

            int[] keys = { 30, 17, 88, 53, 5, 20, 18, 28, 27, 60, 200, 55, 63, -1, 8 };
            int[] delKeys = { 53, 200, 20, 5, 8 };
            foreach (int key in keys) target.Add(key);
            foreach (int key in delKeys) target.Remove(key);

            string actual = target.KeysToString();
            Assert.AreEqual(expectedIn, actual);
            actual = target.KeysToString(Order.Pre);
            Assert.AreEqual(expectedPre, actual);
        }
    }
}
