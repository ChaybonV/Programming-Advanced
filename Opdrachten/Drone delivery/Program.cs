using System;
using System.Collections.Generic;

namespace Drone_delivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int maxBattery = 0;
            string first = Console.ReadLine();

            if (!int.TryParse(first, out maxBattery))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            string rechargeLine = Console.ReadLine();
            if (rechargeLine == null)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            List<string> rechargeCities = new List<string>();
            if (rechargeLine.Trim() != "-")
            {
                foreach (string c in rechargeLine.Split(" "))
                {
                    if (c.Trim() != "")
                    {
                        rechargeCities.Add(c.Trim());
                    }
                }
            }

            int cityCount = 0;
            if (!int.TryParse(Console.ReadLine(), out cityCount))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            int roadCount = 0;
            if (!int.TryParse(Console.ReadLine(), out roadCount))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            Dictionary<string, List<Edge>> graph = new Dictionary<string, List<Edge>>();
            for (int i = 0; i < roadCount; i++)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                string[] parts = line.Split(" ");
                if (parts.Length != 3)
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                string a = parts[0];
                string b = parts[1];

                int cost = 0;
                if (!int.TryParse(parts[2], out cost))
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }

                if (!graph.ContainsKey(a))
                {
                    graph[a] = new List<Edge>();
                }
                if (!graph.ContainsKey(b))
                {
                    graph[b] = new List<Edge>();
                }

                graph[a].Add(new Edge(b, cost));
                graph[b].Add(new Edge(a, cost));
            }

            if (!graph.ContainsKey("S") || !graph.ContainsKey("T"))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            Dictionary<string, int> dist = new Dictionary<string, int>();
            Dictionary<string, int> batteryLeft = new Dictionary<string, int>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Dictionary<string, string> prev = new Dictionary<string, string>();

            foreach (string city in graph.Keys)
            {
                dist[city] = int.MaxValue;
                batteryLeft[city] = 0;
                visited[city] = false;
                prev[city] = null;
            }

            dist["S"] = 0;
            batteryLeft["S"] = maxBattery;

            while (true)
            {
                string current = null;
                int best = int.MaxValue;

                foreach (string city in graph.Keys)
                {
                    if (!visited[city] && dist[city] < best)
                    {
                        best = dist[city];
                        current = city;
                    }
                }

                if (current == null)
                {
                    break;
                }

                visited[current] = true;

                int curBattery = batteryLeft[current];
                if (rechargeCities.Contains(current))
                {
                    curBattery = maxBattery;
                }

                foreach (Edge e in graph[current])
                {
                    int newBattery = curBattery - e.Cost;
                    if (newBattery <= 0)
                    {
                        continue;
                    }

                    int newDist = dist[current] + e.Cost;
                    if (newDist < dist[e.To])
                    {
                        dist[e.To] = newDist;
                        prev[e.To] = current;
                        batteryLeft[e.To] = newBattery;
                    }
                }
            }

            if (dist["T"] == int.MaxValue)
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            List<string> path = new List<string>();
            string curNode = "T";
            while (curNode != null)
            {
                path.Add(curNode);
                curNode = prev[curNode];
            }

            path.Reverse();

            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i]);
                if (i < path.Count - 1)
                {
                    Console.Write(" --> ");
                }
            }

            Console.WriteLine();
            Console.WriteLine(dist["T"]);
        }
    }
}
