using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithm;

namespace AlgorithmTest {
    [TestClass]
    public class HeapSortTest {
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
        public void SortTest() {
            HeapSort.Sort(a);
            string expected = "[ -59 -45 -12 11 11 44 53 62 80 94 ]";
            string actual = SimpleSort.AryToStr(a);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void AddTest() {
            var hp = new Heap(8);
            hp.Add(-2);
            hp.Add(0);
            hp.Add(5);
            hp.Add(5);
            hp.Add(3);
            string expected = "[ -2 0 5 5 3 0 0 0 ]";
            string actual = hp.ToString();
            Assert.AreEqual(actual, expected);        
        }

        [TestMethod]
        public void RemoveTest() {
            var hp = new Heap(8);
            hp.Add(-2);
            hp.Add(0);
            hp.Add(5);
            hp.Add(5);
            hp.Add(3);
            hp.Remove();
            string expected = String.Format("[ 0 3 5 5 {0} 0 0 0 ]", int.MaxValue);
            string actual = hp.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void BuildTest() {
            string expected = "[ -59 -45 11 -12 44 53 80 11 94 62 ]";
            var hp = new Heap(a);
            string actual = hp.ToString();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TravelStringDfsTest() {
            string expected = "-59 -45 -12 11 94 44 62 11 53 80 ";
            var hp = new Heap(a);
            string actual = hp.TravelString(isDfs:true);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TravelStringBfsTest() {
            string expected = "-59 -45 11 -12 44 53 80 11 94 62 ";
            var hp = new Heap(a);
            string actual = hp.TravelString(isDfs: false);
            Assert.AreEqual(actual, expected);
        }
    }
}
