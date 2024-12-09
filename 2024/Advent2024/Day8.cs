namespace Advent2024
{
    public class Day8
    {
        public List<Antenna> Antennas { get; set; } = new List<Antenna>();
        public int Rows { get; set; }
        public int Cols { get; set; }

        public void ReadInput(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] != '.')
                        Antennas.Add(new Antenna()
                        {
                            Frequency = rows[i][j],
                            X = j,
                            Y = i
                        });
            Rows = rows.Length;
            Cols = rows[0].Length;
        }
        public List<AntiNode> GetAntiNodes(Antenna a1, Antenna a2)
        {
            if (a1.Frequency != a2.Frequency) return null;
            List<AntiNode> res = new List<AntiNode>();

            int v1X = a2.X - a1.X;
            int v1Y = a2.Y - a1.Y;

            int v2X = a1.X - a2.X;
            int v2Y = a1.Y - a2.Y;

            res.Add(new AntiNode()
            {
                X = a1.X + v2X,
                Y = a1.Y + v2Y
            });
            res.Add(new AntiNode()
            {
                X = a2.X + v1X,
                Y = a2.Y + v1Y
            });

            return res;
        }
        public List<AntiNode> GetAntiNodesResonant(Antenna a1, Antenna a2)
        {
            if (a1.Frequency != a2.Frequency) return null;
            List<AntiNode> res = new List<AntiNode>();

            int v1X = a2.X - a1.X;
            int v1Y = a2.Y - a1.Y;

            int v2X = a1.X - a2.X;
            int v2Y = a1.Y - a2.Y;

            int x = 0;
            int y = 0;
            int count = 0;
            while (x >= 0 && x < Rows && y >= 0 && y < Cols)
            {
                x = a1.X + v2X * count;
                y = a1.Y + v2Y * count;
                res.Add(new AntiNode()
                {
                    X = x,
                    Y = y
                });
                count++;
            }
            x = 0;
            y = 0;
            count = 0;
            while (x >= 0 && x < Rows && y >= 0 && y < Cols)
            {
                x = a2.X + v1X * count;
                y = a2.Y + v1Y * count;
                res.Add(new AntiNode()
                {
                    X = x,
                    Y = y
                });
                count++;
            }

            return res;
        }
        public int GetUniqueAntiNodes(string input)
        {
            ReadInput(input);
            int count = 0;
            List<AntiNode> antiNodes = new List<AntiNode>();
            for (int i = 0; i < Antennas.Count - 1; i++)
                for (int j = i + 1; j < Antennas.Count; j++)
                    if (Antennas[i].Frequency == Antennas[j].Frequency)
                        foreach (AntiNode anti in GetAntiNodes(Antennas[i], Antennas[j]))
                            if (anti.X >= 0 && anti.X < Cols && anti.Y >= 0 && anti.Y < Rows &&
                                antiNodes.Find(a => a.X == anti.X && a.Y == anti.Y) == null)
                            {
                                count++;
                                antiNodes.Add(anti);
                            }

            return count;
        }
        public int GetUniqueAntiNodesResonant(string input)
        {
            ReadInput(input);
            int count = 0;
            List<AntiNode> antiNodes = new List<AntiNode>();
            for (int i = 0; i < Antennas.Count - 1; i++)
                for (int j = i + 1; j < Antennas.Count; j++)
                    if (Antennas[i].Frequency == Antennas[j].Frequency)
                        foreach (AntiNode anti in GetAntiNodesResonant(Antennas[i], Antennas[j]))
                            if (anti.X >= 0 && anti.X < Cols && anti.Y >= 0 && anti.Y < Rows &&
                                antiNodes.Find(a => a.X == anti.X && a.Y == anti.Y) == null)
                            {
                                count++;
                                antiNodes.Add(anti);
                            }

            return count;
        }
    }

    public class Antenna
    {
        public char Frequency { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class AntiNode
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
