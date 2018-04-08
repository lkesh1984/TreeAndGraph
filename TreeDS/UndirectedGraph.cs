using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDS
{
    class UnDirectedGraph
    {
        int _vertices;
        LinkedList<int>[] _adjancyListArr;

        public UnDirectedGraph(int vertices)
        {
            this._vertices = vertices;
            this.InitializeAdjancyList(vertices);
        }

        private void InitializeAdjancyList(int vertices)
        {
            this._adjancyListArr = new LinkedList<int>[vertices];
            for (int i = 0; i < this._adjancyListArr.Length; i++)
            {
                this._adjancyListArr[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int src, int dest)
        {
            this._adjancyListArr[src].AddFirst(dest);
            this._adjancyListArr[dest].AddFirst(src);
        }

        public void Print()
        {
            for (int i = 0; i < this._adjancyListArr.Length; i++)
            {
                Console.WriteLine("Vertex: {0}", i);
                foreach (var item in this._adjancyListArr[i].ToList())
                {
                    Console.Write("{0} -> ", item);
                }

                Console.WriteLine();
            }
        }

        public void BFSTraverse()
        {
            int[] visited = new int[_vertices];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(0);
            visited[0] = 1;

            do
            {
                int vertex = queue.Dequeue();

                Console.WriteLine(vertex);

                // find the adjance list of the vertex
                LinkedList<int> node = this._adjancyListArr[vertex];
                foreach (var item in node)
                {
                    if (visited[item] != 1)
                    {
                        queue.Enqueue(item);
                        visited[item] = 1;
                    }
                }

            } while (queue.Count > 0);
        }

        public void DFSTraverse()
        {
            int[] visited = new int[_vertices];
            Stack<int> queue = new Stack<int>();

            queue.Push(0);
            visited[0] = 1;

            do
            {
                int vertex = queue.Pop();

                Console.WriteLine(vertex);

                // find the adjance list of the vertex
                LinkedList<int> node = this._adjancyListArr[vertex];
                foreach (var item in node)
                {
                    if (visited[item] != 1)
                    {
                        queue.Push(item);
                        visited[item] = 1;
                    }
                }

            } while (queue.Count > 0);
        }
    }
}
