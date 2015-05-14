namespace Algorithm {
    public class Stack<T> {
        private SinglyLinkedList<T> list = new SinglyLinkedList<T>();

        public void Push(T val) {
            list.Add(val, 0);
        }

        public T Pop() {
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
