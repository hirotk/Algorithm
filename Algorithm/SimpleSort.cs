using System;
using System.Text;
using System.Diagnostics;

namespace Algorithm {
    public struct Pair {
        public int key;
        public char val;
        public int CompareTo(Pair pr) {
            return key.CompareTo(pr.key);
        }
    }

    public class SimpleSort {
        public static void BubbleSort(int[] a) {
            int lastIdx = a.Length - 1;
            for (int sorted = 0; sorted < lastIdx; sorted++) {
                for (int i = lastIdx; i > sorted; i--) { // O(n^2)
                    if (a[i - 1] > a[i]) { // stable sort
                        int t = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = t;
                    }
                }
#if DEBUG
                for (int j = sorted + 1; j <= lastIdx; j++) {
                    Debug.Assert(a[sorted] <= a[j]);
                }
#endif
            }
        }

        public static void SelectionSort(Pair[] a) {
            int lastIdx = a.Length - 1;
            for (int sorted = 0; sorted < lastIdx; sorted++) {
                int minIdx = sorted;
                for (int i = sorted + 1; i <= lastIdx; i++) { // O(n^2)
                    if (a[minIdx].CompareTo(a[i]) > 0) { minIdx = i; }
                }
                if (sorted < minIdx) {
                    var t = a[sorted];
                    a[sorted] = a[minIdx]; // not stable sort                                                        
                    a[minIdx] = t;
                }
            }
        }

        public static string AryToStr(int[] a) {
            var sb = new StringBuilder("[ ");
            foreach (int i in a) {
                sb.AppendFormat("{0} ", i);
            }

            sb.Append("]");
            return sb.ToString();
        }

        public static string PAryToStr(Pair[] a) {
            var sb = new StringBuilder("[ ");
            foreach (Pair i in a) {
                sb.AppendFormat("({0}, {1}) ", i.key, i.val);
            }

            sb.Append("]");
            return sb.ToString();
        }

    }
}