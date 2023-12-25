namespace Advent2023
{
    public class Day12
    {
        public bool IsValid(string value)
        {
            value = value.Trim(new char[] { ' ', '\r', '\n' });

            if (value == "") return false;

            if (value.Contains('?')) return false;

            string[] parts = value.Split(' ');
            string record = parts[0];

            int count = 0;
            List<int> broken = new List<int>();
            foreach (Char c in record)
            {
                if (c == '.')
                {
                    if (count > 0)
                        broken.Add(count);
                    count = 0;
                }
                else
                    count++;
            }
            if (count > 0)
                broken.Add(count);

            string[] numbers = parts[1].Split(',');
            if (numbers.Length != broken.Count)
                return false;
            for (int i = 0; i < numbers.Length; i++)
                if (broken[i] != int.Parse(numbers[i]))
                    return false;

            return true;
        }
        public double SumArrangements(string input,bool unfold = false)
        {
            double sum = 0;
            string[] rows = input.Split('\r');
            foreach (string row in rows)
                if (row != "" && row != "\n")
                    sum += FindArrangements(row,unfold);

            return sum;
        }
        public double FindArrangements(string row, bool unfold = false)
        {
            if (IsValid(row)) return 1;
            if (!row.Contains('?')) return 0;

            row = row.Trim(new char[] { ' ', '\n' });
            if (unfold)
                row = UnfoldRow(row);

            double arrangements = 0;

            string[] parts = row.Split(' ');
            string record = parts[0];
            string numbers = parts[1];

            List<string> permutations = GeneratePermutations(record);

            foreach (string s in permutations)
                if (IsValid(s + " " + numbers))
                    arrangements++;

            return arrangements;
        }
        public string UnfoldRow(string row)
        {
            string[] parts = row.Split(' ');
            string record = parts[0];
            string numbers = parts[1];
            string res = "";
            for (int i = 0; i < 5; i++)
            {
                res += record + "?";
            }
            res = res.Substring(0, res.Length - 1);
            res += " ";
            for (int i = 0; i < 5; i++)
            {
                res += numbers + ",";
            }
            res = res.Substring(0, res.Length - 1);
            return res;
        }
        private static List<string> GeneratePermutations(string input)
        {
            List<string> permutations = new List<string>();
            HashSet<string> visited = new HashSet<string>();
            GeneratePermutationsHelper(input.ToCharArray(), 0, permutations);
            return permutations;
        }
        private static void GeneratePermutationsHelper(char[] chars, int index, List<string> permutations)
        {
            if (index == chars.Length)
            {
                permutations.Add(new string(chars));
                return;
            }

            if (chars[index] == '?')
            {
                chars[index] = '.';
                GeneratePermutationsHelper(chars, index + 1, permutations);
                chars[index] = '#';
                GeneratePermutationsHelper(chars, index + 1, permutations);
                chars[index] = '?'; // Reset the character for backtracking
            }
            else
                GeneratePermutationsHelper(chars, index + 1, permutations);
        }
    }
}
