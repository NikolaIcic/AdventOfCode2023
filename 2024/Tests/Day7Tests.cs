using Advent2024;

namespace Tests
{
    public class Day7Tests
    {
        Day7 d7 = new Day7();
        Equasion eq = new Equasion();

        [Fact]
        public void Test()
        {
            Day6 e = new Day6();
        }
        [Fact]
        public void CanReadInput()
        {
            string input = "190: 10 19\r\n3267: 81 40 27";

            d7.ReadInput(input);

            Assert.Equal(190, d7.Equasions[0].Result);
            Assert.Equal(3267, d7.Equasions[1].Result);
            Assert.Equal(10, d7.Equasions[0].Numbers[0]);
            Assert.Equal(27, d7.Equasions[1].Numbers[2]);
            Assert.Equal(3, d7.MaxLength);
        }
        [Fact]
        public void IsEquasionPossible()
        {
            Equasion e = new Equasion()
            {
                Result = 190,
                Numbers = new List<int> { 10, 19 }
            };
            Equasion e2 = new Equasion()
            {
                Result = 3267,
                Numbers = new List<int> { 81,40,27 }
            };
            Equasion e3 = new Equasion()
            {
                Result = 7290,
                Numbers = new List<int> { 6,8,6,15 }
            };
            Equasion e4 = new Equasion()
            {
                Result = 292,
                Numbers = new List<int> { 11,6,16,20 }
            };

            var operations = PermutationGenerator.GeneratePermutations(3, new List<char> {'+','*'});

            Assert.True(e.IsPossible(operations));
            Assert.True(e2.IsPossible(operations));
            Assert.False(e3.IsPossible(operations));
            Assert.True(e4.IsPossible(operations));
        }
        [Fact]
        public void TestPermutationGenerator()
        {
            var res = PermutationGenerator.GeneratePermutations(10, new List<char> { '+', '*' });

            Assert.Equal(2046, res.Count);
        }
        [Fact]
        public void TotalCalibration_AcceptanceTest()
        {
            string input = "190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20";

            Assert.Equal(3749, d7.TotalCalibration(input));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input7.txt");

            Assert.Equal(1582598718861, d7.TotalCalibration(text));
        }
        [Fact]
        public void TotalCalibrationExtended_AcceptanceTest()
        {
            string input = "190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20";

            Assert.Equal(11387, d7.TotalCalibrationExtended(input));
        }
        [Fact(Skip = "Medium excecution time + Paralellisation")]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input7.txt");

            Assert.Equal(165278151522644, d7.TotalCalibrationExtended(text));
        }
    }
}
