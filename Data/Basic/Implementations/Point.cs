using Data.Basic.Abstractions.Classes;

namespace Data.Basic.Implementations
{
    public class Point : Geometry
    {
        public Vector2 coordinates;

        public Point(Vector2 coordinates)
        {
            this.coordinates = coordinates;
        }

        public override void Push(double x, double y)
        {
            coordinates.x += x;
            coordinates.y += y;
        }
    }
}
