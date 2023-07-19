﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ListtTests
    {
        [Fact]
        public void Add_IntStringDouble_ShouldReturnTrue()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.Add(2.2);
            Assert.Equal(1, testArray[0]);
            Assert.Equal("string", testArray[1]);
            Assert.Equal(2.2, testArray[2]);
        }

        [Fact]
        public void Add_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray.Add(2.2));
        }

        [Fact]
        public void SetElement_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray[0] = 0;

            Assert.Equal(0, testArray[0]);
        }

        [Fact]
        public void Set_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray[0] = 1);
        }

        [Fact]
        public void Contains_Element_ShouldReturnTrue()
        {
            var testArray = new List<string>();
            testArray.Add("string");
            testArray.Add("abc");

            Assert.True(testArray.Contains("string"));
        }

        [Fact]
        public void Contains_ElementNotContained_ShouldReturnFalse()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);

            Assert.False(testArray.Contains(5));
        }

        [Fact]
        public void IndexOf_ElementPresent_ShouldReturnTrue()
        {
            var testArray = new Listt<double>();
            testArray.Add(1.2);
            testArray.Add(2.2);
            testArray.Add(3.3);

            Assert.Equal(0, testArray.IndexOf(1.2));
        }

        [Fact]
        public void IndexOf_ElementNotPresent_ShouldReturnFalse()
        {
            var testArray = new Listt<string>();
            testArray.Add("abc");
            testArray.Add("bcd");

            Assert.Equal(-1, testArray.IndexOf("string"));
        }


        [Fact]
        public void Insert_InsertElement_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(1, 9);

            Assert.Equal(9, testArray[1]);
        }


        [Fact]
        public void Insert_InvalidIndex_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.Insert(4, 9));
        }

        [Fact]
        public void Insert_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray.Insert(1, 1));
        }

        [Fact]
        public void Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new Listt<string>();
            testArray.Add("abc");
            testArray.Add("string");
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void Clear_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray.Clear());
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new Listt<object>();
            testArray.Add("string");
            testArray.Add(2.2);
            testArray.Add(3);

            Assert.True(testArray.Remove("string"));
            Assert.Equal(2.2, testArray[0]);
            Assert.Equal(3, testArray[1]);
            Assert.Equal(2, testArray.Count);
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnFalse()
        {
            var testArray = new Listt<object>();
            testArray.Add("string");
            testArray.Add(2.2);
            testArray.Add(3);

            Assert.False(testArray.Remove("abc"));
            Assert.Equal("string", testArray[0]);
            Assert.Equal(2.2, testArray[1]);
            Assert.Equal(3, testArray.Count);
        }

        [Fact]
        public void Remove_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray.Remove(1));
        }

        [Fact]
        public void RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray.RemoveAt(0);

            Assert.Equal(2, testArray[0]);
        }

        [Fact]
        public void RemoveAt_InvalidIndex_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.RemoveAt(4));
        }

        [Fact]
        public void RemoveAt_IsReadOnly_ShoudThrowException()
        {
            var testArray = new Listt<object>();
            testArray.Add(1);
            testArray.Add("string");
            testArray.MakeListReadOnly();
            Assert.Throws<ReadOnlyException>(() => testArray.RemoveAt(0));
        }

        [Fact]
        public void CopyTo_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            var newArray = new int[6];
            testArray.CopyTo(newArray, 2);

            Assert.Equal(0, newArray[0]);
            Assert.Equal(0, newArray[1]);
            Assert.Equal(1, newArray[2]);
            Assert.Equal(2, newArray[3]);
            Assert.Equal(3, newArray[4]);
            Assert.Equal(4, newArray[5]);
        }

        [Fact]
        public void CopyTo_NullArray_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            int[] newArray = null;
            Assert.Throws<ArgumentNullException>(() => testArray.CopyTo(newArray, 2));
        }

        [Fact]
        public void CopyTo_InvalidIndex_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            var newArray = new int[6];
            Assert.Throws<ArgumentOutOfRangeException>(() => testArray.CopyTo(newArray, 7));
        }

        [Fact]
        public void CopyTo_InvalidArrayLength_ShouldReturnTrue()
        {
            var testArray = new Listt<int>();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            var newArray = new int[6];
            Assert.Throws<ArgumentException>(() => testArray.CopyTo(newArray, 4));
        }
    }
}
