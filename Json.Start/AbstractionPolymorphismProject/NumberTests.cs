using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class NumberTests
    {
        [Fact]
        public void IsJsonNumber_CanBeZero_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("0");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_ContainLetters_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("a");
            var result = a.Match(testJson);
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveASingleDigit_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("7");
            var result = a.Match(testJson);
            Assert.True(result.Success());

        }

        [Fact]
        public void IsJsonNumber_CanHaveMultipleDigits_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("70");
            var result = a.Match(testJson);
            Assert.True(result.Success());

        }

        [Fact]
        public void IsJsonNumber_IsNotNull_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView(null);
            var result = a.Match(testJson);
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_IsNotAnEmptyString_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("");
            var result = a.Match(testJson);
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_StartWithZero_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("07");
            StringView expectedResult = new StringView("07", 1);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_StartWithMinusZero_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("-07");
            StringView expectedResult = new StringView("-07", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_CanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("-26");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeMinusZero_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("-0");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeFractional_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12.34");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanHaveLeadingZeros_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("0.00000001");
            StringView testJsonn = new StringView("10.00000001");
            var result = a.Match(testJson);
            var res = a.Match(testJsonn);
            Assert.True(result.Success());
            Assert.True(res.Success());
        }

        [Fact]
        public void IsJsonNumber_DoesNotEndWithADot_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("12.");
            StringView expectedResult = new StringView("12.", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_HaveTwoFractionParts_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("12.34.56");
            StringView expectedResult = new StringView("12.34.56", 5);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));

        }

        [Fact]
        public void IsJsonNumber_TheDecimalPartDoesNotAllowLetters_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("12.3x");
            StringView expectedResult = new StringView("12.3x", 4);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_CanHaveAnExponent_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12e3");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanStartWithCapitalE_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12E3");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositive_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12e+3");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12e-3");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveFractionAndExponent_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("12.34E3");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentDoesNotAllowLetters_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("12e3x3");
            StringView expectedResult = new StringView("12e3x3", 4);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_HaveTwoExponents_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("22e323e33");
            StringView expectedResult = new StringView("22e323e33", 6);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAlwaysComplete_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("22e");
            StringView expectedResult = new StringView("22e", 2);
            StringView testJsonn = new StringView("22e+");
            StringView expectedResultt = new StringView("22e+", 2);
            StringView testJsonnn = new StringView("22E-");
            StringView expectedResulttt = new StringView("22E-", 2);
            var result = a.Match(testJson);
            var resu = a.Match(testJsonn);
            var res = a.Match(testJsonnn);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
            Assert.True(resu.Success());
            Assert.True(expectedResultt.CompareTo(resu.RemainingText()));
            Assert.True(res.Success());
            Assert.True(expectedResulttt.CompareTo(res.RemainingText()));

        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAfterTheFraction_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("22e3.2");
            StringView expectedResult = new StringView("22e3.2", 4);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("-10.001");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeAndHaveExponent_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("-10e+1");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeFractionAndHaveExponent_ShouldReturnTrue()
        {
            var a = new Number();
            StringView testJson = new StringView("-10.0e+1");
            var result = a.Match(testJson);
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositiveAndNegative_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("10+-1");
            StringView expectedResult = new StringView("10+-1", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoubleNegative_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("10e--1");
            StringView expectedResult = new StringView("10e--1", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoublePositive_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("10e++1");
            StringView expectedResult = new StringView("10e++1", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_PlusSymbolWithoutExponent_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("10+1");
            StringView expectedResult = new StringView("10+1", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }

        [Fact]
        public void IsJsonNumber_MinusSymbolWithoutExponent_ShouldReturnFalse()
        {
            var a = new Number();
            StringView testJson = new StringView("10-1");
            StringView expectedResult = new StringView("10-1", 2);
            var result = a.Match(testJson);
            Assert.True(result.Success());
            Assert.True(expectedResult.CompareTo(result.RemainingText()));
        }
    }
}

