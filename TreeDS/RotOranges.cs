using System.Collections.Generic;
using System.Linq;

namespace TreeDS
{
    class Farm
    {
        private class FarmNode
        {
            private int _x;
            private int _y;

            public FarmNode(int x, int y)
            {
                this._x = x;
                this._y = y;
                Neighbour = new LinkedList<FarmNode>();
            }

            public int X { get { return this._x; } }
            public int Y { get { return this._y; } }
            public LinkedList<FarmNode> Neighbour { get; set; }

        }

        int _rows;
        int _columns;
        int[,] _oranges;
        IList<FarmNode> _rottenOranges;

        public Farm(int[,] oranges)
        {
            this._oranges = oranges;
            this._rows = oranges.GetLength(0);
            this._columns = oranges.GetLength(1);

            // Get the rotten oranges separately
            this._rottenOranges = CollectRottenOranges(oranges);
            this.Initialize(this._rottenOranges);
        }

        private void Initialize(IList<FarmNode> rottenOranges)
        {
            // prepare the adjancy list for the rotten oranges.
            foreach (var item in rottenOranges)
            {
                // add left, right, top, bottom neighbour)
                if (IsValid(item.X - 1, item.Y))
                {
                    FarmNode leftNode = new FarmNode(item.X - 1, item.Y);
                    item.Neighbour.AddFirst(leftNode);
                }

                if (IsValid(item.X + 1, item.Y))
                {
                    FarmNode rightNode = new FarmNode(item.X + 1, item.Y);
                    item.Neighbour.AddFirst(rightNode);
                }

                if (IsValid(item.X, item.Y - 1))
                {
                    FarmNode topNode = new FarmNode(item.X, item.Y - 1);
                    item.Neighbour.AddFirst(topNode);
                }

                if (IsValid(item.X, item.Y + 1))
                {
                    FarmNode bottomNode = new FarmNode(item.X, item.Y + 1);
                    item.Neighbour.AddFirst(bottomNode);
                }
            }
        }

        private bool IsValid(int x, int y)
        {
            return x >= 0 && x < _rows && y >= 0 && y < _columns && this._oranges[x, y] == 1;
        }

        public bool CheckIfAllOrangesCanRotten()
        {
            IList<FarmNode> visitedNodes = new List<FarmNode>();
            foreach (var item in this._rottenOranges)
            {
                TraverseFarm(item, visitedNodes);
            }

            return IsFarmVisited(visitedNodes);
        }

        private bool IsFarmVisited(IList<FarmNode> visitedNodes)
        {
            for (int i = 0; i < this._rows; i++)
            {
                for (int j = 0; j < this._columns; j++)
                {
                    if (this._oranges[i, j] == 1 && !Exists(visitedNodes, new FarmNode(i, j)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void TraverseFarm(FarmNode node, IList<FarmNode> visitedNodes)
        {
            Queue<FarmNode> queue = new Queue<FarmNode>();
            queue.Enqueue(node);

            do
            {
                FarmNode tempNode = queue.Dequeue();
                IList<FarmNode> neighbours = this.GetAllNeighbours(tempNode);

                foreach (var item in neighbours)
                {
                    if (!Exists(visitedNodes, item))
                    {
                        queue.Enqueue(item);
                        visitedNodes.Add(item);
                    }
                }
            }
            while (queue.Count > 0);
        }

        private IList<FarmNode> GetAllNeighbours(FarmNode node)
        {
            List<FarmNode> neighbours = new List<FarmNode>();

            //neighbours.Add(node);

            // Get all bottom
            neighbours.AddRange(this.GetAllBottomNeighbours(node.X, node.Y));

            // get all top
            neighbours.AddRange(this.GetAllTopNeighbours(node.X, node.Y));

            // get all left
            neighbours.AddRange(this.GetAllLeftNeighbours(node.X, node.Y));

            // get all right
            neighbours.AddRange(this.GetAllRightNeighbours(node.X, node.Y));

            return neighbours;
        }

        private IList<FarmNode> GetAllBottomNeighbours(int x, int y)
        {
            List<FarmNode> neighbours = new List<FarmNode>();

            while (IsValid(++x, y))
            {
                neighbours.Add(new FarmNode(x, y));
            }

            return neighbours;
        }

        private IList<FarmNode> GetAllTopNeighbours(int x, int y)
        {
            List<FarmNode> neighbours = new List<FarmNode>();

            while (IsValid(--x, y))
            {
                neighbours.Add(new FarmNode(x, y));
            }

            return neighbours;
        }

        private IList<FarmNode> GetAllLeftNeighbours(int x, int y)
        {
            List<FarmNode> neighbours = new List<FarmNode>();

            while (IsValid(x, --y))
            {
                neighbours.Add(new FarmNode(x, y));
            }

            return neighbours;
        }

        private IList<FarmNode> GetAllRightNeighbours(int x, int y)
        {
            List<FarmNode> neighbours = new List<FarmNode>();

            while (IsValid(x, ++y))
            {
                neighbours.Add(new FarmNode(x, y));
            }

            return neighbours;
        }

        private bool Exists(IList<FarmNode> nodes, FarmNode node)
        {
            return nodes.Any(item => Predicate(item, node));
        }

        private bool Predicate(FarmNode src, FarmNode target)
        {
            return src.X == target.X && src.Y == target.Y;
        }

        private IList<FarmNode> CollectRottenOranges(int[,] oranges)
        {
            List<FarmNode> farmNodes = new List<FarmNode>();

            for (int i = 0; i < oranges.GetLength(0); i++)
            {
                for (int j = 0; j < oranges.GetLength(1); j++)
                {
                    if (oranges[i, j] == 2)
                    {
                        FarmNode node = new FarmNode(i, j);
                        farmNodes.Add(node);
                    }
                }
            }

            return farmNodes;
        }
    }
}
