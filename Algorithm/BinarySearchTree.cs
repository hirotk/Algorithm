using System.Text;
using System.Diagnostics;

namespace Algorithm {
    public enum NodeType {
        Sent, LeftChild, RightChild
    }

    public enum ChildType {
        None, Left, Right, Both
    }

    public enum Order {
        Pre, In, Post
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
                if (Left == null && Right == null) {
                    return ChildType.None;
                } else if (Left == null) {
                    return ChildType.Right;
                } else if (Right == null) {
                    return ChildType.Left;
                } else {
                    return ChildType.Both;
                }
            }
            private set { childTyp = value;}
        }

        public void AddLeftChild(BinNode<T> node){
            Left = node;
            if (node == null) { return; }
            Debug.Assert(node.Key <= this.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.LeftChild;
        }

        public BinNode<T> RemoveLeftChild() {
            var left = this.Left;
            this.Left = null;
            return left;
        }

        public void AddRightChild(BinNode<T> node) {
            this.Right = node;
            if (node == null) return;
            Debug.Assert(this.Key < node.Key);
            node.Parent = this;
            node.NodeTyp = NodeType.RightChild;
        }

        public BinNode<T> RemoveRightChild() {
            var right = this.Right;
            this.Right = null;
            return right;
        }
    }

    public class BinaryTree<T> {
        private BinNode<T> sentinel = new BinNode<T>(int.MaxValue, default(T));
        private BinNode<T> Root { get { return sentinel.Left; } }

        public BinaryTree() {
            sentinel.NodeTyp = NodeType.Sent;
        }

        public void Add(int key, T val=default(T)) {
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

        private BinNode<T> getLeftestNode(BinNode<T> node) {
            if (node == null) return null;
            else if (node.Left == null) return node;
            else return getLeftestNode(node.Left);
        }

        public BinNode<T> Remove(int key) {
            var node = Search(key);
            if (node == null) return node;

            var ctyp = node.ChildTyp;
            var ntyp = node.NodeTyp;
            if (ctyp == ChildType.None) {
                if (ntyp == NodeType.LeftChild) {
                    node.Parent.RemoveLeftChild();
                } else {
                    node.Parent.RemoveRightChild();
                }
            } else if (ctyp == ChildType.Both) {
                var move = getLeftestNode(node.Right);
                Debug.Assert(move.Left == null);
                if (move == node.Right) {
                    move.AddLeftChild(node.Left);
                } else {
                    // Cut the leftest node
                    move.Parent.AddLeftChild(move.Right);
                    // Put the move node
                    move.AddLeftChild(node.Left);
                    move.AddRightChild(node.Right);
                }

                // Set the parent to the move node
                if (ntyp == NodeType.LeftChild) {
                    node.Parent.AddLeftChild(move);
                } else {
                    node.Parent.AddRightChild(move);
                }
            } else if (ctyp == ChildType.Left) {
                if (ntyp == NodeType.LeftChild) {
                    node.Parent.AddLeftChild(node.Left);
                } else {
                    node.Parent.AddRightChild(node.Left);
                }
            } else {
                Debug.Assert(ctyp == ChildType.Right);
                if (ntyp == NodeType.LeftChild) {
                    node.Parent.AddLeftChild(node.Right);
                } else {
                    node.Parent.AddRightChild(node.Right);
                }
            }

            return node;
        }

        private void dfsPost(BinNode<T> node) {
            if (node == null) return;
            dfsPost(node.Left);
            dfsPost(node.Right);
            Remove(node.Key);
        }

        public void Clear() {
            dfsPost(Root);
        }

        private void dfsInOrder(BinNode<T> node, Queue<BinNode<T>> que) {
            if (node == null) return;
            dfsInOrder(node.Left, que);
            que.Enqueue(node);
            dfsInOrder(node.Right, que);
        }

        private void dfsPreOrder(BinNode<T> node, Queue<BinNode<T>> que) {
            if (node == null) return;
            que.Enqueue(node);
            dfsPreOrder(node.Left, que);
            dfsPreOrder(node.Right, que);
        }

        private void dfsPostOrder(BinNode<T> node, Queue<BinNode<T>> que) {
            if (node == null) return;
            dfsPostOrder(node.Left, que);
            dfsPostOrder(node.Right, que);
            que.Enqueue(node);
        }

        private string getKeyValString(bool isKey = false, Order order = Order.In) {
            var que = new Queue<BinNode<T>>();
            if (order == Order.Pre) dfsPreOrder(Root, que);
            else if (order == Order.Post) dfsPostOrder(Root, que);
            else dfsInOrder(Root, que);

            var result = new StringBuilder("[ ");
            while (que.Leng > 0) {
                var node = que.Dequeue();
                if (isKey) {
                    result.Append(node.Key);
                } else {
                    result.Append(node.Val);
                }

                result.Append(" ");
            }
            result.Append("]");

            return result.ToString();
        }

        public string KeysToString(Order order = Order.In) {
            return getKeyValString(isKey:true, order:order);
        }

        public string ValsToString(Order order = Order.In) {
            return getKeyValString(isKey:false, order:order);
        }

        public override string ToString() {
            return ValsToString();
        }
    }
}
