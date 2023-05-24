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

            string test = "true";
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_PrefixMatchText_RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "trueX";
            var result = truee.Match(test);

            Assert.True(result.Success());
            Assert.Equal("X", result.RemainingText());
        }

        [Fact]
        public void Match_PrefixDifferentFromText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "false";
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal("false", result.RemainingText());
        }

        [Fact]
        public void Match_NullText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = null;
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(null, result.RemainingText());
        }

        [Fact]
        public void Match_EmptyText_ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "";
            var result = truee.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_PrefixMatchText__EmptyRemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "false";
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_PrefixMatchText__RemainingText_ShouldReturnTrueAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "falseX";
            var result = falsee.Match(test);

            Assert.True(result.Success());
            Assert.Equal("X", result.RemainingText());
        }

        [Fact]
        public void Match_PrefixDifferentFromText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "true";
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal("true", result.RemainingText());
        }


        [Fact]
        public void Match_NullText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = null;
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal(null, result.RemainingText());
        }

        [Fact]
        public void Match_EmptyText__ShouldReturnFalseAndRemainingText()
        {
            var truee = new Text("true");
            var falsee = new Text("false");

            string test = "";
            var result = falsee.Match(test);

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_EmptyPrefix_ShouldReturnTrueAndRemainingText()
        {
            var empty = new Text("");

            string test = "true";
            var result = empty.Match(test);

            Assert.True(result.Success());
            Assert.Equal("true", result.RemainingText());
        }


        [Fact]
        public void Match_EmptyPrefixNullTest__ShouldReturnFalsedAndRemainingText()
        {
            var empty = new Text("");

            string test = null;
            var result = empty.Match(test);

            Assert.False(result.Success());
            Assert.Equal(null, result.RemainingText());
        }
    }
}
