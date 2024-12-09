using Advent2024;

namespace Tests
{
    public class Day8Tests
    {
        Day8 d8;

        public Day8Tests()
        {
            d8 = new Day8();
        }

        [Fact]
        public void CanReadInput()
        {
            string input = "......\r\n..ab..";

            d8.ReadInput(input);

            Assert.Equal(2, d8.Antennas.Count);
            Assert.Equal('a', d8.Antennas[0].Frequency);
            Assert.Equal(2, d8.Antennas[0].X);
            Assert.Equal(1, d8.Antennas[0].Y);
            Assert.Equal(2, d8.Rows);
            Assert.Equal(6, d8.Cols);
        }

        [Fact]
        public void GetAntiNodes_ShouldReturnCorrect()
        {
            Antenna a1 = new Antenna() { Frequency = 'A', X = 13, Y = 5 };
            Antenna a2 = new Antenna() { Frequency = 'A', X = 10, Y = 6 };

            Antenna a3 = new Antenna() { Frequency = 'A', X = 10, Y = 9 };
            Antenna a4 = new Antenna() { Frequency = 'A', X = 5, Y = 8 };

            var res = d8.GetAntiNodes(a1, a2);
            var res2 = d8.GetAntiNodes(a3, a4);

            Assert.Equal(16, res[0].X);
            Assert.Equal(4, res[0].Y);
            Assert.Equal(7, res[1].X);
            Assert.Equal(7, res[1].Y);

            Assert.Equal(15, res2[0].X);
            Assert.Equal(10, res2[0].Y);
            Assert.Equal(0, res2[1].X);
            Assert.Equal(7, res2[1].Y);
        }
        [Fact]
        public void GetUniqueAntiNodes_AcceptanceTest()
        {
            string input = "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............";

            Assert.Equal(14, d8.GetUniqueAntiNodes(input));
        }

        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input8.txt");

            Assert.Equal(369, d8.GetUniqueAntiNodes(text));
        }
        [Fact]
        public void GetResonantAntiNodes_AcceptanceTest()
        {
            string input = "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............";

            Assert.Equal(34, d8.GetUniqueAntiNodesResonant(input));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input8.txt");

            Assert.Equal(1169, d8.GetUniqueAntiNodesResonant(text));
        }
    }
}
