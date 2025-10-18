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
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                bool[,] visited = new bool[size, size];

                if (grid[startRow, startCol] == word[0] &&
                    SearchWord(word, 0, startRow, startCol, visited))
                {
                    foundWords.Add(word);
                }
            }

            return foundWords;
        }

        private bool SearchWord(string word, int index, int row, int col, bool[,] visited)
        {
            // Basisgeval: woord volledig gevonden
            if (index == word.Length)
                return true;

            // Ongeldige positie
            if (row < 0 || row >= size || col < 0 || col >= size)
                return false;

            // Letter klopt niet of al bezocht
            if (visited[row, col] || grid[row, col] != word[index])
                return false;

            // Markeer als bezocht
            visited[row, col] = true;

            // Richtingen: omhoog, omlaag, links, rechts
            if (SearchWord(word, index + 1, row - 1, col, visited))
            {
                return true;
            }
            if (SearchWord(word, index + 1, row + 1, col, visited))
            {
                return true;
            }
            if (SearchWord(word, index + 1, row, col - 1, visited))
            {
                return true;
            }
            if (SearchWord(word, index + 1, row, col + 1, visited))
            {
                return true;
            }

            // Backtrack
            visited[row, col] = false;

            return false;
        }
    }
}
