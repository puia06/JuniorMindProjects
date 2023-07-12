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
            if (IsValidOperation(index, element, 1))
            {
                base.Insert(index, element);
            }
        }

        public override int this[int index]
        {
            set
            {
                if (IsValidOperation(index, value, 0))
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

        private bool IsValidOperation(int index, int element, int dif)
        {
            if (index < 0 || index >= Count)
            {
                return false;
            }
            if (index == Count - 1 && dif == 0)
            {
                return element >= base[index - 1];
            }
            if (index == 0 && dif == 0)
            {
                return element <= base[index + 1];
            }

            return element >= base[index - 1] && element <= base[index + 1 - dif];
        }
    }
}
