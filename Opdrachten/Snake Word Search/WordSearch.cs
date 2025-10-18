using System;
using System.Collections.Generic;

namespace Snake_Word_Search
{
    public class WordSearch
    {
        private char[,] grid;
        private int size;

        public WordSearch(char[,] grid, int size)
        {
            this.grid = grid;
            this.size = size;
        }

        public List<string> SearchWords(List<string> words, int startRow, int startCol)
        {
            List<string> foundWords = new List<string>();

            foreach (string word in words)
            {
                bool[,] visited = new bool[size, size];

                if (grid[startRow, startCol] == word[0])
                {
                    if (SearchWord(word, 0, startRow, startCol, visited))
                    {
                        foundWords.Add(word);
                    }
                }
            }

            return foundWords;
        }

        private bool SearchWord(string word, int index, int row, int col, bool[,] visited)
        {
            // Basisgeval: woord volledig gevonden
            if (index == word.Length)
                return true;

            // Geldige positie?
            if (row < 0 || row >= size || col < 0 || col >= size)
                return false;

            // Klopt de letter en nog niet bezocht?
            if (visited[row, col] || grid[row, col] != word[index])
                return false;

            // Markeer als bezocht
            visited[row, col] = true;

            // Richtingen: omhoog, omlaag, links, rechts
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            // Probeer in elke richting
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];

                if (SearchWord(word, index + 1, newRow, newCol, visited))
                    return true;
            }

            // Backtrack: markeer weer als niet bezocht
            visited[row, col] = false;
            return false;
        }
    }
}
