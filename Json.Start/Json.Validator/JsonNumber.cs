using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNull(input) &&
                   !IsEmpty(input) &&
                   !ContainInvalidLettersAndSymbols(input) &&
                   IsValidNumber(input);
        }

        private static bool IsNull(string input)
        {
            return input == null;
        }

        private static bool IsEmpty(string input)
        {
            return input == string.Empty;
        }

        private static bool ContainInvalidLettersAndSymbols(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && (input[i] != 'e' && input[i] != 'E'))
                {
                    return true;
                }

                if (char.IsSymbol(input[i]) && (input[i] != '+' && input[i] != '-') && input[i] != '.')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidNumber(string input)
        {
            return !EndWithPoint(input) &&
                   !HaveDuplicateValidSymbols(input) &&
                   HaveValidFormat(input);
        }

        private static bool HaveValidFormat(string input)
        {
            return IsValidExponentFormat(input) ||
                   IsNaturalNumber(input) ||
                   IsDecimalNumber(input);
        }

        private static bool IsValidExponentFormat(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E')
                {
                   return HaveValidExponent(input, i);
                }
            }

            return false;
        }

        private static bool IsNaturalNumber(string input)
        {
            if (input[0] == '0' && input.Length > 1)
            {
                return false;
            }

            int n;
            return int.TryParse(input, out n);
        }

        private static bool IsDecimalNumber(string input)
        {
            if (input[0] == '0' && input[1] != '.')
            {
                return false;
            }

            decimal n;
            return decimal.TryParse(input, out n);
        }

        private static bool EndWithPoint(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool HaveDuplicateValidSymbols(string input)
        {
            int pointCount = 0;
            int plusMinusCount = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    pointCount++;
                }

                if (input[i] == '+' || input[i] == '-')
                {
                    plusMinusCount++;
                }
            }

            return pointCount > 1 || plusMinusCount > 1;
        }

        private static bool HaveValidExponent(string input, int index)
        {
            if (index >= input.Length - 1)
            {
                return false;
            }

            if (index == input.Length - 1 - 1 && (input[index + 1] == '+' || input[index + 1] == '-'))
            {
                return false;
            }

            for (int i = index + 1; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E')
                {
                    return false;
                }

                if (input[i] == '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
