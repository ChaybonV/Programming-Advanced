// GLOBAL OPTIONS BUT NOT USING VAR IN C#

using System;

namespace Trial_exam_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var words = input.Split(" ");

            Console.WriteLine("=== Strategie 1: Sorteren van karakters ===");
            var grouper1 = new AnagramGrouper1();
            PrintGroups(grouper1.GroupAnagrams(words));

            Console.WriteLine("\n=== Strategie 2: ASCII-telling ===");
            var grouper2 = new AnagramGrouper2();
            PrintGroups(grouper2.GroupAnagrams(words));

            Console.WriteLine("\n=== Strategie 3: CompareStrings + sorteren ===");
            var grouper3 = new AnagramGrouper3();
            PrintGroups(grouper3.GroupAnagrams(words));
        }

        static void PrintGroups(List<List<string>> groups)
        {
            foreach (var group in groups)
                Console.WriteLine(string.Join(" ", group));
        }
    }

    // Strategie 1: Sorteren van karakters
    class AnagramGrouper1
    {
        public List<List<string>> GroupAnagrams(string[] words)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                char[] chars = word.ToCharArray();
                Array.Sort(chars);
                string key = new string(chars);

                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<string>();
                } 
                dict[key].Add(word);
            }
            return new List<List<string>>(dict.Values);
        }
    }

    // Strategie 2: ASCII-telling
    class AnagramGrouper2
    {
        private string GetKey(string word)
        {
            int[] count = new int[26];
            foreach (char c in word)
            {
                count[c - 'a']++;
            }
            return string.Join("#", count);
        }

        public List<List<string>> GroupAnagrams(string[] words)
        {
            var dict = new Dictionary<string, List<string>>();
            foreach (var word in words)
            {
                string key = GetKey(word);
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new List<string>();
                }
                dict[key].Add(word);
            }
            return new List<List<string>>(dict.Values);
        }
    }

    // Strategie 3: CompareStrings + Array.Sort
    class AnagramGrouper3
    {
        private int CompareStrings(string s1, string s2)
        {
            char[] a = s1.ToCharArray();
            char[] b = s2.ToCharArray();
            Array.Sort(a);
            Array.Sort(b);

            int minLen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLen; i++)
            {
                if (a[i] != b[i])
                {
                    return a[i] - b[i];
                }
            }
            return a.Length - b.Length;
        }

        public List<List<string>> GroupAnagrams(string[] words)
        {
            Array.Sort(words, CompareStrings);

            var result = new List<List<string>>();
            List<string> currentGroup = new List<string>();

            foreach (var word in words)
            {
                if (currentGroup.Count == 0 || CompareStrings(word, currentGroup[0]) == 0)
                {
                    currentGroup.Add(word);
                }
                else
                {
                    result.Add(currentGroup);
                    currentGroup = new List<string> { word };
                }
            }
            if (currentGroup.Count > 0)
            {
                result.Add(currentGroup);
            }

            return result;
        }
    }
}
