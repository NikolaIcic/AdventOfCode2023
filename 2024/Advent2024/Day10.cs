namespace Advent2024
{
    public class Day10
    {
        public int[,] Map;
        public int Rows;
        public int Cols;

        public void ReadInput(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');
            Rows = rows.Length;
            Cols = rows[0].Length;
            Map = new int[rows.Length, rows[0].Length];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    Map[i, j] = int.Parse(rows[i][j].ToString());
        }

        public int FindTrailheadSum(string input)
        {
            ReadInput(input);
            int sum = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (Map[i, j] == 0)
                        sum += FindTrailheadScore(j, i);
            return sum;
        }

        public int FindTrailheadSumDistinct(string input)
        {
            ReadInput(input);
            int sum = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (Map[i, j] == 0)
                        sum += FindTrailheadScoreDistinct(j, i);
            return sum;
        }

        public int FindTrailheadScore(int x, int y)
        {
            int count = 0;

            List<PathNode> traversed = new List<PathNode>();

            count += IsTrail(x + 1, y, x, y, 0, traversed);
            count += IsTrail(x - 1, y, x, y, 0, traversed);
            count += IsTrail(x, y + 1, x, y, 0, traversed);
            count += IsTrail(x, y - 1, x, y, 0, traversed);

            return count;
        }

        public int FindTrailheadScoreDistinct(int x, int y)
        {
            int count = 0;

            count += IsDistrinctTrail(x + 1, y, x, y, 0);
            count += IsDistrinctTrail(x - 1, y, x, y, 0);
            count += IsDistrinctTrail(x, y + 1, x, y, 0);
            count += IsDistrinctTrail(x, y - 1, x, y, 0);

            return count;
        }

        private int IsTrail(int x, int y, int prevX, int prevY, int score, List<PathNode> traversed)
        {
            if (x < 0 || x >= Cols || y < 0 || y >= Rows)
                return 0;
            if (Map[y, x] != (Map[prevY, prevX] + 1))
                return 0;
            if (Map[y, x] == 9)
            {
                if (traversed.Find(n => n.X == x && n.Y == y) != null)
                    return 0;
                traversed.Add(new PathNode() { X = x, Y = y });
                return 1;
            }

            score += IsTrail(x + 1, y, x, y, 0, traversed);
            score += IsTrail(x - 1, y, x, y, 0, traversed);
            score += IsTrail(x, y + 1, x, y, 0, traversed);
            score += IsTrail(x, y - 1, x, y, 0, traversed);
            return score;
        }

        private int IsDistrinctTrail(int x, int y, int prevX, int prevY, int score)
        {
            if (x < 0 || x >= Cols || y < 0 || y >= Rows)
                return 0;
            if (Map[y, x] != (Map[prevY, prevX] + 1))
                return 0;
            if (Map[y, x] == 9)
                return 1;

            score += IsDistrinctTrail(x + 1, y, x, y, 0);
            score += IsDistrinctTrail(x - 1, y, x, y, 0);
            score += IsDistrinctTrail(x, y + 1, x, y, 0);
            score += IsDistrinctTrail(x, y - 1, x, y, 0);
            return score;
        }
    }

    class PathNode
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
