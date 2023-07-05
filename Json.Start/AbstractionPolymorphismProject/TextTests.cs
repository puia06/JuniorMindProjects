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
            int expectedPosition = test.GetText().Length;
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_PrefixMatchText_RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("trueX");
            int expectedPosition = 4;
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_PrefixDifferentFromText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("false");
            int expectedPosition = 0;
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NullText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_PrefixMatchText__EmptyRemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("false");
            int expectedPosition = test.GetText().Length;
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_PrefixMatchText__RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("falseX");
            int expectedPosition = 5;
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_PrefixDifferentFromText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("true");
            int expectedPosition = 0;
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }


        [Fact]
        public void Match_NullText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            StringView test = new StringView("");
            int expectedPosition = 0;
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_EmptyPrefix_ShouldReturnTrueAndRemainingText()
        {
            var empty = new Text("");

            StringView test = new StringView("true");
            int expectedPosition = 0;
            var result = empty.Match(test);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }


        [Fact]
        public void Match_EmptyPrefixNullTest__ShouldReturnFalsedAndRemainingText()
        {
            var empty = new Text("");

            StringView test = new StringView(null);
            int expectedPosition = 0;
            var result = empty.Match(test);

            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}

