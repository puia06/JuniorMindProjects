using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class DecoratorSortedListt<T> : ListtDecorator<T> where T : IComparable<T>
    {
        public DecoratorSortedListt(IList<T> list) : base(list)
        {
        }

        public override T this[int index]
        {
            set
            {
                base[index] = value;
                SortArray();
            }
        }
        public override void Add(T item)
        {
            base.Add(item);
            SortArray();
        }

        public override void Insert(int index, T item)
        {
            base.Insert(index, item);
            SortArray();
        }

        public override void RemoveAt(int index)
        {
            base.RemoveAt(index);
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
