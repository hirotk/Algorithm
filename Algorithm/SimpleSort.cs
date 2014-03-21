using System;
using System.Text;
using System.Diagnostics;

namespace Algorithm {
    public class SimpleSort {
        public static void BubbleSort(int[] a) {
            int lastIdx = a.Length - 1;
            for (int sorted = 0; sorted < lastIdx; sorted++) {
                for (int i = lastIdx; i > sorted; i--) {
                    if (a[i - 1] > a[i]) { // stable sort
                        int t = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = t;
                    }
                }
                for (int j = sorted + 1; j <= lastIdx; j++) {
                    Debug.Assert(a[sorted] <= a[j]);
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
    }
}