using System;

namespace Algorithm {
    class SinglyLinkedListNode<T> {
        public readonly T val;
        public SinglyLinkedListNode<T> Next {get; set;}

        public SinglyLinkedListNode(T val) { this.val = val; }
    }

    public class SinglyLinkedList<T> {
        private readonly SinglyLinkedListNode<T> head;
        private SinglyLinkedListNode<T> lastNode;

        private int leng;
        public int Leng {get{return leng;}}

        public SinglyLinkedList() { 
            head = new SinglyLinkedListNode<T>(default(T));
            leng = 0;
            lastNode = head;
        }

        private SinglyLinkedListNode<T> getPrevNode(int idx) {
            if (idx < 0 || leng < idx) throw new ArgumentException("The idx is out of range.");
            var iNode = head;
            for (int i = 0; i < idx; ++i) { iNode = iNode.Next; }
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
                if (idx == leng) lastNode = node;
                leng++;
            } catch (Exception e) {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }

        public void AddLast(T val) {
            var node = new SinglyLinkedListNode<T>(val);

            // Add node
            node.Next = lastNode.Next;
            lastNode.Next = node;

            // Update LastNode
            lastNode = node;
            leng++;
        }

        public T Remove(int idx = 0) {
            try {
                if (leng < 1) throw new Exception("The SinglyLinkedList is empty.");
                var iNode = getPrevNode(idx);

                // Remove node
                var node = iNode.Next;
                iNode.Next = node.Next;
                
                // Update LastNode
                if (idx == leng - 1) lastNode = iNode;
                leng--;
                return node.val;
            } catch (Exception e) {
                Console.WriteLine(e.Message + e.StackTrace);
                return default(T);
            }
        }

        public T Peek(int idx = 0) {
            try {
                if (leng < 1) throw new Exception("The SinglyLinkedList is empty.");
                var iNode = getPrevNode(idx + 1);
                return iNode.val;
            } catch (Exception e) {
                Console.WriteLine(e.Message + e.StackTrace);
                return default(T);
            }
        }

        public override string ToString() {
            var sb = new System.Text.StringBuilder("[ ");
            var node = head;
            for (int i = 0; i < this.Leng; ++i) {
                node = node.Next;
                sb.AppendFormat("{0} ", node.val);
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}