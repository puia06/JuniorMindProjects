namespace AbstractionPolymorphismProject
{
    public class RangeTests
    {
        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "abc";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "fab";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_MiddleChar_ShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            string test = "bcd";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = "1abc";

            Assert.False(digit.Match(test));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = null;

            Assert.False(digit.Match(test));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            string test = "";

            Assert.False(digit.Match(test));
        }
    }
}