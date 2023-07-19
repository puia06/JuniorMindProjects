using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Sdk;

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
            CheckIfIsReadOnly();
            array[Count] = element;
            Count++;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; private set; }

        public virtual T this[int index]
        {
            get => array[index];
            set
            {
                CheckIfIsReadOnly();
                array[index] = value;
            }
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
            CheckIfIsReadOnly();
            CheckIndex(index, this.array);
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
            CheckIfIsReadOnly();
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
            CheckIfIsReadOnly();
            CheckIndex(index, this.array);
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
            CheckIfArrayIsNull(array);
            CheckIndex(arrayIndex, array);
            CheckLengthToCopy(array, arrayIndex);
            int index = arrayIndex;

            foreach (T item in this)
            {
                array[index] = item;
                index++;
            }
        }

        private void CheckIfArrayIsNull(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(paramName: nameof(array), message: "Array is null!");
            }
        }

        private void CheckIndex(int index, T[] array)
        {
            if (index >= array.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "Index is invalid!");
            }
        }
        private void CheckLengthToCopy(T[] array, int index)
        {
            if (array.Length < this.array.Length + index)
            {
                throw new ArgumentException(paramName: nameof(array), message: "Can't copy. Array length is too big!");
            }
        }

        private void CheckIfIsReadOnly()
        {
            if (this.IsReadOnly)
            {
                throw new ReadOnlyException("IList is ReadOnly!");
            }
        }

        public void MakeListReadOnly()
        {
            this.IsReadOnly = true;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
