namespace Advent2023
{
    public class Day4
    {
        public int CalculatePoints(string value)
        {
            if (value == null || value == "")
                return 0;

            int points = 0;

            string[] rows = value.Split('\r');
            foreach (string row in rows)
            {
                if (row == "") continue;
                string numeric = row.Split(':')[1];
                string[] numbers = numeric.Split('|');
                List<int> winning = ReadNumbers(numbers[0]);
                List<int> yourNumbers = ReadNumbers(numbers[1]);
                int matches = FindMatchingNumbers(winning, yourNumbers);
                points += matches > 0 ? (int)Math.Pow(2, matches - 1) : 0;
            }

            return points;
        }
        public int CountCards(string value)
        {
            if (value == null || value == "")
                return 0;

            string[] rows = value.Split('\r');
            int count = 0;
            foreach (string row in rows)
            {
                count += FindAllCardCopies(row,rows);
                if (row != "" && row != "\n" && row != "\r")
                    count++;
            }

            return count;

            
        }

        private int FindAllCardCopies(string row,string[] rows)
        {
            if (row == "" || row == "\n")
                return 0;

            int count = 0;

            string numeric = row.Split(':')[1];
            string[] numbers = numeric.Split('|');
            List<int> winning = ReadNumbers(numbers[0]);
            List<int> yourNumbers = ReadNumbers(numbers[1]);
            int matches = FindMatchingNumbers(winning, yourNumbers);
            int cardNumber = GetCardNumber(row);
            count = matches;
            if(matches > 0)
            {
                for (int i = cardNumber + 1; i <= matches + cardNumber; i++)
                {
                    string copy = rows.Where(x => x.Contains(i.ToString() + ":")).FirstOrDefault("");
                    count += FindAllCardCopies(copy, rows);
                }
            }
            return count;
        }

        public List<int> ReadNumbers(string value)
        {
            if (value == null || value == "")
                return new();

            List<int> res = new();
            string[] strings = value.Split(' ');
            foreach (string s in strings)
                if (s != "" && s != " ")
                    res.Add(int.Parse(s));
            return res;
        }
        public int FindMatchingNumbers(List<int> l1, List<int> l2)
        {
            if (l1 == null || l2 == null || l1.Count == 0 || l2.Count == 0)
                return 0;

            int matches = 0;

            foreach (int i in l2)
                if (l1.Contains(i))
                    matches++;

            return matches;
        }
        public int GetCardNumber(string value)
        {
            if (value == null || value == "")
                return 0;

            string cardPart = value.Split(':')[0];
            string cardNumber = cardPart.Split(' ').Last();

            return int.Parse(cardNumber);
        }
    }
}
