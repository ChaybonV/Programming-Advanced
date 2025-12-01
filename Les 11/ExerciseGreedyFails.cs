using System;
using System.Collections.Generic;

namespace Les_11
{
    public class ExerciseGreedyFails
    {
        public TreeNode Root { get; set; }
        private Queue<TreeNode> queue = new Queue<TreeNode>();

        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public ExerciseGreedyFails(int[] nodes)
        {
            Root = null;
            foreach (int value in nodes)
            {
                this.Insert(value);
            }
        }

        private void Insert(int value)
        {
            Console.WriteLine("\n\nnieuwe waarde --> " + value);
            if (Root == null)
            {
                Root = new TreeNode(value);
                queue.Enqueue(Root);
                queue.Enqueue(Root);
            }
            else
            {
                Console.WriteLine("queue --> " + string.Join(" ", queue));
                TreeNode node = queue.Dequeue();
                Console.WriteLine("dequeue -->" + node.Value);

                if (node.Left == null)
                {
                    node.Left = new TreeNode(value);
                    queue.Enqueue(node.Left);
                }
                else if (node.Right == null)
                {
                    node.Right = new TreeNode(value);
                    queue.Enqueue(node.Right);
                }
            }
        }

        public void InOrder()
        {
            InOrder(Root);
        }

        private void InOrder(TreeNode node)
        {
            if (node == null) return;

            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }

        public void PreOrder()
        {
            PreOrder(Root);
        }

        private void PreOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.Value + " ");

            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public int GreedySum()
        {
            if (Root == null) return 0;

            TreeNode node = Root;
            int som = 0;

            while (node != null)
            {
                som += node.Value;

                if (node.Left == null && node.Right == null)
                {
                    break;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    node = (node.Left.Value > node.Right.Value)
                        ? node.Left
                        : node.Right;
                }
            }

            return som;
        }

        public int Sum()
        {
            return MaxPathSum(Root);
        }

        private int MaxPathSum(TreeNode node)
        {
            if (node == null) return int.MinValue;

            if (node.Left == null && node.Right == null)
            {
                return node.Value;
            }

            int leftSum = MaxPathSum(node.Left);
            int rightSum = MaxPathSum(node.Right);

            return node.Value + Math.Max(leftSum, rightSum);
        }
    }
}
