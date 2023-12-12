namespace Advent2023
{
    public class Day9
    {
        public double FindSum(string input,bool reverse = false)
        {
            double sum = 0;
            string[] strings = input.Split('\r');
            foreach (string s in strings)
                if (s != "" && s != "\n")
                {
                    D9Row row = new D9Row(s);
                    if (reverse)
                        row.Numbers.Reverse();
                    sum += row.FindNextNumber();
                }
            return sum;
        }
    }

    public class D9Row
    {
        public List<double> Numbers { get; set; } = new List<double>();

        public D9Row()
        {

        }

        public D9Row(string input)
        {
            LoadNumbers(input);
        }

        public double FindNextNumber()
        {
            List<List<double>> matrix = new() { Numbers };

            int count = 0;
            do
            {
                List<double> nextRow = new();
                for (int i = 0; i < matrix[count].Count - 1; i++)
                    nextRow.Add(matrix[count][i + 1] - matrix[count][i]);
                count++;
                matrix.Add(nextRow);
            } while (!IsAllZeroArray(matrix[count]));

            matrix[count].Add(0);

            for (int i = matrix.Count - 2; i >= 0; i--)
                matrix[i].Add(matrix[i + 1].Last() + matrix[i].Last());

            return matrix[0].Last();
        }

        private static bool IsAllZeroArray(List<double> list)
        {
            foreach (double i in list)
                if (i != 0)
                    return false;
            return true;
        }

        public void LoadNumbers(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            value = value.Trim(new char[] { ' ', '\n', '\r' });

            string[] nums = value.Split(' ');
            foreach (string s in nums)
                Numbers.Add(double.Parse(s));
        }
    }
}
