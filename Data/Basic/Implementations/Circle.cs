using Data.Basic.Abstractions.Classes;

namespace Data.Basic.Implementations
{
    public class Circle : Geometry
    {
        public Vector2 Center;
        public double Radius;

        public Circle(Vector2 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override void Push(double x, double y)
        {
            Center.x += x;
            Center.y += y;
        }
    }
}