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
            StringView expectedResult = new StringView("xabc", 1);
            var result = x.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }


        [Fact]
        public void Match_StartsWith_DifferentCharacter_ShouldReturnTrue()
        {
            var x = new Character('x');
            StringView test = new StringView("abc");
            StringView expectedResult = new StringView("abc", 0);
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var x = new Character('x');
            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var x = new Character('x');
            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = x.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}
