using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
            SortArray();
        }

        private void SortArray()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (base[i] < base[j])
                    {
                        Swap(base[i], base[j]);
                    }
                }
            }
        }

        private (int, int) Swap(int x, int y)
        {
            (y, x) = (x, y);
            return (x, y);
        }
    }
}
