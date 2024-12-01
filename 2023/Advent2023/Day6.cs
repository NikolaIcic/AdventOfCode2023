using System.Collections;

namespace Advent2023
{
    public class Day6
    {
        public List<D6Race> Races { get; set; }

        public Day6()
        {
            Races = new List<D6Race>();
        }

        public void LoadRaces(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string time = value.Split('\r')[0];
            string distance = value.Split('\r')[1];
            time = time.Split(':')[1].Trim(new char[] { ' ', '\n', '\r' });
            distance = distance.Split(':')[1].Trim(new char[] { ' ', '\n', '\r' });
            string[] times = time.Split(' ');
            string[] distances = distance.Split(' ');

            if (times.Length != distances.Length)
                throw new ArgumentOutOfRangeException();

            for (int i = 0; i < times.Length; i++)
                Races.Add(new D6Race(int.Parse(times[i]), int.Parse(distances[i])));
        }
        public void LoadSingleRace(string value)
        {
            if (value == null || value == "")
                throw new ArgumentNullException();

            string time = value.Split('\r')[0];
            string distance = value.Split('\r')[1];
            time = time.Split(':')[1].Trim(new char[] { ' ', '\n', '\r' });
            distance = distance.Split(':')[1].Trim(new char[] { ' ', '\n', '\r' });
            time = time.Replace(" ","");
            distance = distance.Replace(" ", "");
            Races.Add(new D6Race(double.Parse(time), double.Parse(distance)));
        }
        public double MulWays(string input, bool kerning = false)
        {
            if (kerning)
                LoadSingleRace(input);
            else
                LoadRaces(input);
            double res = 1;
            foreach (D6Race race in Races)
                res *= race.WaysToWin();
            return res;
        }
    }

    public class D6Race
    {
        public double Time { get; set; }
        public double Distance { get; set; }

        public D6Race(double time, double distance)
        {
            Time = time;
            Distance = distance;
        }

        public double WaysToWin()
        {
            double min = MinPressTime();
            double max = Time - min;
            return max - min + 1;
        }
        public double MinPressTime()
        {
            for (double i = 0; i < Time; i++)
                if (i * (Time - i) > Distance)
                    return i;

            return 0;
        }
    }
}
