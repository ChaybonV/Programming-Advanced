using System;

namespace Chocolate_Bars
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

            string[] parts = input.Split(" ");
            ChocolateBar[] bars = new ChocolateBar[parts.Length];
            int count = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i]))
                    continue;

                string[] info = parts[i].Split(":");

                if (info.Length != 2)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                string name = info[0].Trim();
                int sweetness;

                if (!int.TryParse(info[1].Trim(), out sweetness))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                bars[count] = new ChocolateBar(name, sweetness, count);
                count++;
            }

            ChocolateBar[] validBars = new ChocolateBar[count];
            for (int i = 0; i < count; i++)
            {
                validBars[i] = bars[i];
            }

            Sorting sorting = new Sorting();
            sorting.Insertion(validBars);

            string result = "";
            for (int i = 0; i < validBars.Length; i++)
            {
                result += validBars[i].ToString();
                if (i < validBars.Length - 1)
                {
                    result += " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}
