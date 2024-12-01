using Advent2023;

namespace Tests
{
    public class Day5Tests
    {
        private readonly D5Range range;
        private readonly D5LinkMap map;
        private readonly Day5 d5;
        public Day5Tests()
        {
            range = new D5Range();
            map = new D5LinkMap();
            d5 = new Day5();
        }
        [Fact]
        public void CanCreateD5RangeEntity()
        {
            D5Range entity = new D5Range();

            Assert.Equal(0, entity.Destination);
            Assert.Equal(0, entity.Source);
            Assert.Equal(0, entity.Length);
        }
        [Fact]
        public void ReadValues_ShouldThrowException_ForNullOrEmpty()
        {
            Action action = () => range.ReadValues("");
            Action action2 = () => range.ReadValues(null);

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void ReadValues_ShouldThrowException_ForInvalidString()
        {
            Action action = () => range.ReadValues("123");
            Action action2 = () => range.ReadValues("abc");
            Action action3 = () => range.ReadValues("1 2 3 4");
            Action action4 = () => range.ReadValues("1 2 b");

            Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Throws<ArgumentOutOfRangeException>(action2);
            Assert.Throws<ArgumentOutOfRangeException>(action3);
        }
        [Theory]
        [InlineData(50, 112, 2, "50 112 2")]
        [InlineData(5, 11, 222, " 5 11 222 ")]
        [InlineData(9, 9, 9, "\n9 9 9\r")]
        public void ReadValues_ShouldSetValues_ForValidString(int d, int s, int l, string v)
        {
            range.ReadValues(v);

            Assert.Equal(d, range.Destination);
            Assert.Equal(s, range.Source);
            Assert.Equal(l, range.Length);
        }
        [Fact]
        public void CanCreateLinkMapEntity()
        {
            D5LinkMap entity = new D5LinkMap();

            Assert.Equal("", entity.Name);
            Assert.Empty(entity.Ranges);
        }
        [Fact]
        public void LoadMap_ShouldThrowException_ForNullOrEmpty()
        {
            Action action = () => map.LoadMap("");
            Action action2 = () => map.LoadMap(null);

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void LoadMap_ShouldMapValues_ForCorrectString()
        {
            string name = "Some map:";
            string range1 = "111 22 3 ";
            string range2 = " 4 555 66";
            string input = name + "\r" + range1 + "\r" + range2 + "\r";

            map.LoadMap(input);

            Assert.Equal(name, map.Name);
            Assert.Equal(2,map.Ranges.Count);
            Assert.Equal(111, map.Ranges[0].Destination);
            Assert.Equal(555, map.Ranges[1].Source);
        }
        [Fact]
        public void ConvertCategory_ShouldReturnSameNumber_IfNumberNotInRanges()
        {
            int x = 700;

            string mapInput = "Map1:\r 1 1 5";

            map.LoadMap(mapInput);

            Assert.Equal(x, map.ConvertCategory(x));
        }
        [Fact]
        public void ConvertCategory_ShouldConvertNumber_IfNumberInCategory()
        {
            int x = 5;
            int y = 1;
            int z = 10;
            int u = 26;

            string mapInput = "Map1:\r 10 1 10\r";
            mapInput += "25 25 10";

            map.LoadMap(mapInput);

            Assert.Equal(14, map.ConvertCategory(x));
            Assert.Equal(10, map.ConvertCategory(y));
            Assert.Equal(19, map.ConvertCategory(z));
            Assert.Equal(26, map.ConvertCategory(u));
        }
        [Fact]
        public void CanCreateDay5Entity()
        {
            Day5 entity = new Day5();

            Assert.Empty(entity.Seeds);
            Assert.Empty(entity.Maps);
        }
        [Fact]
        public void LoadSeeds_ShouldThrowException_ForNullOrEmpty()
        {
            Action action = () => d5.LoadSeeds("");
            Action action2 = () => d5.LoadSeeds(null);

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void LoadSeeds_ShouldThrowException_ForInvalidString()
        {
            Action action = () => d5.LoadSeeds("seeds: 1 2 a 4");

            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
        [Fact]
        public void LoadSeeds_ShouldLoadNumbers()
        {
            d5.LoadSeeds("seeds: 1 2 3");

            Assert.Equal(3, d5.Seeds.Count);
            Assert.Equal(1, d5.Seeds[0]);
            Assert.Equal(3, d5.Seeds[2]);
        }
        [Fact]
        public void LoadData_ShouldLoadCorrectData()
        {
            string text = "seeds: 1 2 3 4 \r\n\r\n";
            text += "map1:\r 1 1 10 \r\n\r\n";
            text += "map2:\r 30 20 10";

            d5.LoadData(text);

            Assert.Equal(4, d5.Seeds.Count);
            Assert.Equal(2, d5.Maps.Count);
        }
        [Fact]
        public void ClosestLocation_ShouldReturnNumberLocation_ForOneNumber()
        {
            string text = "seeds: 5 \r\n\r\n";
            text += "map1:\r 10 1 10 \r\n\r\n";
            text += "map2:\r 30 10 10";

            Assert.Equal(34,d5.ClosestLocation(text));
        }
        [Fact]
        public void CloseLocation_ShouldReturnSmallestNumber_ForMultipleSeeds()
        {
            string text = "seeds: 5 2 65 \r\n\r\n";
            text += "map1:\r 10 1 10 \r\n\r\n";
            text += "map2:\r 30 10 10 \r 10 60 10";

            Assert.Equal(15, d5.ClosestLocation(text));
        }
        [Fact]
        public void ClosestLocation_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test5.txt");

            Assert.Equal(35, d5.ClosestLocation(text));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input5.txt");

            Assert.Equal(31599214, d5.ClosestLocation(text));
        }
        [Fact]
        public void LoadSeedsRange_ShouldThrowException_ForNullOrEmpty()
        {
            Action action = () => d5.LoadSeedsRange("");
            Action action2 = () => d5.LoadSeedsRange(null);

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void LoadSeedsRange_ShouldThrowException_ForInvalidString()
        {
            Action action = () => d5.LoadSeedsRange("seeds: 1 2 a 4");
            Action action2 = () => d5.LoadSeedsRange("seeds: 1 2 3");

            Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Throws<ArgumentOutOfRangeException>(action2);
        }
        [Fact]
        public void LoadSeedsRange_ShouldLoadNumbers()
        {
            d5.LoadSeedsRange("seeds: 1 5 75 4");

            Assert.Equal(9, d5.Seeds.Count);
            Assert.Equal(1, d5.Seeds[0]);
            Assert.Equal(5, d5.Seeds[4]);
            Assert.Equal(75, d5.Seeds[5]);
            Assert.Equal(78, d5.Seeds[8]);
        }
        [Fact]
        public void ClosestLocation_AcceptanceTest2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test5.txt");

            Assert.Equal(46, d5.ClosestLocation(text,true));
        }
        [Fact(Skip = "Long Run Time")]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input5.txt");

            Assert.Equal(20358599, d5.ClosestLocation(text,true));
        }
    }
}
