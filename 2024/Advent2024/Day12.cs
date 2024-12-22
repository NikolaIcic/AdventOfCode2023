using Plot = (int Y, int X);

namespace Advent2024
{
    public class Day12
    {
        public char[,] Garder { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public void ReadInput(string input)
        {
            string[] rows = input.Replace("\n", "").Split('\r');
            Rows = rows.Length;
            Cols = rows[0].Length;
            Garder = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    Garder[i, j] = rows[i][j];
        }
        public void FindRegions()
        {
            List<Plot> traversed = new List<Plot>();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    GetRegion(i, j, traversed);
        }
        private void GetRegion(int i, int j, List<Plot> traversed)
        {
            if (traversed.Contains((i, j))) return;
            Region r = new Region();
            r.Type = Garder[i, j];
            CreateRegionHelper(i, j, r, traversed);
            Regions.Add(r);
        }
        private void CreateRegionHelper(int i, int j, Region r, List<Plot> traversed)
        {
            if (traversed.Contains((i, j))) return;
            if (i < 0 || i >= Rows || j < 0 || j >= Cols) return;
            if (Garder[i, j] != r.Type) return;
            r.Plots.Add((i, j));
            traversed.Add((i, j));
            CreateRegionHelper(i + 1, j, r, traversed);
            CreateRegionHelper(i - 1, j, r, traversed);
            CreateRegionHelper(i, j + 1, r, traversed);
            CreateRegionHelper(i, j - 1, r, traversed);
        }
        public int FindTotalPrice(string input)
        {
            ReadInput(input);
            FindRegions();
            return Regions.Sum(r => r.Price(Rows, Cols));
        }
        public int FindTotalPriceDiscount(string input)
        {
            ReadInput(input);
            FindRegions();
            return Regions.Sum(r => r.PriceDiscount(Rows, Cols));
        }
    }

    public class Region
    {
        public List<Plot> Plots { get; set; } = new List<Plot>();
        public char Type { get; set; }

        public int Price(int rows, int cols) => Plots.Count * Perimiter(rows, cols);
        public int PriceDiscount(int rows, int cols) => Plots.Count * CountSides(rows, cols);
        public int Perimiter(int rows, int cols)
        {
            int count = 0;
            foreach (var plot in Plots)
            {
                if (!Exist(plot.Y + 1, plot.X, rows, cols))
                    count++;
                if (!Exist(plot.Y - 1, plot.X, rows, cols))
                    count++;
                if (!Exist(plot.Y, plot.X + 1, rows, cols))
                    count++;
                if (!Exist(plot.Y, plot.X - 1, rows, cols))
                    count++;
            }
            return count;
        }
        public int CountSides(int rows, int cols)
        {
            int count = 0;
            foreach (var plot in Plots)
            {
                // top left
                if (Exist(plot.Y - 1, plot.X - 1, rows, cols) && Exist(plot.Y - 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X - 1, rows, cols)
                    || !Exist(plot.Y - 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X - 1, rows, cols))
                    count++;
                // top right
                if (Exist(plot.Y - 1, plot.X + 1, rows, cols) && Exist(plot.Y - 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X + 1, rows, cols)
                    || !Exist(plot.Y - 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X + 1, rows, cols))
                    count++;
                // bottom left
                if (Exist(plot.Y + 1, plot.X - 1, rows, cols) && Exist(plot.Y + 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X - 1, rows, cols)
                    || !Exist(plot.Y + 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X - 1, rows, cols))
                    count++;
                // bottom right
                if (Exist(plot.Y + 1, plot.X + 1, rows, cols) && Exist(plot.Y + 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X + 1, rows, cols)
                    || !Exist(plot.Y + 1, plot.X, rows, cols) && !Exist(plot.Y, plot.X + 1, rows, cols))
                    count++;
            }
            return count;
        }
        private bool Exist(int i, int j, int rows, int cols)
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols) return false;
            if (Plots.Contains((i, j))) return true;
            return false;
        }
    }
}
