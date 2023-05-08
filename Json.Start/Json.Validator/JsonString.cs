using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return IsDoubleQuoted(input);
        }

        public static string Quoted(string value)
        {
            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }

        private static bool IsDoubleQuoted(string value)
        {
            return value[0] == '"' && value[value.Length - 1] == '"';
        }
    }
}
