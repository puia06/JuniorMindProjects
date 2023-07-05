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

            StringView test = new StringView("123");
            int expectedPosition = test.GetText().Length;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_OneOrMore_Range_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("1a");
            int expectedPosition = 1;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_OneOrMore_Range_NoMatch_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("bc");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_OneOrMore_Range_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_OneOrMore_Range_NullText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}
