using System;

namespace North_Pole_Decorating
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            string[] tempParts = line.Split(new char[] { ' ', '\t' });

            int count = 0;
            for (int i = 0; i < tempParts.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(tempParts[i]))
                {
                    count++;
                }
            }

            string[] parts = new string[count];
            int index = 0;
            for (int i = 0; i < tempParts.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(tempParts[i]))
                {
                    parts[index] = tempParts[i];
                    index++;
                }
            }

            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                int value;
                if (!int.TryParse(parts[i], out value))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }
                numbers[i] = value;
            }

            Tree tree = new Tree();
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Insert(numbers[i]);
            }

            string result = tree.LevelOrder();
            Console.WriteLine(result);
        }
    }
}
