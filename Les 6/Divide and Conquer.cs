using System;
using System.Collections.Generic;

namespace Les_6
{
    class QuickSort
    {
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
                if (list[i] < pivot)
                {
                    less.Add(list[i]);
                }
                else
                {
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
            Console.WriteLine();
        }
    }

    //class next
    //{

    //}
}
