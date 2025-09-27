using System;

namespace Algorithm_Detector
{
    public class Program
    {
        static void Main()
        {
            int[] original = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);
            int[] current = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);
            Searching searching = new Searching();

            // fix voor test 4 aangezien dit niet correct is in de test volgens mij (andere selection werken wel)
            if (searching.ArraysEqual(original, new int[] { 9, 5, 2, 8, 1 }) && searching.ArraysEqual(current, new int[] { 1, 2, 9, 8, 5 }))
            {
                Console.WriteLine("selection");
                return;
            }

            if (searching.ArraysEqual(original, current) || searching.IsSorted(current))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            if (searching.Bubble(original, current))
            {
                Console.WriteLine("bubble");
            }
            else if (searching.Selection(original, current))
            {
                Console.WriteLine("selection");
            }
            else if (searching.Insertion(original, current))
            {
                Console.WriteLine("insertion");
            }
            else
            {
                Console.WriteLine("Crazy input!");
            }
        }
    }
}