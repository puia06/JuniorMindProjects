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
            var result = e.Match(test);
            StringView expectedResult = new StringView("ea", 1);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatchh_AnyFirstCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("Ea");
            StringView expectedResult = new StringView("Ea", 1);
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("Ea");
            StringView expectedResult = new StringView("Ea", 1);
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("a");
            StringView expectedResult = new StringView("a", 0);
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView(null);
            var result = e.Match(test);
            StringView expectedResult = new StringView(null, 0);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnyFirstCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView("+3");
            StringView expectedResult = new StringView("+3", 1);
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView("-2");
            StringView expectedResult = new StringView("-2", 1);
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            StringView test = new StringView("2");
            StringView expectedResult = new StringView("2", 0);
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("-+");

            StringView test = new StringView(null);
            var result = e.Match(test);
            StringView expectedResult = new StringView(null, 0);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("1+");

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}
