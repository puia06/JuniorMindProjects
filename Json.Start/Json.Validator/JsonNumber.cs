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
                numberString = numberString.Remove(0, 1);
            }

            return !(numberString.StartsWith('0') && numberString.Length > 1) && IsDigits(numberString);
        }

        private static string Integer(string input, int decimalIndex, int exponentIndex)
        {
            int end = decimalIndex > 0 ? decimalIndex : exponentIndex;
            end = end > 0 ? end : input.Length;

            return input[..end];
        }

        private static bool IsFraction(string fractionString)
        {
            if (fractionString.Length > 1)
            {
                fractionString = fractionString.Remove(0, 1);
            }

            return IsDigits(fractionString) || fractionString == string.Empty;
        }

        private static string Fraction(string input, int decimalIndex, int exponentIndex)
        {
            if (decimalIndex <= 0)
            {
                return string.Empty;
            }

            int start = decimalIndex;
            int end = exponentIndex > 0 ? exponentIndex : input.Length;

            return input[start..end];
        }

        private static bool IsExponent(string exponentString)
        {
            if (exponentString.Length > 1 && (exponentString[1] == '+' || exponentString[1] == '-'))
            {
                exponentString = exponentString.Remove(0, 1);
            }

            if (exponentString.Length > 1)
            {
                exponentString = exponentString.Remove(0, 1);
            }

            return IsDigits(exponentString) || exponentString == string.Empty;
        }

        private static string Exponent(string input, int decimalIndex, int exponentIndex)
        {
            int start = exponentIndex > 0 ? exponentIndex : input.Length;

            return input[start..];
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
