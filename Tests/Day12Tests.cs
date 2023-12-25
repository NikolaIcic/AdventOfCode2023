using Advent2023;

namespace Tests
{
    public class Day12Tests
    {
        private readonly Day12 d12;
        public Day12Tests()
        {
            d12 = new Day12();
        }

        [Fact]
        public void IsValid_ShouldReturnFalse_ForEmptyOrNull()
        {
            Assert.False(d12.IsValid(""));
            Assert.False(d12.IsValid(" "));
            Assert.False(d12.IsValid("\n\r"));
        }
        [Fact]
        public void IsValid_ShouldReturnFalse_ForInvalid()
        {
            Assert.False(d12.IsValid("# 5"));
            Assert.False(d12.IsValid("#.# 1"));
            Assert.False(d12.IsValid("#.# 1,1,1"));
        }
        [Fact]
        public void IsValid_ShouldReturnTrue_ForValid()
        {
            Assert.True(d12.IsValid("# 1"));
            Assert.True(d12.IsValid("#.#.### 1,1,3"));
            Assert.True(d12.IsValid("..####...##.###. 4,2,3"));
        }
        [Fact]
        public void IsValid_ShouldReturnFalse_IfContainsQMarks()
        {
            Assert.False(d12.IsValid("? 1"));
        }
        [Fact]
        public void FA_ShouldReturn0_ForNone()
        {
            Assert.Equal(0, d12.FindArrangements(".?. 5"));
            Assert.Equal(0, d12.FindArrangements(".??. 5"));
            Assert.Equal(0, d12.FindArrangements("#.?. 3"));
            Assert.Equal(0, d12.FindArrangements(".##?#. 5"));
            Assert.Equal(0, d12.FindArrangements(".##?#. 2"));
        }
        [Fact]
        public void FA_ShouldReturn1_ForSingle()
        {
            Assert.Equal(1, d12.FindArrangements(".#. 1"));
            Assert.Equal(1, d12.FindArrangements(".?. 1"));
        }
        [Fact]
        public void FA_ShouldReturnMore_ForMultipleQMarks()
        {
            Assert.Equal(3, d12.FindArrangements("??? 1"));
        }
        [Fact]
        public void FA_ForMoreThenOneQMark_AndHigherNumber()
        {
            Assert.Equal(1, d12.FindArrangements("?? 2"));
        }
        [Fact]
        public void FA_ForMultipleNumbers()
        {
            Assert.Equal(10, d12.FindArrangements("?###???????? 3,2,1"));
        }
        [Fact]
        public void SumArrangements_AcceptanceTest()
        {
            string input = "???.### 1,1,3\r\n.??..??...?##. 1,1,3\r\n?#?#?#?#?#?#?#? 1,3,1,6\r\n????.#...#... 4,1,1\r\n????.######..#####. 1,6,5\r\n?###???????? 3,2,1";

            Assert.Equal(21,d12.SumArrangements(input));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input12.txt");

            Assert.Equal(7792, d12.SumArrangements(text));
        }
        [Fact]
        public void UnfoldRow_ShouldUnfoldIt()
        {
            string input = ".# 1";

            Assert.Equal(".#?.#?.#?.#?.# 1,1,1,1,1", d12.UnfoldRow(input));
        }
        [Fact(Skip = "long runtime")]
        public void SumArrangements_AcceptanceTest2()
        {
            string input = "???.### 1,1,3\r\n.??..??...?##. 1,1,3\r\n?#?#?#?#?#?#?#? 1,3,1,6\r\n????.#...#... 4,1,1\r\n????.######..#####. 1,6,5\r\n?###???????? 3,2,1";

            Assert.Equal(525152, d12.SumArrangements(input,true));
        }
    }
}
