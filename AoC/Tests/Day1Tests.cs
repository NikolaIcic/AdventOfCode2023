using Advent2023;

namespace Tests
{
    public class Day1Tests
    {
        private readonly Day1 d;
        public Day1Tests()
        {
            d = new Day1();
        }

        [Fact]
        public void GivenNull_ReturnZero()
        {
            Assert.Equal(0, d.GetDigits(null));
        }
        [Fact]
        public void GivenEmptyString_ReturnZero()
        {
            Assert.Equal(0, d.GetDigits(string.Empty));
        }
        [Fact]
        public void GivenStringWithoutDigits_ReturnZero()
        {
            Assert.Equal(0, d.GetDigits("Test"));
        }
        [Fact]
        public void GiveStringWithDigit_ReturnDoubleDigit()
        {
            int x = 5;

            int res = d.GetDigits("Test" + x.ToString());

            Assert.Equal(x * 10 + x, res);
        }
        [Fact]
        public void GivenStringWithTwoDiggits_ReturnCorrectResult()
        {
            Assert.Equal(12, d.GetDigits("1abc2"));
        }
        [Fact]
        public void GiveStringWithMoreNumbers_ReturnCorrectResult()
        {
            Assert.Equal(37, d.GetDigits("ab34cd56e7"));
        }

        [Fact]
        public void GetSum_ShouldReturnZero_ForEmpty()
        {
            Assert.Equal(0, d.GetSum(""));
        }

        [Fact]
        public void GetSum_ShouldReturnZero_ForEmptyWithLineBreaks()
        {
            Assert.Equal(0, d.GetSum("/n /n"));
        }

        [Fact]
        public void GetSum_ShouldReturnCorrectSum_ForOneRowOfData()
        {
            Assert.Equal(11, d.GetSum("1bacc/n"));
        }
        [Fact]
        public void GetSum_ShouldReturnCorrectSum_ForMultipleRows()
        {
            string row = "1abc2\n";
            row += "pqr3stu8vwx\n";
            row += "a1b2c3d4e5f\n";
            row += "treb7uchet\n";

            Assert.Equal(142, d.GetSum(row));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input1.txt");

            Assert.Equal(55614, d.GetSum(text));
        }
        [Fact]
        public void GetDigit_ShouldReturnStringValue()
        {
            Assert.Equal(11, d.GetDigits("one"));
        }
        [Theory]
        [InlineData(25, "2seven6five")]
        [InlineData(29, "twonine")]
        [InlineData(75, "75")]
        [InlineData(56, "five6")]
        [InlineData(25, "2seven6five")]
        [InlineData(22, "2seven6five2")]
        [InlineData(71, "seven62nineone")]
        [InlineData(65, "sixfive")]
        [InlineData(12, "onetwo")]
        [InlineData(34, "threefour")]
        [InlineData(78, "seveneight")]
        [InlineData(99, "nine")]
        [InlineData(65, "sixfive\n")]
        public void GetDigit_ShouldReturnCorrectForComplex(int exp, string value)
        {
            Assert.Equal(exp, d.GetDigits(value));
        }
        [Fact]
        public void GetSum_ShouldReturnCorrectForWords()
        {
            string val = "seven62nineone\n";
            val += "sixfive\n";

            Assert.Equal(136,d.GetSum(val));
        }
    }
}