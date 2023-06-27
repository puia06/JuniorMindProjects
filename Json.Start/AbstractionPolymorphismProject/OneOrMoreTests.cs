using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class OneOrMoreTests
    {
        [Fact]
        public void Match_OneOrMore_Range_MultipleMatches_ShouldReturnTrueAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "123";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_OneOrMore_Range_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "1a";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("a", result.RemainingText());
        }

        [Fact]
        public void Match_OneOrMore_Range_NoMatch_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "bc";
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_OneOrMore_Range_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = "";
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_OneOrMore_Range_NullText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            string test = null;
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Null(result.RemainingText());
        }
    }
}
