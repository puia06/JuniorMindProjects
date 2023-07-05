using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class AnyTests
    {
        [Fact]
        public void Match_FirstTextCharacterMatch_AnyFirstCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("ea");
            int expectedPosition = 1;
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatchh_AnyFirstCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("Ea");
            int expectedPosition = 1;
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("Ea");
            int expectedPosition = 1;
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("a");
            int expectedPosition = 0;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView(null);
            var result = e.Match(test);
            int expectedPosition = 0;

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnyFirstCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView("+3");
            int expectedPosition = 1;
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView("-2");
            int expectedPosition = 1;
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("2");
            int expectedPosition = 0;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView(null);
            var result = e.Match(test);
            int expectedPosition = 0;

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("1+");

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}
