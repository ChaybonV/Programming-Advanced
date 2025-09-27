using System;

namespace Algorithm_Detector
{
    public class Searching
    {
        public bool Bubble(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i=0;i<array.Length;i++)
            {
                arr[i] = array[i];
            }

            for (int i=0;i<arr.Length;i++)
            {
                bool flag = false;
                for (int j=0;j<arr.Length-i-1;j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }

                if (ArraysEqual(arr, current))
                {
                    return true;
                }

                if (!flag)
                {
                    break;
                }
            }

            return false;
        }

        public bool Selection(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i=0;i<array.Length;i++)
            {
                arr[i] = array[i];
            }

            for (int i=0;i<arr.Length;i++)
            {
                int minIndex = i;
                for (int j = i + 1;j<arr.Length;j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;

                if (ArraysEqual(arr, current))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Insertion(int[] array, int[] current)
        {
            int[] arr = new int[array.Length];
            for (int i=0;i<array.Length;i++)
            {
                arr[i] = array[i];
            }

            for (int i=1;i<arr.Length;i++)
            {
                int number = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > number)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = number;

                if (ArraysEqual(arr, current))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ArraysEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i=0;i<a.Length;i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSorted(int[] a)
        {
            for (int i=1;i<a.Length;i++)
            {
                if (a[i] < a[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}