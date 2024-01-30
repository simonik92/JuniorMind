using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && IsWrappedInDoubleQuotes(input) && !ContainsControlCharacters(input) && ContainsEscapeCharacter(input);
        }

        static bool IsWrappedInDoubleQuotes(string input)
        {
            return input.Length > 1 && input.StartsWith('"') && input.EndsWith('"');
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            foreach (char c in input)
            {
                if (char.IsControl(c))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsEscapeCharacter(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    return CheckEscapeCharacter(input, i);
                }
            }

            return true;
        }

        static bool CheckEscapeCharacter(string input, int i)
        {
            char[] escapeSymbols = { '\'', '"', '\\', '0', 'a', 'b', 'f', 'n', 'r', 't', 'v', 'u' };

            if (i < input.Length)
            {
                return false;
            }

            for (int j = 0; j < escapeSymbols.Length; j++)
            {
                if (input[i + 1] != escapeSymbols[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
