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

            string test = "abc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_ManyPotentialMatches_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            string test = "aabc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            string test = "bc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            string test = "";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            string test = null;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_Symbol_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            string test = "123";
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.Equal("123", result.RemainingText());
        }

        [Fact]
        public void Match_Optional_Character_Symbol_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            string test = "-123";
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.Equal("123", result.RemainingText());
        }
    }
}
