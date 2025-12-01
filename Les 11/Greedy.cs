using System;
using System.Collections.Generic;

namespace Les_11
{
    public class Activity
    {
        public string Name { get; }
        public double Start { get; }
        public double End { get; }

        public Activity(string name, double start, double end)
        {
            Name = name;
            Start = start;
            End = end;
        }
    }

    public class Greedy
    {
        public List<Activity> Schedule(string[] classes, double[] start, double[] end)
        {
            if (classes.Length != start.Length || start.Length != end.Length)
            {
                throw new Exception("Arrays must have the same length");
            }

            List<Activity> activities = new List<Activity>();
            for (int i = 0; i < classes.Length; i++)
            {
                activities.Add(new Activity(classes[i], start[i], end[i]));
            }

            activities.Sort((a, b) => a.End.CompareTo(b.End));

            List<Activity> result = new List<Activity>();
            double lastEndTime = double.MinValue;

            foreach (Activity a in activities)
            {
                if (a.Start >= lastEndTime)
                {
                    result.Add(a);
                    lastEndTime = a.End;
                }
            }

            return result;
        }

        public Dictionary<int, int> CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            Array.Reverse(coins);

            Dictionary<int, int> result = new Dictionary<int, int>();
            int remaining = amount;

            foreach (int coin in coins)
            {
                if (coin <= remaining)
                {
                    int count = remaining / coin;
                    if (count > 0)
                    {
                        result[coin] = count;
                        remaining -= count * coin;
                    }
                }
            }

            return result;
        }
    }
}