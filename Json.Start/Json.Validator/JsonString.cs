using System;

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
            return !ContainsControlCharacters(input) && ContainsEscapeCharacter(input) && !EndsWithAnUnfinishedHexNumber(input);
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
            const int controlCharactersCode = 32;
            foreach (char c in input)
            {
                if (c < controlCharactersCode)
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

        static bool EndsWithAnUnfinishedHexNumber(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\' && input[i + 1] == 'u')
                {
                    return !CheckHexNumber(input, i + 1);
                }
            }

            return false;
        }

        static bool CheckHexNumber(string input, int i)
        {
            const string hexaDigits = "0123456789ABCDEF";
            const int numberOfHexDigits = 4;
            int countTheHexDigits = 0;

            if (input.Length - 1 < i + 1 + numberOfHexDigits)
            {
                return false;
            }

            for (int j = i + 1; j < (i + 1) + numberOfHexDigits; j++)
            {
                for (int hexaDigitPosition = 0; hexaDigitPosition < hexaDigits.Length; hexaDigitPosition++)
                {
                    if (char.ToUpper(input[j]) == hexaDigits[hexaDigitPosition])
                    {
                        countTheHexDigits++;
                    }
                }
            }

            return countTheHexDigits == numberOfHexDigits;
        }
    }
}
