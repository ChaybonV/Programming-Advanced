namespace Les_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sorting sorting = new Sorting();

            int[] arrayBubble = { -1, -9, -3, 5, 8, 1, 4 };
            Console.WriteLine($"Bubble sort: {sorting.Bubble(arrayBubble)}");

            Console.WriteLine("\n----------------\n");

            int[] arraySelection = { -1, -9, -3, 5, 8, 1, 4 };
            Console.WriteLine($"Selection sort: {sorting.Selection(arraySelection)}");

            Console.WriteLine("\n----------------\n");

            int[] arrayInsertion = { -1, -9, -3, 5, 8, 1, 4 };
            Console.WriteLine($"Insertion sort: {sorting.Insertion(arrayInsertion)}");
        }
    }
}