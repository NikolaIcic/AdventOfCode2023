using Advent2024;

namespace Tests
{
    public class Day4Tests
    {
        Day4 d4;

        public Day4Tests()
        {
            d4 = new Day4();
        }

        [Fact]
        public void CanFindXMAS_Horizontal()
        {
            string t1 = "XMAS";
            string t2 = "....XMAS..";
            string t3 = "..SAMX";
            string t4 = "..XMAS..SAMX";


            Assert.Equal(1, d4.GetAllXMASInstances(t1));
            Assert.Equal(1, d4.GetAllXMASInstances(t2));
            Assert.Equal(1, d4.GetAllXMASInstances(t3));
            Assert.Equal(2, d4.GetAllXMASInstances(t4));
        }

        [Fact]
        public void CanFindXMAS_Vertical()
        {
            string t1 = "X\r\nM\r\nA\r\nS";
            string t2 = "S\r\nA\r\nM\r\nX";
            string t3 = "";
            t3 += ".XS.\r";
            t3 += ".MA.\r";
            t3 += ".AM.\r";
            t3 += ".SX.";
            string t4 = ".\r.\rS\r\nA\r\nM\r\nX.\r.\r";

            Assert.Equal(1, d4.GetAllXMASInstances(t1));
            Assert.Equal(1, d4.GetAllXMASInstances(t2));
            Assert.Equal(2, d4.GetAllXMASInstances(t3));
            Assert.Equal(1, d4.GetAllXMASInstances(t4));
        }

        [Fact]
        public void CanFindXMAS_Diagonal()
        {
            string t1 = "";
            t1 += "......\r";
            t1 += "X.....\r";
            t1 += ".M.S..\r";
            t1 += "..A...\r";
            t1 += ".M.S..\r";
            t1 += "X.....";

            string t2 = "";
            t2 += "...S\r";
            t2 += "..A.\r";
            t2 += ".M..\r";
            t2 += "X...";

            string t3 = "";
            t3 += "....\r";
            t3 += "...X\r";
            t3 += "..M.\r";
            t3 += ".A..\r";
            t3 += "S...\r";
            t3 += "....";

            string t4 = "";
            t4 += "....\r";
            t4 += "S..X\r";
            t4 += ".AM.\r";
            t4 += ".MM.\r";
            t4 += "M..X\r";
            t4 += "....";

            string t5 = "";
            t5 += "....\r";
            t5 += "X..X\r";
            t5 += ".MM.\r";
            t5 += ".MA.\r";
            t5 += "M..S\r";
            t5 += "....";


            Assert.Equal(2, d4.GetAllXMASInstances(t1));
            Assert.Equal(1, d4.GetAllXMASInstances(t2));
            Assert.Equal(1, d4.GetAllXMASInstances(t3));
            Assert.Equal(1, d4.GetAllXMASInstances(t4));
            Assert.Equal(1, d4.GetAllXMASInstances(t5));
        }

        [Fact]
        public void GetAllXMAS_AcceptanceTest()
        {
            string input = "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";

            Assert.Equal(18,d4.GetAllXMASInstances(input));
        }

        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input4.txt");

            Assert.Equal(2543, d4.GetAllXMASInstances(text));
        }

        [Fact]
        public void GetAll_X_Mas_AcceptanceTest()
        {
            string input = "MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX";

            Assert.Equal(9, d4.GetAll_X_MAsInstances(input));
        }

        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input4.txt");

            Assert.Equal(1930, d4.GetAll_X_MAsInstances(text));
        }
    }
}
