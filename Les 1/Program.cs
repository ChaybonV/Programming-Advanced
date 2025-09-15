using System;

namespace Les_1
{

    class Program
    {
        static void Main(string[] args)
        {
            Searching search = new Searching();

            Console.WriteLine("Give a number"); // 836
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"LINEAR: {search.Linear(number)} --> {search.Count}");
            Console.WriteLine($"STUPID: {search.Stupid(number)} --> {search.Count}");
            Console.WriteLine($"BINARY: {search.Binary(number)} --> {search.Count}");

            Console.WriteLine("\nGive a number"); // -672
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"LINEAR: {search.Linear(number2)} --> {search.Count}");
            Console.WriteLine($"STUPID: {search.Stupid(number2)} --> {search.Count}");
            Console.WriteLine($"BINARY: {search.Binary(number2)} --> {search.Count}");

            Console.WriteLine("\nGive a number"); // -630
            int number3 = int.Parse(Console.ReadLine());
            Console.WriteLine($"LINEAR: {search.Linear(number3)} --> {search.Count}");
            Console.WriteLine($"STUPID: {search.Stupid(number3)} --> {search.Count}");
            Console.WriteLine($"BINARY: {search.Binary(number3)} --> {search.Count}");
        }
    }
}
