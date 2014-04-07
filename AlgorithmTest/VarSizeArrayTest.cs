using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class VerSizeArrayTest {
        public object InvokePrivateMethod(string methodName, object[] argv) {
            object result = target.GetType().InvokeMember(methodName,
                BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, target, argv);
            return result;
        }

        static VarSizeArray<int> target;

        [ClassInitialize]
        public static void InitializeTarget(TestContext testContext) {}

        [ClassCleanup]
        public static void CleanupTarget() {}

        [TestInitialize]
        public void BeginTestMethod() {
            target = new VarSizeArray<int>();
            target[0] = 2;
            target[1] = 3;
            target[2] = 5;
        }

        [TestCleanup]
        public void EndTestMethod() {}

        [TestMethod]
        public void AddLastTest() {
            target.AddLast(11);
            target.AddLast(13);
            target.AddLast(17);
            target.AddLast(19);
            target.AddLast(23);
            string expected = "[ 2 3 5 0 11 13 17 19 23 0 0 0 0 0 0 0 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(target.Count, 9);
            Assert.AreEqual(target.Capacity, 16);
        }

        [TestMethod]
        public void ToStringTest() {
            target[3] = 7;
            string expected = "[ 2 3 5 7 ]";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void reAllocTest() {
            int expected = target.Capacity * 2;
            InvokePrivateMethod("reAlloc", null);
            int actual = target.Capacity;
            Assert.AreEqual(expected, actual);
        }
    }
}