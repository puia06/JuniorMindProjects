using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class ManyTests
    {
        [Fact]
        public void Match_Many_Character_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            string test = "abc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_Many_Character_MultipleMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            string test = "aaaabc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_Many_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            string test = "bc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_Many_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            string test = "";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_ManyCharacter_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            string test = null;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(null, result.RemainingText());
        }

        [Fact]
        public void Match_Many_Range_MultipleMatchShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            string test = "12345ab123";
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ab123", result.RemainingText());
        }

        [Fact]
        public void Match_Many_Ranger_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            string test = "ab";
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ab", result.RemainingText());
        }
    }
}
