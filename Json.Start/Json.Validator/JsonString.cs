using System;
using System.Linq;

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
            for (int index = 0; index < value.Length; index++)
            {
                if (value[index] == '\\')
                {
                    index++;
                    if (!Validator(value, index))
                    {
                        return false;
                    }
                }
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

        private static bool Validator(string value, int index)
        {
            char[] characters = { 'b', 'f', 'n', 'r', 't', '/', '\\', '\"', 'u' };
            int startIndex = index + 1;
            int endIndex = index + 4;

            if (!characters.Contains(value[index]) || index == value.Length - 1)
            {
                return false;
            }

            if (value[index] == 'u' && (endIndex > value.Length - 1 || !ValidHexaDec(value, startIndex, endIndex)))
            {
                return false;
            }

            return true;
        }

        private static bool ValidHexaDec(string value, int start, int end)
        {
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
