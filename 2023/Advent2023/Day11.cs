namespace Advent2023
{
    public class Day11
    {
        public List<string> Map { get; set; } = new List<string>();
        public List<D11Galaxy> Galaxies = new List<D11Galaxy>();

        public void ExpandMap(double expansionRate = 2)
        {
            List<int> emptyRows = new List<int>();
            List<int> emptyCols = new List<int>();

            for(int i=0; i<Map.Count; i++)
                if (!Map[i].Contains('#'))
                    emptyRows.Add(i);
            for (int i = 0; i < Map[0].Length; i++)
                for (int j = 0; j < Map.Count; j++)
                {
                    if (Map[j][i] == '#')
                        break;
                    if (j == Map.Count - 1)
                        emptyCols.Add(i);
                }

            for (int i = 0; i < emptyRows.Count; i++)
                for(int j=0;j<Galaxies.Count; j++)
                    if (Galaxies[j].Y > emptyRows[i] + i * (expansionRate-1))
                        Galaxies[j].Y += expansionRate - 1;
            for (int i = 0; i < emptyCols.Count; i++)
                for (int j = 0; j < Galaxies.Count; j++)
                    if (Galaxies[j].X > emptyCols[i] + i * (expansionRate - 1))
                        Galaxies[j].X += expansionRate - 1;

        }
        public double GetDistance(D11Galaxy g1, D11Galaxy g2)
        {
            return Math.Abs(g1.X - g2.X) + Math.Abs(g1.Y - g2.Y);
        }
        public void LoadData(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string[] strings = value.Split('\r');
            foreach (string s in strings)
                if (s != "" && s != "\n")
                    Map.Add(s.Trim(new char[] { ' ', '\n' }));

            for (int i = 0; i < Map.Count; i++)
                for (int j = 0; j < Map[i].Length; j++)
                    if (Map[i][j] == '#')
                        Galaxies.Add(new D11Galaxy(j, i));
        }
        public double SumGalaxyDistances(string map,double expansionRate = 2)
        {
            LoadData(map);
            ExpandMap(expansionRate);

            double sum = 0;
            for (int i = 0; i < Galaxies.Count - 1; i++)
                for (int j = i + 1; j < Galaxies.Count; j++)
                    sum += GetDistance(Galaxies[i], Galaxies[j]);

            return sum;
        }
    }

    public class D11Galaxy
    {
        public double X { get; set; }
        public double Y { get; set; }

        public D11Galaxy(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
