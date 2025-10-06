using System;

namespace Les_4
{
    public class Program
    {
        static void Main(string[] args)
        {

            Recursion recursion = new Recursion();

            //string basefolder = Console.ReadLine();
            string basefolder = "C:\\Users\\chayb\\Desktop\\2025-2026 Semester 1\\Programming Advanced\\FILES\\3orhyvogped";
            Console.WriteLine(recursion.Algorithm1(basefolder));

            Console.WriteLine("\n-------\n");

            string basefolder2 = "C:\\Users\\chayb\\Desktop\\2025-2026 Semester 1\\Programming Advanced\\FILES\\3orhyvogped";
            Console.WriteLine(recursion.Algorithm2(basefolder2));

            Console.WriteLine("\n-------\n");

            Console.WriteLine("Factorial: "+recursion.Factorial(6)); // method 1
            Console.WriteLine("Factorial recursion: " + recursion.FactorialRec(6)); // method 2

            Console.WriteLine("\n-------\n");

            //1.
            Console.WriteLine(recursion.SumOfNaturalNumbers(5));
            //2.
            Console.WriteLine(recursion.CountDigits(12345));
            //3.
            Console.WriteLine(recursion.ReverseString("hello"));
        }
    }
}
