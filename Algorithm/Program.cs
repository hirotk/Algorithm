using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            VarSizeArray<int> va = new VarSizeArray<int>(1);
            va[0] = 3;
            va.AddLast(5);
            Console.WriteLine(va);
        }
    }
}