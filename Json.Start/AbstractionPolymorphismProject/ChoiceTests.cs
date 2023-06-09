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
            StringView test = new StringView("012");
            StringView expectedResult = new StringView("012", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            StringView test = new StringView("12");
            StringView expectedResult = new StringView("12", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            StringView test = new StringView("92");
            StringView expectedResult = new StringView("92", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
             new Character('0'),
             new Range('1', '9')
         );
            StringView test = new StringView("a9");
            StringView expectedResult = new StringView("a9", 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Choice(
                       new Character('0'),
                       new Range('1', '9')
                   );
            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("a9");
            StringView expectedResult = new StringView("a9", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("f8");
            StringView expectedResult = new StringView("f8", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("A9");
            StringView expectedResult = new StringView("A9", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("F8");
            StringView expectedResult = new StringView("F8", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("g8");
            StringView expectedResult = new StringView("g8", 0);
            var result = hex.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("0ab");
            StringView expectedResult = new StringView("0ab", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("abc");
            StringView expectedResult = new StringView("abc", 1);
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
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
            StringView test = new StringView("eabc");
            StringView expectedResult = new StringView("eabc", 1);
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}
