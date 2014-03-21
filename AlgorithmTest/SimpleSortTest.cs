using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class SimpleSortTest {
        private int[] a;

        [TestInitialize()]
        public void BeginTestMethod() {
            a = new int[10];
            var rand = new Random(0);
            for (int i = 0; i < 10; i++) {
                a[i] = rand.Next(-99, 99);
            }
        }

        [TestMethod]
        public void BubbleSortTest() {
            SimpleSort.BubbleSort(a);
            string actual = SimpleSort.AryToStr(a);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            Assert.AreEqual(actual, expected);
        }
    }
}