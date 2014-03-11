using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            var sll = new SinglyLinkedList<int>();
            sll.Add(2);
            sll.AddLast(5);
            sll.Add(3, 1);
            sll.Remove(2);
            Console.WriteLine(sll);
        }
    }
}