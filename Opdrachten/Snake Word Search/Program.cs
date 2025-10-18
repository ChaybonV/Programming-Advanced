using System;
using System.Collections.Generic;

namespace Snake_Word_Search {
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Lees matrixgrootte
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                int n = int.Parse(line);

                // Lees startpositie
                string[] startParts = Console.ReadLine().Split(' ');
                if (startParts.Length < 2)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                int startRow = int.Parse(startParts[0]);
                int startCol = int.Parse(startParts[1]);

                // Controleer of startpositie geldig is
                if (startRow < 0 || startRow >= n || startCol < 0 || startCol >= n)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                // Lees matrix
                char[,] grid = new char[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] rowLetters = Console.ReadLine().Split(' ');
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

                // Lees woorden in
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
                        break;

                    words.Add(word);
                }

                // Maak een instantie van de WordSearch klasse
                WordSearch ws = new WordSearch(grid, n);

                // Zoek de woorden
                List<string> foundWords = ws.SearchWords(words, startRow, startCol);

                // Toon resultaat
                Console.WriteLine(string.Join(", ", foundWords));
            }
            catch
            {
                // Als er iets fout gaat bij het lezen of parsen van input
                Console.WriteLine("Crazy input!");
            }
        }
    }
}