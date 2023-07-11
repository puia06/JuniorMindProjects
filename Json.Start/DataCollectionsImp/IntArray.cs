using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            this.array = new int[4];
        }

        public void Add(int element)
        {
            array[Count] = element;
            Count++;
        }

        public int Count { get; private set; } = 0;

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(int element)
        { 
            return IndexOf(element) > -1;
        }

        public int IndexOf(int element)
        {
            for(int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Count++;
            ResizeArrayIfNeeded();
            for (int i = Count - 1; i >= index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            Count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Count--;
        }

        private void ResizeArrayIfNeeded()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}
