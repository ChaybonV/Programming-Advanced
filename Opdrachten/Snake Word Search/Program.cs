using System;
using System.Collections.Generic;

namespace Snake_Word_Search
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n;
            if (string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out n) || n <= 0)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string startLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(startLine))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string[] startParts = startLine.Split(" ");
            int startRow;
            int startCol;
            if (startParts.Length < 2 || !int.TryParse(startParts[0], out startRow) || !int.TryParse(startParts[1], out startCol))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            // Control for is startposition valid
            if (startRow < 0 || startRow >= n || startCol < 0 || startCol >= n)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            char[,] grid = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string rowInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(rowInput))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                string[] rowLetters = rowInput.Split(" ");
                if (rowLetters.Length != n)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                for (int j = 0; j < n; j++)
                {
                    if (rowLetters[j].Length != 1)
                    {
                        Console.WriteLine("Crazy input!");
                        return;
                    }

                    grid[i, j] = rowLetters[j][0];
                }
            }

            List<string> words = new List<string>();
            while (true)
            {
                string word = Console.ReadLine();
                if (word == null)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                if (word == "SEARCH")
                {
                    break;
                }

                words.Add(word);
            }

            WordSearch ws = new WordSearch(grid, n);
            List<string> foundWords = ws.SearchWords(words, startRow, startCol);
            Console.WriteLine(string.Join(", ", foundWords));
        }
    }
}
