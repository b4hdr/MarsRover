using MarsRover.Interface;
using MarsRover.Model;

namespace MarsRover.Compass
{
    public class Compass : ICompass
    {
        List<Direction> Directions { get; set; } = new List<Direction>();

        public void AddDirection(string directionName, int x, int y)
        {
            var direction = new Direction(directionName, x, y);

            Directions.Add(direction);
        }

        public void RemoveDirection(string directionName)
        {
            var direction = GetDirection(directionName);

            if (direction != null)
                Directions.Remove(direction);
        }

        public Direction GetPreviousDirection(string directionName)
        {
            var index = GetDirectionIndex(directionName);
            var previousIndex = (index - 1) % Directions.Count;

            if (previousIndex < 0)
                previousIndex += Directions.Count;

            return Directions[previousIndex];
        }

        public Direction GetNextDirection(string directionName)
        {
            var index = GetDirectionIndex(directionName);
            var nextIndex = (index + 1) % Directions.Count;

            return Directions[nextIndex];
        }

        public Direction GetDirection(string directionName)
        {
            var index = GetDirectionIndex(directionName);
            return Directions[index];
        }

        public bool IsDirectionNameValid(string directionName)
        {
            return Directions.Any(direction => direction.Name == directionName);
        }

        int GetDirectionIndex(string directionName)
        {
            return Directions.FindIndex(direction => direction.Name == directionName);
        }
    }
}
