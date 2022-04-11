using MarsRover.Interface;
using MarsRover.Plateau;
using NUnit.Framework;

namespace MarsRover.Test.Plateau
{
    public class PlateauParserUnitTest
    {
        IPlateauParser PlateauParser { get; set; }

        public PlateauParserUnitTest()
        {
            PlateauParser = new PlateauParser();
        }

        [Test]
        [TestCase("5 5")]
        public void PlateauBoundaryTest(string boundary)
        {
            var plateauBoundary = PlateauParser.Parse(boundary);

            Assert.IsNotNull(plateauBoundary);
        }

        [Test]
        [TestCase("55")]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("-1 -1")]
        [TestCase("-1 0")]
        [TestCase("0 -1")]
        [TestCase("0 0")]
        [TestCase("4 4 4")]
        public void NotValidPlateauBoundaryTest(string boundary)
        {
            var plateauBoundary = PlateauParser.Parse(boundary);

            Assert.IsNull(plateauBoundary);
        }
    }
}
