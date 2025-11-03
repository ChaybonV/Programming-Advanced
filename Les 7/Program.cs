using System;

namespace Les_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fib = new Fibonacci();
            int n = 10;
            Console.WriteLine("\nResult: "+fib.Solve(n));
            Console.WriteLine("\n----------\n");
            Console.WriteLine("\nResult: " + fib.Memoization(n,new int[n+1]));
            Console.WriteLine("\n----------\n");
            Console.WriteLine("\nResult: " + fib.Tabulation(n));
            Console.WriteLine("\n----------\n");
            Console.WriteLine("\nResult: " + fib.Iteration(n));

            Console.WriteLine("\n\n----------\n----------\n\n");

            RodCutting rcut = new RodCutting();
            int n2 = 8;
            Console.WriteLine("\nResult: " + rcut.Solve(n2));
            Console.WriteLine("\n----------\n");
            Console.WriteLine("\nResult: " + rcut.Memoization(n2, new int[n2 + 1]));
            Console.WriteLine("\n----------\n");
            Console.WriteLine("\nResult: " + rcut.Tabulation(n2));
        }
    }
}
