using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class TextTests
    {
        [Fact]
        public void Match_PrefixMatchText_EmptyRemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("true");
            StringView expectedResult = new StringView("true", 4);
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_PrefixMatchText_RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("trueX");
            StringView expectedResult = new StringView("trueX", 4);
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_PrefixDifferentFromText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("false");
            StringView expectedResult = new StringView("false", 0);
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NullText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_PrefixMatchText__EmptyRemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("false");
            StringView expectedResult = new StringView("false", 5);
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_PrefixMatchText__RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("falseX");
            StringView expectedResult = new StringView("falseX", 5);
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_PrefixDifferentFromText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("true");
            StringView expectedResult = new StringView("true", 0);
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }


        [Fact]
        public void Match_NullText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_EmptyText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("");
            StringView expectedResult = new StringView("", 0);
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }   

        [Fact]
        public void Match_EmptyPrefix_ShouldReturnTrueAndRemainingText()
        {
            var empty = new Text("");

            StringView test = new StringView("true");
            StringView expectedResult = new StringView("true", 0);
            var result = empty.Match(test);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }


        [Fact]
        public void Match_EmptyPrefixNullTest__ShouldReturnFalsedAndRemainingText()
        {
            var empty = new Text("");

            StringView test = new StringView(null);
            StringView expectedResult = new StringView(null, 0);
            var result = empty.Match(test);

            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}

