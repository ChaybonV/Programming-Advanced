using System;
using System.Collections.Generic;

namespace Santa_s_Route_Planner
{
    public class SantaRoutePlanner
    {
        private List<int> requiredGifts;
        private List<ElfRoute> elves;

        public SantaRoutePlanner(List<int> requiredGifts, List<ElfRoute> elves)
        {
            this.requiredGifts = requiredGifts;
            this.elves = elves;
        }

        public List<ElfRoute> ChooseElves()
        {
            List<int> uncovered = new List<int>();
            for (int i = 0; i < requiredGifts.Count; i++)
            {
                if (!Contains(uncovered, requiredGifts[i]))
                {
                    uncovered.Add(requiredGifts[i]);
                }
            }

            bool[] used = new bool[elves.Count];
            List<ElfRoute> chosen = new List<ElfRoute>();
            while (uncovered.Count > 0)
            {
                int bestIndex = -1;
                int bestCover = 0;

                for (int i = 0; i < elves.Count; i++)
                {
                    if (used[i])
                    {
                        continue;
                    }

                    int cover = elves[i].CountCovered(uncovered);
                    if (cover > bestCover)
                    {
                        bestCover = cover;
                        bestIndex = i;
                    }
                }

                if (bestIndex == -1 || bestCover == 0)
                {
                    break;
                }

                used[bestIndex] = true;
                chosen.Add(elves[bestIndex]);

                List<int> gifts = elves[bestIndex].Gifts;
                for (int j = 0; j < gifts.Count; j++)
                {
                    RemoveAll(uncovered, gifts[j]);
                }
            }

            return chosen;
        }

        private static bool Contains(List<int> list, int value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        private static void RemoveAll(List<int> list, int value)
        {
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] == value)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
