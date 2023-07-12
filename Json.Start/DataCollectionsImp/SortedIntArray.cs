using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataCollectionsImp
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
            SortArray();
        }

        public override void Add(int element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, int element)
        {
            if (ElementAt(index - 1, element) <= element && element <= ElementAt(index, element))
            {
                base.Insert(index, element);
            }
        }

        public override int this[int index]
        {
            set
            {
                if (ElementAt(index - 1, value) <= value && value <= ElementAt(index + 1, value))
                {
                    array[index] = value;
                } 
            }
        }
        private void SortArray()
        {
            for (int i = 1; i < Count; i++)
            {
                int key = base[i];
                int j = i - 1;

                while (j >= 0 && base[j] > key)
                {
                    base[j + 1] = base[j];
                    j--;
                }

                base[j + 1] = key;
            }
        }

        private int ElementAt(int index, int element)
        {
            if (index <= 0 || index >= Count)
            {
                return element;
            }

            return base[index];
        }
    }
}
