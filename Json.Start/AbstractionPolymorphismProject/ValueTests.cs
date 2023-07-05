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
            StringView testJson = new StringView("true");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_falseValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("false");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_nullValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("null");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_StringValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("\"abc\"");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_NumberValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("7");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_ArrayValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("[ ]");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_ObjectValue_ShouldReturnTrue()
        {
            var value = new Value();

            StringView testJson = new StringView("{ }");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Array_Elements_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("[false, \"abc\"]");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Object_Members_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("{\r\n \"name\" :\"John Doe\",\r\n    \"age\" :30,\r\n    \"city\" :\"New York\"\r\n}");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Object_IncorrectString_ShouldReturnFalse()
        {
            var value = new Value();
            StringView testJson = new StringView("{name\" :\"John Doe\",\r\n    \"age\" :30,\r\n    \"city\" :\"New York\"\r\n}");
            var result = value.Match(testJson);
            int expectedPosition = 0;
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Object_wsws_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("{ \n }");
            int expectedPosition = testJson.GetText().Length;
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }

        [Fact]
        public void Match_Object_invalidObject_ShouldReturnFalse()
        {
            var value = new Value();
            StringView testJson = new StringView("{ \n  r}");
            int expectedPosition = 0;
            var result = value.Match(testJson);
            Assert.False(result.Success());
            Assert.Equal(expectedPosition, result.RemainingText().GetPosition());
        }
    }
}


