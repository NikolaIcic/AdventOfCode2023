using Advent2024;

namespace Tests
{
    public class Day11Tests
    {
        Day11 d11 = new Day11();

        [Fact]
        public void Blinking_AcceptanceTest()
        {
            string input = "125 17";

            Assert.Equal(55312, d11.CountStones(input, 25));
        }
        [Fact]
        public void Part1()
        {
            string input = "3 386358 86195 85 1267 3752457 0 741";

            Assert.Equal(183248, d11.CountStones(input, 25));
        }
        [Fact]
        public void Part2()
        {
            string input = "3 386358 86195 85 1267 3752457 0 741";

            Assert.Equal(218811774248729, d11.CountStones(input, 75));
        }
    }
}
