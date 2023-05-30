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
            var result = a.Match("0");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_ContainLetters_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("a");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveASingleDigit_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("7");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveMultipleDigits_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("70");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_IsNotNull_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match(null);
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_IsNotAnEmptyString_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_StartWithZero_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("07");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_StartWithMinusZero_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("-07");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("-26");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeMinusZero_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("-0");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeFractional_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12.34");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanHaveLeadingZeros_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("0.00000001");
            var res = a.Match("10.00000001");
            Assert.True(result.Success());
            Assert.True(res.Success());
        }

        [Fact]
        public void IsJsonNumber_DoesNotEndWithADot_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("12.");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_HaveTwoFractionParts_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("12.34.56");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheDecimalPartDoesNotAllowLetters_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("12.3x");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveAnExponent_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12e3");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanStartWithCapitalE_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12E3");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositive_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12e+3");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12e-3");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanHaveFractionAndExponent_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("12.34E3");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentDoesNotAllowLetters_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("12e3x3");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_HaveTwoExponents_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("22e323e33");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAlwaysComplete_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("22e");
            var resu = a.Match("22e+");
            var res = a.Match("22E-");
            Assert.False(result.Success());
            Assert.False(resu.Success());
            Assert.False(res.Success());

        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAfterTheFraction_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("22e3.2");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanBeNegative_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("-10.001");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeAndHaveExponent_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("-10e+1");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeFractionAndHaveExponent_ShouldReturnTrue()
        {
            var a = new Number();
            var result = a.Match("-10.0e+1");
            Assert.True(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositiveAndNegative_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("10+-1");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoubleNegative_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("10e--1");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoublePositive_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("10e++1");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_PlusSymbolWithoutExponent_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("10+1");
            Assert.False(result.Success());
        }

        [Fact]
        public void IsJsonNumber_MinusSymbolWithoutExponent_ShouldReturnFalse()
        {
            var a = new Number();
            var result = a.Match("10-1");
            Assert.False(result.Success());
        }
    }
}
