using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ObjectArray : IEnumerable
    {
        protected object[] array;
        private ObjectArrayHelper helper;

        public ObjectArray()
        {
            this.array = new object[4];
        }

        public void Add(object element)
        {
            array[Count] = element;
            Count++;
        }

        public int Count { get; private set; } = 0;

        public object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) > -1;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object element)
        {
            Count++;
            ResizeArrayIfNeeded();
            for (int i = Count - 1; i > index; i--)
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

        public void Remove(object element)
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

        public IEnumerator GetEnumerator()
        {
            return helper;
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
