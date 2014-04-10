using System;
using System.Text;
using System.Diagnostics;

namespace Algorithm {
    public enum NodeType {
        Sent, LeftChild, RightChild
    }

    public enum ChildType {
        None, Left, Right, Both
    }

    public class BinNode<T> {
        public int Key { get; private set; }
        public T Val { get; private set; }
        public BinNode<T> Left { get; private set; }
        public BinNode<T> Right { get; private set; }
        public BinNode<T> Parent { get; private set; }
        public NodeType NodeTyp { get; set; }

        public BinNode(int key, T val) {
            Key = key; Val = val;
            Left = Right = Parent = null;
            ChildTyp = ChildType.None;
        }

        private ChildType childTyp;
        public ChildType ChildTyp {
            get {
                if (Left == null && Right == null)
                    return ChildType.None;
                else if (Left == null)
                    return ChildType.Right;
                else if (Right == null)
                    return ChildType.Left;
                else 
                    return ChildType.Both;                
            }
            private set { childTyp = value;}
        }

        public void AddLeftChild(BinNode<T> node){
            Left = node;
            if (node == null) return;
            Debug.Assert(node.Key <= this.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.LeftChild;
        }

        public void AddRightChild(BinNode<T> node) {
            this.Right = node;
            if (node == null) return;
            Debug.Assert(this.Key < node.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.RightChild;
        }

        private BinNode<T> removeMinNode(BinNode<T> node) {
            Debug.Assert(node != null);
            while (node.Left != null)
                node = node.Left;
            
            Debug.Assert(node.NodeTyp == NodeType.LeftChild);
            node.Parent.AddLeftChild(node.Right);

            return node; // removed node
        }

        public BinNode<T> RemoveThis() {
            BinNode<T> node = null;

            switch (ChildTyp) {
                case ChildType.None:
                    break;
                case ChildType.Left:  // Only
                    node = Left;
                    break;
                case ChildType.Right: // Only
                    node = Right;
                    break;
                case ChildType.Both:
                    node = removeMinNode(Right);
                    node.AddLeftChild(Left);
                    node.AddRightChild(Right);
                    break;
            }

            if (NodeTyp == NodeType.LeftChild)
                Parent.AddLeftChild(node);
            else if (NodeTyp == NodeType.RightChild)
                Parent.AddRightChild(node);
           
            return node;
        }
    }

    public class BinaryTree<T> {
        private BinNode<T> sentinel = new BinNode<T>(int.MaxValue, default(T));
        private BinNode<T> Root { get { return sentinel.Left; } }

        public BinaryTree() {
            sentinel.NodeTyp = NodeType.Sent;
        }

        public void Add(int key, T val) {
            var newNode = new BinNode<T>(key, val);
            if (Root == null) {
                sentinel.AddLeftChild(newNode);
                return;
            }

            var node = Root;
            while (true) {
                if (key <= node.Key) {
                    if (node.Left != null) {
                        node = node.Left; // move to the left node
                    } else {
                        node.AddLeftChild(newNode);
                        return;
                    }
                } else {
                    if (node.Right != null) {
                        node = node.Right; // move to the right node
                    } else {
                        node.AddRightChild(newNode);
                        return;
                    }
                }
            }
        }

        public BinNode<T> Search(int key) {
            var node = Root;

            while (node != null) {
                if (key == node.Key)
                    return node;
                else if (key < node.Key)
                    node = node.Left;
                else
                    node = node.Right;
            }
            return null;
        }

        public BinNode<T> Remove(int key) {
            var node = Search(key);

            if (node != null)
                node = node.RemoveThis();

            return node;
        }

        private void depthFirst(BinNode<T> node, Queue<BinNode<T>> que, bool cleared = false) {
            if (node == null) return;
            if (cleared == false) {
                que = new Queue<BinNode<T>>();
                cleared = true;
            }

            depthFirst(node.Left, que, cleared);
            que.Enqueue(node);
            depthFirst(node.Right, que, cleared);
        }

        private string getKeyValString(bool isKey = false) {
            var que = new Queue<BinNode<T>>();
            depthFirst(Root, que, true);

            var result = new StringBuilder("[ ");
            while (que.Leng > 0) {
                var node = que.Dequeue();
                if (isKey)
                    result.Append(node.Key);
                else
                    result.Append(node.Val);

                result.Append(" ");
            }
            result.Append("]");

            return result.ToString();
        }

        public string KeysToString() {
            return getKeyValString(isKey:true);
        }

        public string ValsToString() {
            return getKeyValString(isKey:false);
        }

        public override string ToString() {
            return ValsToString();
        }
    }
}