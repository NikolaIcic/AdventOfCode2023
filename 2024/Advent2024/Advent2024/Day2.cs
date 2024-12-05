namespace Advent2024
{
    public class Day2
    {
        public List<Report> Reports = new List<Report>();

        public void ReadFromInput(string input)
        {
            string[] rows = input.Split('\r');
            foreach (string row in rows)
            {
                string n = row.Replace("\n", "");
                Report r = new();
                string[] lvls = n.Split(' ');
                foreach (string l in lvls)
                    r.Levels.Add(int.Parse(l));
                Reports.Add(r);
            }
        }

        public int GetTotalSafe(string input)
        {
            ReadFromInput(input);
            int count = 0;
            foreach (Report r in Reports)
                if (r.IsSafe())
                    count++;
            return count;
        }

        public int GetTotalSafeExpanded(string input)
        {
            ReadFromInput(input);
            int count = 0;
            foreach (Report r in Reports)
                if (r.IsSafeExpanded())
                    count++;
            return count;
        }
    }

    public class Report
    {
        public List<int> Levels { get; set; } = new List<int>();
        public const int MAX_INC = 3;
        public const int MIN_INC = 1;

        public bool IsSafe()
        {
            if (Levels.Count < 2)
                return true;
            int diff = Levels[0] - Levels[1];
            int sign = 1;
            if (diff == 0) return false;
            if (diff < 0) sign = -1;

            for (int i = 0; i < Levels.Count - 1; i++)
            {
                diff = Levels[i] - Levels[i + 1];
                if (diff == 0 || (diff < 0 && sign == 1) || (diff > 0 && sign == -1))
                    return false;
                if (MathF.Abs(diff) > MAX_INC) return false;
            }
            return true;
        }

        public bool IsSafeExpanded()
        {
            if (IsSafe()) return true;
            List<int> original = new List<int>(Levels);
            for (int i = 0; i < Levels.Count; i++)
            {
                Levels.RemoveAt(i);
                if (IsSafe()) return true;
                Levels = new List<int>(original);
            }
            return false;
        }
    }
}
