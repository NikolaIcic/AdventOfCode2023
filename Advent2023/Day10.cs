namespace Advent2023
{
    public class Day10
    {
        public D10Node StartingNode { get; set; } = new D10Node();
        public List<D10Node> Nodes { get; set; } = new List<D10Node>();

        public void LoadData(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');

            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                {
                    D10Node node = new D10Node(j, i, rows[i][j]);
                    Nodes.Add(node);
                    if (node.Symbol == 'S')
                        StartingNode = node;
                }
        }
        public int LoopLength(int x, int y, int prevX, int prevY,List<D10Node> history,int count = 0)
        {
            D10Node node = Nodes.Where(n => n.X == x && n.Y == y).FirstOrDefault();
            if (node == null || node.Symbol == '.')
                return 0;

            if (history.Contains(node))
                return 0;
            history.Add(node);

            int nextX = 0;
            int nextY = 0;
            switch (node.Symbol)
            {
                case 'S':
                    return count + 1;

                case '|':
                    if (prevY == y)
                        return 0;
                    nextX = x;
                    nextY = y - 1;
                    if (y > prevY)
                        nextY = y + 1;
                    break;
                case '-':
                    if (prevX == x)
                        return 0;
                    nextX = x - 1;
                    nextY = y;
                    if (x > prevX)
                        nextX = x + 1;
                    break;
                case 'F':
                    if (prevX < x || prevY < y)
                        return 0;
                    if(prevX > x)
                    {
                        nextY = y + 1;
                        nextX = x;
                    }
                    else
                    {
                        nextY = y;
                        nextX = x + 1;
                    }
                    break;
                case '7':
                    if (prevX > x || prevY < y)
                        return 0;
                    if (prevX < x)
                    {
                        nextY = y + 1;
                        nextX = x;
                    }
                    else
                    {
                        nextY = y;
                        nextX = x - 1;
                    }
                    break;
                case 'L':
                    if (prevX < x || prevY > y)
                        return 0;
                    if (prevX > x)
                    {
                        nextY = y - 1;
                        nextX = x;
                    }
                    else
                    {
                        nextY = y;
                        nextX = x + 1;
                    }
                    break;
                case 'J':
                    if (prevY > y || prevX > x)
                        return 0;
                    if (prevX < x)
                    {
                        nextY = y - 1;
                        nextX = x;
                    }
                    else
                    {
                        nextY = y;
                        nextX = x - 1;
                    }
                    break;
            }

            return LoopLength(nextX,nextY,x,y,history,count + 1);
        }
        public int FindFarthestDistance(string input)
        {
            LoadData(input);
            int total = 0;
            total = LoopLength(StartingNode.X+1, StartingNode.Y, StartingNode.X, StartingNode.Y, new List<D10Node>());
            if (total != 0)
                return total / 2;
            total = LoopLength(StartingNode.X-1, StartingNode.Y, StartingNode.X, StartingNode.Y, new List<D10Node>());
            if (total != 0)
                return total / 2;
            total = LoopLength(StartingNode.X, StartingNode.Y+1, StartingNode.X, StartingNode.Y, new List<D10Node>());
            if (total != 0)
                return total / 2;
            total = LoopLength(StartingNode.X, StartingNode.Y-1, StartingNode.X, StartingNode.Y, new List<D10Node>());
            if (total != 0)
                return total / 2;
            return 0;
        }
    }
    public class D10Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public D10Node(int x, int y, char c)
        {
            X = x;
            Y = y;
            Symbol = c;
        }
        public D10Node()
        {

        }
    }
}
