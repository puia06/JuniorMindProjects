﻿namespace AbstractionPolymorphismProject
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
            var digit = new Choice(
                       new Character('0'),
                       new Range('1', '9')
                   );

            Assert.False(digit.Match(""));
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

            Assert.True(hex.Match(test));
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

            Assert.True(hex.Match(test));
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

            Assert.True(hex.Match(test));
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

            Assert.True(hex.Match(test));
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

            Assert.False(hex.Match(test));
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

            Assert.True(hex.Match(test));
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

            Assert.True(hex.Match(test));
        }
    }
}
