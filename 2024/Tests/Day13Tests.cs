using Advent2024;

namespace Tests
{
    public class Day13Tests
    {
        Day13 d13 = new Day13();

        [Fact]
        public void CanReadInput()
        {
            string input = "Button A: X+94, Y+34\r\nButton B: X+22, Y+67\r\nPrize: X=8400, Y=5400\r\n\r\nButton A: X+26, Y+66\r\nButton B: X+67, Y+21\r\nPrize: X=12748, Y=12176";

            d13.ReadInput(input);

            Assert.Equal(2,d13.Machines.Count);
        }
        [Fact]
        public void LowestPrice_Test()
        {
            string input = "Button A: X+94, Y+34\r\nButton B: X+22, Y+67\r\nPrize: X=8400, Y=5400";

            d13.ReadInput(input);

            Assert.Equal(280, d13.Machines[0].LowestPrice());
        }
        [Fact]
        public void Acceptance_Test()
        {
            string input = "Button A: X+94, Y+34\r\nButton B: X+22, Y+67\r\nPrize: X=8400, Y=5400\r\n\r\nButton A: X+26, Y+66\r\nButton B: X+67, Y+21\r\nPrize: X=12748, Y=12176\r\n\r\nButton A: X+17, Y+86\r\nButton B: X+84, Y+37\r\nPrize: X=7870, Y=6450\r\n\r\nButton A: X+69, Y+23\r\nButton B: X+27, Y+71\r\nPrize: X=18641, Y=10279";

            Assert.Equal(480, d13.FewerstTokens(input));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input13.txt");

            Assert.Equal(32041, d13.FewerstTokens(text));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input13.txt");

            Assert.Equal(95843948914827, d13.FewestTokensCorrected(text));

        }
    }
}
