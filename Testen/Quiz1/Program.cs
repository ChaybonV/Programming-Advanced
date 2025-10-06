using System;
using System.Collections.Generic;

namespace Quiz1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            List<int> priorities = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PRINT" || input == "print")
                {
                    for (int i = 0; i < priorities.Count - 1; i++)
                    {
                        for (int j = 0; j < priorities.Count - i - 1; j++)
                        {
                            if (priorities[j] < priorities[j + 1])
                            {
                                int tempPrio = priorities[j];
                                priorities[j] = priorities[j + 1];
                                priorities[j + 1] = tempPrio;

                                string tempName = names[j];
                                names[j] = names[j + 1];
                                names[j + 1] = tempName;
                            }
                        }
                    }
                    for (int i = 0; i < names.Count; i++)
                    {
                        Console.Write(names[i] + " " + priorities[i]);
                        if (i < names.Count - 1)
                        {
                            Console.Write(" -> ");
                        }
                    }
                    break;
                }
                else if (input == "")
                {
                    Console.WriteLine("Crazy input!");
                }
                else
                {
                    string[] parts = input.Split(" ");
                    names.Add(parts[0]);
                    if (!int.TryParse(parts[1], out int prio))
                    {
                        Console.WriteLine("Crazy input!");
                        break;
                    }
                    priorities.Add(prio);
                }
            }
        }
    }
}

// Chaybon Verlooy