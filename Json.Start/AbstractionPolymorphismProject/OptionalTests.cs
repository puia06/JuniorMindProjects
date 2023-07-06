using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class OptionalTests
    {
        [Fact]
        public void Match_Optional_Character_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("abc");
            StringView expectedResult = new StringView("abc", 1);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_ManyPotentialMatches_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("aabc");
            StringView expectedResult = new StringView("aabc",1);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("bc");
            StringView expectedResult = new StringView("bc", 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_Symbol_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            StringView test = new StringView("123");
            StringView expectedResult = new StringView("123", 0);
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Optional_Character_Symbol_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            StringView test = new StringView("-123");
            StringView expectedResult = new StringView("-123", 1);
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}