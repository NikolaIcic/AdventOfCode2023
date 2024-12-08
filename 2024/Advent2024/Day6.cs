namespace Advent2024
{
    public class Day6
    {
        public int GetGuardMoves(string input)
        {
            Map m = new Map();
            m.ReadInput(input);
            return m.GetGuardMoves();
        }

        public int GetAllInfinitePath(string input)
        {
            Map m = new Map();
            m.ReadInput(input);
            return m.GetAllInfinitePaths();
        }
    }
    public class Map
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public char[,] Matrix { get; set; }

        public void ReadInput(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');
            Rows = rows.Length;
            Cols = rows[0].Length;
            Matrix = new char[Rows, Cols];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    Matrix[i, j] = rows[i][j];
        }

        public int GetGuardMoves()
        {
            int count = 0;
            char dir = '^';
            int guardX = 0;
            int guardY = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (Matrix[i, j] == '^' || Matrix[i, j] == '>' || Matrix[i, j] == '<' || Matrix[i, j] == 'v')
                    {
                        dir = Matrix[i, j];
                        guardX = j;
                        guardY = i;
                    }
            char[,] traversed = new char[Rows, Cols];
            while (true)
            {
                if (traversed[guardX, guardY] != 'X')
                {
                    count++;
                    traversed[guardX, guardY] = 'X';
                }

                int nextX = guardX;
                int nextY = guardY;
                switch (dir)
                {
                    case '^':
                        nextY--;
                        break;
                    case '>':
                        nextX++;
                        break;
                    case '<':
                        nextX--;
                        break;
                    case 'v':
                        nextY++;
                        break;
                }
                if (nextX < 0 || nextX >= Cols || nextY < 0 || nextY >= Rows)
                    break;
                if (Matrix[nextY, nextX] == '#')
                    dir = Rotate90Deg(dir);
                else
                {
                    guardX = nextX;
                    guardY = nextY;
                }
            }

            return count;
        }

        public bool IsPathInfinite()
        {
            char dir = '^';
            int guardX = 0;
            int guardY = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (Matrix[i, j] != '.' && Matrix[i, j] != '#')
                    {
                        dir = Matrix[i, j];
                        guardX = j;
                        guardY = i;
                    }
            char[,,] obstaclesTraversed = new char[Rows, Cols, 4];
            while (true)
            {
                int nextX = guardX;
                int nextY = guardY;
                switch (dir)
                {
                    case '^':
                        nextY--;
                        break;
                    case '>':
                        nextX++;
                        break;
                    case '<':
                        nextX--;
                        break;
                    case 'v':
                        nextY++;
                        break;
                }
                if (nextX < 0 || nextX >= Cols || nextY < 0 || nextY >= Rows)
                    break;
                if (Matrix[nextY, nextX] == '#')
                {
                    if (obstaclesTraversed[nextY, nextX, DirToInt(dir)] == '#')
                        return true;
                    obstaclesTraversed[nextY, nextX, DirToInt(dir)] = '#';
                    dir = Rotate90Deg(dir);
                }
                else
                {
                    guardX = nextX;
                    guardY = nextY;
                }
            }
            return false;
        }

        public int GetAllInfinitePaths()
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                {
                    char temp = Matrix[i, j];
                    Matrix[i, j] = '#';
                    if (IsPathInfinite())
                        count++;
                    Matrix[i, j] = temp;
                }
            return count;
        }

        private static char Rotate90Deg(char dir)
        {
            switch (dir)
            {
                case '^':
                    return '>';
                case '>':
                    return 'v';
                case 'v':
                    return '<';
                case '<':
                    return '^';
                default:
                    return '^';
            }
        }

        private static int DirToInt(char dir)
        {
            switch (dir)
            {
                case '^':
                    return 0;
                case '>':
                    return 1;
                case '<':
                    return 2;
                case 'v':
                    return 3;
                default: return 0;
            }
        }
    }
}
