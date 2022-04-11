using MarsRover.Model;

namespace MarsRover.Interface
{
    public interface IPlateau
    {
        Point Boundary { get; set; }
        void SetBoundary(int x, int y);
        void SetBoundary(Point boundary);
    }
}
