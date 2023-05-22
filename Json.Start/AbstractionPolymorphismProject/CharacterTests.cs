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

            Assert.True(x.Match(test));
        }

        [Fact]
        public void Match_StartsWith_DifferentCharacter_ShouldReturnTrue()
        {
            var x = new Character('x');
            string test = "abc";

            Assert.False(x.Match(test));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var x = new Character('x');
            string test = null;

            Assert.False(x.Match(test));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var x = new Character('x');
            string test = "";

            Assert.False(x.Match(test));
        }
    }
}
