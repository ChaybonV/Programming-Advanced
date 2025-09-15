using System;
using System.IO;

namespace Les_1
{
    public class Searching
    {
        int[] array;

        public int Count { get; set; }

        public Searching()
        {
            //array = new int[] { -10, -7, -5, -2, 0, 1, 2, 4, 5, 7, 9 };
            array = Array.ConvertAll(File.ReadAllLines("sorted_numbers.txt"),int.Parse);
        }

        public int Linear(int number)
        {
            Count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] == number)
                {
                    return i; // i = position of index
                }
                Count++;
            }
            return -1;
        }

        public int Stupid(int number)
        {
            Count = 0;
            Random rd = new Random();
            int count = 0;
            int i = -1;
            while(count< array.Length)
            {
                i = rd.Next(0,array.Length); // random position in list (sometimes it is possible -1 when number is in list)

                if (array[i] == number)
                {
                    return i; // i = position of index
                }
                count++;
                Count++;
            }
            return -1;
        }

        public int Binary(int number)
        {
            Count = 0;
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low+high) / 2;
                if (array[mid] == number)
                {
                    return mid; // position of index
                }
                else if (number < array[mid])
                {
                    high = mid - 1; // searching at left
                }
                else
                {
                    low = mid + 1; // searching at right
                }
                Count++;
            }
            return -1;
        }

    }

}