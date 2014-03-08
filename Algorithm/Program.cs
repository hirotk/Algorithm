using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
/*            VarSizeArray<int> va = new VarSizeArray<int>(1);
            va[0] = 3;
            va.AddLast(5);
            Console.WriteLine(va);
*/
            int[] a = { 2, 3, 5, 7, 11, 13, 17, 19, 23};
            Console.WriteLine(BinarySearch.IndexOf(a, 17));
            Console.WriteLine(BinarySearch.IndexOfRec(a, 29));
        }
    }
}