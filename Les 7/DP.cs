using System;

namespace Les_7
{
    public class Fibonacci
    {
        public int Solve(int n)
        {
            Console.WriteLine("Solve met " + n + " "); // See how often each number is used again
            if (n == 0)
            {
                return 0;
            }
            if(n == 1)
            {
                return 1;
            }

            return Solve(n - 1)+Solve(n-2);
        }

        public int Memoization(int n, int[] array)
        {
            Console.WriteLine("Memo met " + n + " "); // See how often each number is used again
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (array[n] > 0)
            {
                return array[n];
            }

            array[n] = Memoization(n - 1,array) + Memoization(n - 2,array);
            return array[n];
        }

        public int Tabulation(int n)
        {
            int[] array = new int[n + 1];
            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine("Tab met " + i + " ");
                array[i] = array[i - 1] + array[i - 2];
            }
            return array[n];
        }

        public int Iteration(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            int temp_n_2 = 0;
            int temp_n_1 = 1;
            int temp = 0;

            for (int i = 2; i <= n; i++)
            {
                Console.WriteLine("Iteration met " + i + " ");
                temp = temp_n_1 + temp_n_2;
                temp_n_2 = temp_n_1;
                temp_n_1 = temp;
            }
            return temp;
        }
    }


    public class RodCutting
    {
        int[] prices = new int[] { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 }; // Each index is a unit size, values is price

        public int Solve(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Solve met "+i+ " ");
                max = Math.Max(max, prices[i - 1] + Solve(n - i));
            }
            return max;
        }

        public int Memoization(int n, int[] array)
        {
            if (n == 0)
            {
                return 0;
            }
            if (array[n] > 0)
            {
                return array[n];
            }

            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                max = Math.Max(max, prices[i - 1] + Memoization(n - i,array));
                array[n] = max;
                Console.WriteLine("Memo met " + i + " ");
            }
            return max;
        }

        public int Tabulation(int n)
        {
            int[] tabulation = new int[n + 1];
            tabulation[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int max = int.MinValue;
                for (int j = 1; j <= i; j++)
                {
                    max = Math.Max(max, prices[j - 1] + tabulation[i - j]);
                    Console.WriteLine("Tab met "+prices[j - 1] + tabulation[i - j] + " ");
                    tabulation[i] = max;
                }
                Console.WriteLine();
            }
            return tabulation[n];
        }
    }

}
