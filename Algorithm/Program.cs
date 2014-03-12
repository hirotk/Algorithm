using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            var st = new Stack<int>();
            st.Push(2);
            st.Push(3);
            st.Push(5);
            Console.WriteLine(st);
            st.Pop();
            Console.WriteLine(st);
        }
    }
}