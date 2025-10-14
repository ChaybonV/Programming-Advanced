using System;
using System.Collections.Generic;

namespace Cipher
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? "";

            int vowelCount = CountVowels(input, 0);
            int digitProduct = ProductOfDigits(input, 0, false);
            string uppercaseLetters = GetUppercase(input, 0);
            int asciiSum = SumASCII(input, 0);
            int uniqueLetters = CountUniqueLetters(input.ToLower(), 0, new List<char>());
            int secondLargestDigit = GetSecondLargestDigit(input);
            bool isPalindrome = IsPalindrome(input, 0, input.Length - 1);

            string code = $"V{vowelCount}-D{digitProduct}-C{uppercaseLetters}-A{asciiSum}-U{uniqueLetters}-S{secondLargestDigit}-P{(isPalindrome ? "T" : "F")}";
            Console.WriteLine(code);
        }

        // Vowel count (recursive)
        static int CountVowels(string s, int index)
        {
            if (index >= s.Length) return 0;
            char c = char.ToLower(s[index]);
            int current = "aeiou".Contains(c) ? 1 : 0;
            return current + CountVowels(s, index + 1);
        }

        // Digit product (recursive) met basecase 1 als geen digits
        static int ProductOfDigits(string s, int index, bool hasDigit)
        {
            if (index >= s.Length)
                return hasDigit ? 1 : 1; // basecase: geen digits → 1

            if (char.IsDigit(s[index]))
            {
                int digit = s[index] - '0';
                return digit * ProductOfDigits(s, index + 1, true);
            }
            return ProductOfDigits(s, index + 1, hasDigit);
        }

        // Uppercase letters (recursive)
        static string GetUppercase(string s, int index)
        {
            if (index >= s.Length) return "";
            char c = s[index];
            return (char.IsUpper(c) ? c.ToString() : "") + GetUppercase(s, index + 1);
        }

        // ASCII sum (recursive)
        static int SumASCII(string s, int index)
        {
            if (index >= s.Length) return 0;
            return (int)s[index] + SumASCII(s, index + 1);
        }

        // Unique letters (recursive)
        static int CountUniqueLetters(string s, int index, List<char> unique)
        {
            if (index >= s.Length) return unique.Count;
            char c = s[index];
            if (char.IsLetter(c) && !unique.Contains(c))
                unique.Add(c);
            return CountUniqueLetters(s, index + 1, unique);
        }

        // Second largest digit (recursive)
        static int GetSecondLargestDigit(string s)
        {
            List<int> digits = new List<int>();
            CollectDigits(s, 0, digits);
            if (digits.Count < 2) return 0;

            int first = -1, second = -1;
            FindTwoLargest(digits, 0, ref first, ref second);
            return second;
        }

        static void CollectDigits(string s, int index, List<int> digits)
        {
            if (index >= s.Length) return;
            if (char.IsDigit(s[index])) digits.Add(s[index] - '0');
            CollectDigits(s, index + 1, digits);
        }

        static void FindTwoLargest(List<int> digits, int index, ref int first, ref int second)
        {
            if (index >= digits.Count) return;
            int val = digits[index];
            if (val > first)
            {
                second = first;
                first = val;
            }
            else if (val > second && val != first)
            {
                second = val;
            }
            FindTwoLargest(digits, index + 1, ref first, ref second);
        }

        // Palindrome check (recursive, letters/digits only, case-insensitive)
        static bool IsPalindrome(string s, int left, int right)
        {
            if (left >= right) return true;

            if (!char.IsLetterOrDigit(s[left])) return IsPalindrome(s, left + 1, right);
            if (!char.IsLetterOrDigit(s[right])) return IsPalindrome(s, left, right - 1);

            if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;

            return IsPalindrome(s, left + 1, right - 1);
        }
    }
}
