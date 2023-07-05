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
            StringView test = new StringView("xabc");
            int expectedPosition = 1;
            var result = x.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }


        [Fact]
        public void Match_StartsWith_DifferentCharacter_ShouldReturnTrue()
        {
            var x = new Character('x');
            StringView test = new StringView("abc");
            int expectedPosition = 0;
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var x = new Character('x');
            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var x = new Character('x');
            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}
