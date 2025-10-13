using System;

namespace Les_5
{
    public class Backtracking
    {
        private char[,] board;
        private int[] arr;
        private int size;

        // Constructor voor NQueens
        public Backtracking(int s)
        {
            size = s;
            board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        // Constructor voor SubsetProblem
        public Backtracking(int[] a)
        {
            arr = a;
            size = a.Length;
        }

        // Solve NQueens
        public bool SolveNQueens(int col)
        {
            if (col >= size)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                return true;
            }

            bool foundSolution = false;

            for (int row = 0; row < size; row++)
            {
                bool safe = true;

                for (int j = 0; j < col; j++)
                {
                    if (board[row, j] == 'Q')
                    {
                        safe = false;
                        break;
                    }
                }

                for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
                {
                    if (board[i, j] == 'Q')
                    {
                        safe = false;
                        break;
                    }
                }

                for (int i = row, j = col; i < size && j >= 0; i++, j--)
                {
                    if (board[i, j] == 'Q')
                    {
                        safe = false;
                        break;
                    }
                }

                if (safe)
                {
                    board[row, col] = 'Q';
                    if (SolveNQueens(col + 1))
                    {
                        foundSolution = true;
                    }
                    board[row, col] = '-';
                }
            }

            return foundSolution;
        }

        // Solve Subset Problem
        public void SolveSubsets()
        {
            int total = (int)Math.Pow(2, size);

            for (int i = 0; i < total; i++)
            {
                Console.Write("{ ");
                for (int j = 0; j < size; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        Console.Write(arr[j] + " ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        // Solve Subset Problem Binary
        public void SolveSubsets2()
        {
            int total = (int)Math.Pow(2, arr.Length);

            for (int i = 0; i < total; i++)
            {
                int temp = i;
                int[] bits = new int[arr.Length];

                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    if (temp % 2 == 1)
                    {
                        bits[j] = 1;
                    }
                    else
                    {
                        bits[j] = 0;
                    }

                    temp = temp / 2;
                }

                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(bits[j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
