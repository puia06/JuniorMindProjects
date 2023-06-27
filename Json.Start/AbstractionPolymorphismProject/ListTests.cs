using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class ListTests
    {
        [Fact]
        public void Match_List_Range_EndWithRangeMember_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1,2,3";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_List_Range_EndWithSeparator_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1,2,3,";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(",", result.RemainingText());
        }

        [Fact]
        public void Match_List_Range_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "1a";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("a", result.RemainingText());
        }

        [Fact]
        public void Match_List_Range_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "abc";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }

        [Fact]
        public void Match_List_Range_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = "";
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_List_Range_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            string test = null;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Null(result.RemainingText());
        }

        [Fact]
        public void Match_List_l_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "1; 22  ;\n 333 \t; 22";
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_List_lL_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "1 \n;";
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal(" \n;", result.RemainingText());
        }

        [Fact]
        public void Match_List_lLL_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            string test = "abc";
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal("abc", result.RemainingText());
        }
    }
}
