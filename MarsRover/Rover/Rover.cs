
using MarsRover.Interface;
using MarsRover.Model;

namespace MarsRover.Rover
{
    public class Rover : IRover
    {
        Point Position { get; set; }
        string Direction { get; set; }
        string Command { get; set; }
        ICompass Compass { get; set; }
        IPlateau Plateau { get; set; }

        public Rover(ICompass compass, IPlateau plateau)
        {
            Compass = compass;
            Plateau = plateau;
        }

        public void SetPosition(int x, int y)
        {
            Position = new Point(x, y);
        }

        public void SetPosition(Point position)
        {
            Position = position;
        }

        public void SetDirection(string direction)
        {
            Direction = direction;
        }

        public void SetCommand(string command)
        {
            Command = command;
        }

        public void Start()
        {
            var movements = Command.ToCharArray();

            Move(movements);
        }

        void Move(char[] movements)
        {
            foreach (var movement in movements)
            {
                Move(movement);
            }
        }

        void Move(char movement)
        {
            switch (movement)
            {
                case 'L': TurnLeft(); break;
                case 'R': TurnRight(); break;
                case 'M': Move(); break;
                case '_': WrongCommand(); break; //TODO: VS BUG??
            }
        }

        void TurnLeft()
        {
            var previousDirection = Compass.GetPreviousDirection(Direction);
            var previousDirectionName = previousDirection.Name;

            Direction = previousDirectionName;
        }

        void TurnRight()
        {
            var nextDirection = Compass.GetNextDirection(Direction);
            var nextDirectionName = nextDirection.Name;

            Direction = nextDirectionName;
        }

        void Move()
        {
            var direction = Compass.GetDirection(Direction);
            var vector = direction.Vector;

            Position = CalculateNewPosition(Position, vector, Plateau.Boundary);
        }

        //TODO: Where??
        Point CalculateNewPosition(Point point, Vector vector, Point boundary)
        {
            var x = point.X + vector.X;
            x = Math.Max(x, 0);
            x = Math.Min(x, boundary.X);

            var y = point.Y + vector.Y;
            y = Math.Max(y, 0);
            y = Math.Min(y, boundary.Y);

            var newPosition = new Point(x, y);

            return newPosition;
        }

        void WrongCommand()
        {
            Console.WriteLine("WrongCommand");
        }

        public string GetFullPosition()
        {
            return $"{Position.X} {Position.Y} {Direction}";
        }
    }
}
