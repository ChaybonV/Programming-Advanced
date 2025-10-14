using System;
using System.Collections.Generic;

namespace Cipher
{
    public class CipherMethods
    {
        public int CountVowels(string s, int index = 0)
        {
            if (index >= s.Length)
            {
                return 0;
            }

            char c = char.ToLower(s[index]);
            int current = 0;

            if ("aeiou".Contains(c))
            {
                current = 1;
            }

            return current + CountVowels(s, index + 1);
        }

        public int ProductOfDigits(string s, bool hasDigit = false, int index = 0)
        {
            if (index >= s.Length)
            {
                return 1;
            }

            char c = s[index];

            if (char.IsDigit(c))
            {
                int digit = c - '0';
                return digit * ProductOfDigits(s, true, index + 1);
            }
            else
            {
                return ProductOfDigits(s, hasDigit, index + 1);
            }
        }

        public string GetUppercase(string s, int index = 0)
        {
            if (index >= s.Length)
            {
                return "";
            }

            char c = s[index];
            string result = "";

            if (char.IsUpper(c))
            {
                result = c.ToString();
            }

            return result + GetUppercase(s, index + 1);
        }

        public int SumASCII(string s, int index = 0)
        {
            if (index >= s.Length)
            {
                return 0;
            }

            return (int)s[index] + SumASCII(s, index + 1);
        }

        public int CountUniqueLetters(string s, List<char> unique, int index = 0)
        {
            if (index >= s.Length)
            {
                return unique.Count;
            }

            char c = s[index];

            if (char.IsLetter(c) && !unique.Contains(c))
            {
                unique.Add(c);
            }

            return CountUniqueLetters(s, unique, index + 1);
        }

        public int GetSecondLargestDigit(string s, int index = 0, int first = -1, int second = -1)
        {
            if (index >= s.Length)
            {
                if (second == -1)
                {
                    return 0;
                }
                else
                {
                    return second;
                }
            }

            char c = s[index];

            if (char.IsDigit(c))
            {
                int val = c - '0';

                if (val > first)
                {
                    second = first;
                    first = val;
                }
                else
                {
                    if (val > second && val != first)
                    {
                        second = val;
                    }
                }
            }

            return GetSecondLargestDigit(s, index + 1, first, second);
        }

        public bool IsPalindrome(string s, int right, int left = 0)
        {
            if (left >= right)
            {
                return true;
            }

            if (!char.IsLetterOrDigit(s[left]))
            {
                return IsPalindrome(s, right, left + 1);
            }

            if (!char.IsLetterOrDigit(s[right]))
            {
                return IsPalindrome(s, right - 1, left);
            }

            char leftChar = char.ToLower(s[left]);
            char rightChar = char.ToLower(s[right]);

            if (leftChar != rightChar)
            {
                return false;
            }

            return IsPalindrome(s, right - 1, left + 1);
        }
    }
}
