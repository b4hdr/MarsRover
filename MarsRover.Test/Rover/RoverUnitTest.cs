using MarsRover.Interface;
using NUnit.Framework;

namespace MarsRover.Test.Rover
{
    class RoverUnitTest
    {
        ICompass Compass { get; set; }
        IPlateau Plateau { get; set; }

        public RoverUnitTest()
        {
            Compass = new MarsRover.Compass.Compass();

            Compass.AddDirection("N", 0, 1);
            Compass.AddDirection("E", 1, 0);
            Compass.AddDirection("S", 0, -1);
            Compass.AddDirection("W", -1, 0);

            Plateau = new MarsRover.Plateau.Plateau();
        }

        [Test]
        [TestCase(5, 5, 1, 2, "N", "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, 3, 3, "E", "MMRMMRMRRM", "5 1 E")]
        [TestCase(5, 5, 0, 0, "N", "MMLMMRRMMLM", "2 3 N")]
        [TestCase(5, 5, 10, 10, "E", "MMLMMRRMMRM", "4 3 W")]
        public void RoverMovementTest(int boundaryX, int boundaryY, int positionX, int positionY, string direction, string command, string expected)
        {
            Plateau.SetBoundary(boundaryX, boundaryY);

            var rover = new MarsRover.Rover.Rover(Compass, Plateau);
            rover.SetPosition(positionX, positionY);
            rover.SetDirection(direction);
            rover.SetCommand(command);
            rover.Start();

            var fullPosition = rover.GetFullPosition();

            Assert.AreEqual(expected, fullPosition);
        }
    }
}