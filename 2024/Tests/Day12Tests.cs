using Advent2024;

namespace Tests
{
    public class Day12Tests
    {
        Day12 d12 = new Day12();

        [Fact]
        public void CanReadInput()
        {
            string input = "AAAA\r\nBBCD\r\nBBCC\r\nEEEC";

            d12.ReadInput(input);

            Assert.Equal(4, d12.Rows);
            Assert.Equal(4, d12.Cols);
        }

        [Fact]
        public void CanFindRegions()
        {
            string input = "AAAA\r\nBBCD\r\nBBCC\r\nEEEC";

            d12.ReadInput(input);
            d12.FindRegions();

            Assert.Equal(5, d12.Regions.Count);
        }
        [Fact]
        public void PerimiterTest()
        {
            Region r = new Region();
            r.Plots = [
                (0, 0),
                (0, 1),
                (1, 1)
            ];

            Assert.Equal(8, r.Perimiter(4,4));
        }
        [Fact]
        public void Acceptance_Test()
        {
            string input2 = "RRRRIICCFF\r\nRRRRIICCCF\r\nVVRRRCCFFF\r\nVVRCCCJFFF\r\nVVVVCJJCFE\r\nVVIVCCJJEE\r\nVVIIICJJEE\r\nMIIIIIJJEE\r\nMIIISIJEEE\r\nMMMISSJEEE";

            Assert.Equal(1930, d12.FindTotalPrice(input2));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input12.txt");

            Assert.Equal(1477762, d12.FindTotalPrice(text));
        }
        [Fact]
        public void Acceptance_Test2()
        {
            string input = "AAAA\r\nBBCD\r\nBBCC\r\nEEEC";

            Assert.Equal(80,d12.FindTotalPriceDiscount(input));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input12.txt");

            Assert.Equal(923480, d12.FindTotalPriceDiscount(text));
        }
    }
}
