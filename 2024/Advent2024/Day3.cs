namespace Advent2024
{
    public class Day3
    {
        public int SumMuls(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length - 8; i++)
            {
                if (input[i] == 'm' && input[i + 1] == 'u' && input[i + 2] == 'l' && input[i + 3] == '(')
                    sum += ValidMulOpp(input.Substring(i + 4, 8));
            }
            return sum;
        }

        public int SumMulesConditional(string input)
        {
            int sum = 0;
            bool enabled = true;
            for (int i = 0; i < input.Length - 8; i++)
            {
                if (input[i] == 'd' && input[i + 1] == 'o' && input[i + 2] == '(' && input[i + 3] == ')')
                    enabled = true;
                else if (input[i] == 'd' && input[i + 1] == 'o' && input[i + 2] == 'n' && input[i + 3] == '\'' && input[i + 4] == 't' && input[i + 5] == '(' && input[i + 6] == ')')
                    enabled = false;
                else if (enabled && input[i] == 'm' && input[i + 1] == 'u' && input[i + 2] == 'l' && input[i + 3] == '(')
                    sum += ValidMulOpp(input.Substring(i + 4, 8));
            }
            return sum;
        }

        public int ValidMulOpp(string text)
        {
            if (!text.Contains(',') || !text.Contains(')')) return 0;

            string[] parts = text.Split(',');
            if (!int.TryParse(parts[0], out int num1))
                return 0;
            if (!int.TryParse(parts[1].Split(')')[0], out int num2))
                return 0;
            return num1 * num2;
        }
    }
}
