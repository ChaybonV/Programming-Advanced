using System;
using System.Collections.Generic;

namespace Les_10
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }


    public class BinaryTree
    {
        public TreeNode Root { get; private set; }

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                return;
            }

            TreeNode node = Root;
            TreeNode parent = null;

            while (node != null)
            {
                parent = node;

                if (value < node.Value)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            if (value < parent.Value)
            {
                parent.Left = new TreeNode(value);
            }
            else
            {
                parent.Right = new TreeNode(value);
            }
        }


        public void PrintInOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            PrintInOrder(node.Left);
            Console.Write(node.Value + " ");
            PrintInOrder(node.Right);
        }

        public void PrintPreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.Value + " ");
            PrintPreOrder(node.Left);
            PrintPreOrder(node.Right);
        }

        public void PrintPostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            PrintPostOrder(node.Left);
            PrintPostOrder(node.Right);
            Console.Write(node.Value + " ");
        }



    }
}

