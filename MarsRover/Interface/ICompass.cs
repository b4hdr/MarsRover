using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface ICompass
    {
        void AddDirection(string directionName, int x, int y);
        void RemoveDirection(string directionName);
        Direction GetPreviousDirection(string directionName);
        Direction GetNextDirection(string directionName);
        Direction GetDirection(string directionName);
        bool IsDirectionNameValid(string directionName);
    }
}
