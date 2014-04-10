using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class BinaryTreeTest {
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
    }
}