using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class CharacterTests
    {
        [Fact]
        public void Match_StartsWith_pattern_ShouldReturnTrue()
        {
            var x = new Character('x');
            string test = "xabc";
            var result = x.Match(test);

            Assert.True(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_DifferentCharacter_ShouldReturnTrue()
        {
            var x = new Character('x');
            string test = "abc";
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var x = new Character('x');
            string test = null;
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var x = new Character('x');
            string test = "";
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }
    }
}
