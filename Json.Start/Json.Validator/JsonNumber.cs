using Microsoft.CodeAnalysis;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (IsNull(input))
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
            int end = input.Length;

            if (decimalIndex > 0)
            {
                end = decimalIndex;
            }

            if (end != decimalIndex && exponentIndex > 0)
            {
                end = exponentIndex;
            }

            return SaveResult(input, 0, end);
        }

        private static bool IsFraction(string fractionString)
        {
            if (fractionString.Length > 1)
            {
                fractionString = fractionString.Remove(0, 1);
            }

            return IsDigits(fractionString) || IsEmpty(fractionString);
        }

        private static string Fraction(string input, int decimalIndex, int exponentIndex)
        {
            string result = "";
            if (decimalIndex > 0)
            {
                int end = input.Length;
                int start = decimalIndex;

                if (exponentIndex > 0)
                {
                    end = exponentIndex;
                }

                result = SaveResult(input, start, end);
            }

            return result;
        }

        private static bool IsExponent(string exponentString)
        {
            if (exponentString.Length > 1)
            {
                exponentString = exponentString.Remove(0, 1);
            }

            return IsDigits(exponentString) || IsEmpty(exponentString);
        }

        private static string Exponent(string input, int decimalIndex, int exponentIndex)
        {
            string result = "";

            if (exponentIndex > 0)
            {
                int start = exponentIndex;
                if (start < input.Length - 1 && (input[start + 1] == '+' || input[start + 1] == '-'))
                {
                    start++;
                }

                result = SaveResult(input, start, input.Length);
            }

            return result;
        }

        private static bool IsNull(string input)
        {
            return input == null;
        }

        private static bool IsEmpty(string input)
        {
            return input == "";
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

        private static string SaveResult(string input, int startIndex, int endIndex)
        {
            string result = "";
            for (int i = startIndex; i < endIndex; i++)
            {
                result += input[i];
            }

            return result;
        }
    }
}
