using Advent2023;

namespace Tests
{
    public class Day7Tests
    {
        private readonly D7Hand hand = new D7Hand();
        private readonly Day7 d7 = new Day7();
        [Fact]
        public void CanCreateHandEntity()
        {
            string input = "12345 123";
            D7Hand entity = new D7Hand(input);

            Assert.Equal("12345", entity.Cards);
            Assert.Equal(123, entity.Bid);
        }
        [Fact]
        public void LoadHand_ShouldThrowException_ForInvalidString()
        {
            Action action = () => hand.Load("");
            Action action2 = () => hand.Load("abc");
            Action action3 = () => hand.Load("abc 123");
            Action action4 = () => hand.Load("abcefg 123");

            Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Throws<ArgumentOutOfRangeException>(action2);
            Assert.Throws<ArgumentOutOfRangeException>(action3);
            Assert.Throws<ArgumentOutOfRangeException>(action4);
        }
        [Fact]
        public void CanLoadHandData()
        {
            string cards = "KKKKK";
            int bid = 5;

            string value = cards + " " + bid.ToString();

            hand.Load(value);

            Assert.Equal(cards, hand.Cards);
            Assert.Equal(bid, hand.Bid);
        }
        [Fact]
        public void GetHandType_ShouldGet_HighCard()
        {
            string input = "23456 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.HighCard, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_OnePair()
        {
            string input = "AA234 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.OnePair, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_TwoPair()
        {
            string input = "AAQQ3 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.TwoPair, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_ThreeOfAKind()
        {
            string input = "AAA34 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.ThreeOfAKind, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_FullHouse()
        {
            string input = "AAAQQ 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.FullHouse, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_FourOfAKind()
        {
            string input = "AAAA4 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.FourOfAKind, hand.HandType);
        }
        [Fact]
        public void GetHandType_ShouldGet_FiveOfAKind()
        {
            string input = "AAAAA 1";

            hand.Load(input);
            hand.GetHandType();

            Assert.Equal(HandType.FiveOfAKind, hand.HandType);
        }
        [Fact]
        public void Evaluate_ShouldReturnCorrect()
        {
            string input = "KKKKK 1";

            hand.Load(input);
            hand.Evaluate();

            Assert.Equal(71414141414, hand.Evaluate());
        }
        [Fact]
        public void TotalWinnings_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test7.txt");

            Assert.Equal(6592, d7.TotalWinnings(text));
        }
        [Fact]
        public void TotalWinningsWithJoker_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test7.txt");

            Assert.Equal(6839, d7.TotalWinnings(text,true));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input7.txt");

            Assert.Equal(241344943, d7.TotalWinnings(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input7.txt");

            Assert.Equal(0, d7.TotalWinnings(text,true));
        }
    }
}
