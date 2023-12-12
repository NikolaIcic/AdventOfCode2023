using Advent2023;

namespace Tests
{
    public class Day8Tests
    {
        private readonly Day8 d8;
        public Day8Tests()
        {
            d8 = new Day8();
        }

        [Fact]
        public void LoadDirections_ThrowsException_ForNullOrEMpty()
        {
            Action action = () => d8.LoadDirections(null);
            Action action2 = () => d8.LoadDirections("");

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void LoadDirections_ShouldLoadCorrect_ForOneDirection()
        {
            Assert.Equal("L", d8.LoadDirections("L"));
            Assert.Equal("LR", d8.LoadDirections("LR"));
            Assert.Equal("LR", d8.LoadDirections("LR "));
            Assert.Equal("L", d8.LoadDirections(" L\n"));
        }
        [Fact]
        public void LoadDirections_ShouldThrowException_ForInvalidInput()
        {
            Action action = () => d8.LoadDirections("ABC");
            Action action2 = () => d8.LoadDirections("L1");

            Assert.Throws<ArgumentOutOfRangeException>(action);
            Assert.Throws<ArgumentOutOfRangeException>(action2);
        }
        [Fact]
        public void LoadNode_ShouldThrowException_ForEmptyOrNull()
        {
            Action action = () => d8.LoadNode(null);
            Action action2 = () => d8.LoadNode("");

            Assert.Throws<ArgumentNullException>(action);
            Assert.Throws<ArgumentNullException>(action2);
        }
        [Fact]
        public void CanCreateNodeEntity()
        {
            D8Node entity = new D8Node();
            Assert.Equal("", entity.Name);
            Assert.Equal("", entity.LeftChild);
            Assert.Equal("", entity.RightChild);
        }
        [Fact]
        public void LoadNode_ShouldLoadNode()
        {
            D8Node res = d8.LoadNode("AAA = (BBB,CCC)");

            Assert.Equal("AAA", res.Name);
            Assert.Equal("BBB", res.LeftChild);
            Assert.Equal("CCC", res.RightChild);
        }
        [Fact]
        public void LoadNodes_ShouldLoadMultipleNodes()
        {
            string input = "AAA = (BBB,CCC)\r";
            input += "ZZZ = (DDD,EEE)";

            var res = d8.LoadNodes(input);
            Assert.Equal(2, res.Count);
            Assert.Equal("AAA", res[0].Name);
            Assert.Equal("ZZZ", res[1].Name);
        }
        [Fact]
        public void CalculateSteps_ThrowsException_ForInvalid()
        {
            Action action = () =>  d8.CalculateSteps("LR \r AAA ");
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
        [Fact]
        public void CalculateSteps_ShouldReturnOne_ForTwoValidNodes()
        {
            string input = "L\r\n\r\n";
            input += "AAA = (ZZZ,CCC)\r";
            input += "ZZZ = (ZZZ,ZZZ)";

            Assert.Equal(1, d8.CalculateSteps(input));
        }
        [Fact]
        public void CalculateSteps_ShouldReturnCorrect_ForComplex()
        {
            string input = "LR\r\n\r\n";
            input += "AAA = (BBB,ZZZ)\r";
            input += "BBB = (CCC,CCC)\r";
            input += "CCC = (AAA,CCC)\r";
            input += "ZZZ = (ZZZ,ZZZ)";

            Assert.Equal(4, d8.CalculateSteps(input));
        }
        [Fact]
        public void CalculateSteps_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test8.txt");

            Assert.Equal(6, d8.CalculateSteps(text));
        }
        [Fact]
        public void Advent_Test()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input8.txt");

            Assert.Equal(19241, d8.CalculateSteps(text));
        }
        [Fact]
        public void CalculateForGhousts_AcceptanceTest()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Test8.2.txt");

            Assert.Equal(6, d8.CalculateForGhousts(text));
        }
        [Fact]
        public void Advent_Test2()
        {
            string text = File.ReadAllText(@"D:\\Projects\\Training\\AdventOfCode\\2023\\Advent2023\\Tests\\Puzzles\\Input8.txt");

            Assert.Equal(9606140307013, d8.CalculateForGhousts(text));
        }
    }
}
