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
            StringView testJson = new StringView(Quoted("abc"));
            var result = a.Match(testJson);
            int expectedPosition = testJson.GetText().Length;
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_AlwaysStartsWithQuotse_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("abc\"");
            var result = a.Match(testJson);
            int expectedPosition = 0;
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_AlwaysEndsWithQuotes_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("\"abc");
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_IsNull_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(null);
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_AnEmptyStringIsNotAJsonString_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("");
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_ContainControlCharacters_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\nb\rc"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainLargeUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted("⛅⚾"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedQuotationMark_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"\""a\"" b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \\ b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());

        }

        [Fact]
        public void IsJsonString_CanContainEscapedSolidus_ShouldReturnTrue()
        {

            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \/ b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedBackspace_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \b b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedFormFeed_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \f b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedLineFeed__ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \n b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedCarrigeReturn_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \r b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedHorizontalTab_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \t b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainEscapedUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a \u26Be b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_CanContainAnyMultipleEscapeSequences_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"\\\u1212\n\t\r\\\b"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_DoesNotContainUnrecognizedExcapceCharacters_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\x"));
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\"));
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonStringt_EndWithAnUnfinishedHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            StringView test1Json = new StringView(Quoted(@"a\u"));
            var ab = new String();
            StringView test2Json = new StringView(Quoted(@"a\u123"));
            int expectedPosition = 0;
            var result = a.Match(test1Json);
            var resultt = ab.Match(test2Json);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
            Assert.True(resultt.Success());
            Assert.Equal(expectedPosition, resultt.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonStringt_EmptySpaceAfterReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\ b abc"));
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonStringt_InvalidHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\u123z io"));
            int expectedPosition = 0;
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonStringt_ContainControlCharactersConsecutively_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\b\n\t"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void IsJsonStringt_EndWithValidReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"abc\\"));
            int expectedPosition = testJson.GetText().Length;
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
