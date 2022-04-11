using MarsRover.Interface;
using NUnit.Framework;

namespace MarsRover.Test.Compass
{
    public class CompassUnitTest
    {
        ICompass Compass { get; set; }

        public CompassUnitTest()
        {
            Compass = new MarsRover.Compass.Compass();

            Compass.AddDirection("N", 0, 1);
            Compass.AddDirection("E", 1, 0);
            Compass.AddDirection("S", 0, -1);
            Compass.AddDirection("W", -1, 0);
        }

        [Test]
        [TestCase("N", "W")]
        [TestCase("E", "N")]
        [TestCase("S", "E")]
        [TestCase("W", "S")]
        public void PreviousDirectionTest(string currentDirection, string expectedDirection)
        {
            var previousDirection = Compass.GetPreviousDirection(currentDirection);

            Assert.AreEqual(expectedDirection, previousDirection.Name);
        }

        [Test]
        [TestCase("N", "E")]
        [TestCase("E", "S")]
        [TestCase("S", "W")]
        [TestCase("W", "N")]
        public void NextDirectionTest(string currentDirection, string expectedDirection)
        {
            var nextDirection = Compass.GetNextDirection(currentDirection);

            Assert.AreEqual(expectedDirection, nextDirection.Name);
        }

        [Test]
        [TestCase("N", "N")]
        [TestCase("E", "E")]
        [TestCase("S", "S")]
        [TestCase("W", "W")]
        public void CurrentDirectionTest(string currentDirection, string expectedDirection)
        {
            var direction = Compass.GetDirection(currentDirection);

            Assert.AreEqual(expectedDirection, direction.Name);
        }
    }
}
