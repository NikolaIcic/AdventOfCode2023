using Advent2024;

namespace Tests
{
    public class Day2Tests
    {
        Report r;
        Day2 d2;
        public Day2Tests()
        {
            r = new Report();
            d2 = new Day2();
        }
        [Fact]
        public void CreateEntities()
        {
            Day2 entity = new();
            Report entityReport = new();
        }

        [Fact]
        public void Report_CanCheckIfSafe_ForSimpleValues()
        {
            r.Levels.Add(0);
            Assert.True(r.IsSafe());

            r.Levels.Clear();
            Assert.True(r.IsSafe());
        }

        [Fact]
        public void Report_NotSafe_ForNoOrder()
        {
            r.Levels = new() { 0, 0 };
            Assert.False(r.IsSafe());

            r.Levels = new() { 0, 1, 2, 1 };
            Assert.False(r.IsSafe());

            r.Levels = new() { 9, 7, 5, 6 };
            Assert.False(r.IsSafe());
        }

        [Fact]
        public void Report_NotSafe_ForBigDifferences()
        {
            r.Levels = new() { 1, 2, 3, 7 };
            Assert.False(r.IsSafe());

            r.Levels = new() { 10, 9, 5 };
            Assert.False(r.IsSafe());
        }

        [Fact]
        public void Report_Safe_ForSafeValues()
        {
            r.Levels = new() { 1, 2, 3, 4, 6, 9 };
            Assert.True(r.IsSafe());

            r.Levels = new() { 10, 7, 5, 4 };
            Assert.True(r.IsSafe());
        }

        [Fact]
        public void CanReadReportsFromInput()
        {
            string input = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";

            d2.ReadFromInput(input);

            Assert.Equal(6, d2.Reports.Count);
            Assert.Equal(7, d2.Reports[0].Levels[0]);
            Assert.Equal(1, d2.Reports[0].Levels[4]);
            Assert.Equal(1, d2.Reports[5].Levels[0]);
            Assert.Equal(9, d2.Reports[5].Levels[4]);
        }

        [Fact]
        public void GetTotalSafe_AcceptanceTest()
        {
            string input = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";

            Assert.Equal(2, d2.GetTotalSafe(input));
        }

        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Advent2024\Tests\Input2.txt");

            Assert.Equal(371, d2.GetTotalSafe(text));
        }

        [Fact]
        public void IsSafeExpanded_ReturnTrue_ForSingleBadLevel()
        {
            r.Levels = new() { 1, 2, 3, 13 };
            Assert.True(r.IsSafeExpanded());

            r.Levels = new() { 10, 15, 7, 5, 4 };
            Assert.True(r.IsSafeExpanded());

            r.Levels = new() { 20, 18, 5, 16 };
            Assert.True(r.IsSafeExpanded());
        }

        [Fact]
        public void GetTotalSafeExpanded_AcceptanceTest()
        {
            string input = "7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9";

            Assert.Equal(4, d2.GetTotalSafeExpanded(input));
        }

        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Advent2024\Tests\Input2.txt");

            Assert.Equal(426, d2.GetTotalSafeExpanded(text));
        }
    }
}