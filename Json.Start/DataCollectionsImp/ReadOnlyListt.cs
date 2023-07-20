using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataCollectionsImp
{
    public class ReadOnlyListt<T> : IList<T> 
    { 
        private IList<T> readOnlyList;

        public ReadOnlyListt(IList<T> readOnlyList)
        {
            this.readOnlyList = readOnlyList;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get;} = true;

        public T this[int index]
        {
            get => readOnlyList[index];
            set => throw new NotSupportedException("IList is ReadOnly!"); 
        }

        public void Add(T item)
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }
        public bool Contains(T element)
        {
            return IndexOf(element) > -1;
        }

        public void Clear()
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return readOnlyList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return readOnlyList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("IList is ReadOnly!");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
