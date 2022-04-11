using MarsRover.Interface;
using MarsRover.Rover;
using NUnit.Framework;

namespace MarsRover.Test.Rover
{
    public class RoverParserUnitTest
    {
        IRoverParser RoverParser { get; set; }
        ICompass Compass { get; set; }

        public RoverParserUnitTest()
        {
            Compass = new MarsRover.Compass.Compass();

            Compass.AddDirection("N", 0, 1);
            Compass.AddDirection("E", 1, 0);
            Compass.AddDirection("S", 0, -1);
            Compass.AddDirection("W", -1, 0);

            RoverParser = new RoverParser(Compass);
        }

        [Test]
        [TestCase("1 2 N")]
        [TestCase("3 3 E")]
        [TestCase("0 4 S")]
        public void RoverLocationTest(string location)
        {
            var roverLocation = RoverParser.ParseLocation(location);

            Assert.IsNotNull(roverLocation.Item1);
            Assert.IsNotNull(roverLocation.Item2);
        }

        [Test]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1 2")]
        [TestCase("1 2 3")]
        [TestCase("1 2 3 5")]
        [TestCase("1 2 N 5")]
        [TestCase("A A N")]
        [TestCase("1 2 C")]
        [TestCase("-1 2 N")]
        [TestCase("-1 -2 N")]
        [TestCase("1 -2 N")]
        [TestCase("   ")]
        public void NotValidRoverLocationTest(string location)
        {
            var roverLocation = RoverParser.ParseLocation(location);

            Assert.IsNull(roverLocation.Item1);
            Assert.IsNull(roverLocation.Item2);
        }


        [Test]
        [TestCase("LMLMLMLMLMLRRRMMM")]
        [TestCase("LMLMLMLM")]
        [TestCase("MMMMMM")]
        [TestCase("LLLLL")]
        [TestCase("RRRRR")]
        [TestCase("RLRLRLR")]
        [TestCase("MLMLMLMMM")]
        [TestCase("RMRMRMR")]
        public void RoverComandTest(string command)
        {
            var roverCommand = RoverParser.ParseCommand(command);

            Assert.IsNotNull(roverCommand);
        }

        [Test]
        [TestCase("LMLMLMLMLMBLRRRMMM")]
        [TestCase("LMLMLMLTM")]
        [TestCase("LMLMLML M")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("123")]
        [TestCase("lmrr")]
        [TestCase("LLMR ")]
        [TestCase(" LLMR")]
        public void NotValidRoverComandTest(string command)
        {
            var roverCommand = RoverParser.ParseCommand(command);

            Assert.IsNull(roverCommand);
        }
    }
}
