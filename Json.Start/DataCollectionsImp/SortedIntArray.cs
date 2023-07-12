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
            if (IsValidOperation(index, element))
            {
                base.Insert(index, element);
            }
        }

        public override int this[int index]
        {
            set
            {
                if (IsValidOperation(index, value))
                {
                    array[index] = value;
                }
            }
        }
        private void SortArray()
        {
            for (int i = 1; i < Count; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        private bool IsValidOperation(int index, int element)
        {
            if (index < 0 || index >= Count)
            {
                return false;
            }
            if (index == Count - 1 )
            {
                return element >= base[index - 1];
            }
            if (index == 0)
            {
                return element <= base[index + 1];
            }

            return element >= base[index - 1] && element <= base[index + 1];
        }
    }
}
