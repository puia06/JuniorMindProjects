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
                    IsDoubleQuoted(input);
        }

        public static bool ContainControlCharacter(string value)
        {
            char[] letters = { 'b', 'f', 'n', 'r', 't', '/', '\\', '\"', 'u' };

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '\\' && letters.Contains(value[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        public static string Quoted(string value)
        {
            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
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
    }
}
