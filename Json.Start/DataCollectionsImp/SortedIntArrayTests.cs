using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void SortArray_Add_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(1);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(2, testArray[1]);
            Assert.Equal(3, testArray[2]);
        }


        [Fact]
        public void SortArray_Count_SameLength_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(0);

            Assert.Equal(3, testArray.Count);
        }

        [Fact]
        public void SortArray_Element_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(1, testArray[0]);
        }

        [Fact]
        public void SortArray_SetElement_InCorrectElement_ShouldReturnFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(2);
            testArray[0] = 9;

            Assert.Equal(2, testArray[0]);
            Assert.Equal(2, testArray[1]);
            Assert.Equal(3, testArray[2]);
        }

        [Fact]
        public void SortArray_SetElement_StartValidElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(2);
            testArray[0] = 1;

            Assert.Equal(1, testArray[0]);
            Assert.Equal(2, testArray[1]);
            Assert.Equal(3, testArray[2]);
        }

        [Fact]
        public void SortArray_SetElement_EndValidElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(2);
            testArray.Add(2);
            testArray[2] = 4;

            Assert.Equal(2, testArray[0]);
            Assert.Equal(2, testArray[1]);
            Assert.Equal(4, testArray[2]);
        }

        [Fact]
        public void SortArray_Contains_Element_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);

            Assert.True(testArray.Contains(2));
        }

        [Fact]
        public void SortArray_Contains_ElementNotContained_ShouldReturnFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);

            Assert.False(testArray.Contains(4));
        }

        [Fact]
        public void SortArray_IndexOf_ElementPresent_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(1, testArray.IndexOf(2));
        }

        [Fact]
        public void SortArray_IndexOf_ElementNotPresent_ShouldReturnFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(-1, testArray.IndexOf(4));
        }


        [Fact]
        public void SortArray_Insert_InsertInvalidElement_ShouldReturnFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(1, 9);

            Assert.Equal(3, testArray.Count);
        }

        [Fact]
        public void SortArray_Insert_InsertValidElementEndPosition_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(3, 9);

            Assert.Equal(4, testArray.Count);
        }

        [Fact]
        public void SortArray_Insert_InsertValidElementStartPosition_ShouldReturnFalse()
        {
            var testArray = new SortedIntArray();
            testArray.Add(4);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Insert(0, 1);

            Assert.Equal(4, testArray.Count);
        }

        [Fact]
        public void SortArray_Insert_InsertValidElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(4);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(2, 3);

            Assert.Equal(4, testArray.Count);
            Assert.Equal(3, testArray[2]);
            Assert.Equal(4, testArray[3]);
        }

        [Fact]
        public void SortArray_Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void SortArray_Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);
            testArray.Remove(2);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(3, testArray[1]);
        }

        [Fact]
        public void SortArray_RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new SortedIntArray();
            testArray.Add(3);
            testArray.Add(1);
            testArray.Add(2);
            testArray.RemoveAt(1);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(3, testArray[1]);
        }
    }
}
