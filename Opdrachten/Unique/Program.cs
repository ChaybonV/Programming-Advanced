using System;

class Program
{
    static void Main()
    {
        //5 8 2 10 6 3 8 2
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
            if (string.IsNullOrEmpty(parts[i].Trim()))
            {
                continue;
            }

            if (!int.TryParse(parts[i].Trim(),out int value))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            numbers[count] = value;
            count++;
        }

        if (count==0)
        {
            Console.WriteLine("Crazy input!");
            return;
        }

        int[] valid = new int[count];
        for (int i=0;i<count;i++)
        {
            valid[i] = numbers[i];
        }

        Array.Sort(valid);

        int uniqueCount = 0;
        int[] unique = new int[valid.Length];
        for (int i=0;i<valid.Length;i++)
        {
            if (i==0||valid[i]!=valid[i - 1])
            {
                unique[uniqueCount] = valid[i];
                uniqueCount++;
            }
        }
        
        for (int i=0;i<uniqueCount;i++)
        {
            Console.Write(unique[i]);
            if (i<uniqueCount-1)
                Console.Write(" ");
        }
    }
}