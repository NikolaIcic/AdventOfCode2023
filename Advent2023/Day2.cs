namespace Advent2023
{
    public class Day2
    {
        private const int RED_CUBES = 12;
        private const int GREEN_CUBES = 13;
        private const int BLUE_CUBES = 14;

        public int GetIndexSum(string value)
        {
            int sum = 0;
            string[] row = value.Split('\r');
            for (int i = 0; i < row.Length; i++)
                if (IsPossible(row[i]))
                    sum += GetGameID(row[i]);
            return sum;
        }
        public int GetPowerSum(string value)
        {
            if (value == null || value == "")
                return 0;

            int sum = 0;
            string[] row = value.Split('\r');
            for (int i = 0; i < row.Length; i++)
                sum += CubePower(row[i]);
            return sum;
        }
        public int GetGameID(string value)
        {
            if (value == null || value == "") return 0;

            string gameName = value.Split(": ")[0];
            string gameNumber = gameName.Substring(5);
            return int.Parse(gameNumber);
        }
        public bool IsPossible(string value)
        {
            if (value == null || value == "") return false;

            string data = value.Split(": ")[1];
            string[] draws = data.Split("; ");
            for (int i = 0; i < draws.Length; i++)
            {
                string[] cubes = draws[i].Split(", ");
                for (int j = 0; j < cubes.Length; j++)
                {
                    string[] strings = cubes[j].Split(" ");
                    int count = int.Parse(strings[0]);
                    if (strings[1] == "red" && count > RED_CUBES)
                        return false;
                    if (strings[1] == "green" && count > GREEN_CUBES)
                        return false;
                    if (strings[1] == "blue" && count > BLUE_CUBES)
                        return false;
                }

            }

            return true;
        }
        public int CubePower(string value)
        {
            if (value == null || value == "")
                return 0;

            int power = 1;
            int red = 0;
            int blue = 0;
            int green = 0;

            string data = value.Split(": ")[1];
            string[] draws = data.Split("; ");
            for (int i = 0; i < draws.Length; i++)
            {
                string[] cubes = draws[i].Split(", ");
                for (int j = 0; j < cubes.Length; j++)
                {
                    string[] strings = cubes[j].Split(" ");
                    int count = int.Parse(strings[0]);
                    if (strings[1] == "red" && count > red)
                        red = count;
                    if (strings[1] == "blue" && count > blue)
                        blue = count;
                    if (strings[1] == "green" && count > green)
                        green = count;
                }
            }

            power *= red > 0 ? red : 1;
            power *= blue > 0 ? blue : 1;
            power *= green > 0 ? green : 1;

            return power;
        }
    }
}
