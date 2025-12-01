using System;

namespace Les_11
{
    public class Program
    {
        static void Main(string[] args)
        {
            // === Activity Selection ===
            string[] classes = { "art", "eng", "math", "cs", "music" };
            double[] start = { 9, 9.5, 10, 10.5, 11 };
            double[] end = { 10, 10.5, 11, 11.5, 12 };

            Greedy greedy = new Greedy();
            List<Activity> selected = greedy.Schedule(classes, start, end);

            Console.WriteLine("Following classes are selected:");
            List<string> names = new List<string>();
            foreach (Activity a in selected)
            {
                names.Add(a.Name);
            }
            Console.WriteLine(string.Join(" ", names));
            Console.WriteLine();



            // === Coin Change Problem ===
            int[] coins = { 50, 20, 10, 5, 2, 1 };
            int target = 67;

            Dictionary<int, int> change = greedy.CoinChange(coins, target);

            Console.WriteLine($"Greedy coin change for {target} cents:");
            int totalCoins = 0;
            foreach (var kvp in change)
            {
                Console.WriteLine($"{kvp.Value} coin(s) of {kvp.Key} cents");
                totalCoins += kvp.Value;
            }
            Console.WriteLine($"Total coins used: {totalCoins}");



            // === Extra exercise ===
            Console.WriteLine();
            int[] waarden = { 5, 9, 1, 2, 1, 8, 7 };

            ExerciseGreedyFails tree = new ExerciseGreedyFails(waarden);

            Console.WriteLine("\nPreOrder traversal:");
            tree.PreOrder();

            Console.WriteLine("\n\nInOrder traversal:");
            tree.InOrder();

            Console.WriteLine("\n\nGreedy som:");
            int greedySum = tree.GreedySum();
            Console.WriteLine(greedySum);

            Console.WriteLine("\nOptimale som:");
            int optimaal = tree.Sum();
            Console.WriteLine(optimaal);
        }
    }
}
