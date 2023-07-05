namespace AbstractionPolymorphismProject
{
    public class RangeTests
    {
        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("abc");
            int expectedPosition = 1;
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("fab");
            int expectedPosition = 1;
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_StartsWith_MiddleChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("bcd");
            int expectedPosition = 1;
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("1abc");
            int expectedPosition = 0;
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}