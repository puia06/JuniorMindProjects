using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class StringTests
    {
        [Fact]
        public void IsJsonString_IsWrappedInDoubleQuotes_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted("abc"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_AlwaysStartsWithQuotse_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match("abc\"");
            Assert.False(result.Success());
            Assert.Equal("abc\"", result.RemainingText());
        }

        [Fact]
        public void IsJsonString_AlwaysEndsWithQuotes_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match("\"abc");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonString_IsNull_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match(null);
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonString_AnEmptyStringIsNotAJsonString_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match("");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonString_ContainControlCharacters_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted("a\nb\rc"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainLargeUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted("⛅⚾"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedQuotationMark_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"\""a\"" b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \\ b"));
            Assert.True(result.Success());
  
        }

        [Fact]
        public void IsJsonString_CanContainEscapedSolidus_ShouldReturnTrue()
        {

            var a = new String();
            var result = a.Match(Quoted(@"a \/ b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedBackspace_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \b b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedFormFeed_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \f b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedLineFeed__ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \n b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedCarrigeReturn_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \r b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedHorizontalTab_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \t b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a \u26Be b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_CanContainAnyMultipleEscapeSequences_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"\\\u1212\n\t\r\\\b"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonString_DoesNotContainUnrecognizedExcapceCharacters_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a\x"));
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a\"));
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonStringt_EndWithAnUnfinishedHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            var ab = new String();
            var result = a.Match(Quoted(@"a\u"));
            var resultt = ab.Match(Quoted(@"a\u123"));
            Assert.False(result.Success());
            Assert.False(resultt.Success());
        }

        [Fact]
        public void IsJsonStringt_EmptySpaceAfterReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a\ b abc"));
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonStringt_InvalidHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a\u123z io"));
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonStringt_ContainControlCharactersConsecutively_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"a\b\n\t"));
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonStringt_EndWithValidReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            var result = a.Match(Quoted(@"abc\\"));
            Assert.True(result.Success());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}

