using System;
using System.Collections.Generic;

namespace Les_6
{
    class QuickSort
    {
        public int Counter = 0;  // For Big O tracking
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
                    // duplicate check
                    //if (!less.Contains(list[i]))
                    //{
                    //    less.Add(list[i]);
                    //}
                    less.Add(list[i]);
                }
                else
                {
                    // duplicate check
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

    //class next
    //{

    //}
}
