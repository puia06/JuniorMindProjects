using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNull(input) &&
                   !IsEmpty(input) &&
                   !ContainInvalidLettersOrSymbols(input) &&
                   HaveValidFormat(input);
        }

        private static bool IsNull(string input)
        {
            return input == null;
        }

        private static bool IsEmpty(string input)
        {
            return input == string.Empty;
        }

        private static bool ContainInvalidLettersOrSymbols(string input)
        {
            int pointCount = 0;
            int plusMinusCount = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if ((char.IsSymbol(input[i]) || char.IsLetter(input[i])) && !IsValidCharacter(input[i]))
                {
                    return true;
                }

                if (input[i] == '.')
                {
                    pointCount++;
                }

                if (input[i] == '+' || (input[i] == '-' && i != 0))
                {
                    plusMinusCount++;
                }
            }

            return pointCount > 1 || plusMinusCount > 1;
        }

        private static bool IsValidCharacter(char c)
        {
            char[] validcharacters = { 'e', 'E', '+', '-', '.' };

            return validcharacters.Contains(c);
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
                    return HaveValidExponent(input, i) && i < input.Length - 1 && (input[input.Length - 1] != '+' && input[input.Length - 1] != '-');
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
            return decimal.TryParse(input, out n) && !EndWithPoint(input);
        }

        private static bool EndWithPoint(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool HaveValidExponent(string input, int index)
        {
            for (int i = index + 1; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E' || input[i] == '.')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
