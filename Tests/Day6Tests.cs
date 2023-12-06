using Advent2023;

namespace Tests
{
    public class Day6Tests
    {
        private readonly Day6 d6;
        public Day6Tests()
        {
            d6 = new Day6();
        }

        [Fact]
        public void CanCreateRaceEntity()
        {
            int time = 5;
            int dist = 6;
            D6Race entity = new D6Race(time, dist);

            Assert.Equal(time, entity.Time);
            Assert.Equal(dist, entity.Distance);
        }
        [Fact]
        public void LoadRaces_ShouldThrowException_ForEmptyOrNull()
        {
            Action action = () => d6.LoadRaces("");

            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]
        public void LoadRaces_ThrowsException_ForInvalidString()
        {
            string input = "Time: 10\r";
            input += "Distance: 5 11\r";
            Action action = () => d6.LoadRaces(input);

            Assert.Throws<ArgumentOutOfRangeException>(action);

        }
        [Fact]
        public void LoadRaces_CanLoadOneRace()
        {
            string input = "Time: 10\r";
            input += "Distance: 5\r";
            d6.LoadRaces(input);

            Assert.Single(d6.Races);
        }
        [Fact]
        public void LoadRaces_CanLoadMultiple()
        {
            string input = "Time: 10 20 30\r";
            input += "Distance: 50 100 150\r";
            d6.LoadRaces(input);

            Assert.Equal(3, d6.Races.Count);
            Assert.Equal(10, d6.Races[0].Time);
            Assert.Equal(20, d6.Races[1].Time);
            Assert.Equal(30, d6.Races[2].Time);
            Assert.Equal(50, d6.Races[0].Distance);
            Assert.Equal(100, d6.Races[1].Distance);
            Assert.Equal(150, d6.Races[2].Distance);
        }
        [Fact]
        public void MinPressTime_ShouldReturnCorrectValue()
        {
            string input = "Time: 53 98 89 76\r";
            input += "Distance: 313 1201 1090 1214\r";

            d6.LoadRaces(input);
            double res = d6.Races[0].MinPressTime();
            double res2 = d6.Races[1].MinPressTime();
            double res3 = d6.Races[2].MinPressTime();
            double res4 = d6.Races[3].MinPressTime();

            Assert.Equal(7, res);
            Assert.Equal(15, res2);
            Assert.Equal(15, res3);
            Assert.Equal(23, res4);
        }
        [Fact]
        public void WaysToWin_ShouldReturnCorrect()
        {
            string input = "Time:7 15 30\r";
            input += "Distance: 9 40 200\r";

            d6.LoadRaces(input);

            Assert.Equal(4, d6.Races[0].WaysToWin());
            Assert.Equal(8, d6.Races[1].WaysToWin());
            Assert.Equal(9, d6.Races[2].WaysToWin());
        }

        [Fact]
        public void MulWays_ShouldReturnCorrect()
        {
            string input = "Time:7 15 30\r";
            input += "Distance: 9 40 200\r";

            Assert.Equal(288, d6.MulWays(input));
        }
        [Fact]
        public void Advent_Test()
        {
            string input = "Time: 53 89 76 98\r";
            input += "Distance: 313 1090 1214 1201\r";

            Assert.Equal(5133600, d6.MulWays(input));
        }
        [Fact]
        public void LoadSingleRace_ShouldThrowException_ForEmptyOrNull()
        {
            Action action = () => d6.LoadSingleRace("");

            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]
        public void LoadSingleRace_ShouldLoadOneRaceOnly()
        {
            string input = "Time: 10 20 30\r";
            input += "Distance: 50 100 150\r";

            d6.LoadSingleRace(input);

            Assert.Single(d6.Races);
            Assert.Equal(102030, d6.Races[0].Time);
            Assert.Equal(50100150, d6.Races[0].Distance);
        }
        [Fact]
        public void Advent_Test2()
        {
            string input = "Time: 53 89 76 98\r";
            input += "Distance: 313 1090 1214 1201\r";

            Assert.Equal(40651271, d6.MulWays(input,true));
        }
    }
}
