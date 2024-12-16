using Advent2024;

namespace Tests
{
    public class Day10Tests
    {
        Day10 d10 = new Day10();

        [Fact]
        public void CanReadInput()
        {
            d10.ReadInput("0123\r\n1234\r\n8765\r\n9876");

            Assert.Equal(0, d10.Map[0, 0]);
            Assert.Equal(6, d10.Map[3, 3]);
            Assert.Equal(4, d10.Rows);
            Assert.Equal(4, d10.Cols);
        }

        [Fact]
        public void FindTrailheadScore()
        {
            string input = "";
            input += "0123\r";
            input += "1234\r";
            input += "8765\r";
            input += "9876";

            string input2 = "";
            input2 += "0123\r";
            input2 += "2134\r";
            input2 += "1165\r";
            input2 += "9876";

            d10.ReadInput(input);
            Assert.Equal(16, d10.FindTrailheadScoreDistinct(0, 0));
            d10.ReadInput(input2);
            Assert.Equal(4, d10.FindTrailheadScoreDistinct(0, 0));
        }
        [Fact]
        public void FindTHSum()
        {
            string input = "";
            input += "0123\r";
            input += "1234\r";
            input += "8765\r";
            input += "9876";

            string input2 = "";
            input2 += "0123\r";
            input2 += "2134\r";
            input2 += "1165\r";
            input2 += "9876";

            string input3 = "";
            input3 += "0123456789\r";
            input3 += "1114111111\r";
            input3 += "2345611111\r";
            input3 += "3456789111";

            Assert.Equal(16, d10.FindTrailheadSumDistinct(input));
            Assert.Equal(4, d10.FindTrailheadSumDistinct(input2));
            Assert.Equal(8, d10.FindTrailheadSumDistinct(input3));
        }
        [Fact]
        public void FindTHSum_AcceptanceTest()
        {
            string input = "89010123\r\n78121874\r\n87430965\r\n96549874\r\n45678903\r\n32019012\r\n01329801\r\n10456732";

            Assert.Equal(36, d10.FindTrailheadSum(input));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input10.txt");

            Assert.Equal(472, d10.FindTrailheadSum(text));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input10.txt");

            Assert.Equal(969, d10.FindTrailheadSumDistinct(text));
        }
    }
}
