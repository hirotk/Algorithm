using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            int[] a = new int[10];
            
            var rand = new Random(0);
            for (int i = 0; i < 10; i++) {
                a[i] = rand.Next(-99, 99);
            }

            SimpleSort.BubbleSort(a);
            Console.WriteLine(SimpleSort.AryToStr(a));
        }
    }
}