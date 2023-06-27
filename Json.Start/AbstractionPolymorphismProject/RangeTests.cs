namespace AbstractionPolymorphismProject
{
    public class RangeTests
    {
        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "abc";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "fab";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ab", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_MiddleChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "bcd";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("cd", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = "1abc";
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal("1abc", result.RemainingText());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = null;
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = "";
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }
    }
}