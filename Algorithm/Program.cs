using System;

namespace Algorithm {
    public class Program {
        public static void Main(String[] args){
            var tree = new BinaryTree();
            tree.Add(3);
            tree.Add(2);
            tree.Add(7);
            tree.Add(4);
            tree.Add(6);
            tree.Remove(3);
            tree.Remove(6);
            Console.WriteLine(tree);
        }
    }
}