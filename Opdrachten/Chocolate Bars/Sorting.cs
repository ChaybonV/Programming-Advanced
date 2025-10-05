using System;

namespace Chocolate_Bars
{
    public class Sorting
    {
        public void Insertion(ChocolateBar[] bars)
        {
            ChocolateBar[] arr = new ChocolateBar[bars.Length];
            for (int i = 0; i < bars.Length; i++)
            {
                arr[i] = bars[i];
            }

            for (int i = 1; i < arr.Length; i++)
            {
                ChocolateBar current = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].Sweetness > current.Sweetness)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }

            for (int i = 0; i < bars.Length; i++)
            {
                bars[i] = arr[i];
            }
        }
    }
}
