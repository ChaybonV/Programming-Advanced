using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Les_6
{

    class QuickSort
    {
        public int Counter { get; set; } = 0;  // For Big O tracking
        public List<int> Sort(List<int> list)
        {
            // Basecase: list with 1 or 0 elements is sorted
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list[0];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            // Split list in 'less' and 'greater'
            for (int i = 1; i < list.Count; i++)
            {
                Counter++;
                if (list[i] < pivot)
                {
                    // You can do this check for removing duplicates
                    //if (!less.Contains(list[i]))
                    //{
                    //    less.Add(list[i]);
                    //}
                    less.Add(list[i]);
                }
                else
                {
                    // You can do this check for removing duplicates
                    //if (!greater.Contains(list[i]))
                    //{
                    //    greater.Add(list[i]);
                    //}
                    greater.Add(list[i]);
                }
            }

            // Recursive sorting and merging
            List<int> result = new List<int>();
            result.AddRange(Sort(less));
            result.Add(pivot);
            result.AddRange(Sort(greater));

            return result;
        }

        public void Print(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
        }
    }

    class Hanoi
    {
        public void DivideAndConquer(int n, char source, char target, char temp)
        {
            if (n == 1)
            {
                Console.WriteLine($"Move disk {n} from {source} to {target}");
                return;
            }
            else
            {
                // Step 1: source to temp
                DivideAndConquer(n - 1, source, temp, target);
                // Step 2: Biggest disc to target
                Console.WriteLine($"Move disk {n} from {source} to {target}");
                // Step 3: temp to target
                DivideAndConquer(n - 1, temp, target, source);
            }
        }
    }

    //Extra exercises:
    //
    // 1. Merge sort - Split array in half, sort each half, merge back together(Quicksort does work before recursion (partitioning), Merge sort does work after recursion (merging))
    // 2. Array Multiplication - Split array, multiply each half, multiply results
    // 3. Binary search - Split sorted array in half, search relevant half

    class MergeSort
    {
        public List<int> Sort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int mid = list.Count / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < mid; i++)
            {
                left.Add(list[i]);
            }
            for (int i = mid; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i] < right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        public void Print(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }

    class ArrayMultiplication
    {
        public int Multiply(List<int> list, int start, int end)
        {
            if (start == end)
            {
                return list[start];
            }

            int mid = (start + end) / 2;
            int leftProduct = Multiply(list, start, mid);
            int rightProduct = Multiply(list, mid + 1, end);

            return leftProduct * rightProduct;
        }
    }

    class BinarySearch
    {
        public int Search(List<int> list, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (list[mid] == target)
            {
                return mid;
            }
            else if (target < list[mid])
            {
                return Search(list, target, start, mid - 1);
            }
            else
            {
                return Search(list, target, mid + 1, end);
            }
        }
    }

}
