using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            var qu = new Queue<int>();
            qu.Enqueue(2);
            qu.Enqueue(3);
            qu.Enqueue(5);
            Console.WriteLine(qu);
            qu.Dequeue();
            Console.WriteLine(qu);
        }
    }
}