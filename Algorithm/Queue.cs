using System;

namespace Algorithm {
    public class Queue<T> {
        private SinglyLinkedList<T> sll = new SinglyLinkedList<T>();

        public void Enqueue(T val) {
            sll.AddLast(val);
        }

        public T Dequeue() {
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
