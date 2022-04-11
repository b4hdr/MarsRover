using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IRoverParser
    {
        (Point?, string?) ParseLocation(string location);
        string? ParseCommand(string command);
    }
}
