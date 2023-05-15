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
        private const string InvalidInput = "Invalid input";

        public static bool IsJsonNumber(string input)
        {
            return IsInteger(Integer(input)) &&
                   IsFraction(Fraction(input)) &&
                   IsExponent(Exponent(input));
        }

        private static bool IsInteger(string numberString)
        {
            if (StartWithMinus(numberString))
            {
                numberString = numberString.Remove(0, 1);
            }

            return !StartWithZero(numberString) && HasValidContent(numberString);
        }

        private static string Integer(string input)
        {
            string result = "";

            if (IsEmpty(input) || IsNull(input))
            {
                return InvalidInput;
            }

            foreach (char c in input)
            {
                if (!IsPoint(c) && !IsExponentChar(c))
                {
                    result += c;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private static bool IsFraction(string fractionString)
        {
            return HasValidContent(fractionString);
        }

        private static string Fraction(string input)
        {
            string result = "";
            int length = input.Length;

            if (input.Contains('.'))
            {
                int start = input.IndexOf('.') + 1;
                if (input.Contains('e') || input.Contains('E'))
                {
                    length = ExtractExponentIndex(input);
                }

                if (start >= length)
                {
                    return InvalidInput;
                }

                result = SaveResult(input, start, length);
            }

            return result;
        }

        private static bool IsExponent(string exponentString)
        {
            return HasValidContent(exponentString);
        }

        private static string Exponent(string input)
        {
            string result = "";

            if (input.Contains('e') || input.Contains('E'))
            {
                int start = ExtractExponentIndex(input) + 1;
                if (start < input.Length - 1 && IsPlusMinus(input[start]))
                {
                    start++;
                }

                if (start >= input.Length)
                {
                    return InvalidInput;
                }

                result = SaveResult(input, start, input.Length);
            }

            return result;
        }

        private static bool IsEmpty(string input)
        {
            return input == string.Empty;
        }

        private static bool IsNull(string input)
        {
            return input == null;
        }

        private static bool HasValidContent(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPlusMinus(char a)
        {
            return a == '+' || a == '-';
        }

        private static bool StartWithMinus(string input)
        {
            return input[0] == '-' && input.Length > 1;
        }

        private static bool StartWithZero(string input)
        {
            return input[0] == '0' && input.Length > 1;
        }

        private static bool IsPoint(char c)
        {
            return c == '.';
        }

        private static bool IsExponentChar(char c)
        {
            return c == 'e' || c == 'E';
        }

        private static int ExtractExponentIndex(string input)
        {
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (IsExponentChar(input[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
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
