using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class SortedListtTests
    {
        [Fact]
        public void Add_SortInt_ShouldReturnTrue()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(4);
            testArray.Add(3);
            Assert.Equal(1, testArray[0]);
            Assert.Equal(3, testArray[1]);
            Assert.Equal(4, testArray[2]);
        }

        [Fact]
        public void Add_SortDouble_ShouldReturnTrue()
        {
            var testArray = new SortedListt<double>();
            testArray.Add(1.2);
            testArray.Add(4.2);
            testArray.Add(3.2);
            Assert.Equal(1.2, testArray[0]);
            Assert.Equal(3.2, testArray[1]);
            Assert.Equal(4.2, testArray[2]);
        }

        [Fact]
        public void Add_SortString_ShouldReturnTrue()
        {
            var testArray = new SortedListt<string>();
            testArray.Add("abc");
            testArray.Add("cde");
            testArray.Add("bcd");
            Assert.Equal("abc", testArray[0]);
            Assert.Equal("bcd", testArray[1]);
            Assert.Equal("cde", testArray[2]);
        }



        [Fact]
        public void SetElement_ValidElement_ShouldReturnTrue()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(3);
            testArray.Add(2);
            testArray[0] = 1;

            Assert.Equal(1, testArray[0]);
            Assert.Equal(3, testArray[1]);
        }

        [Fact]
        public void SetElement_InValidElement_ShouldReturnFalse()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(3);
            testArray.Add(2);
            testArray[0] = 3;

            Assert.Equal(2, testArray[0]);
            Assert.Equal(3, testArray[1]);
        }

        [Fact]
        public void Contains_Element_ShouldReturnTrue()
        {
            var testArray = new SortedListt<string>();
            testArray.Add("string");
            testArray.Add("abc");

            Assert.True(testArray.Contains("string"));
        }

        [Fact]
        public void Contains_ElementNotContained_ShouldReturnFalse()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(2);

            Assert.False(testArray.Contains(0));
        }

        [Fact]
        public void IndexOf_ElementPresent_ShouldReturnTrue()
        {
            var testArray = new SortedListt<string>();
            testArray.Add("abc");
            testArray.Add("bcd");
            testArray.Add("string");

            Assert.Equal(2, testArray.IndexOf("string"));
        }

        [Fact]
        public void IndexOf_ElementNotPresent_ShouldReturnFalse()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(-1, testArray.IndexOf(3));
        }


        [Fact]
        public void Insert_InsertElement_ShouldReturnTrue()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(3);
            testArray.Insert(1, 2);

            Assert.Equal(2, testArray[1]);
        }

        [Fact]
        public void Insert_InsertElement_ShouldReturnFalse()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(3);
            testArray.Insert(1, 4);

            Assert.Equal(3, testArray[1]);
        }

        [Fact]
        public void Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new SortedListt<string>();
            testArray.Add("abc");
            testArray.Add("string");
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new SortedListt<double>();
            testArray.Add(2.2);
            testArray.Add(1.2);
            testArray.Add(3.2);
            testArray.Remove(2.2);

            Assert.Equal(1.2, testArray[0]);
            Assert.Equal(3.2, testArray[1]);
        }

        [Fact]
        public void RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new SortedListt<double>();
            testArray.Add(2.9);
            testArray.Add(2.4);
            testArray.RemoveAt(0);

            Assert.Equal(2.9, testArray[0]);
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            var testArray = new SortedListt<int>();
            testArray.Add(1);
            testArray.Add(2);
            var enumerator = testArray.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(2, enumerator.Current);
        }

    }
}
