using Advent2023;

namespace Tests
{
    public class Day10Tests
    {
        private readonly Day10 d10;
        public Day10Tests()
        {
            d10 = new Day10();
        }
        [Fact]
        public void CanCreateNodeEntity()
        {
            D10Node entity = new D10Node();
            Assert.Equal(0, entity.X);
            Assert.Equal(0, entity.Y);
        }
        [Fact]
        public void LoadData_ShouldFindStart_ForCorrect()
        {
            string input = "..S7..\r";
            input += "..LJ..";

            d10.LoadData(input);

            Assert.Equal('S', d10.Nodes[2].Symbol);
            Assert.Equal(12, d10.Nodes.Count);
            Assert.Equal(0, d10.StartingNode.Y);
            Assert.Equal(2, d10.StartingNode.X);
        }
        [Fact]
        public void LoopLength_ShouldReturnZero_IfNotLoop()
        {
            string input = "..S7..\r";
            input += "..LJ..";

            d10.LoadData(input);

            Assert.Equal(0, d10.LoopLength(1, 0, d10.StartingNode.X, d10.StartingNode.Y, new List<D10Node>()));
        }
        [Fact]
        public void LoopLength_ShouldReturnCorrect_IfIsLoop()
        {
            string input = "";
            input += "..S7..\r";
            input += "..LJ..";

            d10.LoadData(input);

            Assert.Equal(4, d10.LoopLength(3, 0, d10.StartingNode.X, d10.StartingNode.Y, new List<D10Node>()));
        }
        [Fact]
        public void LoopLength_ShouldReturnCorrect_ForBiggerLoop()
        {
            string input = ".....\r";
            input += ".S-7.\r";
            input += ".|.|.\r";
            input += ".L-J.\r";
            input += ".....\r";

            d10.LoadData(input);

            Assert.Equal(8, d10.LoopLength(2, 1, d10.StartingNode.X, d10.StartingNode.Y, new List<D10Node>()));
        }
        [Fact]
        public void FindFarthestDistance_ShouldReturnCorrect_ForSimple()
        {
            string input = ".....\r";
            input += ".S-7.\r";
            input += ".|.|.\r";
            input += ".L-J.\r";
            input += ".....\r";

            Assert.Equal(4, d10.FindFarthestDistance(input));
        }
        [Fact]
        public void FindFarthest_AcceptanceTest()
        {
            string input = "..F7.\r\n.FJ|.\r\nSJ.L7\r\n|F--J\r\nLJ...";

            Assert.Equal(8, d10.FindFarthestDistance(input));
        }
        [Fact(Skip = "Failed")]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input10.txt");

            Assert.Equal(0, d10.FindFarthestDistance(text));
        }
    }
}
