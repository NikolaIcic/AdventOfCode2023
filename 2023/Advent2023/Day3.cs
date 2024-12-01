namespace Advent2023
{
    public class Day3
    {
        public List<D3Number> MapNumbers(string value)
        {
            if (value == null || value == "") return new();

            string[] rows = value.Split('\n');

            List<D3Number> list = new();
            List<D3Digit> digits = new();
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (Char.IsDigit(rows[i][j]))
                        digits.Add(new D3Digit(j, i, int.Parse(rows[i][j].ToString())));
                    else if (digits.Count > 0)
                    {
                        list.Add(new D3Number(digits));
                        digits = new();
                    }
                }
            }
            if (digits.Count > 0)
                list.Add(new D3Number(digits));
            return list;
        }
        public List<D3Symbol> MapSymbols(string value, string special = "!@#$%^&*()_+=")
        {
            if (value == null || value == "") return new();

            List<D3Symbol> list = new();
            string[] rows = value.Split('\n');

            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (special.Contains(rows[i][j]))
                        list.Add(new D3Symbol(j, i));
            return list;
        }
        public int SumPartNumbers(string value)
        {
            if (value == null || value == "")
                return 0;

            int sum = 0;
            string specialChars = GetSpecialChars(value);
            List<D3Number> numbers = MapNumbers(value);
            List<D3Symbol> symbols = MapSymbols(value, specialChars);

            foreach (D3Number num in numbers)
                if (num.IsPartNumber(symbols))
                    sum += num.GetValue();

            return sum;
        }
        public string GetSpecialChars(string s)
        {
            string res = "";
            foreach (Char c in s)
            {
                if (!res.Contains(c) && c != '.' && !Char.IsDigit(c) && c != '\n' && c != '\r')
                    res += c + " ";
            }
            return res;
        }
        public int SumGears(string value)
        {
            if (value == null || value == "")
                return 0;

            int sum = 0;
            string specialChars = "*";
            List<D3Number> numbers = MapNumbers(value);
            List<D3Symbol> symbols = MapSymbols(value, specialChars);

            foreach (D3Symbol s in symbols)
                sum += s.GetGearValue(numbers);

            return sum;
        }
    }

    public class D3Digit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public D3Digit(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public bool IsAdjacentToSymbol(List<D3Symbol> symbols)
        {
            if (symbols == null || symbols.Count == 0)
                return false;

            if (symbols.Where(x =>
            x.X == X - 1 && x.Y == Y ||
            x.X == X + 1 && x.Y == Y ||
            x.X == X - 1 && x.Y == Y - 1 ||
            x.X == X && x.Y == Y - 1 ||
            x.X == X + 1 && x.Y == Y - 1 ||
            x.X == X - 1 && x.Y == Y + 1 ||
            x.X == X && x.Y == Y + 1 ||
            x.X == X + 1 && x.Y == Y + 1).Any())
                return true;
            return false;
        }
    }

    public class D3Number
    {
        public List<D3Digit> Digits { get; set; }

        public D3Number()
        {
            Digits = new List<D3Digit>();
        }
        public D3Number(List<D3Digit> digits)
        {
            Digits = digits;
        }

        public bool IsPartNumber(List<D3Symbol> symbols)
        {
            if (symbols == null || symbols.Count == 0)
                return false;

            foreach (D3Digit digit in Digits)
                if (digit.IsAdjacentToSymbol(symbols))
                    return true;

            return false;
        }

        public int GetValue()
        {
            if (Digits == null || Digits.Count == 0) return 0;

            int value = 0;
            int multiplier = 1;
            for (int i = Digits.Count - 1; i >= 0; i--)
            {
                value += Digits[i].Value * multiplier;
                multiplier *= 10;
            }
            return value;
        }
    }

    public class D3Symbol
    {
        public int X { get; set; }
        public int Y { get; set; }

        public D3Symbol(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetGearValue(List<D3Number> numbers)
        {
            int count = 0;
            int res = 1;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].Digits[0].Y > Y + 1 || numbers[i].Digits[0].Y < Y - 1)
                    continue;
                for (int j = 0; j < numbers[i].Digits.Count; j++)
                {
                    if (
                    numbers[i].Digits[j].X == X - 1 && numbers[i].Digits[j].Y == Y ||
                    numbers[i].Digits[j].X == X + 1 && numbers[i].Digits[j].Y == Y ||
                    numbers[i].Digits[j].X == X - 1 && numbers[i].Digits[j].Y == Y - 1 ||
                    numbers[i].Digits[j].X == X && numbers[i].Digits[j].Y == Y - 1 ||
                    numbers[i].Digits[j].X == X + 1 && numbers[i].Digits[j].Y == Y - 1 ||
                    numbers[i].Digits[j].X == X - 1 && numbers[i].Digits[j].Y == Y + 1 ||
                    numbers[i].Digits[j].X == X && numbers[i].Digits[j].Y == Y + 1 ||
                    numbers[i].Digits[j].X == X + 1 && numbers[i].Digits[j].Y == Y + 1)
                    {
                        res *= numbers[i].GetValue();
                        count++;
                        break;
                    }
                }
                if (count > 2)
                    return 0;
            }

            if (count != 2)
                return 0;
            return res;
        }
    }
}
