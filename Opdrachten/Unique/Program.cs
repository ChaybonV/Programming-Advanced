using System;

class Program
{
    static void Main()
    {
        //5 8 2 10 6 3 8 2
        //-1 -5 -3 -9 -6 -2 -1
        Console.WriteLine("Give a list of numbers, separated by spaces");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Crazy input!");
            return;
        }

        string[] parts = input.Split(" ");
        int[] numbers = new int[parts.Length];
        int count = 0;

        for (int i=0;i<parts.Length;i++)
        {
            if (string.IsNullOrEmpty(parts[i]))
            {
                continue;
            }

            if (!int.TryParse(parts[i],out int value))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            numbers[count] = value;
            count++;
        }

        Unique unique = new Unique();
        int[] uniqueArray = unique.GetUnique(numbers);

        for (int i=0;i<uniqueArray.Length;i++)
        {
            Console.Write(uniqueArray[i]);
            if (i < uniqueArray.Length-1)
                Console.Write(" ");
        }
    }
}