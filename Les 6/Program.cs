using System;
using System.Collections.Generic;

namespace Les_6
{
    class Program
    {
        static void Main(string[] args)
        {

            QuickSort qs = new QuickSort();
            List<int> list = new List<int> { 12, 56, 34, 78, 12, 23, 89, 45, 67, 90, 21 };
            list = qs.Sort(list);
            qs.Print(list);
            Console.WriteLine("\nBig O -> "+qs.Counter);

            Console.Write("\n----------\n\n");

            Hanoi hanoi = new Hanoi();
            hanoi.DivideAndConquer(3, 'A', 'C', 'B');

            Console.Write("\n----------\n\n");

            MergeSort ms = new MergeSort();
            List<int> numbers = new List<int> { 12, 56, 34, 78, 23, 89, 45, 67, 90, 21 };
            numbers = ms.Sort(numbers);
            Console.WriteLine("Merge sort:");
            ms.Print(numbers);

            ArrayMultiplication am = new ArrayMultiplication();
            int product = am.Multiply(new List<int> { 2, 3, 4, 5 }, 0, 3);
            Console.WriteLine("\n\nArray multiplication:");
            Console.WriteLine("Product: " + product);

            BinarySearch bs = new BinarySearch();
            Console.WriteLine("\nBinary search:");
            Console.Write("Give a number to search: ");
            int target;
            if (int.TryParse(Console.ReadLine(), out target))
            {
                int index = bs.Search(numbers, target, 0, numbers.Count - 1);
                if (index != -1)
                {
                    Console.WriteLine($"Number {target} is on index {index}");
                }
                else
                {
                    Console.WriteLine($"Number {target} is not in the list");
                } 
            }
            else
            {
                Console.WriteLine("Invalid input, give a integer number!");
            }

        }
    }
}
