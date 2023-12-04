using Advent2023;

namespace Tests
{
    public class Day2Tests
    {
        private readonly Day2 d2;
        public Day2Tests()
        {
            d2 = new Day2();
        }

        [Fact]
        public void IsPossible_ShouldReturnFalse_ForNull()
        {
            Assert.False(d2.IsPossible(null));
        }
        [Fact]
        public void IsPossible_ShouldReturnFalse_ForEmptyString()
        {
            Assert.False(d2.IsPossible(""));
        }
        [Fact]
        public void IsPossible_ShouldReturnTrue_ForGivenInput()
        {
            Assert.True(d2.IsPossible("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"));
        }
        [Fact]
        public void IsPossible_ShouldReturnFalse_ForGivenInput()
        {
            Assert.False(d2.IsPossible("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"));
        }
        [Theory]
        [InlineData("Game 99: 99 blue")]
        [InlineData("Game 99: 99 green")]
        [InlineData("Game 99: 99 red")]
        public void IsPossible_ShouldReturnFalse_ForHigherColorCount(string value)
        {
            Assert.False(d2.IsPossible(value));
        }
        [Fact]
        public void GetGameID_ShouldReturnZero_ForEmptyOrNull()
        {
            Assert.Equal(0, d2.GetGameID(null));
            Assert.Equal(0, d2.GetGameID(""));
        }
        [Fact]
        public void GetGameID_ShouldReturnID_ForValidGameString()
        {
            Assert.Equal(42, d2.GetGameID("Game 42: zzzz"));
        }
        [Fact]
        public void GetIndexSum_ShouldReturnIndexSum_OfPossibleGames()
        {
            string val = "Game 5: 99 blue\r";
            val += "Game 15: 1 blue\r";
            val += "Game 45: 1 blue\r";

            Assert.Equal(60,d2.GetIndexSum(val));
        }
        [Theory]
        [InlineData(true, "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
        [InlineData(true, "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
        [InlineData(false, "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
        [InlineData(false, "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red")]
        [InlineData(true, "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
        public void IsPossible_AcceptanceTests(bool res, string value)
        {
            Assert.Equal(res, d2.IsPossible(value));
        }
        [Fact]
        public void GetIndexSum_AcceptanceTest()
        {
            string val = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r";
            val += "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r";
            val += "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\r";
            val += "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\r";
            val += "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green\r";
            Assert.Equal(8, d2.GetIndexSum(val));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input2.txt");

            Assert.Equal(2528,d2.GetIndexSum(text));
        }
        [Fact]
        public void CubePower_ShouldReturnZero_ForNullOrEmpty()
        {
            Assert.Equal(0, d2.GetPowerSum(""));
            Assert.Equal(0, d2.GetPowerSum(null));
        }
        [Fact]
        public void CubePower_ShouldReturnRespectiveValues_ForOneDraw()
        {
            Assert.Equal(12, d2.GetPowerSum("Game 1: 3 blue, 4 red"));
        }
        [Fact]
        public void CubePower_ShouldReturnMaxPower_ForMultipleDraws()
        {
            Assert.Equal(630, d2.GetPowerSum("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"));
        }
        [Fact]
        public void GetPowerSum_ShouldReturnSum_OfTwoGamePowers()
        {
            string val = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\r";
            val += "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\r";

            Assert.Equal(60,d2.GetPowerSum(val));
        }
        [Fact]
        public void GetPowerSum_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test2.txt");

            Assert.Equal(2286, d2.GetPowerSum(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input2.txt");

            Assert.Equal(67363, d2.GetPowerSum(text));
        }
    }
}
