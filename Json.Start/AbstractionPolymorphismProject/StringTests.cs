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
            StringView expectedResult = new StringView(Quoted("abc"), 5);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_AlwaysStartsWithQuotse_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("abc\"");
            var result = a.Match(testJson);
            StringView expectedResult = new StringView("abc\"", 0);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_AlwaysEndsWithQuotes_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("\"abc");
            StringView expectedResult = new StringView("\"abc", 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_IsNull_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_AnEmptyStringIsNotAJsonString_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_ContainControlCharacters_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a\nb\rc");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainLargeUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted("⛅⚾");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedQuotationMark_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"\""a\"" b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \\ b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));

        }

        [Fact]
        public void IsJsonString_CanContainEscapedSolidus_ShouldReturnTrue()
        {

            var a = new String();
            string st = Quoted(@"a \/ b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedBackspace_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \b b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedFormFeed_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \f b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedLineFeed__ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \n b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedCarrigeReturn_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \r b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedHorizontalTab_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \t b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainEscapedUnicodeCharacters_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a \u26Be b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_CanContainAnyMultipleEscapeSequences_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"\\\u1212\n\t\r\\\b");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_DoesNotContainUnrecognizedExcapceCharacters_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\x"));
            StringView expectedResult = new StringView(Quoted(@"a\x"), 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonString_DoesNotEndWithReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\"));
            StringView expectedResult = new StringView(Quoted(@"a\"), 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonStringt_EndWithAnUnfinishedHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            StringView test1Json = new StringView(Quoted(@"a\u"));
            var ab = new String();
            StringView test2Json = new StringView(Quoted(@"a\u123"));
            StringView expectedResult = new StringView(Quoted(@"a\u"), 0);
            StringView expectedResultt = new StringView(Quoted(@"a\u123"), 0);
            var result = a.Match(test1Json);
            var resultt = ab.Match(test2Json);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText())); 
            Assert.False(resultt.Success());
            Assert.True(expectedResultt.CompareTo(resultt.RemainingText()));
        }

        [Fact]
        public void IsJsonStringt_EmptySpaceAfterReverseSolidus_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\ b abc"));
            StringView expectedResult = new StringView(Quoted(@"a\ b abc"), 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonStringt_InvalidHexNumber_ShouldReturnFalse()
        {
            var a = new String();
            StringView testJson = new StringView(Quoted(@"a\u123z io"));
            StringView expectedResult = new StringView(Quoted(@"a\u123z io"), 0);
            var result = a.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonStringt_ContainControlCharactersConsecutively_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"a\b\n\t");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonStringt_EndWithValidReverseSolidus_ShouldReturnTrue()
        {
            var a = new String();
            string st = Quoted(@"abc\\");
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
