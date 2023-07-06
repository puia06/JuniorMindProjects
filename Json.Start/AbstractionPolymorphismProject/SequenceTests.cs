using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class SequenceTests
    {
        [Fact]
        public void Match_StartsWithTwoPatterns_ShouldReturnTrueAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            StringView test = new StringView("abcd");
            StringView expectedResult = new StringView("abcd", 2);
            var result = ab.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_FirstMatch_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            StringView test = new StringView("ax");
            StringView expectedResult = new StringView("ax", 0);
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_NoMatch_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            StringView test = new StringView("def");
            StringView expectedResult = new StringView("def", 0);
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_Empty_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_Null_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ComplexSequenceObj_ShouldReturnTrueAndRemainingText()
        {
            var hex = new Choice(
           new Range('0', '9'),
           new Range('a', 'f'),
           new Range('A', 'F')
       );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            StringView test = new StringView("u1234");
            StringView expectedResult = new StringView("u1234", 5);
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }


        [Fact]
        public void Match_ComplexSequenceObj_ShouldTestCorrect()
        {
            var hex = new Choice(
           new Range('0', '9'),
           new Range('a', 'f'),
           new Range('A', 'F')
       );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            StringView test = new StringView("uabcdef");
            StringView expectedResult = new StringView("uabcdef", 5);
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ComplexSequenceObj_ShouldTestCorrect_True()
        {
            var hex = new Choice(
           new Range('0', '9'),
           new Range('a', 'f'),
           new Range('A', 'F')
       );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            StringView test = new StringView("uB005 ab");
            StringView expectedResult = new StringView("uB005 ab", 5);
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ComplexSequenceObj_ShouldReturnFalseAndRemainingText()
        {
            var hex = new Choice(
           new Range('0', '9'),
           new Range('a', 'f'),
           new Range('A', 'F')
       );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            StringView test = new StringView("abc");
            StringView expectedResult = new StringView("abc", 0);
            var result = hexSeq.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ComplexSequenceObj_Null_ShouldReturnFalseAndRemainingText()
        {
            var hex = new Choice(
           new Range('0', '9'),
           new Range('a', 'f'),
           new Range('A', 'F')
       );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );
            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = hexSeq.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}
