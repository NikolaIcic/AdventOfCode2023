using Advent2023;

namespace Tests
{
    public class Day9Tests
    {
        private readonly Day9 d9;
        private readonly D9Row row;
        public Day9Tests()
        {
            d9 = new Day9();
            row = new D9Row();
        }
        [Fact]
        public void CanCreateRowEntity()
        {
            D9Row entity = new D9Row();

            Assert.Empty(entity.Numbers);
        }
        [Fact]
        public void LoadNumbers_ThrowsErrorForEmpty()
        {
            Action action = () => row.LoadNumbers("");

            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]
        public void LoadNumbers_ShouldLoadCorrect()
        {
            row.LoadNumbers("\n1 2 3 ");

            Assert.Equal(3, row.Numbers.Count);
            Assert.Equal(1, row.Numbers[0]);
            Assert.Equal(3, row.Numbers[2]);
        }
        [Fact]
        public void FindNextNumber_ShouldReturnCorrect()
        {
            row.LoadNumbers("1 2 3 ");

            Assert.Equal(4, row.FindNextNumber());
        }
        [Theory]
        [InlineData(28, "1 3 6 10 15 21")]
        [InlineData(68, "10 13 16 21 30 45")]
        [InlineData(-31, "-5 -10 -16 -23")]
        [InlineData(-7, "14 13 12 11 10 9 8 7 6 5 4 3 2 1 0 -1 -2 -3 -4 -5 -6")]
        public void FindNextNumber_ReturnsCorrectForComplex(int res, string input)
        {
            row.LoadNumbers(input);

            Assert.Equal(res, row.FindNextNumber());
        }

        [Fact]
        public void FindSum_AcceptanceTest()
        {
            string input = "0 3 6 9 12 15\r";
            input += "1 3 6 10 15 21\r";
            input += "10 13 16 21 30 45";

            Assert.Equal(114, d9.FindSum(input));
        }

        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input9.txt");

            Assert.Equal(1904165718, d9.FindSum(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input9.txt");

            Assert.Equal(964, d9.FindSum(text, true));
        }
    }
}
