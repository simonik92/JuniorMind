using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && ContainsDigits(input);
        }

        static bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
