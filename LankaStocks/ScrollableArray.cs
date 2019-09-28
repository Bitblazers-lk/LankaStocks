using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LankaStocks
{
    public class ScrollableArray<T> : ICollection<T>, IEnumerator<T>
    {
        #region Data
        public T[] A;
        public int root = 0;
        public int Count = 0;//Working Area

        public int Capacity;

        int ICollection<T>.Count => Count;

        public bool IsReadOnly => false;


        public ScrollableArray() : this(10) { }
        public ScrollableArray(int InitialSize)
        {
            Count = 0;
            Capacity = InitialSize;

            A = new T[Capacity];
        }
        #endregion

        public void AddToFront(params T[] items)
        {
            int l = items.Length;
            int newSize = l + Count;

            lock (A)
            {

                CheckAndResize(newSize);

                root -= l;
                Wrap1(ref root);
                int cursor = root;

                for (int i = 0; i < l; i++)
                {
                    A[cursor] = items[i];
                    cursor = Wrap1(cursor + 1);
                }

                Count += l;

            }
        }
        public void AddToBack(params T[] items)
        {
            int l = items.Length;
            int newSize = l + Count;

            lock (A)
            {

                CheckAndResize(newSize);

                int cursor = Wrap(root + Count);

                for (int i = 0; i < l; i++)
                {
                    A[cursor] = items[i];
                    cursor = Wrap1(cursor + 1);
                }

                Count += l;

            }
        }
        public void CheckAndResize(int newSize, int incrementWith = 2)
        {
            if (Capacity < newSize)
            {
                lock (A)
                {

                    int newCapacity = newSize + incrementWith;

                    T[] B = new T[newCapacity];


                    int cursor = root;
                    for (int i = 0; i < Count; i++)
                    {

                        B[i] = A[cursor];
                        cursor = Wrap1(cursor + 1);
                    }

                    root = 0;

                    A = B;
                    Capacity = newCapacity;


                }
            }
        }
        public void RemoveFromBegining(int count)
        {
            if (Count < count)
                count = Count;

            Count -= count;

            for (int i = 0; i < count; i++)
            {
                A[root] = default;
                root = Wrap1(root + 1);
            }
        }
        public void RemoveFromEnd(int count)
        {
            if (Count < count)
                count = Count;


            int cursor = Wrap(root + Count);

            for (int i = 0; i < count; i++)
            {
                A[cursor] = default;
                cursor = Wrap1(cursor - 1);
            }
            Count -= count;
        }
        public void RemoveRange(int start, int count)
        {
            if (Count < start + count)
                count = Count - start;


            int cursor = Wrap(root + start);
            int replacer = Wrap(root + start + count);
            int eol = Wrap(root + Count);
            bool replace = true;

            for (int i = 0; i < Count - start; i++)
            {

                if (replace)
                {

                    if (replacer == eol)
                    {
                        replace = false;
                        A[cursor] = default;
                    }
                    else
                    {
                        A[cursor] = A[replacer];
                        A[replacer] = default;
                    }
                    replacer = Wrap1(replacer + 1);
                }
                else
                {
                    A[cursor] = default;
                }


                cursor = Wrap1(cursor + 1);
            }

            Count -= count;
        }

        /// <summary>
        /// Add items to the begining; Return Last Elements; Remove Last Elements
        /// </summary>
        public T[] PushForward(params T[] items)
        {
            var ts = PushForward(items.Length);
            AddToFront(items);
            return ts;
        }

        /// <summary>
        /// Return Last Elements; Remove them
        /// </summary>
        public T[] PushForward(int count = 1)
        {
            T[] ts = new T[count];

            int cursor = Wrap(root + (Count - count));

            for (int i = 0; i < count; i++)
            {
                ts[i] = A[cursor];
                cursor = Wrap1(cursor + 1);
            }

            RemoveFromEnd(count);

            return ts;
        }

        /// <summary>
        /// Add items to Back; Return First Elements; Remove them
        /// </summary>
        public T[] PullBackward(params T[] items)
        {
            var ts = PullBackward(items.Length);
            AddToBack(items);
            return ts;
        }

        /// <summary>
        /// Return First Elements; Remove them
        /// </summary>
        public T[] PullBackward(int count = 1)
        {
            T[] ts = new T[count];

            int cursor = root;

            for (int i = 0; i < count; i++)
            {
                ts[i] = A[cursor];
                cursor = Wrap1(cursor + 1);
            }

            RemoveFromBegining(count);

            return ts;
        }

        public T this[int index]
        {
            get { return A[Wrap(root + index)]; }
            set { A[Wrap(root + index)] = value; }
        }

        public T GetItem(int i) { return A[Wrap(root + i)]; }
        public void SetItem(int i, T value) { A[Wrap(root + i)] = value; }

        public int Wrap(int v)
        {
            while (v >= Capacity)
            {
                v -= Capacity;
            }
            while (v < 0)
            {
                v += Capacity;
            }
            return v;
        }
        public void Wrap(ref int v)
        {
            while (v >= Capacity)
            {
                v -= Capacity;
            }
            while (v < 0)
            {
                v += Capacity;
            }
        }

        public int Wrap1(int v)
        {
            if (v >= Capacity)
            {
                v -= Capacity;
            }
            else if (v < 0)
            {
                v += Capacity;
            }
            return v;
        }
        public void Wrap1(ref int v)
        {
            if (v >= Capacity)
            {
                v -= Capacity;
            }
            else if (v < 0)
            {
                v += Capacity;
            }
        }

        public IEnumerable<int> YieldIndex()
        {
            lock (A)
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return Wrap1(root + i);
                }
            }
        }
        public IEnumerable<T> YieldItems()
        {
            lock (A)
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return A[Wrap1(root + i)];
                }
            }
        }

        public void Add(T item)
        {
            AddToBack(item);
        }
        public void Clear()
        {
            A = new T[Capacity];
            Count = 0;
            root = 0;
        }
        public bool Contains(T item)
        {
            return A.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (A)
            {
                for (int i = 0; i < Count; i++)
                {
                    array[i + arrayIndex] = A[Wrap1(root + i)];
                }
            }
        }
        public void CopyTo(T[] array, int start, int count)
        {
            lock (A)
            {
                int cursor = Wrap(root + start);

                for (int i = 0; i < count; i++)
                {
                    array[i] = A[cursor];
                    cursor = Wrap1(cursor + 1);
                }
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            CopyTo(array, 0);
            return array;
        }
        public List<T> ToList()
        {
            List<T> lst = new List<T>(Count);
            lock (A)
            {
                for (int i = 0; i < Count; i++)
                {
                    lst.Add(A[Wrap1(root + i)]);
                }
            }
            return lst;
        }
        public bool Remove(T item)
        {
            int i = AbsoluteIndexOf(item);
            if (i == -1) return false;

            RemoveRange(i, 1);
            return true;
        }
        public int IndexOf(T item)
        {
            int i = AbsoluteIndexOf(item);

            if (i == -1)
            {
                return -1;
            }
            else
            {
                return Wrap1(root + i);
            }
        }
        public int AbsoluteIndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (A[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            lock (A)
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return A[Wrap1(root + i)];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Dispose()
        {
            A = null;
        }

        private int IEnumeratorIndex = 0;

        public bool MoveNext()
        {
            if (IEnumeratorIndex > Count - 1)
            {
                return false;
            }

            IEnumeratorIndex++;

            return true;
        }
        public void Reset()
        {
            IEnumeratorIndex = 0;
        }

        public T Current => A[Wrap1(IEnumeratorIndex + root)];
        object IEnumerator.Current => Current;

        public override string ToString()
        {
            return $"ScrollableArray<{typeof(T).Name}> \t {{ {String.Join(", ", YieldItems())} }} \t Root {root}, Count {Count}, Capacity {Capacity} \t Raw : {{ {String.Join(", ", A)} }} ";
        }

    }
}
