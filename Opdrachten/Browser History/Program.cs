using System;

namespace Browser_History
{
    public class Program
    {
        static void Main()
        {
            Stack back = new Stack();
            Stack forward = new Stack();
            string current = "";
            bool hasInput = false;
            string line = "";

            while ((line = Console.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                {
                    continue;
                }

                hasInput = true;
                string[] parts = line.Split(" ", 2);
                string command = parts[0].ToUpper();

                if (command == "VISIT")
                {
                    if (parts.Length < 2 || parts[1].Trim() == "")
                    {
                        Console.WriteLine("Crazy input!");
                        return;
                    }

                    string url = parts[1].Trim();
                    if (current != "")
                    {
                        back.Push(current);
                    }
                    current = url;
                    forward.Clear();
                }
                else if (command == "BACK")
                {
                    if (!back.IsEmpty())
                    {
                        forward.Push(current);
                        current = back.Pop();
                    }
                }
                else if (command == "FORWARD")
                {
                    if (!forward.IsEmpty())
                    {
                        back.Push(current);
                        current = forward.Pop();
                    }
                }
                else if (command == "CURRENT")
                {
                    Console.WriteLine(current);
                }
                else
                {
                    Console.WriteLine("Crazy input!");
                    return;
                }
            }

            if (!hasInput)
            {
                Console.WriteLine("Crazy input!");
            }
        }
    }
}
