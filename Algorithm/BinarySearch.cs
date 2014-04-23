using System;

namespace Algorithm {
    public class BinarySearch {
        /// <summary>
        /// Search a value in an array
        /// </summary>
        /// <param name="a">a sorted array in ascending order</param>
        /// <param name="v">a value to search</param>
        /// <returns>the index of the value</returns>
        public static int IndexOf(int[] a, int v) {
            int li = 0, hi = a.Length - 1;

            while (li <= hi) {
                int mi = li + (hi - li) / 2;
                if (a[mi] == v) {
                    return mi;
                } else if (a[mi] < v) {
                    li = mi + 1;
                } else {
                    hi = mi - 1;
                }
            }

            return -1;
        }

        public static int IndexOfRec(int[] a, int v) { 
            return half(a, 0, a.Length - 1, v);
        }

        private static int half(int[] a, int li, int hi, int v){
            if (li > hi) { return -1; }
            int mi = li + (hi - li) / 2;
            if (a[mi] == v) { return mi; }

            if (a[mi] < v) {
                return half(a, mi + 1, hi, v);
            } else {
                return half(a, li, mi - 1, v);
            }
        }
    }
}
