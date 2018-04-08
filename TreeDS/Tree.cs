using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    class Tree
    {
        public Node Root { get; set; }

        public Node Add(int value)
        {
            Node node = new Node { Value = value };

            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node targetNode = FindPos(Root, value);
                node.Parent = targetNode;

                if (value <= targetNode.Value)
                {
                    targetNode.Left = node;
                }
                else
                {
                    targetNode.Right = node;
                }
            }

            return node;
        }

        public Node FindPos(Node node, int value)
        {
            if (value <= node.Value)
            {
                if (node.Left == null)
                {
                    return node;
                }
            }
            else
            {
                if (node.Right == null)
                {
                    return node;
                }
            }

            if (value <= node.Value)
            {
                return FindPos(node.Left, value);
            }
            else
            {
                return FindPos(node.Right, value);
            }
        }

        public void Print()
        {
            InorderTraverse(Root);
        }

        public void InorderTraverse(Node node)
        {
            if (node == null) return;

            Console.WriteLine();

            // Print Left
            InorderTraverse(node.Left);

            // Print node
            Console.Write("{0} ", node.Value);

            // Print Right
            InorderTraverse(node.Right);
        }

        public void TraverseLeft(Node node)
        {
            do
            {
                Console.Write(node.Value);
                node = node.Left;

            } while (node.Left != null);
        }

        public void TraverseRight(Node node)
        {
            do
            {
                Console.Write(node.Value);
                node = node.Right;

            } while (node.Right != null);
        }
    }

    class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
    }
}
