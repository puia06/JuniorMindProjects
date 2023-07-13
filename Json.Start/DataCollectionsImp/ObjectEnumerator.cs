using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ObjectEnumerator : IEnumerator
    {
        private ObjectArray array;
        private int position;

        public ObjectEnumerator(ObjectArray array)
        {
            this.array = array;
            this.position = 0;
        }

        public object Current
        {
            get
            {
                return array[position];
            }
        }

        public bool MoveNext()
        {
            position++;

            return position < array.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
