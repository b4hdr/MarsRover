using MarsRover.Interface;
using MarsRover.Model;

namespace MarsRover.Plateau
{
    public class PlateauParser : IPlateauParser
    {
        public Point? Parse(string plateuBoundaryString)
        {
            if (String.IsNullOrEmpty(plateuBoundaryString))
                return null;

            var plateuBoundaries = plateuBoundaryString.Split(" ");

            if (plateuBoundaries.Length != 2)
                return null;

            if (!Int32.TryParse(plateuBoundaries[0], out int plateauBoundaryX))
                return null;

            if (!Int32.TryParse(plateuBoundaries[1], out int plateauBoundaryY))
                return null;

            if (plateauBoundaryX <= 0 || plateauBoundaryY <= 0)
                return null;

            return new Point(plateauBoundaryX, plateauBoundaryY);
        }
    }
}