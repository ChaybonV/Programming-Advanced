using System;

namespace Les_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise oefeningCountChar = new Exercise();
            Console.WriteLine(oefeningCountChar.CountChar("Programming", 'g')); // 2

            Console.WriteLine("\n------------\n");

            Backtracking nQueens = new Backtracking(4);
            nQueens.SolveNQueens(0);

            Console.WriteLine("\n------------\n");

            Backtracking subsets = new Backtracking(new int[] { 1, 2, 3 });
            Console.WriteLine("Solve");
            subsets.SolveSubsets();
            Console.WriteLine("\nSolve Binary");
            subsets.SolveSubsets2();
        }
    }
}
