using System;
using System.Text;

namespace Algorithm {
    class SinglyLinkedListNode<T> {
        public readonly T val;
        public SinglyLinkedListNode<T> Next {get; set;}

        public SinglyLinkedListNode(T val) { this.val = val; }
    }

    public class SinglyLinkedList<T> {
        private readonly SinglyLinkedListNode<T> head;
        private SinglyLinkedListNode<T> lastNode;

        public int Leng { get; private set; }

        public SinglyLinkedList() { 
            head = new SinglyLinkedListNode<T>(default(T));
            Leng = 0;
            lastNode = head;
        }

        private SinglyLinkedListNode<T> getPrevNode(int idx) {
            if (idx < 0 || Leng < idx) { throw new ArgumentOutOfRangeException("idx"); }
            var iNode = head;
            for (int i = 0; i < idx; i++) {
                iNode = iNode.Next;
            }

            return iNode;
        }

        public void Add(T val, int idx = 0){
            try {
                var iNode = getPrevNode(idx);
                var node = new SinglyLinkedListNode<T>(val);

                // Add node
                node.Next = iNode.Next;
                iNode.Next = node;

                // Update LastNode
                if (idx == Leng) { lastNode = node; }
                Leng++;
            } catch (Exception) {
                throw;
            }
        }

        public void AddLast(T val) {
            Add(val, Leng);
        }

        public T Remove(int idx = 0) {
            try {
                if (Leng < 1) { throw new Exception("The SinglyLinkedList is empty."); }
                var iNode = getPrevNode(idx);

                // Remove node
                var node = iNode.Next;
                iNode.Next = node.Next;
                
                // Update LastNode
                if (idx == Leng - 1) { lastNode = iNode; }
                Leng--;
                return node.val;
            } catch (Exception) {
                throw;
            }
        }

        public T Peek(int idx = 0) {
            try {
                if (Leng < 1) { throw new Exception("The SinglyLinkedList is empty."); }
                var iNode = getPrevNode(idx + 1);
                return iNode.val;
            } catch (Exception) {
                throw;
            }
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
