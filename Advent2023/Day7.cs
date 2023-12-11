namespace Advent2023
{
    public class Day7
    {
        List<D7Hand> Hands { get; set; }

        public void LoadHands(string value)
        {
            string[] strings = value.Split('\r');
            foreach (string s in strings)
                if (s != "" || s != "\n")
                    Hands.Add(new D7Hand(s));
        }

        public double TotalWinnings(string value,bool useJoker = false)
        {
            double sum = 0;
            LoadHands(value);
            Hands = Hands.OrderBy(x => x.Evaluate(useJoker)).ToList();
            for (int i = 0; i < Hands.Count; i++)
                sum += Hands[i].Bid * (i + 1);
            return sum;
        }

        public Day7()
        {
            Hands = new List<D7Hand>();
        }
    }

    public class D7Hand
    {
        private char[] CARD_NUMBERS = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

        public string Cards { get; set; }
        public int Bid { get; set; }
        public HandType HandType { get; set; }
        public double Strenght { get; set; }

        public void Load(string value)
        {
            if (value == null || value == "")
                throw new ArgumentOutOfRangeException();

            value = value.Trim(new char[] { ' ', '\n', '\r' });
            string[] strings = value.Split(' ');
            if (strings.Length != 2 || strings[0].Length != 5)
                throw new ArgumentOutOfRangeException();
            Cards = strings[0];
            Bid = int.Parse(strings[1]);
        }

        public void GetHandType()
        {
            Dictionary<char, int> histogram = new Dictionary<char, int>();
            foreach (Char c in Cards)
            {
                if (histogram.ContainsKey(c))
                    histogram[c]++;
                else
                    histogram[c] = 1;
            }

            if (histogram.Count == 1)
                HandType = HandType.FiveOfAKind;
            else if (histogram.Count == 2 && histogram.ElementAt(0).Value != 3 && histogram.ElementAt(0).Value != 2)
                HandType = HandType.FourOfAKind;
            else if (histogram.Count == 2)
                HandType = HandType.FullHouse;
            else if (histogram.Count == 3 && histogram.ContainsValue(3))
                HandType = HandType.ThreeOfAKind;
            else if (histogram.Count == 3)
                HandType = HandType.TwoPair;
            else if (histogram.Count == 4)
                HandType = HandType.OnePair;
            else
                HandType = HandType.HighCard;
        }
        public void GetHandTypeWithJokers()
        {
            string temp = Cards;
            if (!Cards.Contains('J'))
            {
                GetHandType();
                return;
            }
            HandType bestHand = HandType.HighCard;
            foreach (Char c in CARD_NUMBERS)
            {
                Cards = Cards.Replace('J', c);
                GetHandType();
                if (HandType < bestHand)
                    bestHand = HandType;
                Cards = temp;
            }
            HandType = bestHand;
        }
        public double Evaluate(bool useJoker = false)
        {
            if (useJoker)
                GetHandTypeWithJokers();
            else
                GetHandType();
            double result = 7 - (int)HandType;
            result *= 10000000000;
            int mul = 1;
            for (int i = Cards.Length - 1; i >= 0; i--)
            {
                int c;
                if (Cards[i] == 'A')
                    c = 15;
                else if (Cards[i] == 'K')
                    c = 14;
                else if (Cards[i] == 'Q')
                    c = 13;
                else if (Cards[i] == 'J' && !useJoker)
                    c = 12;
                else if (Cards[i] == 'J')
                    c = 1;
                else if (Cards[i] == 'T')
                    c = 10;
                else
                    c = int.Parse(Cards[i].ToString());
                result += c * mul;
                mul *= 100;
            }
            return result;
        }

        public D7Hand()
        {
            Cards = "";
        }
        public D7Hand(string input)
        {
            Cards = "";
            Load(input);
        }

    }
    public enum HandType
    {
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard
    }

}
