using Domain.Primitives.Abstractions;
using Domain.Primitives.Interfaces;

namespace Domain.Primitives.Implementations
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

        public override void Push(double value)
        {
            Center.x += value;
        }
    }
}