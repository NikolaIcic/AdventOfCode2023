namespace Advent2023
{
    public class Day11
    {
        public List<string> Map { get; set; } = new List<string>();

        public void ExpandMap(double exp = 1)
        {
            List<int> emptyRows = new List<int>();
            List<int> emptyCols = new List<int>();
            for(int i=0; i<Map.Count; i++)
                if (!Map[i].Contains('#'))
                    emptyRows.Add(i);
            for(int i=0;i< Map[0].Length; i++)
                for (int j = 0; j < Map.Count; j++)
                {
                    if (Map[j][i] == '#')
                        break;
                    if (j == Map.Count - 1)
                        emptyCols.Add(i);
                }
            for(int i=0;i< emptyRows.Count; i++)
                Map.Insert(emptyRows[i] + i, new string('.', Map[0].Length));
            for(int i=0;i<emptyCols.Count;i++)
                for (int j = 0; j < Map.Count; j++)
                    Map[j] = Map[j].Insert(emptyCols[i] + i, ".");

        }
        public int GetDistance(D11Galaxy g1, D11Galaxy g2)
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
        }
        public int SumGalaxyDistances(string map,double exp = 1)
        {
            LoadData(map);
            ExpandMap(exp);
            List<D11Galaxy> galaxies = new List<D11Galaxy>();
            for(int i=0;i< Map.Count;i++)
                for(int j = 0; j < Map[i].Length;j++)
                    if (Map[i][j] == '#')
                        galaxies.Add(new D11Galaxy(j, i));

            int sum = 0;
            for (int i = 0; i < galaxies.Count - 1; i++)
                for (int j = i + 1; j < galaxies.Count; j++)
                    sum += GetDistance(galaxies[i], galaxies[j]);

            return sum;
        }
    }

    public class D11Galaxy
    {
        public int X { get; set; }
        public int Y { get; set; }

        public D11Galaxy(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
