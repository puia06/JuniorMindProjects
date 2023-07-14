using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class SortedListt<T> : Listt<T> where T : IComparable<T>
    {
        public SortedListt() : base() 
        { 
        }

        public override void Add(T element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, T element)
        {
            if (ElementAt(index - 1, element).CompareTo(element) <= 0 && element.CompareTo(ElementAt(index, element)) <= 0)
            {
                base.Insert(index, element);
            }
        }

        public override T this[int index]
        {
            set
            {
                if (ElementAt(index - 1, value).CompareTo(value) <= 0 && value.CompareTo(ElementAt(index + 1, value)) <= 0)
                {
                    base[index] = value;
                }
            }
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

        private T ElementAt(int index, T element)
        {
            if (index <= 0 || index >= Count)
            {
                return element;
            }

            return base[index];
        }
    }
}
