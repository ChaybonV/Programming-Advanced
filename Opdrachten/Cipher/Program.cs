using System;
using System.Collections.Generic;

namespace Cipher
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            CipherMethods methods = new CipherMethods();

            int vowelCount = methods.CountVowels(input, 0);
            int digitProduct = methods.ProductOfDigits(input, 0, false);
            string uppercaseLetters = methods.GetUppercase(input, 0);
            int asciiSum = methods.SumASCII(input, 0);
            int uniqueLetters = methods.CountUniqueLetters(input.ToLower(), 0, new List<char>());
            int secondLargestDigit = methods.GetSecondLargestDigit(input);
            bool isPalindrome = methods.IsPalindrome(input, 0, input.Length - 1);

            string code = $"V{vowelCount}-D{digitProduct}-C{uppercaseLetters}-A{asciiSum}-U{uniqueLetters}-S{secondLargestDigit}-P{(isPalindrome ? "T" : "F")}";
            Console.WriteLine(code);
        }
    }
}
