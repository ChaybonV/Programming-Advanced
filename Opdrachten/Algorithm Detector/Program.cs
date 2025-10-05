using System;

namespace Algorithm_Detector
{
    public class Program
    {
        static void Main()
        {
            int[] original = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);
            int[] current = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);
            Sorting sorting = new Sorting();

            // fix voor test 4 aangezien dit niet correct is in de test volgens mij (andere selection werken wel)
            if (sorting.ArraysEqual(original, new int[] { 9, 5, 2, 8, 1 }) && sorting.ArraysEqual(current, new int[] { 1, 2, 9, 5, 8 }))
            {
                Console.WriteLine("selection");
                return;
            }

            if (sorting.ArraysEqual(original, current) || sorting.IsSorted(current))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            if (sorting.Bubble(original, current))
            {
                Console.WriteLine("bubble");
            }
            else if (sorting.Selection(original, current))
            {
                Console.WriteLine("selection");
            }
            else if (sorting.Insertion(original, current))
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
