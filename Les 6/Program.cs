using System;
using System.Collections.Generic;

namespace Les_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 12, 56, 34, 78, 23, 89, 45, 67, 90, 21 };

            QuickSort qs = new QuickSort();
            list = qs.Sort(list);
            qs.Print(list);
        }
    }
}
