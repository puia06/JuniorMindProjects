using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataCollectionsImp
{
    public class Listt<T> : IList<T>
    {
        private T[] array;

        public Listt()
        {
            this.array = new T[4];
        }

        public virtual void Add(T element)
        {
            array[Count] = element;
            Count++;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) > -1;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
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

        public bool Remove(T element)
        {
            if (array.Contains(element))
            {
                RemoveAt(IndexOf(element));
                return true;
            }

            return false;
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
            foreach (var element in array)
            {
                yield return element;
            }
        }

        private void ResizeArrayIfNeeded()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int index = arrayIndex;
            foreach (T item in this)
            {
                array[index] = item;
                index++;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }
    }
}
