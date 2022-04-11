namespace MarsRover.Model
{
    public class Direction
    {
        public string Name { get; set; }
        public Vector Vector { get; set; }

        public Direction(string name, int x, int y)
        {
            Name = name;
            Vector = new Vector(x, y);
        }
    }
}
