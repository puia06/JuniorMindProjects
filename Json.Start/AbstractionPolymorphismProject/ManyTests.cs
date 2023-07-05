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

            StringView test = new StringView("abc");
            int expectedPosition = 1;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Many_Character_MultipleMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("aaaabc");
            int expectedPosition = 4;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Many_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("bc");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Many_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_ManyCharacter_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Many_Range_MultipleMatchShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            StringView test = new StringView("12345ab123");
            int expectedPosition = 5;
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Many_Ranger_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            StringView test = new StringView("ab");
            int expectedPosition = 0;
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}



