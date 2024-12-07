using Advent2024;

namespace Tests
{
    public class Day5Tests
    {
        Day5 d5;
        public Day5Tests()
        {
            d5 = new Day5();
        }

        [Fact]
        public void CanReadInput_Rules()
        {
            string input = "" +
                "75|14\r\n" +
                "53|13\r\n" +
                "\r\n" +
                "75,47,61,53,29\r\n" +
                "97,61,53,29,13";

            d5.ReadInput(input);

            Assert.Equal(2, d5.Rules.Count);
            Assert.Equal(75, d5.Rules[0].Num1);
            Assert.Equal(13, d5.Rules[1].Num2);
        }
        [Fact]
        public void CanReadInput_Updates()
        {
            string input = "" +
                "75|14\r\n" +
                "\r\n" +
                "75,47,61,53,29\r\n" +
                "97,61,53,29,13";

            d5.ReadInput(input);

            Assert.Equal(2, d5.Updates.Count);
            Assert.Equal(5, d5.Updates[0].Pages.Count);
            Assert.Equal(97, d5.Updates[1].Pages[0]);
            Assert.Equal(13, d5.Updates[1].Pages[4]);
        }
        [Fact]
        public void IsInOrder_ShouldReturnCorrect()
        {
            Update u = new Update();
            u.Pages = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<Rule> rules = new List<Rule>() {
                new Rule() { Num1 = 99, Num2 = 102},
                new Rule{ Num1 = 4, Num2 = 6 }
            };
            List<Rule> rules2 = new List<Rule>() {
                new Rule() { Num1 = 1, Num2 = 2},
                new Rule{ Num1 = 5, Num2 = 2 }
            };

            Assert.True(u.IsInOrder(rules));
            Assert.False(u.IsInOrder(rules2));

        }
        [Fact]
        public void FindMiddleNumber_ShouldReturnMiddleNumber()
        {
            Update u = new Update() { Pages = { 1, 2, 3, 7, 4, 5, 6 } };
            Update u2 = new Update() { Pages = { 1, 2, 3 } };

            Assert.Equal(7, u.FindMiddleNumber());
            Assert.Equal(2, u2.FindMiddleNumber());
        }
        [Fact]
        public void SumCorrectUpdateMiddle_AcceptanceTest()
        {
            string input = "47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29" +
                "\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53" +
                "\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61" +
                "\r\n75|61\r\n47|29\r\n75|13\r\n53|13\r\n\r\n75,47,61,53,29" +
                "\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47";

            Assert.Equal(143, d5.SumCorrectUpdateMiddle(input));
        }
        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input5.txt");

            Assert.Equal(4905, d5.SumCorrectUpdateMiddle(text));
        }
        [Fact]
        public void SumIncorrectUpdateMiddle_AcceptanceTest()
        {
            string input = "47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29" +
                "\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53" +
                "\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61" +
                "\r\n75|61\r\n47|29\r\n75|13\r\n53|13\r\n\r\n75,47,61,53,29" +
                "\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47";

            Assert.Equal(123, d5.SumIncorrectUpdateMiddle(input));
        }
        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Tests\Input5.txt");

            Assert.Equal(6204, d5.SumIncorrectUpdateMiddle(text));
        }
    }
}
