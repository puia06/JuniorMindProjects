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
            StringView expectedResult = new StringView("123", 3);

            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_OneOrMore_Range_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("1a");
            StringView expectedResult = new StringView("1a", 1);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_OneOrMore_Range_NoMatch_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("bc");
            StringView expectedResult = new StringView("bc", 0);
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_OneOrMore_Range_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_OneOrMore_Range_NullText_ShouldReturnFalseAndRemainingText()
        {
            var a = new OneOrMore(new Range('0', '9'));

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = a.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}
