using System;

namespace MagicBridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            if (string.IsNullOrEmpty(firstLine))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string[] firstParts = firstLine.Trim().Split(" ");
            if (firstParts.Length != 2)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            int n;
            int k;
            if (!int.TryParse(firstParts[0], out n) || !int.TryParse(firstParts[1], out k))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string secondLine = Console.ReadLine();
            if (string.IsNullOrEmpty(secondLine))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string[] secondParts = secondLine.Trim().Split(" ");
            if (secondParts.Length != n)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            int[] planks = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(secondParts[i], out planks[i]))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }
            }

            TreasureHunter hunter = new TreasureHunter();
            Console.WriteLine(hunter.FindMaxEnergy(n, k, planks));
        }
    }
}