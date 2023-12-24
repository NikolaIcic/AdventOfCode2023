using Advent2023;

namespace Tests
{
    public class Day11Tests
    {
        private readonly Day11 d11;
        public Day11Tests()
        {
            d11 = new Day11();
        }
        [Fact]
        public void CanCreateGalaxyEntity()
        {
            D11Galaxy entity = new D11Galaxy(5,6);

            Assert.Equal(5, entity.X);
            Assert.Equal(6, entity.Y);
        }
        [Fact]
        public void GetDistance_ShouldReturnCorrect()
        {
            D11Galaxy g1 = new D11Galaxy(3, 3);
            D11Galaxy g2 = new D11Galaxy(7, 5);
            D11Galaxy g3 = new D11Galaxy(0, 0);

            Assert.Equal(6, d11.GetDistance(g1,g2));
            Assert.Equal(6, d11.GetDistance(g1,g3));
            Assert.Equal(12, d11.GetDistance(g2,g3));
        }
        [Fact]
        public void LoadData_ShouldThrowException_ForEmptyOrNull()
        {
            Action action = () => d11.LoadData("");
            Action action2 = () => d11.LoadData(null);

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void LoadData_CanLoadRow()
        {
            d11.LoadData("...");

            Assert.Single(d11.Map);
        }
        [Fact]
        public void LoadData_CanLoadMultipleRows()
        {
            d11.LoadData("...\r...\r..#\r");

            Assert.Equal(3, d11.Map.Count);
        }
        [Fact]
        public void ExpandMap_ShouldAddRow()
        {
            d11.LoadData("...\r.#.");
            d11.ExpandMap();

            Assert.Equal(3, d11.Map.Count);
            Assert.Equal("..#..", d11.Map[2]);
        }
        [Fact]
        public void ExpandMap_ShouldAddColumn()
        {
            string map = "";
            map += "....\r";
            map += "..#.\r";
            map += "....\r";

            d11.LoadData(map);
            d11.ExpandMap();

            Assert.Equal(5, d11.Map.Count);
            Assert.Equal("....#..", d11.Map[2]);
        }
        [Fact]
        public void SumGalaxyDistances_ShouldReturnCorrect_ForOnePair()
        {
            string map = "..#..#..";

            Assert.Equal(5, d11.SumGalaxyDistances(map));
        }
        [Fact]
        public void SumGalaxyDistances_ShouldReturnCorrect_ForComplex()
        {
            string map = "";
            map += "....\r";
            map += "..#.\r";
            map += "....\r";
            map += "....\r";
            map += "#...\r";

            Assert.Equal(8,d11.SumGalaxyDistances(map));
        }
        [Fact]
        public void SumGalaxyDistances_AcceptanceTest()
        {
            string input = "...#......\r\n" +
                ".......#..\r\n" +
                "#.........\r\n" +
                "..........\r\n" +
                "......#...\r\n" +
                ".#........\r\n" +
                ".........#\r\n" +
                "..........\r\n" +
                ".......#..\r\n" +
                "#...#.....";

            Assert.Equal(374,d11.SumGalaxyDistances(input));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input11.txt");

            Assert.Equal(9536038, d11.SumGalaxyDistances(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input11.txt");

            Assert.Equal(9539358, d11.SumGalaxyDistances(text));
        }
    }
}
