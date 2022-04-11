using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IRover
    {
        void Start();
        void SetPosition(int x, int y);
        void SetPosition(Point position);
        void SetDirection(string direction);
        void SetCommand(string command);
        string GetFullPosition();
    }
}
