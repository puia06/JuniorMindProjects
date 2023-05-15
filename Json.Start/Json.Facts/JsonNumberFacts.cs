
using Xunit;
using static Json.JsonNumber;

namespace Json.Facts
{
    public class JsonNumberFacts
    {
        [Fact]
        public void IsJsonNumber_CanBeZero_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0"));
        }

        [Fact]
        public void IsJsonNumber_ContainLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("a"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveASingleDigit_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("7"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveMultipleDigits_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("70"));
        }

        [Fact]
        public void IsJsonNumber_IsNotNull_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber(null));
        }

        [Fact]
        public void IsJsonNumber_IsNotAnEmptyString_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber(string.Empty));
        }

        [Fact]
        public void IsJsonNumber_StartWithZero_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("07"));
        }

        [Fact]
        public void IsJsonNumber_StartWithMinusZero_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("-07"));
        }

        [Fact]
        public void IsJsonNumber_CanBeNegative_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-26"));
        }

        [Fact]
        public void IsJsonNumber_CanBeMinusZero_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-0"));
        }

        [Fact]
        public void IsJsonNumber_CanBeFractional_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12.34"));
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanHaveLeadingZeros_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("0.00000001"));
            Assert.True(IsJsonNumber("10.00000001"));
        }

        [Fact]
        public void IsJsonNumber_DoesNotEndWithADot_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12."));
        }

        [Fact]
        public void IsJsonNumber_HaveTwoFractionParts_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12.34.56"));
        }

        [Fact]
        public void IsJsonNumber_TheDecimalPartDoesNotAllowLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("12.3x"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveAnExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12e3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanStartWithCapitalE_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12E3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositive_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12e+3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeNegative_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("61e-9"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveFractionAndExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("12.34E3"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentDoesNotAllowLetters_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e3x3"));
        }

        [Fact]
        public void IsJsonNumber_HaveTwoExponents_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e323e33"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAlwaysComplete_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e"));
            Assert.False(IsJsonNumber("22e+"));
            Assert.False(IsJsonNumber("23E-"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentIsAfterTheFraction_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22e3.3"));
        }

        [Fact]
        public void IsJsonNumber_ContainInvalidSymbols_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("22$5"));
        }

        [Fact]
        public void IsJsonNumber_TheFractionCanBeNegative_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-10.001"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanHaveMultipleDigits_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("10E123"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositiveAndHaveMultipleDigits_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("10E+123"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanNegativeAndHaveMultipleDigits_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("10e-123"));
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeAndHaveExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-10e+1"));
        }

        [Fact]
        public void IsJsonNumber_CanBeNegativeFractionAndHaveExponent_ShouldReturnTrue()
        {
            Assert.True(IsJsonNumber("-10.0e+1"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBePositiveAndNegative_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10e+-1"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoubleNegative_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10e--1"));
        }

        [Fact]
        public void IsJsonNumber_TheExponentCanBeDoublePositive_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10e++1"));
        }

        [Fact]
        public void IsJsonNumber_PlusSymbolWithoutExponent_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10+1"));
        }

        [Fact]
        public void IsJsonNumber_MinusSymbolWithoutExponent_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10-1"));
        }

        [Fact]
        public void IsJsonNumber_CanHaveSymbols_ShouldReturnFalse()
        {
            Assert.False(IsJsonNumber("10!1"));
        }
    }
}
