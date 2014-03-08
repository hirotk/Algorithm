using System;

namespace Algorithm {
    public class VarSizeArray<T> {
        const  int INIT_LENG = 4;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="leng">initial array length</param>
        public VarSizeArray(int leng = INIT_LENG) {
            if (leng <= 0) throw new ArgumentException("The leng is out of range.");
            ary = new T[leng];
            count = capacity = leng;
        }
        
        private T[] ary;

        private int capacity;
        public int Capacity { get { return capacity;} }

        private int count;
        public int Count { get { return count; } }

        public T this[int i] {
            set {
                if ((i < 0) || (count <= i)) {
                    throw new ArgumentOutOfRangeException("i");
                }
                this.ary[i] = value;
            }
            get {
                if ((i < 0) || (count <= i)) {
                    throw new ArgumentOutOfRangeException("i");
                }
                return this.ary[i];
            }
        }

        public void AddLast(T elm) {
            if (this.Capacity <= count) { reAlloc(); }
            ary[count] = elm;
            count++;
        }

        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("[ ");
            foreach (T e in ary)
                sb.AppendFormat("{0} ", e);

            sb.Append("]");
            return sb.ToString();
        }

        void reAlloc() {
            int LENG = this.ary.Length;
            int CAPA = LENG * 2;
            T[] newAry = new T[CAPA];

            // copy the current array to a new array
            for (int i = 0; i < LENG; i++) {
                newAry[i] = this.ary[i];
            }

            this.ary = newAry;
            capacity = ary.Length;
        }
    }
}