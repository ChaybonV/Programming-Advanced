using System;
using System.Collections.Generic;

namespace Santa_s_Route_Planner
{
    public class ElfRoute
    {
        private List<int> gifts;

        public ElfRoute(List<int> gifts)
        {
            this.gifts = gifts;
        }

        public List<int> Gifts
        {
            get { return gifts; }
        }

        public int CountCovered(List<int> uncovered)
        {
            int count = 0;
            for (int i = 0; i < gifts.Count; i++)
            {
                if (Contains(uncovered, gifts[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private bool Contains(List<int> list, int value)
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
    }
}
