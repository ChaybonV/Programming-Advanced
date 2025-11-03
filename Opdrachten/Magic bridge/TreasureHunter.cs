using System;

namespace MagicBridge
{
    public class TreasureHunter
    {
        public int FindMaxEnergy(int n, int k, int[] planks)
        {
            int[] maxEnergy = new int[n];
            maxEnergy[0] = planks[0];

            for (int i = 1; i < n; i++)
            {
                maxEnergy[i] = int.MinValue;
                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    maxEnergy[i] = Math.Max(maxEnergy[i], maxEnergy[j] + planks[i]);
                }

                if (i <= k)
                {
                    maxEnergy[i] = Math.Max(maxEnergy[i], planks[i]);
                }
            }

            return maxEnergy[n - 1];
        }
    }
}