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
        }
    }
}
