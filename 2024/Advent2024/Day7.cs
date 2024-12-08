
namespace Advent2024
{
    public class Day7
    {
        public List<Equasion> Equasions { get; set; } = new List<Equasion>();
        public int MaxLength = 0;

        public void ReadInput(string input)
        {
            input = input.Replace("\n", "");
            string[] rows = input.Split('\r');
            foreach (string row in rows)
            {
                string[] parts = row.Split(": ");
                Equasion e = new Equasion();
                e.Result = double.Parse(parts[0]);
                string[] nums = parts[1].Split(" ");
                foreach (string num in nums)
                    e.Numbers.Add(int.Parse(num));
                if (nums.Length > MaxLength)
                    MaxLength = nums.Length;
                Equasions.Add(e);
            }
        }

        public double TotalCalibration(string input)
        {
            ReadInput(input);
            double sum = 0;
            var opps = PermutationGenerator.GeneratePermutations(MaxLength, new List<char> { '*', '+' });
            foreach (Equasion e in Equasions)
                if (e.IsPossible(opps))
                    sum += e.Result;
            return sum;
        }

        public double TotalCalibrationExtended(string input)
        {
            ReadInput(input);
            ulong sum = 0;
            var opps = PermutationGenerator.GeneratePermutations(MaxLength, new List<char> { '*', '+', '|' });

            Parallel.ForEach(Equasions, e =>
            {
                if (e.IsPossible(opps))
                    Interlocked.Add(ref sum, (ulong)e.Result);
            });
            return sum;
        }
    }

    public class Equasion
    {
        public double Result { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();

        public bool IsPossible(List<List<char>> operations)
        {
            for (int j = 0; j < operations.Count; j++)
            {
                if (operations[j].Count < Numbers.Count - 1)
                    continue;
                if (operations[j].Count > Numbers.Count - 1)
                    break;

                double current = Numbers[0];
                for (int i = 1; i < Numbers.Count; i++)
                {
                    if (operations[j][i - 1] == '+')
                        current += Numbers[i];
                    else if (operations[j][i - 1] == '*')
                        current *= Numbers[i];
                    else
                        current = double.Parse(current.ToString() + Numbers[i].ToString());
                }
                if (current == Result)
                    return true;
            }

            return false;
        }
    }

    public static class PermutationGenerator
    {
        public static List<List<char>> GeneratePermutations(int maxLength, List<char> toPermutate)
        {
            List<List<char>> result = new List<List<char>>();

            for (int length = 1; length <= maxLength; length++)
            {
                GeneratePermutationsHelper(result, new List<char>(), length, toPermutate);
            }

            return result;
        }

        private static void GeneratePermutationsHelper(List<List<char>> result, List<char> current, int length, List<char> toPermutate)
        {
            if (current.Count == length)
            {
                result.Add(new List<char>(current));
                return;
            }

            foreach (char c in toPermutate)
            {
                current.Add(c);
                GeneratePermutationsHelper(result, current, length, toPermutate);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
