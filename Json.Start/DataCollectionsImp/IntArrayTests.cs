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

            Assert.Equal(1, testArray.Element(0));
            Assert.Equal(2, testArray.Element(1));
        }

        [Fact]
        public void Count_SameLength_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(2, testArray.Count());
        }

        [Fact]
        public void Element_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.Equal(2, testArray.Element(1));
        }

        [Fact]
        public void Element_IncorrectElement_ShouldReturnFalse()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);

            Assert.NotEqual(2, testArray.Element(0));
        }

        [Fact]
        public void SetElement_CorrectElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.SetElement(1, 9);

            Assert.Equal(9, testArray.Element(1));
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

            Assert.Equal(9, testArray.Element(1));
            Assert.Equal(3, testArray.Count());
        }

        [Fact]
        public void Clear_ClearElements_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Clear();  

            Assert.Equal(0, testArray.Count());
        }

        [Fact]
        public void Remove_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.Remove(2);

            Assert.Equal(1, testArray.Element(0));
            Assert.Equal(1, testArray.Count());
        }

        [Fact]
        public void RemoveAt_RemoveElement_ShouldReturnTrue()
        {
            var testArray = new IntArray();
            testArray.Add(1);
            testArray.Add(2);
            testArray.RemoveAt(1);

            Assert.Equal(1, testArray.Element(0));
            Assert.Equal(1, testArray.Count());
        }
    }
}