namespace AbstractionPolymorphismProject
{
    public class RangeTests
    {
        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("abc");
            StringView expectedResult = new StringView("abc", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("fab");
            StringView expectedResult = new StringView("fab", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_MiddleChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("bcd");
            StringView expectedResult = new StringView("bcd", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("1abc");
            StringView expectedResult = new StringView("1abc", 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}