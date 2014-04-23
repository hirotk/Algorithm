using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class SinglyLinkedListTest {
        static SinglyLinkedList<int> target;

        [ClassInitialize]
        public static void InitializeTarget(TestContext testContext) { }

        [ClassCleanup]
        public static void CleanupTarget() { }

        [TestInitialize]
        public void BeginTestMethod() {
            target = new SinglyLinkedList<int>();
            Assert.AreEqual(target.Leng, 0);
            target.Add(2);
            target.Add(3, 1);
            target.AddLast(5);
        }

        [TestCleanup]
        public void EndTestMethod() { }

        [TestMethod]
        public void AddTest() {
            Assert.AreEqual(target.Leng, 3);
            target.Add(-2);
            target.Add(4, 3);
            target.Add(7, 5);
            string expected = "[ -2 2 3 4 5 7 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 6);
        }

        [TestMethod]
        public void AddLastTest() {
            target.AddLast(7);
            target.AddLast(11);
            string expected = "[ 2 3 5 7 11 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 5);
        }

        [TestMethod]
        public void RemoveTest() {
            target.Remove();
            target.Remove(1);
            target.AddLast(7);
            string expected = "[ 3 7 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 2);
            
            target.Remove(1);
            target.Remove();
            expected = "[ ]";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PeekTest() {
            int expected = 3;
            int actual = target.Peek(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringTest() {
            target.Add(7, 3);
            string expected = "[ 2 3 5 7 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
