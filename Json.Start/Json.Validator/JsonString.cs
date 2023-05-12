using System;

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
                    if (!ControlCharacterValidator(value, index))
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

        private static bool ControlCharacterValidator(string value, int index)
        {
            int startIndex = index + 1;
            int endIndex = index + 4;

            if (!IsControlCharacter(value[index]) || index == value.Length - 1)
            {
                return false;
            }

            if (value[index] == 'u' && (endIndex > value.Length - 1 || !ValidHexaDec(value, startIndex, endIndex)))
            {
                return false;
            }

            return true;
        }

        private static bool IsControlCharacter(char a)
        {
            const string controlcharacters = "bfnrtu/\"\\";

            return controlcharacters.Contains(a);
        }

        private static bool ValidHexaDec(string value, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (!IsHexDigit(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsHexDigit(char c)
        {
            bool isvalidnumber = c >= '0' && c <= '9';
            bool isvalidletter = (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');

            return isvalidnumber || isvalidletter;
        }
    }
}
