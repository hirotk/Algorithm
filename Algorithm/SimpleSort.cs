//#define STABLE 
using System;
using System.Text;
using System.Diagnostics;
 
namespace Algorithm {
    public struct Pair<T> {
        public int key;
        public T val;
        public int CompareTo(Pair<T> pr) {
            return key.CompareTo(pr.key);
        }
    }

    public class SimpleSort {
        public static void BubbleSort(int[] a) {
            int LAST_IDX = a.Length - 1;
            for (int sortedIdx = 0; sortedIdx < LAST_IDX; sortedIdx++) {
                for (int i = LAST_IDX; i > sortedIdx; i--) { // O(n^2)
                    if (a[i - 1] > a[i]) { // stable sort
                        int t = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = t;
                    }
                }
#if DEBUG
                for (int j = sortedIdx + 1; j <= LAST_IDX; j++)
                    Debug.Assert(a[sortedIdx] <= a[j]);                
#endif
            }
        }

        public static void SelectionSort(Pair<char>[] a) {
            int LAST_IDX = a.Length - 1;
            for (int sortedIdx = 0; sortedIdx < LAST_IDX; sortedIdx++) {
                int minIdx = sortedIdx;
                for (int i = sortedIdx + 1; i <= LAST_IDX; i++) // O(n^2)
                    if (a[minIdx].CompareTo(a[i]) > 0) minIdx = i;
                
#if STABLE
                for (int j = minIdx; j > sortedIdx; j--) {
                    var t = a[j - 1];
                    a[j - 1] = a[j];
                    a[j] = t;
                }
#else
                if (sortedIdx < minIdx) {
                    var t = a[sortedIdx];
                    a[sortedIdx] = a[minIdx]; // not stable sort                                                        
                    a[minIdx] = t;
                }
#endif
            }
        }

        public static void InsertionSort(int[] a) {
            int LAST_IDX = a.Length - 1;
            for (int sortedIdx = 1; sortedIdx <= LAST_IDX; sortedIdx++) {
                for (int i = sortedIdx; i > 0; i--) { // O(n^2)
                    if (a[i - 1] > a[i]) { // stable sort
                        int t = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = t;
                    }
                }
#if DEBUG
                for (int j = sortedIdx; j > 0; j--)
                    Debug.Assert(a[0] <= a[j]);                
#endif
            }
        }

        public static string AryToStr(int[] a) {
            var sb = new StringBuilder("[ ");
            foreach (int i in a)
                sb.AppendFormat("{0} ", i);            

            sb.Append("]");
            return sb.ToString();
        }

        public static string PAryToStr<T>(Pair<T>[] a) {
            var sb = new StringBuilder("[ ");
            foreach (Pair<T> i in a)
                sb.AppendFormat("({0}, {1}) ", i.key, i.val);
            
            sb.Append("]");
            return sb.ToString();
        }
    }
}