using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class ReadOnlyListtTests
    {
        [Fact]
        public void Add_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList.Add(1));
        }

        [Fact]
        public void Contains_ShouldReturnTrue()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.True(readOnlyList.Contains(1));
        }

        [Fact]
        public void Set_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList[0] = 1);
        }

        [Fact]
        public void Clear_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList.Clear());
        }


        [Fact]
        public void IndexOf_ShouldReturnTrue()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Equal(0, readOnlyList.IndexOf(1));
        }

        [Fact]
        public void Insert_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList.Insert(1, 2));
        }


        [Fact]
        public void Remove_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList.Remove(1));
        }

        [Fact]
        public void RemoveAt_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);

            Assert.Throws<NotSupportedException>(() => readOnlyList.RemoveAt(1));
        }

        [Fact]
        public void CopyTo_ShouldReturnException()
        {
            var testList = new Listt<int>();
            testList.Add(1);
            testList.Add(2);
            var readOnlyList = new ReadOnlyListt<int>(testList);
            var arr = new int[2];

            Assert.Throws<NotSupportedException>(() => readOnlyList.CopyTo(arr, 1));
        }
    }
}
