using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ObjectArrayTests
    {
        [Fact]
        public void Add_IndStringDouble_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add("string");
            testArray.Add(2.2);
            Assert.Equal(1, testArray[0]);
            Assert.Equal("string", testArray[1]);
            Assert.Equal(2.2, testArray[2]);
        }

        [Fact]
        public void SetElement_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add("string");
            testArray.Add(2);
            testArray[0] = 2.2;

            Assert.Equal(2.2, testArray[0]);
        }

        [Fact]
        public void Contains_Element_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add("string");
            testArray.Add(2);

            Assert.True(testArray.Contains("string"));
        }

        [Fact]
        public void Contains_ElementNotContained_ShouldReturnFalse()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.False(testArray.Contains("string"));
        }

        [Fact]
        public void IndexOf_ElementPresent_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add(2.2);
            testArray.Add("string");

            Assert.Equal(2, testArray.IndexOf("string"));
        }

        [Fact]
        public void IndexOf_ElementNotPresent_ShouldReturnFalse()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);   
            testArray.Add(2);

            Assert.Equal(-1, testArray.IndexOf("string"));
        }


        [Fact]
        public void Insert_InsertElement_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(1, 9.9);

            Assert.Equal(9.9, testArray[1]);
        }

        [Fact]
        public void Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add(1);
            testArray.Add("string");
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add("string");
            testArray.Add(2.2);
            testArray.Add(3);
            testArray.Remove("string");

            Assert.Equal(2.2, testArray[0]);
            Assert.Equal(3, testArray[1]);
            Assert.Equal(2, testArray.Count);
        }

        [Fact]
        public void RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new ObjectArray();
            testArray.Add("string");
            testArray.Add(2);
            testArray.RemoveAt(0);

            Assert.Equal(2, testArray[1]);
        }
    }
}
