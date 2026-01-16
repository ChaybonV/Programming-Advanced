using System;

namespace ExamLongestUniqueSubstring
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = "";
            if (input == null)
            {
                Console.WriteLine("Crazy input!");
                return;
            }
            input = input.Trim();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!(c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }
            }
            result = SolveStrategy1(input); // Optie 1
            result = SolveStrategy2(input); // Optie 2
            result = SolveStrategy3(input); // Optie 3
            Console.WriteLine(result);
        }

        // Strategy 1: Tijd: O(^3) & Ruimte: O(1)
        // Heel de string doorgaan en controleren op alle duplicates
        public static string SolveStrategy1(string s)
        {
            int n = s.Length;
            int bestStart = 0;
            int bestLen = 0;

            int i = 0;
            while (i < n)
            {
                int j = i;
                while (j < n)
                {
                    if (!HasDuplicateInRange(s, i, j))
                    {
                        int len = j - i + 1;
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestStart = i;
                        }
                        else if (len == bestLen && i < bestStart)
                        {
                            bestStart = i;
                        }
                    }
                    j++;
                }
                i++;
            }
            return s.Substring(bestStart, bestLen);
        }

        public static bool HasDuplicateInRange(string s, int start, int end)
        {
            int i = start;
            while (i <= end)
            {
                int j = i + 1;
                while (j <= end)
                {
                    if (s[i] == s[j])
                    {
                        return true;
                    }
                    j++;
                }
                i++;
            }
            return false;
        }

        // Strategy 2: Tijd: O(^2) & Ruimte O(1)
        // Gebruikmakend van asci values om seen[] er voor te laten zorgen als controle op startpunt
        public static string SolveStrategy2(string s)
        {
            int n = s.Length;
            int bestStart = 0;
            int bestLen = 0;

            int i = 0;
            while (i < n)
            {
                bool[] seen = new bool[256];
                int j = i;
                while (j < n)
                {
                    int asciCode = (int)s[j];
                    if (asciCode < 0 || asciCode >= 256)
                    {
                        break;
                    }
                    if (seen[asciCode])
                    {
                        break;
                    }
                    seen[asciCode] = true;
                    int len = j - i + 1;
                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestStart = i;
                    }
                    else if (len == bestLen && i < bestStart)
                    {
                        bestStart = i;
                    }
                    j++;
                }
                i++;
            }
            return s.Substring(bestStart, bestLen);
        }

        // Strategy 3: // Tijd: O(n) & Ruimte O(1)
        // Gehele lastIndex dat veranderd door left en right waardoor we maar 1 loop moeten gebruiken
        public static string SolveStrategy3(string s)
        {
            int n = s.Length;
            int bestStart = 0;
            int bestLen = 0;

            int[] lastIndex = new int[256];
            int left = 0;
            int right = 0;

            while (right < n)
            {
                int asciCode = (int)s[right];

                if (lastIndex[asciCode] > left)
                {
                    left = lastIndex[asciCode];
                }

                lastIndex[asciCode] = right + 1;

                int currentLen = right - left + 1;
                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestStart = left;
                }
                else if (currentLen == bestLen && left < bestStart)
                {
                    bestStart = left;
                }

                right++;
            }
            return s.Substring(bestStart, bestLen);
        }
    }
}

// Chaybon Verlooy - 2BADI