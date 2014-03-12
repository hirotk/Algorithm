using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class StackTest {
        static Stack<int> target;

        [TestInitialize()]
        public void BeginTestMethod() {
            target = new Stack<int>();
            Assert.AreEqual(target.Leng, 0);
            target.Push(2);
            target.Push(3);
            target.Push(5);
        }        
        
        [TestMethod]
        public void PushTest() {
            target.Push(7);
            string expected = "[ 7 5 3 2 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 4);
        }

        [TestMethod]
        public void PopTest() {
            int ret = target.Pop();
            Assert.AreEqual(ret, 5);
            string expected = "[ 3 2 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 2);
        }

        [TestMethod]
        public void PeekTest() {
            int ret = target.Peek();
            Assert.AreEqual(ret, 5);
            string expected = "[ 5 3 2 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Leng, 3);
        }
    }
}
