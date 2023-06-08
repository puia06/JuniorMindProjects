using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class ValueTests
    {
        [Fact]
        public void Match_trueValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "true";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_falseValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "false";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_nullValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "null";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_StringValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "\"abc\"";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_NumberValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "7";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_ArrayValue_ShouldReturnTrue()
        {
            var value = new Value();
            var testJson = "[true, \"abc\"]";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_ObjectValue_ShouldReturnTrue()
        {
            var value = new Value();

            var testJson = " ";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());
        }
    }
}
