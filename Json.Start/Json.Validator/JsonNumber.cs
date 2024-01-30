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
            return !StartsWithZero(input) && !EndWithADot(input) && !HaveMoreThanOneFractionParts(input);
        }

        static bool ContainsDigits(string input)
        {
                foreach (char c in input)
                {
                  if (char.IsDigit(c))
                  {
                    const string searchString = "-";
                    const StringComparison comparison = StringComparison.InvariantCulture;
                    if (input.StartsWith(searchString, comparison))
                    {
                        return true;
                    }

                    return true;
                  }
                }

                return false;
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
            int count = 0;
            if (CountDots(input) == 1 || CountDots(input) == 0)
            {
                foreach (char c in input)
                {
                    if (char.IsLetter(c) && !IsExponent(c, input))
                    {
                        return true;
                    }
                    else if (char.IsLetter(c) && IsExponent(c, input))
                    {
                        count++;
                    }
                }
            }

            return CountDots(input) > 1 || count > 1;
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

        static bool IsExponent(char c, string str)
        {
            double result;
            return (str.Contains("E") || str.Contains("e")) && double.TryParse(str, out result);
        }
    }
}
