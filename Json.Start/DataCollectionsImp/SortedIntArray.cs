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
            base.Insert(index, element);
            SortArray();
        }

        public override int this[int index]
        {
            set
            {
                array[index] = value;
                SortArray();
            }
        }
        private void SortArray()
        {
            bool repeat;
            do
            {
                repeat = false;
                for (int i = 0; i < Count - 1; i++)
                {
                    if (base[i] > base[i + 1])
                    {
                        int z = base[i];
                        base[i] = base[i + 1];
                        base[i + 1] = z;
                        repeat = true;
                    }
                }
            }
            while (repeat);
        }
    }
}
