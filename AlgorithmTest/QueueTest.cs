using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class QueueTest {
        static Queue<int> target;

        [TestInitialize]
        public void BeginTestMethod() {
            target = new Queue<int>();
            Assert.AreEqual(target.Leng, 0);
            target.Enqueue(2);
            target.Enqueue(3);
            target.Enqueue(5);
        }

        [TestMethod]
        public void EnqueueTest() {
            target.Enqueue(7);
            string expected = "[ 2 3 5 7 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 4);
        }

        [TestMethod]
        public void DequeueTest() {
            int ret = target.Dequeue();
            Assert.AreEqual(ret, 2);
            string expected = "[ 3 5 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 2);
        }

        [TestMethod]
        public void PeekTest() {
            int ret = target.Peek();
            Assert.AreEqual(ret, 2);
            string expected = "[ 2 3 5 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 3);
        }
    }
}
