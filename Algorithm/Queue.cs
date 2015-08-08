namespace Algorithm {
    public class Queue<T> {
        private DoublyLinkedList<T> list = new DoublyLinkedList<T>();

        public void Enqueue(T val) {
            list.AddLast(val);
        }

        public T Dequeue() {
            return list.Remove(0);
        }

        public T Peek() {
            return list.Peek(0);
        }

        public override string ToString() {
            return list.ToString();
        }

        public int Leng { get { return list.Leng; } }
    }
}
