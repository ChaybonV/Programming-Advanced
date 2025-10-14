using System;
using System.Collections.Generic;

namespace Cipher
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelCount = CountVowels(input, 0);
            int digitProduct = ProductOfDigits(input, 0);
            string uppercaseLetters = GetUppercase(input, 0);
            int asciiSum = SumASCII(input, 0);
            int uniqueLetters = CountUniqueLetters(input.ToLower(), 0, new List<char>());
            int secondLargestDigit = GetSecondLargestDigit(input, new List<int>(), 0);
            bool isPalindrome = IsPalindrome(input, 0, input.Length - 1);

            string code = $"V{vowelCount}-D{digitProduct}-C{uppercaseLetters}-A{asciiSum}-U{uniqueLetters}-S{secondLargestDigit}-P{(isPalindrome ? "T" : "F")}";
            Console.WriteLine(code);
        }

        // Vowel count
        static int CountVowels(string s, int index)
        {
            if (index >= s.Length) return 0;
            char c = char.ToLower(s[index]);
            int current = "aeiou".Contains(c) ? 1 : 0;
            return current + CountVowels(s, index + 1);
        }

        // Digit product
        static int ProductOfDigits(string s, int index)
        {
            if (index >= s.Length) return 1;
            if (char.IsDigit(s[index]))
            {
                int digit = s[index] - '0';
                return digit * ProductOfDigits(s, index + 1);
            }
            return ProductOfDigits(s, index + 1);
        }

        // Uppercase letters
        static string GetUppercase(string s, int index)
        {
            if (index >= s.Length) return "";
            char c = s[index];
            return (char.IsUpper(c) ? c.ToString() : "") + GetUppercase(s, index + 1);
        }

        // ASCII sum
        static int SumASCII(string s, int index)
        {
            if (index >= s.Length) return 0;
            return (int)s[index] + SumASCII(s, index + 1);
        }

        // Unique letters
        static int CountUniqueLetters(string s, int index, List<char> unique)
        {
            if (index >= s.Length) return unique.Count;
            char c = s[index];
            if (char.IsLetter(c) && !unique.Contains(c))
                unique.Add(c);
            return CountUniqueLetters(s, index + 1, unique);
        }

        // Second largest digit
        static int GetSecondLargestDigit(string s, List<int> digits, int index)
        {
            if (index >= s.Length)
            {
                if (digits.Count < 2) return 0;
                digits.Sort();
                digits.Reverse();
                return digits[1];
            }
            if (char.IsDigit(s[index]))
                digits.Add(s[index] - '0');
            return GetSecondLargestDigit(s, digits, index + 1);
        }

        // Palindrome check
        static bool IsPalindrome(string s, int left, int right)
        {
            if (left >= right) return true;
            if (s[left] != s[right]) return false;
            return IsPalindrome(s, left + 1, right - 1);
        }
    }
}
