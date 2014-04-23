using System;

namespace Algorithm {
    public class HeapSort {
        public static void Sort(int[] a) {
            var hp = new Heap(a.Length);
            foreach (int n in a) {
                hp.Add(n);
            }

            for (int i = 0; i < a.Length; i++) {
                a[i] = hp.Remove();
            }
        }
    }

    public class Heap{
        int[] a;
        int count;
        
        public Heap(int leng) {
            a = new int[leng];
            count = 0;
        }

        public Heap(int[] ary) {
            a = new int[ary.Length];
            Array.Copy(ary, a, a.Length);
            count = a.Length;
            rebuild();
        }

        public void Add(int val) {
            if (a.Length <= count) { throw new Exception("Heap is full."); }
            
            a[count] = val;
            ascend(count, 0);
            count++;
        }

        private void ascend(int startIdx, int endIdx) {
            int i = startIdx;

            while (endIdx < i) {
                if (a[(i - 1) / 2] <= a[i]) { break; }

                int t = a[(i - 1) / 2];
                a[(i - 1) / 2] = a[i];
                a[i] = t;

                i = (i - 1) / 2;
            }
        }

        public int Remove() {
            if (count <= 0) { throw new Exception("Heap is empty."); }
            
            var min = a[0];
            a[0] = a[count - 1];
            a[count - 1] = int.MaxValue;
            descend(0, count - 2);
            count--;

            return min;
        }

        private void descend(int startIdx, int endIdx) {
            int i = startIdx;

            while (i < endIdx) {
                int lChild = 2 * i + 1 < endIdx ? a[2 * i + 1] : int.MaxValue;
                int rChild = 2 * i + 2 < endIdx ? a[2 * i + 2] : int.MaxValue;
                if (a[i] <= lChild && a[i] <= rChild) { break; }

                if (lChild < rChild) {
                    a[2 * i + 1] = a[i];
                    a[i] = lChild;
                    i = 2 * i + 1;
                } else {
                    a[2 * i + 2] = a[i];
                    a[i] = rChild;
                    i = 2 * i + 2;
                }
            }
        }

        private void rebuild() {
            int lastParentIdx = count / 2;
            for (int i = lastParentIdx; i >= 0; i++) {
                descend(i, count);
            }
        }

        public override string ToString() {
            var sb = new System.Text.StringBuilder("[ ");
            foreach (int n in a) {
                sb.AppendFormat("{0} ", n);
            }            
            sb.Append("]");
            return sb.ToString();
        }
    }
}
