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

    public class BinNode {
        public int Key { get; set; }
        //public T Val { get; set; }
        public BinNode Left { get; set; }
        public BinNode Right { get; set; }
        public BinNode Parent { get; set; }
        public NodeType NodeTyp { get; set; }

        public BinNode(int key) {
            this.Key = key;
            this.Left = null;
            this.Right = null;
            this.Parent = null;
            this.ChildTyp = ChildType.None;
        }

        private ChildType childTyp;
        public ChildType ChildTyp {
            get {
                if ((this.Left == null) && (this.Right == null)) {
                    return ChildType.None;
                } else if (this.Left == null) {
                    return ChildType.Right;
                } else if (this.Right == null) {
                    return ChildType.Left;
                } else {
                    return ChildType.Both;
                }
            }
            set { childTyp = value;}
        }

        public void AddLeftChild(BinNode node){
            this.Left = node;
            if (node == null) return;
            Debug.Assert(node.Key <= this.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.LeftChild;
        }

        public void AddRightChild(BinNode node) {
            this.Right = node;
            if (node == null) { return; }
            Debug.Assert(this.Key < node.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.RightChild;
        }

        private BinNode removeMinNode(BinNode node) {
            Debug.Assert(node != null);
            while (node.Left != null) {
                node = node.Left;
            }

            Debug.Assert(node.NodeTyp == NodeType.LeftChild);
            node.Parent.AddLeftChild(node.Right);

            return node; // removed node
        }

        public BinNode RemoveThis() {
            BinNode node = null;

            switch (ChildTyp) {
                case ChildType.None:
                    break;
                case ChildType.Left:  // Only
                    node = this.Left;
                    break;
                case ChildType.Right: // Only
                    node = this.Right;
                    break;
                case ChildType.Both:
                    node = removeMinNode(this.Right);
                    node.AddLeftChild(this.Left);
                    node.AddRightChild(this.Right);
                    break;
            }

            if (this.NodeTyp == NodeType.LeftChild) {
                this.Parent.AddLeftChild(node);
            } else if (this.NodeTyp == NodeType.RightChild) {
                this.Parent.AddRightChild(node);
            }

            return node;
        }
    }
    
    public class BinaryTree {
        private BinNode sentinel = new BinNode(int.MaxValue);
        private BinNode Root { get { return sentinel.Left; } }

        public BinaryTree() {
            sentinel.NodeTyp = NodeType.Sent;
        }

        public void Add(int key) {
            if (Root == null) {                
                sentinel.AddLeftChild(new BinNode(key));
                return;
            }

            var node = this.Root;
            while (true) {
                if (key <= node.Key) {
                    if (node.Left != null) {
                        node = node.Left; // move to the left node
                    } else {
                        node.AddLeftChild(new BinNode(key));
                        return;
                    }
                } else {
                    if (node.Right != null) {
                        node = node.Right; // move to the right node
                    } else {
                        node.AddRightChild(new BinNode(key));
                        return;
                    }
                }
            }
        }

        public BinNode Search(int key) {
            var node = this.Root;

            while (node != null) {
                if (key == node.Key) {
                    return node;
                } else if (key < node.Key) {
                    node = node.Left;
                } else {
                    node = node.Right;
                }
            }
            return null;
        }

        public void Remove(int key) {
            var node = Search(key);

            if (node != null) {
                node = node.RemoveThis();
            }            
        }

        private void depthFirst(BinNode node, Queue<BinNode> que, bool cleared = false) {
            if (node == null) { return; }
            if (cleared == false) {
                que = new Queue<BinNode>();
                cleared = true;
            }

            depthFirst(node.Left, que, true);
            que.Enqueue(node);
            depthFirst(node.Right, que, true);
        }

        public override string ToString() {
            var que = new Queue<BinNode>();
            depthFirst(this.Root, que, true);

            var result = new StringBuilder("[ ");
            while (que.Leng > 0) {
                var node = que.Dequeue();
                result.Append(node.Key);
                result.Append(" ");
            }
            result.Append("]");

            return result.ToString();
        }
    }
}