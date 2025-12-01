using System;
using System.Collections.Generic;

namespace North_Pole_Decorating
{
    public class Tree
    {
        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
            }
        }

        private Node root;

        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node current = root;

            while (true)
            {
                if (value < current.Value)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(value);
                        break;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(value);
                        break;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
        }

        public string LevelOrder()
        {
            if (root == null)
            {
                return string.Empty;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            string result = "";
            bool first = true;

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                if (!first)
                {
                    result += " ";
                }
                result += current.Value;
                first = false;

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }

            return result;
        }
    }
}
