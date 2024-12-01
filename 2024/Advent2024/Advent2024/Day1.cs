
namespace Advent2024
{
    public class Day1
    {
        public int GetTotalDistance(string input)
        {
            LocationLists ll = new LocationLists();
            ll.GetLists(input);
            ll.SortLists();
            return ll.GetTotalDistance();
        }

        public int GetTotalSimilarities(string input)
        {
            LocationLists ll = new LocationLists();
            ll.GetLists(input);
            return ll.SimilarityScore();
        }
    }

    public class LocationLists
    {
        public List<int> List1 { get; set; } = new List<int>();
        public List<int> List2 { get; set; } = new List<int>();

        public void GetLists(string input)
        {
            string[] rows = input.Split('\r');
            foreach (string row in rows)
            {
                string n = row.Replace("\n", "");
                string[] nums = n.Split(" ");
                List1.Add(int.Parse(nums[0]));
                List2.Add(int.Parse(nums[nums.Length - 1]));
            }
        }

        public void SortLists()
        {
            List1.Sort();
            List2.Sort();
        }

        public int GetTotalDistance()
        {
            if (List1.Count != List2.Count)
                throw new ArgumentOutOfRangeException();

            int sum = 0;
            for (int i = 0; i < List1.Count; i++)
                sum += Math.Abs(List1[i] - List2[i]);
            return sum;
        }

        public int FindSimilarity(int a, List<int> b)
        {
            int count = 0;
            foreach (int i in b)
                if (i == a)
                    count++;
            return count * a;
        }

        public int SimilarityScore()
        {
            int total = 0;
            foreach (int num in List1)
                total += FindSimilarity(num, List2);
            return total;
        }
    }
}
