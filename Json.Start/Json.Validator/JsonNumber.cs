using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (input == null)
            {
                return false;
            }

            int decimalIndex = input.IndexOf('.');
            int exponentIndex = input.IndexOfAny("eE".ToCharArray());

            return IsInteger(Integer(input, decimalIndex, exponentIndex)) &&
                   IsFraction(Fraction(input, decimalIndex, exponentIndex)) &&
                   IsExponent(Exponent(input, decimalIndex, exponentIndex));
        }

        private static bool IsInteger(string numberString)
        {
            if (numberString.StartsWith('-') && numberString.Length > 1)
            {
                numberString = numberString[1..];
            }

            if (numberString.StartsWith('0') && numberString.Length > 1)
            {
                return false;
            }

            return IsDigits(numberString);
        }

        private static string Integer(string input, int decimalIndex, int exponentIndex)
        {
            int end = decimalIndex > 0 ? decimalIndex : exponentIndex;

            return end > 0 ? input[..end] : input[..input.Length];
        }

        private static bool IsFraction(string fractionString)
        {
            if (fractionString.Length > 1)
            {
                fractionString = fractionString[1..];
            }

            return IsDigits(fractionString) || fractionString == string.Empty;
        }

        private static string Fraction(string input, int decimalIndex, int exponentIndex)
        {
            if (decimalIndex == -1)
            {
                return string.Empty;
            }

            return exponentIndex > 0 ? input[decimalIndex..exponentIndex] : input[decimalIndex..input.Length];
        }

        private static bool IsExponent(string exponentString)
        {
            if (exponentString.Length > 1 && (exponentString[1] == '+' || exponentString[1] == '-'))
            {
                exponentString = exponentString[1..];
            }

            if (exponentString.Length > 1)
            {
                exponentString = exponentString[1..];
            }

            return IsDigits(exponentString) || exponentString == string.Empty;
        }

        private static string Exponent(string input, int decimalIndex, int exponentIndex)
        {
            return exponentIndex != -1 ? input[exponentIndex..] : input[input.Length..];
        }

        private static bool IsDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return input.Length > 0;
        }
    }
}
