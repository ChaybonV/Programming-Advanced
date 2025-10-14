using System;
using System.Collections.Generic;

namespace Cipher
{
    public class CipherMethods
    {
        // Vowel count (recursive)
        public int CountVowels(string s, int index)
        {
            if (index >= s.Length) return 0;
            char c = char.ToLower(s[index]);
            int current = "aeiou".Contains(c) ? 1 : 0;
            return current + CountVowels(s, index + 1);
        }

        // Digit product (recursive) met basecase 1 als geen digits
        public int ProductOfDigits(string s, int index, bool hasDigit)
        {
            if (index >= s.Length)
                return hasDigit ? 1 : 1; // basecase → 1, ook als er geen cijfers zijn

            if (char.IsDigit(s[index]))
            {
                int digit = s[index] - '0';
                return digit * ProductOfDigits(s, index + 1, true);
            }

            return ProductOfDigits(s, index + 1, hasDigit);
        }

        // Uppercase letters (recursive)
        public string GetUppercase(string s, int index)
        {
            if (index >= s.Length) return "";
            char c = s[index];
            return (char.IsUpper(c) ? c.ToString() : "") + GetUppercase(s, index + 1);
        }

        // ASCII sum (recursive)
        public int SumASCII(string s, int index)
        {
            if (index >= s.Length) return 0;
            return (int)s[index] + SumASCII(s, index + 1);
        }

        // Unique letters (recursive)
        public int CountUniqueLetters(string s, int index, List<char> unique)
        {
            if (index >= s.Length) return unique.Count;
            char c = s[index];
            if (char.IsLetter(c) && !unique.Contains(c))
                unique.Add(c);
            return CountUniqueLetters(s, index + 1, unique);
        }

        // Second largest digit (volledig recursive)
        public int GetSecondLargestDigit(string s)
        {
            return GetSecondLargestDigitRec(s, 0, -1, -1);
        }

        private int GetSecondLargestDigitRec(string s, int index, int first, int second)
        {
            if (index >= s.Length)
                return second == -1 ? 0 : second;

            if (char.IsDigit(s[index]))
            {
                int val = s[index] - '0';
                if (val > first)
                {
                    second = first;
                    first = val;
                }
                else if (val > second && val != first)
                {
                    second = val;
                }
            }

            return GetSecondLargestDigitRec(s, index + 1, first, second);
        }

        // Palindrome check (recursive, letters/digits only, case-insensitive)
        public bool IsPalindrome(string s, int left, int right)
        {
            if (left >= right) return true;

            if (!char.IsLetterOrDigit(s[left])) return IsPalindrome(s, left + 1, right);
            if (!char.IsLetterOrDigit(s[right])) return IsPalindrome(s, left, right - 1);

            if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;

            return IsPalindrome(s, left + 1, right - 1);
        }
    }
}
