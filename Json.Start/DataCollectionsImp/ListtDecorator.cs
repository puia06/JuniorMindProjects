using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ListtDecorator<T> : IList<T>
    {
        private IList<T> decoratorList;

        public ListtDecorator(IList<T> printList)
        {
            this.decoratorList = printList;
        }
        public virtual T this[int index] 
        {
            get => decoratorList[index];
            set => decoratorList[index] = value;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; } = false;

        public virtual void Add(T item)
        {
            decoratorList.Add(item);
        }
        public bool Contains(T element)
        {
            return IndexOf(element) > -1;
        }

        public void Clear()
        {
            decoratorList.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            decoratorList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return decoratorList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return decoratorList.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
           decoratorList.Insert(index, item);   
        }

        public bool Remove(T item)
        {
            return decoratorList.Remove(item);
        }

        public virtual void RemoveAt(int index)
        {
            decoratorList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
