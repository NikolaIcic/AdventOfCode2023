namespace Advent2023
{
    public class Day5
    {
        public List<double> Seeds { get; set; }
        public List<D5LinkMap> Maps { get; set; }

        public Day5()
        {
            Seeds = new List<double>();
            Maps = new List<D5LinkMap>();
        }

        public void LoadSeeds(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string seeds = value.Split(':')[1];
            seeds = seeds.Trim(new char[] { ' ', '\r', '\n' });
            string[] strings = seeds.Split(' ');
            foreach (string s in strings)
            {
                if (!double.TryParse(s, out double val))
                    throw new ArgumentOutOfRangeException();
                Seeds.Add(val);
            }
        }
        public void LoadData(string text, bool loadRange = false)
        {
            string[] strings = text.Split("\r\n\r\n");
            if (loadRange)
                LoadSeedsRange(strings[0]);
            else
                LoadSeeds(strings[0]);
            for (int i = 1; i < strings.Length; i++)
                if (strings[i] != "" && strings[i] != "\n")
                    Maps.Add(new D5LinkMap(strings[i]));

        }
        public void LoadSeedsRange(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string seeds = value.Split(':')[1];
            seeds = seeds.Trim(new char[] { ' ', '\r', '\n' });
            string[] strings = seeds.Split(' ');
            if (strings.Length % 2 != 0)
                throw new ArgumentOutOfRangeException();

            double baseNum = 0;
            foreach (string s in strings)
            {
                if (baseNum == 0)
                {
                    if (!double.TryParse(s, out double val))
                        throw new ArgumentOutOfRangeException();
                    baseNum = val;
                }
                else
                {
                    if (!double.TryParse(s, out double val))
                        throw new ArgumentOutOfRangeException();
                    for (double i = baseNum; i < baseNum + val; i++)
                        Seeds.Add(i);
                    baseNum = 0;
                }
            }
        }

        public double ClosestLocation(string text, bool loadRange = false)
        {
            LoadData(text, loadRange);
            List<double> Locations = Seeds;
            foreach (D5LinkMap map in Maps)
                    Parallel.For(0, Locations.Count, (i) => Locations[i] = map.ConvertCategory(Locations[i]));

                double res = Locations[0];
            for (int i = 1; i < Locations.Count; i++)
                if (Locations[i] < res)
                    res = Locations[i];
            return res;
        }
    }

    public class D5LinkMap
    {
        public string Name { get; set; }
        public List<D5Range> Ranges { get; set; }

        public D5LinkMap()
        {
            Name = "";
            Ranges = new List<D5Range>();
        }
        public D5LinkMap(string v)
        {
            Name = "";
            Ranges = new List<D5Range>();
            LoadMap(v);
        }

        public void LoadMap(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string[] strings = value.Split('\r');
            Name = strings[0];
            for (int i = 1; i < strings.Length; i++)
                if (strings[i] != "" && strings[i] != "\n")
                    Ranges.Add(new D5Range(strings[i]));
        }
        public double ConvertCategory(double x)
        {
            foreach (D5Range range in Ranges)
                if (x >= range.Source && x < (range.Source + range.Length))
                    return range.Destination + x - range.Source;
            return x;
        }
    }
    public class D5Range
    {
        public double Destination { get; set; }
        public double Source { get; set; }
        public double Length { get; set; }

        public D5Range()
        {

        }
        public D5Range(string value)
        {
            ReadValues(value);
        }

        public void ReadValues(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            value = value.Trim(new char[] { ' ', '\r', '\n' });

            List<double> numbs = new List<double>();
            string[] strings = value.Split(' ');
            if (strings.Length != 3)
                throw new ArgumentOutOfRangeException();

            foreach (string s in strings)
            {
                if (!double.TryParse(s, out double val))
                    throw new ArgumentOutOfRangeException();
                numbs.Add(val);
            }
            Destination = numbs[0];
            Source = numbs[1];
            Length = numbs[2];
        }
    }
}
