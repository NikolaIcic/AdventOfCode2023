using Advent2024;

namespace Tests
{
    public class Day1Tests
    {
        private Day1 d1;
        public Day1Tests()
        {
            d1 = new();
        }
        [Fact]
        public void CreateEntity()
        {
            Day1 entity = new();
        }

        [Fact]
        public void CanReadListsFromInput()
        {
            string input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";

            LocationLists ll = new LocationLists();

            ll.GetLists(input);

            Assert.Equal(3, ll.List1[0]);
            Assert.Equal(4, ll.List2[0]);
            Assert.Equal(2, ll.List1[2]);
            Assert.Equal(5, ll.List2[2]);
        }

        [Fact]
        public void SortList_SortsListAssending()
        {
            LocationLists l = new LocationLists();
            l.List1.Add(0);
            l.List1.Add(3);
            l.List1.Add(7);
            l.List1.Add(2);

            l.SortLists();

            Assert.Equal(0, l.List1[0]);
            Assert.Equal(7, l.List1[3]);
        }

        [Fact]
        public void GetTotalDistance_ShouldReturnCorrect()
        {
            LocationLists ll = new LocationLists();
            string input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";

            ll.GetLists(input);
            ll.SortLists();

            Assert.Equal(11, ll.GetTotalDistance());
        }

        [Fact]
        public void Part1_AcceptanceTest()
        {
            string input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";

            Assert.Equal(11, d1.GetTotalDistance(input));
        }

        [Fact]
        public void Part1()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Advent2024\Tests\Input1.txt");

            Assert.Equal(1197984, d1.GetTotalDistance(text));
        }

        [Fact]
        public void CanCheckSimilarity()
        {
            LocationLists ll = new LocationLists();
            int a = 5;
            List<int> b = new List<int>() { 0, 1, 5, 5, 3, 5, 4 };
            List<int> c = new List<int>() { 0, 0, 1, 2, 3 };
            List<int> d = new List<int>() { 5 };


            Assert.Equal(15, ll.FindSimilarity(a, b));
            Assert.Equal(0, ll.FindSimilarity(a, c));
            Assert.Equal(5, ll.FindSimilarity(a, d));
        }

        [Fact]
        public void SimilarityScore_ShouldReturnCorrect()
        {
            LocationLists ll = new LocationLists();

            ll.List1 = new List<int>() { 1, 2, 3 };
            ll.List2 = new List<int>() { 1,1,2,2,2,3,4,5,2,2 };

            Assert.Equal(15, ll.SimilarityScore());
        }

        [Fact]
        public void Part2_AcceptanceTest()
        {
            string input = "3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3";

            Assert.Equal(31, d1.GetTotalSimilarities(input));
        }

        [Fact]
        public void Part2()
        {
            string text = File.ReadAllText(@"D:\Projects\AoC\2024\Advent2024\Tests\Input1.txt");

            Assert.Equal(23387399, d1.GetTotalSimilarities(text));
        }
    }
}