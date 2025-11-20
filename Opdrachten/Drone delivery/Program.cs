using System;
using System.Collections.Generic;

namespace Drone_delivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int maxBattery = ReadIntOrFail();
            List<string> rechargeCities = ReadRechargeCities();
            int cityCount = ReadIntOrFail();
            int roadCount = ReadIntOrFail();

            Dictionary<string, List<Edge>> graph = ReadGraph(roadCount);
            if (!graph.ContainsKey("S") || !graph.ContainsKey("T"))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            Dictionary<string, int> dist;
            Dictionary<string, string> prev;
            if (!CalculateShortestPath(graph, rechargeCities, maxBattery, out dist, out prev))
            {
                Console.WriteLine("Crazy input!");
                return;
            }

            List<string> path = ReconstructPath(prev, "T");

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

        public static int ReadIntOrFail()
        {
            string input = Console.ReadLine();
            int value = 0;
            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Crazy input!");
                Environment.Exit(0);
            }

            return value;
        }

        public static List<string> ReadRechargeCities()
        {
            string line = Console.ReadLine();
            if (line == null)
            {
                Console.WriteLine("Crazy input!");
                Environment.Exit(0);
            }

            List<string> list = new List<string>();
            if (line.Trim() != "-")
            {
                foreach (string c in line.Split(" "))
                {
                    if (c.Trim() != "")
                    {
                        list.Add(c.Trim());
                    }
                }
            }

            return list;
        }

        public static Dictionary<string, List<Edge>> ReadGraph(int roadCount)
        {
            Dictionary<string, List<Edge>> graph = new Dictionary<string, List<Edge>>();

            for (int i = 0; i < roadCount; i++)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    Console.WriteLine("Crazy input!");
                    Environment.Exit(0);
                }

                string[] parts = line.Split(" ");
                if (parts.Length != 3)
                {
                    Console.WriteLine("Crazy input!");
                    Environment.Exit(0);
                }

                string a = parts[0];
                string b = parts[1];

                int cost = 0;
                if (!int.TryParse(parts[2], out cost))
                {
                    Console.WriteLine("Crazy input!");
                    Environment.Exit(0);
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

            return graph;
        }

        public static bool CalculateShortestPath(Dictionary<string, List<Edge>> graph,List<string> rechargeCities,int maxBattery,out Dictionary<string, int> dist,out Dictionary<string, string> prev)
        {
            dist = new Dictionary<string, int>();
            prev = new Dictionary<string, string>();
            Dictionary<string, int> batteryLeft = new Dictionary<string, int>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();

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

            return dist["T"] != int.MaxValue;
        }

        public static List<string> ReconstructPath(Dictionary<string, string> prev, string end)
        {
            List<string> path = new List<string>();
            string cur = end;
            while (cur != null)
            {
                path.Add(cur);
                cur = prev[cur];
            }

            path.Reverse();
            return path;
        }
    }
}
