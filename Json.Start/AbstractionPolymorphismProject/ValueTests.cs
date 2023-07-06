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
            StringView expectedResult = new StringView("true", 4);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_falseValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("false");
            StringView expectedResult = new StringView("false", 5);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_nullValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("null");
            StringView expectedResult = new StringView("null", 4);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_StringValue_ShouldReturnTrue()
        {
            var value = new Value();
            string st = "\"abc\"";
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_NumberValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("7");
            StringView expectedResult = new StringView("7", 1);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ArrayValue_ShouldReturnTrue()
        {
            var value = new Value();
            StringView testJson = new StringView("[ ]");
            StringView expectedResult = new StringView("[ ]", 3);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_ObjectValue_ShouldReturnTrue()
        {
            var value = new Value();

            StringView testJson = new StringView("{ }");
            StringView expectedResult = new StringView("{ }", 3);
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Array_Elements_ShouldReturnTrue()
        {
            var value = new Value();
            string st = "[false, \"abc\"]";
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Object_Members_ShouldReturnTrue()
        {
            var value = new Value();
            string st = "{\r\n \"name\" :\"John Doe\",\r\n    \"age\" :30,\r\n    \"city\" :\"New York\"\r\n}";
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Object_IncorrectString_ShouldReturnFalse()
        {
            var value = new Value();
            StringView testJson = new StringView("{name\" :\"John Doe\",\r\n    \"age\" :30,\r\n    \"city\" :\"New York\"\r\n}");
            var result = value.Match(testJson);
            StringView expectedResult = new StringView("{name\" :\"John Doe\",\r\n    \"age\" :30,\r\n    \"city\" :\"New York\"\r\n}", 0);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Object_wsws_ShouldReturnTrue()
        {
            var value = new Value();
            string st = "{ \n }";
            StringView testJson = new StringView(st);
            StringView expectedResult = new StringView(st, st.Length);
            var result = value.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void Match_Object_invalidObject_ShouldReturnFalse()
        {
            var value = new Value();
            StringView testJson = new StringView("{ \n  r}");
            StringView expectedResult = new StringView("{ \n  r}", 0);
            var result = value.Match(testJson);
            Assert.False(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}


