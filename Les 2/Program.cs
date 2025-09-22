namespace Les_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sorting sorting = new Sorting();

            int[] arrayBubble = Array.ConvertAll(File.ReadAllLines("numbers.txt"), int.Parse);
            Console.WriteLine($"Bubble sort: {sorting.Bubble(arrayBubble)}");

            Console.WriteLine("\n----------------\n");

            int[] arraySelection = Array.ConvertAll(File.ReadAllLines("numbers.txt"), int.Parse);
            Console.WriteLine($"Selection sort: {sorting.Selection(arraySelection)}");

            Console.WriteLine("\n----------------\n");

            int[] arrayInsertion = Array.ConvertAll(File.ReadAllLines("numbers.txt"), int.Parse);
            Console.WriteLine($"Insertion sort: {sorting.Insertion(arrayInsertion)}");

            Console.WriteLine("\n----------------\n");

            int[] arrayIsSorted = Array.ConvertAll(File.ReadAllLines("numbers.txt"), int.Parse);
            Console.WriteLine($"Is sorted?: {sorting.isSorted(arrayIsSorted)}");
        }
    }
}