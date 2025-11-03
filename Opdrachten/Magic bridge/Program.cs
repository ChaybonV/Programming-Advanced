using System;

namespace MagicBridge
{
    class TreasureHunter
    {
        private int n;
        private int k;
        private int[] planks;

        public TreasureHunter(int n, int k, int[] planks) // geen constructor indien mogelijk
        {
            this.n = n;
            this.k = k;
            this.planks = planks;
        }

        public long FindMaxEnergy()
        {
            long[] dp = new long[n]; // duidelijkere benaming dan dp
            dp[0] = planks[0];

            for (int i = 1; i < n; i++)
            {
                dp[i] = long.MinValue;
                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    if (dp[j] != long.MinValue)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + planks[i]);
                    }
                }

                if (i <= k)
                {
                    dp[i] = Math.Max(dp[i], planks[i]);
                }
            }

            return dp[n - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            if (string.IsNullOrEmpty(firstLine))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string[] firstParts = firstLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // geen trim en geen split op new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries
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

            string[] secondParts = secondLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // geen trim en geen split op new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries
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

            TreasureHunter hunter = new TreasureHunter(n, k, planks);
            Console.WriteLine(hunter.FindMaxEnergy());
        }
    }
}