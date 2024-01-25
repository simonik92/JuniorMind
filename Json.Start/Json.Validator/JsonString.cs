using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNull(input) && IsWrappedInDoubleQuotes(input);
        }

        static bool IsWrappedInDoubleQuotes(string input)
        {
            return input.Length > 1 && input[0] == '"' && input[input.Length - 1] == '"';
        }

        static bool IsNull(string input)
        {
            return input == null;
        }
    }
}
