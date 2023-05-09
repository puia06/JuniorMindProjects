using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Json
{
    public static class JsonString
    {
        const int MaxASCIIValue = 127;

        public static bool IsJsonString(string input)
        {
            return !IsNull(input) &&
                    HasContent(input) &&
                    IsDoubleQuoted(input);
        }

        public static bool ContainValidControlCharacter(string value)
        {
            const int minUnicodeDigits = 4;
            const int firstUnicodIndex = 2;
            char[] characters = { 'b', 'f', 'n', 'r', 't', '/', '\\', '\"', 'u' };
            int count = 0;

            for (int i = 0; i < value.Length - 1; i++)
            {
                if (value[i] == '\\' && characters.Contains(value[i + 1]) && i != value.Length - 1)
                {
                    count++;
                }

                if (value[i] == '\\' && value[i + 1] == 'u' && !ValidHexaDec(value, i + firstUnicodIndex, i + 1 + minUnicodeDigits))
                {
                    return false;
                }
            }

            return count > 0;
        }

        public static bool ContainLargeUnicodeCharacters(string value)
        {
            foreach (char c in value)
            {
                if (c > MaxASCIIValue)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsDoubleQuoted(string value)
        {
            return value[0] == '"' && value[value.Length - 1] == '"';
        }

        private static bool IsNull(string value)
        {
            return value == null;
        }

        private static bool HasContent(string value)
        {
            return value != string.Empty;
        }

        private static bool ValidHexaDec(string value, int start, int end)
        {
            if (end > value.Length - 1)
            {
                return false;
            }

            while (start <= end)
            {
                if (value[start] >= '0' && value[start] <= '9')
                {
                    start++;
                }
                else if (value[start] >= 'a' && value[start] <= 'f' || value[start] >= 'A' && value[start] <= 'F')
                {
                    start++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
