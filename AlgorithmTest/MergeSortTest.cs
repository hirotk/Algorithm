using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {    
    [TestClass]
    public class MergeSortTest {
        private int[] a;

        [TestInitialize()]
        public void BeginTestMethod() {
            a = new int[10];
            var rand = new Random(0);
            for (int i = 0; i < 10; i++) {
                a[i] = rand.Next(-99, 99);
            } // -> [ 44 62 53 11 -59 11 80 -12 94 -45 ]        
        }

        [TestMethod]
        public void SortAryTest() {
            MergeSort.Sort(a);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            string actual = SimpleSort.AryToStr(a);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void SortListTest() {
            var list = new SinglyLinkedList<int>();
            foreach (int n in a) {
                list.Add(n);
            }

            MergeSort.Sort(list);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            string actual = list.ToString();
            Assert.AreEqual(actual, expected);
        }
    }
}
