using System;
using Algorithm;
using NList = Algorithm.SinglyLinkedList<int>;

namespace Algorithm {
    public class MergeSort {
        public static void Sort(int[] a) {
            int lastIdx = a.Length - 1;
            split(a, 0, lastIdx);
        }

        private static void split(int[] a, int minIdx, int maxIdx) {
            if (maxIdx <= minIdx) return;

            int midIdx = minIdx + (maxIdx - minIdx) / 2;

            split(a, minIdx, midIdx);
            split(a, midIdx + 1, maxIdx);

            merge(a, minIdx, midIdx, maxIdx);
        }

        private static void merge(int[] a, int minIdx, int midIdx, int maxIdx) {
            int LENG = maxIdx - minIdx + 1;
            var b = new int[LENG];
            int i = minIdx, j = midIdx + 1, k = 0;

            while (i <= midIdx && j <= maxIdx) {
                b[k++] = (a[i] <= a[j]) ? a[i++] : a[j++]; // stable sort
            }
            while (i <= midIdx) { b[k++] = a[i++]; }
            while (j <= maxIdx) { b[k++] = a[j++]; }

            Array.Copy(b, 0, a, minIdx, LENG);
        }

        public static void Sort(NList list) {
            var list1 = split(list);
            while (0 < list.Leng) { list.Remove(); }
            while (0 < list1.Leng) { list.AddLast(list1.Remove()); }
        }

        private static NList split(NList list) {
            if (list.Leng <= 1) return list;

            int halfLeng = list.Leng / 2;
            var list1 = (NList)Activator.CreateInstance(list.GetType());

            while (halfLeng < list.Leng) {
                list1.Add(list.Remove());
            }
            
            return merge(split(list), split(list1));    
        }

        private static NList merge(NList list1, NList list2) {
            var mrgList = (NList)Activator.CreateInstance(list1.GetType());

            while (0 < list1.Leng &&  0 < list2.Leng) {
                if (list1.Peek(0) <= list2.Peek(0)) {
                    mrgList.AddLast(list1.Remove());
                } else {
                    mrgList.AddLast(list2.Remove());
                }
            }

            while (0 < list1.Leng) { mrgList.AddLast(list1.Remove()); }
            while (0 < list2.Leng) { mrgList.AddLast(list2.Remove()); }

            return mrgList;
        }
    }
}
