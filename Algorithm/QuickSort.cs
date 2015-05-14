namespace Algorithm {
    public class QuickSort {
        public static void Sort(int[] a) {
            int lastIdx = a.Length - 1;
            quickSort(a, 0, lastIdx);
        }

        private static void quickSort(int[] a, int minIdx, int maxIdx) {
            if (minIdx >= maxIdx) return;
            
            int pivot = a[minIdx]; // An ideal pivot is median
            int i = minIdx + 1, j = maxIdx;

            while (true) {
                while (i < maxIdx && a[i] < pivot) i++;
                while (minIdx < j && pivot <= a[j]) j--;
                if (j <= i) break;
                int tmp = a[i];
                a[i] = a[j]; // not stable sort 
                a[j] = tmp;
            }

            a[minIdx] = a[j];
            a[j] = pivot;

            quickSort(a, minIdx, j - 1);
            quickSort(a, j + 1, maxIdx);
        }
    }
}
