using Advent2024;

namespace Tests
{
    public class Day6Tests
    {
        Day6 d6 = new Day6();
        Map m = new Map();
        [Fact]
        public void Test()
        {
            Day6 e = new Day6();
            Map e2 = new Map();
        }
        [Fact]
        public void CanReadMap()
        {
            string input = "...\r\n";
            input += "..#";
            m.ReadInput(input);

            Assert.Equal(2, m.Rows);
            Assert.Equal(3, m.Cols);
            Assert.Equal('.', m.Matrix[0, 0]);
            Assert.Equal('#', m.Matrix[1, 2]);
        }
        [Fact]
        public void GetGuardMoves_CanGetSimple()
        {
            string input = "";
            input += "...\r";
            input += ".^.";

            string input2 = "";
            input2 += "...\r";
            input2 += ">..\r";
            input2 += "...";

            m.ReadInput(input);
            Assert.Equal(2, m.GetGuardMoves());
            m.ReadInput(input2);
            Assert.Equal(3, m.GetGuardMoves());
        }
        [Fact]
        public void GetGuardMoves_WithObstacles()
        {
            string input2 = "";
            input2 += "....\r";
            input2 += ">.#.\r";
            input2 += "#...\r";
            input2 += ".#..";

            m.ReadInput(input2);
            Assert.Equal(4, m.GetGuardMoves());
        }
        [Fact]
        public void GetGuardMoves_AcceptanceTest()
        {
            string input = "....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...";

            Assert.Equal(41,d6.GetGuardMoves(input));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input6.txt");

            Assert.Equal(5177, d6.GetGuardMoves(text));
        }
        [Fact]
        public void IsPathInfinite_Test()
        {
            string input2 = "";
            input2 += "##...\r";
            input2 += "^...#\r";
            input2 += "#....\r";
            input2 += "...#.";

            m.ReadInput(input2);

            Assert.True(m.IsPathInfinite());
        }
        [Fact]
        public void GetAllInfinitePath_AcceptanceTest()
        {
            string input = "....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...";
            
            Assert.Equal(6, d6.GetAllInfinitePath(input));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input6.txt");

            Assert.Equal(1686, d6.GetAllInfinitePath(text));
        }
    }
}
