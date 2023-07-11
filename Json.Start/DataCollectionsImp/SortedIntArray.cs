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
            get => array[index];
            set
            {
                array[index] = value;
                SortArray();
            }
        }
        private void SortArray()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (base[i] > base[j])
                    {
                        int z = base[i];
                        base[i] = base[j];
                        base[j] = z;
                    }
                }
            }
        }
    }
}
