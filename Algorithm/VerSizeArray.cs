using System;
using System.Text;

namespace Algorithm {
    public class VarSizeArray<T> {
        const int INIT_LENG = 4;
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="leng">initial array length</param>
        public VarSizeArray(int leng = INIT_LENG) {
            if (leng <= 0) { throw new ArgumentException("The leng is out of range."); }
            ary = new T[leng];
            Count = Capacity = leng;
        }
        
        private T[] ary;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public T this[int i] {
            set {
                if (i < 0 || Count <= i) { throw new ArgumentOutOfRangeException("i"); }
                ary[i] = value;
            }
            get {
                if (i < 0 || Count <= i) { throw new ArgumentOutOfRangeException("i"); }
                return ary[i];
            }
        }

        public void AddLast(T v) {
            if (Capacity <= Count) { reAlloc(); }
            ary[Count++] = v;
        }

        public override string ToString() {
            var sb = new StringBuilder("[ ");
            foreach (T v in ary) {
                sb.AppendFormat("{0} ", v);
            }
            sb.Append("]");
            return sb.ToString();
        }

        void reAlloc() {
            var newAry = new T[ary.Length * 2];
            Array.Copy(ary, newAry, ary.Length);            
            ary = newAry;
            Capacity = ary.Length;
        }
    }
}
