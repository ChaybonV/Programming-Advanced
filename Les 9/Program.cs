using System;

namespace Les_9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Weighted_Graphs graph = new Weighted_Graphs(25);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 9);
            graph.AddEdge(9, 14);
            graph.AddEdge(18, 17);
            graph.AddEdge(18, 19);
            graph.AddEdge(19, 14);
            graph.AddEdge(19, 24);
            graph.AddEdge(24, 23);
            graph.AddEdge(18, 23);
            graph.AddEdge(22, 23);
            graph.AddEdge(17, 12);
            graph.AddEdge(21, 22);
            graph.AddEdge(21, 20);
            graph.AddEdge(20, 15);
            graph.AddEdge(15, 10);
            graph.AddEdge(10, 5);
            graph.AddEdge(5, 0);

            Console.WriteLine(graph.Dijkstra(12, 0));
            Console.WriteLine(graph.ToString());


            // ====== EXERCISE: KIP MET OBSTAKELS ======

            // Obstakel-gewichten (groter = slechter)
            int SEEDS = 0;
            int CHICKEN_FRIENDS = 2;
            int NORMAL_PATH = 5;
            int BRIDGE = 10;
            int CACTI = 15;
            int FALLEN_TREES = 20;
            int WOLVES = 25;
            int FIRE = 50;

            Weighted_ChickenGraph chickenGraph = new Weighted_ChickenGraph(25);
            chickenGraph.AddEdge(0, 1, NORMAL_PATH);
            chickenGraph.AddEdge(1, 2, SEEDS);
            chickenGraph.AddEdge(2, 3, NORMAL_PATH);
            chickenGraph.AddEdge(3, 4, BRIDGE);
            chickenGraph.AddEdge(4, 9, NORMAL_PATH);
            chickenGraph.AddEdge(9, 14, WOLVES);
            chickenGraph.AddEdge(18, 17, NORMAL_PATH);
            chickenGraph.AddEdge(18, 19, CACTI);
            chickenGraph.AddEdge(19, 14, FALLEN_TREES);
            chickenGraph.AddEdge(19, 24, NORMAL_PATH);
            chickenGraph.AddEdge(24, 23, CHICKEN_FRIENDS);
            chickenGraph.AddEdge(18, 23, NORMAL_PATH);
            chickenGraph.AddEdge(22, 23, NORMAL_PATH);
            chickenGraph.AddEdge(17, 12, SEEDS);
            chickenGraph.AddEdge(21, 22, NORMAL_PATH);
            chickenGraph.AddEdge(21, 20, BRIDGE);
            chickenGraph.AddEdge(20, 15, NORMAL_PATH);
            chickenGraph.AddEdge(15, 10, CACTI);
            chickenGraph.AddEdge(10, 5, NORMAL_PATH);
            chickenGraph.AddEdge(5, 0, FIRE);

            int start = 12;
            int end = 0;

            Console.WriteLine();
            Console.WriteLine("=== Kippenwereld (gewogen graaf met obstakels) ===");
            Console.WriteLine(chickenGraph.ToString());

            Console.WriteLine("Kortste pad voor de kip van " + start + " naar " + end + ":");
            Console.WriteLine(chickenGraph.Dijkstra(start, end));
        }
    }
}
