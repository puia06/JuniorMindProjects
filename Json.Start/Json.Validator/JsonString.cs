using System;
using System.Linq;
using System.Reflection;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNull(input) &&
                    HasContent(input) &&
                    IsDoubleQuoted(input) &&
                    CanContainValidControlCharacter(input);
        }

        private static bool CanContainValidControlCharacter(string value)
        {
            const int minUnicodeDigits = 4;
            const int firstUnicodIndex = 2;
            int invalidIndexPosition = value.Length - 2;
            int index = 0;
            char[] characters = { 'b', 'f', 'n', 'r', 't', '/', '\\', '\"', 'u' };

            while (index < value.Length)
            {
                if (value[index] == '\\')
                {
                    if (!characters.Contains(value[index + 1]) || index == invalidIndexPosition)
                    {
                        return false;
                    }

                    if (value[index + 1] == 'u' && !ValidHexaDec(value, index + firstUnicodIndex, index + 1 + minUnicodeDigits))
                    {
                        return false;
                    }

                    index++;
                }

                index++;
            }

            return true;
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
