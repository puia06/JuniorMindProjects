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
            string test = "abcd";
            var result = ab.Match(test);

            Assert.True(result.Success());
            Assert.Equal("cd", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_FirstMatch_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            string test = "ax";
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.Equal("ax", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_NoMatch_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            string test = "def";
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.Equal("def", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_Empty_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            string test = "";
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.Equal(test, result.RemainingText());
        }

        [Fact]
        public void Match_StartsWithTwoPatterns_Null_ShouldReturnFalseAndRemainingText()
        {
            var ab = new Sequence(
    new Character('a'),
    new Character('b')
            );
            string test = null;
            var result = ab.Match(test);

            Assert.False(result.Success());
            Assert.Equal(test, result.RemainingText());
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
            string test = "u1234";
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
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
            string test = "uabcdef";
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ef", result.RemainingText());
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
            string test = "uB005 ab";
            var result = hexSeq.Match(test);

            Assert.True(result.Success());
            Assert.Equal(" ab", result.RemainingText());
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
            string test = "abc";
            var result = hexSeq.Match(test);

            Assert.False(result.Success());
            Assert.Equal("abc", result.RemainingText());
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
            string test = null;
            var result = hexSeq.Match(test);

            Assert.False(result.Success());
            Assert.Equal(test, result.RemainingText());
        }
    }
}
