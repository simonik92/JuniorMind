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
                const int positionOfLastChar = 2;
                if (input[input.Length - positionOfLastChar] == '\\')
                {
                    return false;
                }
                else if (input[i] == '\\')
                {
                    return CheckEscapeCharacter(input, i);
                }
            }

            return true;
        }

        static bool CheckEscapeCharacter(string input, int i)
        {
            int count = 0;
            const string escapeSymbols = "\\\"/bfnrtu";

            for (int j = 0; j < escapeSymbols.Length; j++)
            {
                if (input[i + 1] == escapeSymbols[j])
                {
                    count++;
                }
            }

            return count > 0;
        }
    }
}
