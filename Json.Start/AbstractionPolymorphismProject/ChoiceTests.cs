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
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("12", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "12";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "92";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
             new Character('0'),
             new Range('1', '9')
         );
            string test = "a9";
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal("a9", result.RemainingText());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var result = digit.Match(null);

            Assert.False(result.Success());
            Assert.Equal(null, result.RemainingText());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Choice(
                       new Character('0'),
                       new Range('1', '9')
                   );
            var result = digit.Match("");

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_StartChar_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "a9";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("9", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_EndChar_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "f8";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_StartCharr_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "A9";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("9", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_EndCharr_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "F8";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "g8";
            var result = hex.Match(test);

            Assert.False(result.Success());
            Assert.Equal("g8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_pattern_ShouldReturnTrue()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "0ab";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ab", result.RemainingText());
        }


        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_ValidChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "abc";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_AddPattern_ValidCharInDigit_ShouldReturnTrue()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var e = new Character('e');
            digit.Add(e);
            string test = "eabc";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }
    }
}
