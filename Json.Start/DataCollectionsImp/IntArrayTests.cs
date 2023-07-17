namespace DataCollectionsImp
{
    public class IntArrayTests
    {
        [Fact]
        public void Add_AddElements_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(2, testArray[1]);
        }

        [Fact]
        public void Count_SameLength_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(2, testArray.Count);
        }

        [Fact]
        public void Element_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(2, testArray[1]);
        }

        [Fact]
        public void Element_IncorrectElement_ShouldReturnFalse()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.NotEqual(2, testArray[0]);
        }

        [Fact]
        public void SetElement_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray[1] = 9;

            Assert.Equal(9, testArray[1]);
        }

        [Fact]
        public void Contains_Element_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.True(testArray.Contains(2));
        }

        [Fact]
        public void Contains_ElementNotContained_ShouldReturnFalse()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.False(testArray.Contains(3));
        }

        [Fact]
        public void IndexOf_ElementPresent_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(1, testArray.IndexOf(2));
        }

        [Fact]
        public void IndexOf_ElementNotPresent_ShouldReturnFalse()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(-1, testArray.IndexOf(3));
        }


        [Fact]
        public void Insert_InsertElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(1, 9);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(9, testArray[1]);
            Assert.Equal(2, testArray[2]);
        }

        [Fact]
        public void Insert_InsertElementPositionZero_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Insert(0, 9);

            Assert.Equal(9, testArray[0]);
            Assert.Equal(1, testArray[1]);
            Assert.Equal(2, testArray[2]);
        }

        [Fact]
        public void Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Clear();

            Assert.Equal(0, testArray.Count);
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Remove(2);

            Assert.Equal(1, testArray[0]);
        }

        [Fact]
        public void RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.RemoveAt(1);

            Assert.Equal(1, testArray[0]);
        }

        [Fact]
        public void RemoveAtAndCount_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);
            testArray.RemoveAt(1);

            Assert.Equal(1, testArray[0]);
            Assert.Equal(3, testArray[1]);
            Assert.Equal(4, testArray[2]);
            Assert.Equal(3, testArray.Count);
        }

        [Fact]
        public void Insert_InsertElement_InvalidPosition_ExceptionTest_ShouldReturnException()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Add(3);
            testArray.Add(4);

            var exception = Assert.Throws<IndexOutOfRangeException>(() => testArray.Insert(-1, 0));
            Assert.NotNull(exception);
        }

        [Fact]
        public void DividedByZeroException()
        {
            var test = 5;
            int result;
            try
            {
               result = test / 0;
               Assert.True(false, "Expected DividedByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                Assert.True(true, "DividedByZeroException was caught successfully.");
            }
        }

        [Fact]
        public void NullReferenceException()
        {
            string test = null;
            int result;
            try
            {
                result = test.Length;
                Assert.True(false, "Expected NullReferenceException was not thrown.");
            }
            catch (NullReferenceException)
            {
                Assert.True(true, "NullReferenceException was caught successfully.");
            }
        }
    }
}