using System;

namespace Algorithm {
    public class Stack<T> {
        private SinglyLinkedList<T> sll = new SinglyLinkedList<T>();

        public void Push(T val) {
            sll.Add(val, 0);
        }

        public T Pop() {
            return sll.Remove(0);
        }

        public T Peek() {
            return sll.Peek(0);
        }

        public override string ToString() {
            return sll.ToString();
        }

        public int Leng { get { return sll.Leng; } }
    }
}
