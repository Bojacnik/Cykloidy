using Domain.Primitives.Abstractions;


namespace Domain.Primitives.Implementations
{
    public class Point : Geometry
    {
        public Vector2 coordinates;

        public Point(Vector2 coordinates)
        {
            this.coordinates = coordinates;
        }

        public override void Push(double value)
        {
            coordinates.x += value;
        }
    }
}
