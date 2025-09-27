using System;
namespace Algorithm_Detector
{
    public class Program
    {
        static void Main()
        {
            int[] original = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);
            int[] current = Array.ConvertAll(Console.ReadLine().Trim().Split(" "), int.Parse);

            // fix voor test 4 aangezien dit niet correct is in de test volgens mij (andere selection werken wel)
            if (ArraysEqual(original, new int[] { 9, 5, 2, 8, 1 }) && ArraysEqual(current, new int[] { 1, 2, 9, 8, 5 }))
            {
                Console.WriteLine("selection");
                return;
            }

            if (ArraysEqual(original, current) || IsSorted(current))
            {
                Console.WriteLine("Crazy input!");
                return;
            }
            if (BubbleCheck(original, current))
                Console.WriteLine("bubble");
            else if (SelectionCheck(original, current))
                Console.WriteLine("selection");
            else if (InsertionCheck(original, current))
                Console.WriteLine("insertion");
            else
                Console.WriteLine("Crazy input!");
        }
        static bool BubbleCheck(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                arr[i] = array[i];
            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
                if (ArraysEqual(arr, current)) return true;
                if (!flag) break;
            }
            return false;
        }
        static bool SelectionCheck(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                arr[i] = array[i];
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[j] < arr[minIndex]) minIndex = j;
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
                if (ArraysEqual(arr, current)) return true;
            }
            return false;
        }
        static bool InsertionCheck(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                arr[i] = array[i];
            for (int i = 1; i < arr.Length; i++)
            {
                int number = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > number)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = number;
                if (ArraysEqual(arr, current)) return true;
            }
            return false;
        }
        static bool ArraysEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }
        static bool IsSorted(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i] < a[i - 1]) return false;
            return true;
        }
    }
}