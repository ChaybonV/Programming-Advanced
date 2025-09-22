using System;

namespace Les_2
{
    public class Sorting
    {
        // 2 4 1 3 7 --> array used to understand and make the sorting logic in my code.

        public string Bubble(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Change the position with next one
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            //string output = "";
            //for (int i = 0; i < array.Length; i++)
            //{
            //    output += array[i] + " ";
            //}
            //return output;
            return string.Join(" ", array);
        }

        public string Selection(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                // Change the current element with the smallest founded element
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }

            //string output = "";
            //for (int i = 0; i < array.Length; i++)
            //{
            //    output += array[i] + " ";
            //}
            //return output;
            return string.Join(" ", array);
        }

    }
}