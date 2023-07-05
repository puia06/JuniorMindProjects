﻿using System;
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

            StringView test = new StringView("1,2,3");
            int expectedPosition = 5;
            var result = a.Match(test);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_Range_EndWithSeparator_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            StringView test = new StringView("1,2,3,");
            int expectedPosition = 5;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_Range_OneMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            StringView test = new StringView("1a");
            int expectedPosition = 1;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_Range_NoMatch_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            StringView test = new StringView("abc");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_Range_EmptyText_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_Range_NullText_ShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = a.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_l_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            StringView test = new StringView("1; 22  ;\n 333 \t; 22");
            int expectedPosition = test.GetText().Length;
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_lL_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            StringView test = new StringView("1 \n;");
            int expectedPosition = 1;
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_List_lLL_ShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            StringView test = new StringView("abc");
            int expectedPosition = 0;
            var result = list.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}

