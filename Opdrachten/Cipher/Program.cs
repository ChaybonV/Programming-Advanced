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

            int vowelCount = methods.CountVowels(input);
            int digitProduct = methods.ProductOfDigits(input);
            string uppercaseLetters = methods.GetUppercase(input);
            int asciiSum = methods.SumASCII(input);
            int uniqueLetters = methods.CountUniqueLetters(input.ToLower(), new List<char>());
            int secondLargestDigit = methods.GetSecondLargestDigit(input);
            bool isPalindrome = methods.IsPalindrome(input, input.Length - 1);

            string palindromeLetter = "";
            if (isPalindrome)
            {
                palindromeLetter = "T";
            }
            else
            {
                palindromeLetter = "F";
            }

            string code = "V" + vowelCount + "-D" + digitProduct + "-C" + uppercaseLetters + "-A" + asciiSum + "-U" + uniqueLetters + "-S" + secondLargestDigit + "-P" + palindromeLetter;
            Console.WriteLine(code);
        }
    }
}
