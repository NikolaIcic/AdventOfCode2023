namespace Advent2024
{
    public class Day5
    {
        public List<Rule> Rules { get; set; } = new List<Rule>();
        public List<Update> Updates { get; set; } = new List<Update>();

        public void ReadInput(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');

            int index = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i] == "")
                {
                    index = i;
                    break;
                }
                string[] nums = rows[i].Split('|');
                Rules.Add(new Rule()
                {
                    Num1 = int.Parse(nums[0]),
                    Num2 = int.Parse(nums[1])
                });
            }
            for (int i = index + 1; i < rows.Length; i++)
            {
                string[] nums = rows[i].Split(',');
                Update u = new Update();
                foreach (string n in nums)
                    u.Pages.Add(int.Parse(n));
                Updates.Add(u);
            }
        }

        public int SumCorrectUpdateMiddle(string input)
        {
            int sum = 0;

            ReadInput(input);
            foreach (Update u in Updates)
                if (u.IsInOrder(Rules))
                    sum += u.FindMiddleNumber();

            return sum;
        }
        public int SumIncorrectUpdateMiddle(string input)
        {
            ReadInput(input);

            int sum = 0;
            Parallel.ForEach(Updates, u =>
            {
                if (!u.IsInOrder(Rules))
                {
                    u.FixUpdate(Rules);
                    Interlocked.Add(ref sum, u.FindMiddleNumber());
                }
            });

            return sum;
        }
    }

    public class Rule
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
    }

    public class Update
    {
        public List<int> Pages { get; set; } = new List<int>();

        public int FindMiddleNumber()
        {
            return Pages[Pages.Count / 2];
        }

        public bool IsInOrder(List<Rule> rules)
        {
            foreach (Rule rule in rules)
            {
                int i1 = Pages.IndexOf(rule.Num1);
                if (i1 == -1) continue;
                int i2 = Pages.IndexOf(rule.Num2);
                if (i2 == -1) continue;
                if (i1 > i2) return false;
            }
            return true;
        }

        public void FixUpdate(List<Rule> rules)
        {
            while (!IsInOrder(rules))
            {
                foreach (Rule rule in rules)
                {
                    int i1 = Pages.IndexOf(rule.Num1);
                    int i2 = Pages.IndexOf(rule.Num2);
                    if (i1 == -1 || i2 == -1 || i1 < i2) continue;
                    Swap(Pages, i1, i2);
                }
            }
        }

        private static void Swap(List<int> numbers, int i, int j)
        {
            (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
        }
    }
}
