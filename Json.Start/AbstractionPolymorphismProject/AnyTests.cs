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

            string test = "ea";
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal("a", result.RemainingText());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("eE");

            string test = "Ea";
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal("a", result.RemainingText());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            string test = "a";
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal("a", result.RemainingText());
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            string test = null;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            string test = "";
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnyFirstCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            string test = "+3";
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal("3", result.RemainingText());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_AnySecondCharacter_Symbols_ShouldReturnTrueAndRemainingText()
        {
            var e = new Any("-+");

            string test = "-2";
            var result = e.Match(test);

            Assert.True(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_FirstTextCharacterMatch_DifferentAnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("eE");

            string test = "2";
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_NullTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("-+");

            string test = null;
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_EmptyTextCharacterMatch_AnyCharacters_Symbols_ShouldReturnFalseAndRemainingText()
        {
            var e = new Any("1+");

            string test = "";
            var result = e.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

    }
}
