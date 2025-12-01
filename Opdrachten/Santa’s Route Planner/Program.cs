using System;
using System.Collections.Generic;
using System.Text;

namespace Santa_s_Route_Planner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string requiredLine = Console.ReadLine();
            if (requiredLine == null)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string routesLine = Console.ReadLine();
            if (routesLine == null)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            requiredLine = requiredLine.Trim();
            routesLine = routesLine.Trim();
            if (requiredLine.Length == 0 || routesLine.Length == 0)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            List<int> requiredGifts = new List<int>();
            if (!ParseGifts(requiredLine, requiredGifts))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            List<ElfRoute> elves = ParseElves(routesLine);
            if (elves.Count == 0)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            SantaRoutePlanner planner = new SantaRoutePlanner(requiredGifts, elves);
            List<ElfRoute> chosen = planner.ChooseElves();

            if (chosen.Count == 0 && requiredGifts.Count > 0)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            for (int i = 0; i < chosen.Count; i++)
            {
                PrintRoute(chosen[i]);
            }
        }

        private static bool ParseGifts(string line, List<int> result)
        {
            char[] separators = new char[] { ' ', ',' };
            string[] parts = line.Split(separators);

            if (parts.Length == 0)
            {
                return false;
            }

            bool anyValid = false;

            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i].Trim();
                if (part.Length == 0)
                {
                    continue;
                }

                int value;
                if (!int.TryParse(part, out value))
                {
                    return false;
                }
                if (!Contains(result, value))
                {
                    result.Add(value);
                }
                anyValid = true;
            }

            return anyValid && result.Count > 0;
        }

        private static List<ElfRoute> ParseElves(string line)
        {
            List<ElfRoute> elves = new List<ElfRoute>();
            string[] routeParts = line.Split(',');

            for (int i = 0; i < routeParts.Length; i++)
            {
                string routeText = routeParts[i].Trim();
                if (routeText.Length == 0)
                {
                    continue;
                }

                char[] sep = new char[] { ' ' };
                string[] giftParts = routeText.Split(sep);
                List<int> gifts = new List<int>();

                for (int j = 0; j < giftParts.Length; j++)
                {
                    string part = giftParts[j].Trim();
                    if (part.Length == 0)
                    {
                        continue;
                    }

                    int value;
                    if (!int.TryParse(part, out value))
                    {
                        return new List<ElfRoute>();
                    }
                    if (!Contains(gifts, value))
                    {
                        gifts.Add(value);
                    }
                }

                if (gifts.Count > 0)
                {
                    ElfRoute elf = new ElfRoute(gifts);
                    elves.Add(elf);
                }
            }

            return elves;
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

        private static void PrintRoute(ElfRoute route)
        {
            List<int> gifts = route.Gifts;
            if (gifts.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < gifts.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(gifts[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
