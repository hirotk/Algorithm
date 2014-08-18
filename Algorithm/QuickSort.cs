using System;
using Algorithm;

namespace Algorithm {
    public class QuickSort {
        public static void Sort(int[] a) {
            int LAST_IDX = a.Length - 1;
            quickSort(a, 0, LAST_IDX);
        }

        private static void quickSort(int[] a, int minIdx, int maxIdx) {
            if (minIdx >= maxIdx) { return; }
            int pivot = partition(a, minIdx, maxIdx);
            quickSort(a, minIdx, pivot - 1);
            quickSort(a, pivot + 1, maxIdx);                      
        }

        private static int partition(int[] a, int minIdx, int maxIdx) {
            int pivot = a[maxIdx];
            int i = minIdx, j = maxIdx - 1;

            while (true) {
                while (a[i] < pivot) { i++; }
                while (i < j && pivot < a[j]) { j--; }
                if (i >= j) { break; }
                int t = a[j];
                a[j] = a[i]; // not stable sort 
                a[i] = t;
            }

            a[maxIdx] = a[i];
            a[i] = pivot;

            return i;            
        }
    }
}
