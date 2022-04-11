using MarsRover.Interface;
using MarsRover.Model;

namespace MarsRover.Rover
{
    public class RoverParser : IRoverParser
    {
        ICompass Compass { get; set; }

        public RoverParser(ICompass compass)
        {
            Compass = compass;
        }

        public string? ParseCommand(string command)
        {
            if (String.IsNullOrEmpty(command))
                return null;

            var validCommands = new List<char>() { 'R', 'L', 'M' };
            var commands = command.ToCharArray();

            var notValid = commands.Any(command => !validCommands.Contains(command));

            return notValid ? null : command;
        }

        public (Point?, string?) ParseLocation(string location)
        {
            if (String.IsNullOrEmpty(location))
                return (null, null);

            var locations = location.Split(" ");

            if (locations.Length != 3)
                return (null, null);

            if (!Int32.TryParse(locations[0], out int roverPositionX))
                return (null, null);

            if (!Int32.TryParse(locations[1], out int roverPositionY))
                return (null, null);

            if(roverPositionX < 0 || roverPositionY < 0)
                return (null, null);

            var roverDirection = locations[2];
            var isDirectionNameValid = Compass.IsDirectionNameValid(roverDirection);

            if (!isDirectionNameValid)
                return (null, null);

            var roverPosition = new Point(roverPositionX, roverPositionY);

            return (roverPosition, roverDirection);
        }
    }
}
