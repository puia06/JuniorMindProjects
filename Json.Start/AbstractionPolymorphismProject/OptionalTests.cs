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
            int expectedPosition = 1;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_ManyPotentialMatches_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("aabc");
            int expectedPosition = 1;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("bc");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Optional(new Character('a'));

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_Symbol_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            StringView test = new StringView("123");
            int expectedPosition = 0;
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Optional_Character_Symbol_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var sign = new Optional(new Character('-'));

            StringView test = new StringView("-123");
            int expectedPosition = 1;
            var result = sign.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}