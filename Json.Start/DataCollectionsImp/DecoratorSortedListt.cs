using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    internal class DecoratorSortedListt<T> : ListtDecorator<T> where T : IComparable<T>
    {
        private IList<T> sortedListt;
        public DecoratorSortedListt(IList<T> sortedListt) : base(sortedListt)
        {
            this.sortedListt = sortedListt;
        }

        public override T this[int index]
        {
            set
            {
                sortedListt[index] = value;
                SortArray();
            }
        }
        public override void Add(T item)
        {
            sortedListt.Add(item);
            SortArray();
        }

        public override void Insert(int index, T item)
        {
            sortedListt.Insert(index, item);
            SortArray();
        }

        public override void RemoveAt(int index)
        {
            sortedListt.RemoveAt(index);
            SortArray();
        }
        private void SortArray()
        {
            for (int i = 1; i < Count; i++)
            {
                for (int j = i; j > 0 && base[j - 1].CompareTo(base[j]) > 0; j--)
                {
                    T x = base[j];
                    base[j] = base[j - 1];
                    base[j - 1] = x;
                }
            }
        }
    }
}
