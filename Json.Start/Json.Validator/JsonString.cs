using System;
using System.Linq;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && IsWrappedInDoubleQuotes(input) && IsAValidString(input);
        }

        public static bool IsAValidString(string input)
        {
            return !ContainsControlCharacters(input) && CheckEscapeCharacter(input);
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
                if (c < ' ')
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheckEscapeCharacter(string input)
        {
            var skipNExtCharacter = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (skipNExtCharacter)
                {
                    skipNExtCharacter = false;
                    continue;
                }

                if (input[i] == '\\' && input[i + 1] == 'u' && !CheckHexNumber(input, i + 1))
                {
                    return false;
                }

                if (input[i] == '\\')
                {
                    if (i + 1 >= input.Length - 1)
                    {
                        return false;
                    }

                    const string escapeSymbols = "\"/bfnrtu\\";
                    if (escapeSymbols.Contains(input[i + 1]))
                    {
                        skipNExtCharacter = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool CheckHexNumber(string input, int i)
        {
            const int numberOfHexDigits = 4;
            int countTheHexDigits = 0;

            if (input.Length - 1 < i + 1 + numberOfHexDigits)
            {
                return false;
            }

            for (int j = i + 1; j < (i + 1) + numberOfHexDigits; j++)
            {
                if (char.IsBetween(input[j], '0', '9') || char.IsBetween(char.ToUpper(input[j]), 'A', 'Z'))
                {
                    countTheHexDigits++;
                }
            }

            return countTheHexDigits == numberOfHexDigits;
        }
    }
}
