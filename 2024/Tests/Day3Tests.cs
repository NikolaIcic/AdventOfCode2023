using Advent2024;

namespace Tests
{
    public class Day3Tests
    {
        Day3 d3 = new Day3();
        [Fact]
        public void CanCreateEntities()
        {
            Day3 entity = new Day3();
        }

        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input3.txt");

            Assert.Equal(182619815, d3.SumMuls(text));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input3.txt");

            Assert.Equal(80747545, d3.SumMulesConditional(text));
        }
    }
}
