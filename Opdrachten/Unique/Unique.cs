using System;

public class Unique
{
    public int[] GetUnique(int[] numbers)
    {
        Array.Sort(numbers);

        int[] unique = new int[numbers.Length];
        int count = 0;

        for (int i=0;i<numbers.Length;i++)
        {
            if (i==0 || numbers[i] != numbers[i-1])
            {
                unique[count] = numbers[i];
                count++;
            }
        }

        int[] result = new int[count];
        for (int i=0;i<count;i++)
        {
            result[i] = unique[i];
        }

        return result;
    }
}