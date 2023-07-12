using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ObjectArrayHelperTests
    {
        [Fact]
        public void Current_ShouldReturnTrue()
        {
            var objectArray = new ObjectArray();
            objectArray.Add(1);
            objectArray.Add(2);
            objectArray.Add(3);
            var testArray = new ObjectArrayHelper(objectArray);

            Assert.Equal(1, testArray.Current);
        }

        [Fact]
        public void MoveNext_ShouldReturnTrue()
        {
            var objectArray = new ObjectArray();
            objectArray.Add(1);
            objectArray.Add(2);
            objectArray.Add(3);
            var testArray = new ObjectArrayHelper(objectArray);
            testArray.MoveNext();

            Assert.Equal(2, testArray.Current);
        }

        [Fact]
        public void Reset_ShouldReturnTrue()
        {
            var objectArray = new ObjectArray();
            objectArray.Add(1);
            objectArray.Add(2);
            objectArray.Add(3);
            var testArray = new ObjectArrayHelper(objectArray);
            testArray.MoveNext();
            testArray.MoveNext();
            testArray.Reset();
            testArray.MoveNext();

            Assert.Equal(1, testArray.Current);
        }
    }
}
