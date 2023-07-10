using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            this.array = new int[4];
            this.count = 0;
        }

        public void Add(int element)
        {
            array[count] = element;
            count++;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        { 

            return IndexOf(element) > -1;
        }

        public int IndexOf(int element)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            count++;
            ResizeArrayIfNeeded();
            for (int i = array.Length - 1; i >= index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
            count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
            count--;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
        }

        private void ResizeArrayIfNeeded()
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}
