using System;
using System.Text;

namespace Algorithm {
    public class SinglyLinkedList<T> {
        class Node<T1> {
            public readonly T1 val;
            public Node<T1> Next { get; set; }

            public Node(T1 val) { this.val = val; }
        }

        private readonly Node<T> head;
        private Node<T> lastNode;

        private int leng;
        public int Leng { get { return this.leng; }}

        public SinglyLinkedList() { 
            this.head = new Node<T>(default(T));
            lastNode = head;
            this.leng = 0;
        }

        private Node<T> getPrevNode(int idx) {
            if (idx < 0 || Leng < idx) throw new ArgumentOutOfRangeException("idx");

            if (idx == Leng) return lastNode;

            var iNode = head;
            for (int i = 0; i < idx; i++) {
                iNode = iNode.Next;
            }

            return iNode;
        }

        public void Add(T val, int idx = 0){
            var iNode = getPrevNode(idx);
            var node = new Node<T>(val);

            // Add node
            node.Next = iNode.Next;
            iNode.Next = node;

            // Update LastNode
            if (idx == Leng) lastNode = node;
            this.leng++;
        }

        public void AddLast(T val) {
            Add(val, this.leng);
        }

        public T Remove(int idx = 0) {
            if (Leng < 1) throw new Exception("The list is empty.");

            var iNode = getPrevNode(idx);

            // Remove node
            var node = iNode.Next;
            iNode.Next = node.Next;
                
            // Update LastNode
            if (idx == Leng - 1) lastNode = iNode;
            this.leng--;
            return node.val;
        }

        public T Peek(int idx = 0) {
            if (Leng < 1) throw new Exception("The list is empty.");

            var iNode = getPrevNode(idx + 1);
            return iNode.val;
        }

        public override string ToString() {
            var sb = new StringBuilder("[ ");
            var node = head;

            for (int i = 0; i < Leng; i++) {
                node = node.Next;
                sb.AppendFormat("{0} ", node.val);
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}
