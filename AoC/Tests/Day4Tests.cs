using Advent2023;

namespace Tests
{
    public class Day4Tests
    {
        private readonly Day4 d4;
        public Day4Tests()
        {
            d4 = new Day4();
        }
        
        [Fact]
        public void ReadNumbers_ShouldReturnEmpty_ForEmptyOrNull()
        {
            Assert.Empty(d4.ReadNumbers(""));
            Assert.Empty(d4.ReadNumbers(null));
        }
        [Fact]
        public void ReadNumbers_ShouldReadANumber_FromString()
        {
            Assert.Equal(5, d4.ReadNumbers("5")[0]);
            Assert.Equal(12, d4.ReadNumbers("12")[0]);
            Assert.Equal(6, d4.ReadNumbers(" 6")[0]);
            Assert.Equal(6, d4.ReadNumbers(" 6 ")[0]);
            Assert.Equal(6, d4.ReadNumbers("6 ")[0]);
        }
        [Fact]
        public void ReadNumbers_ShouldReadMultipleNumbers()
        {
            Assert.Equal(2, d4.ReadNumbers(" 6 7 ").Count);
            Assert.Equal(5, d4.ReadNumbers("1 2 3 4 5").Count);
        }
        [Fact]
        public void FindMatchingNumbers_ShouldReturnZero_ForEmptyOrNull()
        {
            Assert.Equal(0, d4.FindMatchingNumbers(null,null));
            Assert.Equal(0, d4.FindMatchingNumbers(null,new()));
            Assert.Equal(0, d4.FindMatchingNumbers(new(),null));
            Assert.Equal(0, d4.FindMatchingNumbers(new(),new()));
        }
        [Fact]
        public void FindMatchingNumbers_ShouldReturn1_ForSameLists()
        {
            List<int> list = new List<int>() { 7 };
            Assert.Equal(1, d4.FindMatchingNumbers(list, list));
        }
        [Fact]
        public void FindMatchingNumbers_ShouldReturnCorrect_ForMultiple()
        {
            List<int> l1 = new List<int>() { 1,2,3,4,5,6 };
            List<int> l2 = new List<int>() { 2,4,6,8 };


            Assert.Equal(3, d4.FindMatchingNumbers(l1, l2));
        }
        [Fact]
        public void CalculatePoints_ShouldReturnZero_ForEmpty()
        {
            Assert.Equal(0, d4.CalculatePoints(""));
            Assert.Equal(0, d4.CalculatePoints(null));
        }
        [Fact]
        public void CalculatePoints_ShouldReturnCorrect_ForOneRow()
        {
            string input = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19";

            Assert.Equal(2,d4.CalculatePoints(input));
        }
        [Fact]
        public void CalculatePoints_ShouldReturnCorrect_ForMultipleRows()
        {
            string input = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r";
            input += "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\r";

            Assert.Equal(4, d4.CalculatePoints(input));
        }
        [Fact]
        public void CalculatePoints_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test4.txt");

            Assert.Equal(13,d4.CalculatePoints(text));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input4.txt");

            Assert.Equal(18653, d4.CalculatePoints(text));
        }
        [Fact]
        public void GetCardNumber_ShouldReturnZero_ForEmpty()
        {
            Assert.Equal(0, d4.GetCardNumber(""));
            Assert.Equal(0, d4.GetCardNumber(null));
        }
        [Fact]
        public void GetCardNumber_ShouldReturnCorrect()
        {
            Assert.Equal(1, d4.GetCardNumber("Card 1:"));
            Assert.Equal(2, d4.GetCardNumber("Card  2:"));
            Assert.Equal(35, d4.GetCardNumber("Card   35: 1 2"));
        }
        [Fact]
        public void CountCards_ShouldReturnZero_ForEmptyOrNull()
        {
            Assert.Equal(0, d4.CountCards(""));
            Assert.Equal(0, d4.CountCards(null));
        }
        [Fact]
        public void CountCards_ShouldReturnCorrect_ForOneRowCopies()
        {
            string input = "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\r";
            input += "Card 3: 1 2 | 3 4\r";
            input += "Card 4: 1 2 | 3 4\r";

            Assert.Equal(5, d4.CountCards(input));
        }
        [Fact]
        public void CountCards_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test4.txt");

            Assert.Equal(30, d4.CountCards(text));
        }
        [Fact(Skip = "Operation to expansive")]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input4.txt");

            Assert.Equal(5921508, d4.CountCards(text));
        }
    }
}
