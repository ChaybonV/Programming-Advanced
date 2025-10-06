using System;
using System.Collections.Generic;
using System.IO;

namespace Les_4
{
    public class Recursion
    {
        public string Algorithm1(string basefolder)
        {
            List<string> folders = new List<string>();
            folders.Add(basefolder);

            while (folders.Count != 0)
            {
                string currentFolder = folders[0];
                folders.RemoveAt(0);

                string[] files = Directory.GetFiles(currentFolder);
                if (files.Length > 0)
                {
                    // First file found -> return path
                    return files[0];
                }

                // Add all subfolders to the list
                string[] subfolders = Directory.GetDirectories(currentFolder);
                for (int i = 0; i < subfolders.Length; i++)
                {
                    folders.Add(subfolders[i]);
                }
            }

            return "No file found.";
        }

        public string Algorithm2(string basefolder)
        {
            // Includes both files and folders
            string[] items = Directory.GetFileSystemEntries(basefolder);

            for (int i = 0; i < items.Length; i++)
            {
                // If it's a file -> done
                if (File.Exists(items[i]))
                {
                    return items[i];
                }

                // If it's a folder -> search recursively
                if (Directory.Exists(items[i]))
                {
                    string result = Algorithm2(items[i]);
                    if (result != "No file found.")
                    {
                        return result;
                    }
                }
            }

            return "No file found.";
        }

        public int Factorial(int n)
        {
            if (n <= 2)
            {
                return n;
            }

            int result = 1;
            for(int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        public int FactorialRec(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * FactorialRec(n - 1);
        }



        // EXTRA EXERCISES RECURSION

        // 1.
        public int SumOfNaturalNumbers(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else
            {
                return n + SumOfNaturalNumbers(n - 1);
            }
        }

        // 2.
        public int CountDigits(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else
            {
                return 1 + CountDigits(n / 10);
            }
        }

        // 3.
        public string ReverseString(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                return ReverseString(str.Substring(1)) + str[0];
            }  
        }

    }
}
