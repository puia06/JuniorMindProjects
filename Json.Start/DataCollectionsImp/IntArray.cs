using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class IntArray
    {
        private int[] array;
        public IntArray()
        {
            this.array = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;
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
            foreach (int i in array) 
            {
                if (i == element)
                {
                    return true;
                }
            }

            return false;
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
          int[] newArray = new int[array.Length + 1];
          int newArrayIndex = 0;

           for (int i = 0; i < array.Length; i++)
           {
              if (newArrayIndex == index)
              {
                    newArray[newArrayIndex] = element;
                    newArrayIndex++;
              }
                newArray[newArrayIndex] = array[i];
                newArrayIndex++;
            }

           array = newArray;
        }

        public void Clear()
        {
            Array.Resize(ref array, 0);
        }

        public void Remove(int element)
        {
            if (array.Contains(element))
            {
                int[] newArray = new int[array.Length - 1];
                int newArrayIndex = 0;
                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != element && count == 0)
                    {
                        newArray[newArrayIndex] = array[i];
                        newArrayIndex++;
                    }
                    else
                    {
                        count++;
                    }
                }

                array = newArray;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < array.Length)
            {
                int[] newArray = new int[array.Length - 1];
                int newArrayIndex = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i != index)
                    {
                        newArray[newArrayIndex] = array[i];
                        newArrayIndex++;
                    }
                }

                array = newArray;
            }
        }
    }
}
