using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Tree Demo...");
            Tree tree = new Tree();
            tree.Add(1);
            tree.Add(3);
            tree.Add(2);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            tree.Print();
        }

        static void Main2(string[] args)
        {
            Console.WriteLine("UnDirected Graph Demo...");
            UnDirectedGraph graph = new UnDirectedGraph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(4, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 1);

            graph.Print();

            Console.WriteLine("BFS Traversal");
            graph.BFSTraverse();

            Console.WriteLine("DFS Traversal");
            graph.DFSTraverse();
        }

        static void Main3(string[] args)
        {
            Console.WriteLine("Directed Graph Demo...");
            DirectedGraph graph = new DirectedGraph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(4, 3);
            graph.AddEdge(3, 2);
            graph.AddEdge(2, 1);

            graph.Print();

            Console.WriteLine("BFS Traversal");
            graph.BFSTraverse();

            Console.WriteLine("DFS Traversal");
            graph.DFSTraverse();

            Console.WriteLine("Retrieving all the cycles");
            graph.GetAllLoops();
        }

        static void Main(string[] args)
        {
            int[,] data = new int[3, 5];
            data = new int[,] {{2, 1, 0, 2, 1},
                              {1, 0, 1, 2, 1},
                              {1, 0, 0, 2, 1}};

            Farm farm = new Farm(data);
            bool canDo = farm.CheckIfAllOrangesCanRotten();
        }
    }
}
