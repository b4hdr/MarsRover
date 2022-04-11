using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IPlateauParser
    {
        Point? Parse(string plateuBoundaryString);
    }
}
