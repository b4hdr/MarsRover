using MarsRover.Interface;
using MarsRover.Model;

namespace MarsRover.Plateau
{
    public class Plateau : IPlateau
    {
        public Point Boundary { get; set; }

        public Plateau()
        {
            Boundary = new Point(0, 0);
        }

        public void SetBoundary(int x, int y)
        {
            Boundary.X = x;
            Boundary.Y = y;
        }

        public void SetBoundary(Point boundary)
        {
            Boundary = boundary;
        }
    }
}
