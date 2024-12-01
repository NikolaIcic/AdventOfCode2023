namespace Advent2023
{
    public class Day8
    {
        public int CalculateSteps(string input)
        {
            string[] strings = input.Split("\r\n\r\n");
            if (strings.Length != 2)
                throw new ArgumentOutOfRangeException();

            string directions = LoadDirections(strings[0]);
            List<D8Node> nodes = LoadNodes(strings[1]);

            int steps = 0;

            D8Node temp = nodes.Where(x => x.Name == "AAA").First();
            while (temp.Name != "ZZZ")
            {
                foreach (Char c in directions)
                {
                    if (c == 'L')
                        temp = nodes.Where(x => x.Name == temp.LeftChild).First();
                    else
                        temp = nodes.Where(x => x.Name == temp.RightChild).First();
                    steps++;
                    if (temp.Name == "ZZZ")
                        return steps;
                }
            }

            return steps;
        }
        public double CalculateForGhousts(string input)
        {
            string[] strings = input.Split("\r\n\r\n");
            if (strings.Length != 2)
                throw new ArgumentOutOfRangeException();

            string directions = LoadDirections(strings[0]);
            List<D8Node> nodes = LoadNodes(strings[1]);
            List<D8Node> startingNodes = nodes.Where(x => x.Name[2] == 'A').ToList();
            List<double> pathLengths = new List<double>();
            foreach (D8Node startNode in startingNodes)
            {
                double steps = 0;
                bool exit = false;
                D8Node temp = startNode;
                while (temp.Name[2] != 'Z')
                {
                    foreach (Char c in directions)
                    {
                        if (c == 'L')
                            temp = nodes.Where(x => x.Name == temp.LeftChild).First();
                        else
                            temp = nodes.Where(x => x.Name == temp.RightChild).First();
                        steps++;
                        if (temp.Name[2] == 'Z')
                        {
                            pathLengths.Add(steps);
                            exit = true;
                            break;
                        }
                    }
                }
                if (!exit)
                    pathLengths.Add(steps);
            };

            return LeastCommonMultiple(pathLengths);
        }
        private double LeastCommonMultiple(List<double> numbers)
        {
            static double gcd(double n1, double n2)
            {
                if (n2 == 0)
                {
                    return n1;
                }
                else
                {
                    return gcd(n2, n1 % n2);
                }
            }

            return numbers.Aggregate((S, val) => S * val / gcd(S, val));
        }
        public string LoadDirections(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            value = value.Trim(new char[] { ' ', '\n', '\r' });
            foreach (char c in value)
                if (c != 'R' && c != 'L')
                    throw new ArgumentOutOfRangeException();
            return value;
        }
        public D8Node LoadNode(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();
            value = value.Trim(new char[] { ' ', '\n', '\r' });
            char[] toReplace = { ' ', '=', '(', ')', ',' };
            foreach (char c in toReplace)
                value = value.Replace(c.ToString(), "");
            return new D8Node()
            {
                Name = value.Substring(0, 3),
                LeftChild = value.Substring(3, 3),
                RightChild = value.Substring(6, 3)
            };
        }
        public List<D8Node> LoadNodes(string value)
        {
            List<D8Node> list = new List<D8Node>();
            string[] strings = value.Split('\r');
            foreach (string s in strings)
                if (s != null && s != "" && s != "\n")
                    list.Add(LoadNode(s));
            return list;
        }
    }

    public class D8Node
    {
        public string Name { get; set; } = "";
        public string LeftChild { get; set; } = "";
        public string RightChild { get; set; } = "";
    }
}
