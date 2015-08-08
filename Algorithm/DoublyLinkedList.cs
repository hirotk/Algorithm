using System;
using System.Text;

namespace Algorithm {
    public class DoublyLinkedList<T> {
        class Node<T1> {
            public Node(T1 val) {
                this.Value = val;
            }

            public T1 Value { get; set; }
            public Node<T1> Next { get; set; }
            public Node<T1> Prev { get; set; }
        }

        private readonly Node<T> head;

        public DoublyLinkedList() {
            this.head = new Node<T>(default(T));
            head.Next = head;
            head.Prev = head;
            this.leng = 0;
        }

        private int leng;
        public int Leng {
            get { return this.leng; }
        }

        Node<T> getPrevNode(int idx) {
            if (idx < 0 || this.leng < idx) {
                throw new ArgumentOutOfRangeException("idx");
            }

            Node<T> iNode = null;

            /* 
             * i: h 0 1 2 t  (len=3)
             * h to 1 needs 2steps.
             * t to 1 needs 2steps.
             * 
             * i: h 0 1 2 3 t  (len=4)
             * h to 2 needs 3steps.
             * t to 2 needs 2steps.
            */
            if (this.leng < 4 || idx <= this.leng / 2) {
                iNode = this.head;

                for (int i = 0; i < idx; i++) {
                    iNode = iNode.Next;
                }
            } else {
                iNode = this.head;

                for (int i = this.leng - 1; i >= idx - 1; i--) {
                    iNode = iNode.Prev;
                }
            }

            return iNode;
        }

        public void Add(T val, int idx = 0) {
            var node = new Node<T>(val);
            var left = this.getPrevNode(idx);
            var right = left.Next;

            // Add node
            node.Prev = left;
            node.Next = right;

            right.Prev = node;
            left.Next = node;

            this.leng++;
        }

        public void AddLast(T val) {
            this.Add(val, this.leng);
        }

        public T Remove(int idx = 0) {
            if (this.leng < 1) {
                throw new Exception("The list is empty.");
            }

            var left = this.getPrevNode(idx);
            var right = left.Next.Next;

            // Remove node
            var node = left.Next;
            node.Next = null;
            node.Prev = null;

            right.Prev = left;
            left.Next = right;

            this.leng--;

            return node.Value;
        }

        public T Peek(int idx = 0) {
            if (this.leng < 1) {
                throw new Exception("The list is empty.");
            }

            var iNode = this.getPrevNode(idx + 1);

            return iNode.Value;
        }

        public override string ToString() {
            var sb = new StringBuilder("[ ");
            var node = this.head;

            for (int i = 0; i < this.leng; i++) {
                node = node.Next;
                sb.AppendFormat("{0} ", node.Value);
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}
