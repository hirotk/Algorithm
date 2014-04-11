using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class SimpleSortTest {
        private int[] a;

        [TestInitialize]
        public void BeginTestMethod() {
            a = new int[10];
            var rand = new Random(0);
            for (int i = 0; i < 10; i++) {
                a[i] = rand.Next(-99, 99);
            } // -> [ 44 62 53 11 -59 11 80 -12 94 -45 ]
        }

        [TestMethod]
        public void BubbleSortTest() {
            SimpleSort.BubbleSort(a);
            string actual = SimpleSort.AryToStr(a);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void SelectionSortTest() {
            int[] k = { 44, 62, 53, 11, 11, -59, 8, -12, 94, -45 };
            var pa = new Pair<char>[10];

            for (int i = 0; i < 10; i++) {
                pa[i].key = k[i];
                pa[i].val = '_';
            }

            pa[3].val = 'A';
            pa[4].val = 'B';

            SimpleSort.SelectionSort(pa);
            string actual = SimpleSort.PAryToStr<char>(pa);
            string expected = "[ (-59, _) (-45, _) (-12, _) (8, _) (11, B) (11, A) (44, _) (53, _) (62, _) (94, _) ]"; // not stable
//            string expected = "[ (-59, _) (-45, _) (-12, _) (8, _) (11, A) (11, B) (44, _) (53, _) (62, _) (94, _) ]"; // stable
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void InsertionSortTest() {
            SimpleSort.InsertionSort(a);
            string actual = SimpleSort.AryToStr(a);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            Assert.AreEqual(actual, expected);
        }
    }
}