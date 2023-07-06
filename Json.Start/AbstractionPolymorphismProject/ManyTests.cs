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
            StringView expectedResult = new StringView("abc", 1);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Many_Character_MultipleMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("aaaabc");
            StringView expectedResult = new StringView("aaaabc", 4);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Many_Character_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("bc");
            StringView expectedResult = new StringView("bc", 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Many_Character_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ManyCharacter_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new Many(new Character('a'));

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Many_Range_MultipleMatchShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            StringView test = new StringView("12345ab123");
            StringView expectedResult = new StringView("12345ab123", 5);
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Many_Ranger_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var digits = new Many(new Range('0', '9'));

            StringView test = new StringView("ab");
            StringView expectedResult = new StringView("ab", 0);
            var result = digits.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}



