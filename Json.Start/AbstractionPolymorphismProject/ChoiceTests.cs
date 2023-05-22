namespace AbstractionPolymorphismProject
{
    public class ChoiceTests
    {
        [Fact]
        public void Match_StartsWith_pattern_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "012";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "12";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "92";

            Assert.True(digit.Match(test));
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
             new Character('0'),
             new Range('1', '9')
         );
            string test = "a9";

            Assert.False(digit.Match(test));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );

            Assert.False(digit.Match(null));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Range('a', 'f');

            Assert.False(digit.Match(""));
        }
    }
}
