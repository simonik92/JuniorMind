using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && ContainsDigits(input) && IsAValidNumber(input);
        }

        static bool IsAValidNumber(string input)
        {
            return !StartsWithZero(input) && !EndWithADot(input) && !HaveMoreThanOneFractionParts(input) && CanBeNegative(input);
        }

        static bool ContainsDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        static bool StartsWithZero(string input)
        {
            return input.StartsWith('0') && input.Length > 1 && input[1] != '.';
        }

        static bool EndWithADot(string input)
        {
            return input.EndsWith('.');
        }

        static bool HaveMoreThanOneFractionParts(string input)
        {
            return CountDots(input) > 1;
        }

        static int CountDots(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == '.')
                {
                    count++;
                }
            }

            return count;
        }

        static bool CanBeNegative(string input)
        {
            const string searchString = "-";
            const StringComparison comparison = StringComparison.InvariantCulture;
            return input.StartsWith(searchString, comparison);
        }
    }
}
