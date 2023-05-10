using Xunit;
using static Json.JsonString;

namespace Json.Facts
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsJsonString_IsWrappedInDoubleQuotes_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void IsJsonString_AlwaysStartsWithQuotse_ShouldReturnFalse()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void IsJsonString_AlwaysEndsWithQuotes_ShouldReturnFalse()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsJsonString_IsNull_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsJsonString_AnEmptyStringIsNotAJsonString_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsJsonString_IsAnEmptyDoubleQuotedString_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void IsJsonString_ContainControlCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void IsJsonString_CanContainLargeUnicodeCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedQuotationMark_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedReverseSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedSolidus_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedBackspace_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedFormFeed_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedLineFeed__ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedCarrigeReturn_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedHorizontalTab_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedUnicodeCharacters_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact]
        public void IsJsonString_CanContainAnyMultipleEscapeSequences_ShouldReturnTrue()
        {
            Assert.True(IsJsonString(Quoted(@"\\\u1212\n\t\r\\\b")));
        }

        [Fact]
        public void IsJsonString_DoesNotContainUnrecognizedExcapceCharacters_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithReverseSolidus_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
        }

        [Fact]
        public void IsJsonStringt_EndWithAnUnfinishedHexNumber_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
        }

        [Fact]
        public void IsJsonStringt_InvalidHexNumber_ShouldReturnFalse()
        {
            Assert.False(IsJsonString(Quoted(@"a\u123z io")));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
