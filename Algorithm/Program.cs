using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            int[] k = {44, 62, 53, 11, 11, -59, 8, -12, 94, -45};
            Pair[] pa = new Pair[10];

            for (int i = 0; i < 10; i++) {
                pa[i].key = k[i];
                pa[i].val = '_';
            }

            pa[3].val = 'A';
            pa[4].val = 'B';

            Console.WriteLine(SimpleSort.PAryToStr(pa));
            SimpleSort.SelectionSort(pa);
            Console.WriteLine(SimpleSort.PAryToStr(pa));
        }
    }
}