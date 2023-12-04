using Advent2023;

namespace Tests
{
    public class Day3Tests
    {
        private const int DIGIT_X = 3;
        private const int DIGIT_Y = 2;

        private readonly Day3 d3;
        private readonly D3Digit digit;
        private readonly D3Number number;
        public Day3Tests()
        {
            d3 = new Day3();
            digit = new D3Digit(DIGIT_X,DIGIT_Y,0);
            number = new D3Number();
        }

        [Fact]
        public void CanCreateDigitEntity()
        {
            int x = 5;
            int y = 6;
            int val = 9;
            D3Digit dp = new D3Digit(x, y, val);

            Assert.Equal(x, dp.X);
            Assert.Equal(y, dp.Y);
            Assert.Equal(val, dp.Value);
        }
        [Fact]
        public void CanCreateNumberEntity()
        {
            D3Number num = new D3Number();

            Assert.Empty(num.Digits);
        }
        [Fact]
        public void CanCreateSymbolEntity()
        {
            int x = 5; int y = 3;

            D3Symbol symbol = new D3Symbol(x, y);

            Assert.Equal(x, symbol.X);
            Assert.Equal(y, symbol.Y);
        }
        [Fact]
        public void MapNumbers_ShouldReturnEmpty_ForNullOrEmptyString()
        {
            Assert.Empty(d3.MapNumbers(""));
            Assert.Empty(d3.MapNumbers(null));
        }
        [Fact]
        public void MapNumbers_ShouldReturnCorrectNumber_ForStringWithOneNumber()
        {
            string val = ".123.";

            var res = d3.MapNumbers(val);

            Assert.Single(res);
            Assert.Equal(1, res[0].Digits[0].Value);
            Assert.Equal(2, res[0].Digits[1].Value);
            Assert.Equal(3, res[0].Digits[2].Value);
        }
        [Fact]
        public void MapNumbers_ShouldReturnCorrect_ForTwoNumbers()
        {
            string val = ".51..7.";

            var res = d3.MapNumbers(val);

            Assert.Equal(2, res.Count);
            Assert.Equal(5, res[0].Digits[0].Value);
            Assert.Equal(1, res[0].Digits[1].Value);
            Assert.Equal(7, res[1].Digits[0].Value);
        }
        [Fact]
        public void MapNumbers_ShouldReturnCorrectCordinates_ForTwoRows()
        {
            string val = "..5...\n";
            val += "...7..";

            var res = d3.MapNumbers(val);

            Assert.Equal(2, res.Count);
            Assert.Equal(2, res[0].Digits[0].X);
            Assert.Equal(0, res[0].Digits[0].Y);
            Assert.Equal(3, res[1].Digits[0].X);
            Assert.Equal(1, res[1].Digits[0].Y);
        }
        [Fact]
        public void MapNumbers_ShouldAddLastNumber()
        {
            string val = ".7....52";

            var res = d3.MapNumbers(val);

            Assert.Equal(2, res.Count);
        }
        [Fact]
        public void MapSymbols_ShouldReturnEmpty_ForEmptyOrNull()
        {
            Assert.Empty(d3.MapSymbols(null));
            Assert.Empty(d3.MapSymbols(""));
            Assert.Empty(d3.MapSymbols("...."));
        }
        [Fact]
        public void MapSymbols_ShouldReturnSingle_ForOneSymbol()
        {
            Assert.Single(d3.MapSymbols("..#.."));
        }
        [Fact]
        public void MapSymbols_ShouldReturnCorrect_ForMultipleRows()
        {
            string val = "...#...\n";
            val += "..+..$..";

            var res = d3.MapSymbols(val);
            Assert.Equal(3, res.Count);
            Assert.Equal(3, res[0].X);
            Assert.Equal(0, res[0].Y);
            Assert.Equal(2, res[1].X);
            Assert.Equal(1, res[1].Y);
            Assert.Equal(5, res[2].X);
            Assert.Equal(1, res[2].Y);
        }
        [Fact]
        public void IsAdjacentToSymbol_ShouldReturnFalse_ForEmptyList()
        {
            Assert.False(digit.IsAdjacentToSymbol(null));
            Assert.False(digit.IsAdjacentToSymbol(new()));
        }
        [Theory]
        [InlineData(2,2)]
        [InlineData(4,2)]
        [InlineData(2,1)]
        [InlineData(3,1)]
        [InlineData(4,1)]
        [InlineData(2,3)]
        [InlineData(3,3)]
        [InlineData(4,3)]
        public void IsAdjacentToSymbol_ShouldReturnTrue_ForAdjacentSymbol(int x,int y)
        {
            // X = 3, Y = 2
            D3Symbol s = new D3Symbol(x, y);

            Assert.True(digit.IsAdjacentToSymbol(new() { s }));
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(9, 9)]
        [InlineData(-1, -1)]
        public void IsAdjacentToSymbol_ShouldReturnFalse_ForANodjacentSymbol(int x, int y)
        {
            D3Symbol s = new D3Symbol(x, y);

            Assert.False(digit.IsAdjacentToSymbol(new() { s }));
        }
        [Fact]
        public void IsPartNumber_ShouldReturnFalse_ForEmptySymbolList()
        {
            Assert.False(number.IsPartNumber(null));
            Assert.False(number.IsPartNumber(new()));
        }
        [Fact]
        public void IsPartNumber_ShouldReturnTrue_IfNumberHasAdjacent()
        {
            number.Digits.Add(new D3Digit(DIGIT_X,DIGIT_Y,0));
            List<D3Symbol> symbols = new List<D3Symbol>()
            {
                new D3Symbol(DIGIT_X + 1,DIGIT_Y)
            };

            Assert.True(number.IsPartNumber(symbols));
        }
        [Fact]
        public void GetValue_ShouldReturnZero_ForNoDigits()
        {
            Assert.Equal(0, number.GetValue());
        }
        [Fact]
        public void GetValue_ShouldReturnCorrectValue()
        {
            int a = 5;int b = 6;
            number.Digits.Add(new D3Digit(DIGIT_X, DIGIT_Y, a));
            number.Digits.Add(new D3Digit(DIGIT_X + 1, DIGIT_Y, b));

            Assert.Equal(a*10+b, number.GetValue());
        }
        [Fact]
        public void SumPartNumbers_ShouldReturnZero_ForEmptyList()
        {
            Assert.Equal(0, d3.SumPartNumbers(""));
            Assert.Equal(0, d3.SumPartNumbers(null));
        }
        [Fact]
        public void SumPartNumbers_ShouldReturnCorrect_ForOneNumber()
        {
            string input = "..45#..";

            Assert.Equal(45, d3.SumPartNumbers(input));
        }
        [Fact]
        public void SumPartNumbers_ShouldReturnCorrect_ForMultipleRows()
        {
            string input = "..#..\n";
            input += ".2...\n";
            input += "..40#";

            Assert.Equal(42, d3.SumPartNumbers(input));
        }
        [Fact]
        public void SumPartNumbers_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test3.txt");

            Assert.Equal(4361, d3.SumPartNumbers(text));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input3.txt");

            Assert.Equal(539433, d3.SumPartNumbers(text));
        }
        [Fact]
        public void GetSpecialChars_ShouldReturnSpecialCharactersUsed()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input3.txt");

            Assert.Equal("= * + / & # - % $ @ ", d3.GetSpecialChars(text));
        }
        [Fact]
        public void GetGearValue_ShouldReturnZero_ForOneAdjacentNumber()
        {
            string input = "...*11..";

            Assert.Equal(0, d3.SumGears(input));
        }
        [Fact]
        public void GetGearValue_ShouldReturnCorrect_ForTwoAdjacentNumbers()
        {
            string input = "..11*11..";

            Assert.Equal(121,d3.SumGears(input));
        }
        [Fact]
        public void GetGearValue_ShouldReturnZero_ForMoreThenTwoAdjacentNumbers()
        {
            string input = "";
            input += "..12..\n";
            input += "15*5..";

            Assert.Equal(0, d3.SumGears(input));
        }
        [Fact]
        public void SumGears_ShouldReturnZero_ForEmpty()
        {
            Assert.Equal(0, d3.SumGears(""));
            Assert.Equal(0, d3.SumGears(null));
        }
        [Fact]
        public void SumGears_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test3.txt");

            Assert.Equal(467835, d3.SumGears(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input3.txt");

            Assert.Equal(75847567, d3.SumGears(text));
        }
    }
}
