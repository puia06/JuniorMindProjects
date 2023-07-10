using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class IntArray
    {
        private int[] array;
        private int position;

        public IntArray()
        {
            this.array = new int[4];
            this.position = 0;
        }

        public void Add(int element)
        {
            array[position] = element;
            position++;
        }

        public int Count()
        {
            return array.Length;
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

            return true ? IndexOf(element) > -1 : false;
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
            position++;
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
            position = 0;
        }

        public void Remove(int element)
        {
            if (array.Contains(element))
            {
                RemoveAt(IndexOf(element));
                position--;
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
                position--;
            }
        }

        private void ResizeArrayIfNeeded()
        {
            if (position + 1  % 4 == 0)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }
    }
}
