//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LankaStocks
//{
//    public class ScrollableArray<T>
//    {
//        public int Count = 0;
//        public int Capacity;
//        public T[] arr;
//        private int root = 0;


//        /// <summary>
//        /// Increment Count before incrementing root
//        /// </summary>
//        public int Root
//        {
//            get => root;
//            set
//            {
//                root = Wrap(value);
//            }
//        }

//        public int Wrap(int v)
//        {
//            while (v >= Capacity)
//            {
//                v -= Capacity;
//            }
//            while (v < 0)
//            {
//                v += Capacity;
//            }
//            return v;
//        }
//        public void Wrap(ref int v)
//        {
//            while (v >= Capacity)
//            {
//                v -= Capacity;
//            }
//            while (v < 0)
//            {
//                v += Capacity;
//            }
//        }

//        public void CheckAndResize(int newSize, int incrementWith = 2)
//        {
//            if (Capacity < newSize)
//            {
//                Array.Resize(ref arr, newSize + incrementWith);
//                Capacity = newSize + incrementWith;
//            }
//        }




//        public ScrollableArray()
//        {
//            Capacity = 4;
//            arr = new T[Capacity];
//        }

//        public ScrollableArray(int capacity)
//        {
//            Capacity = capacity;
//            arr = new T[Capacity];
//        }


//        public void AddToFront(params T[] items)
//        {

//            int newSize = Count + items.Length;

//            CheckAndResize(newSize);

//            Count += items.Length;
//            Root -= items.Length;

//            for (int i = 0; i < items.Length; i++)
//            {
//                arr[Wrap(Root + i)] = items[i];
//            }



//            //  |4|5| + |r 0|1|2|3|
//            //= |0|1|2|3|r 4|5|
//        }


//        public void AddToBack(params T[] items)
//        {
//            int newSize = Count + items.Length;

//            CheckAndResize(newSize);

//            for (int i = 0; i < items.Length; i++)
//            {
//                arr[Wrap(Count + i)] = items[i];
//            }

//            Count += items.Length;

//            //  |0|1|2|3|+|4|5|
//            //= |r 0|1|2|3|4|5|
//        }



//        //Fix this ____________________________----------------------------------------------
//        public void RemoveFromFront(int count)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                arr[i] = default;
//            }

//            Count -= count;
//            Root += count;

//        }
//        public void RemoveFromBack(int count)
//        {
//            for (int i = Root; i < count; i++)
//            {
//                arr[i] = default;
//            }

//            Count -= count;
//        }
//    }
//}
